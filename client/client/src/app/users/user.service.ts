import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { Login } from '../login/login';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Register } from '../register/register';
import { User } from './user';

export class UserParams {
    search = ''
    sort = 'name'
    sortType = 'asc'
    pageNumber = 1
    pageSize = 60
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;
  userParams = new UserParams()

  constructor(private http: HttpClient) { }

  getUsers() {
    let params = new HttpParams();
    params = params.append('sort', this.userParams.sort);
    params = params.append('sortType', this.userParams.sortType);
    params = params.append('pageIndex', this.userParams.pageNumber);
    params = params.append('pageSize', this.userParams.pageSize);
    if (this.userParams.search) params = params.append('search', this.userParams.search);

    return this.http.get<User>(this.baseUrl + '/user', {params})
  }

  deleteUser(id: string) {
    return this.http.delete(this.baseUrl + '/user/' + id)
  }

  setUserParams(params: UserParams) {
    this.userParams = params;
  }

  getShopParams() {
    return this.userParams;
  }
}
