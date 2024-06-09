import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Login } from '../login/login';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Register } from '../register/register';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient, private router: Router) { }

  login(data:any) {
    let payload = {
      email: data.email,
      password: data.password
    }
  
    return this.http.post<Login>(this.baseUrl + '/Account/login', payload).pipe(
      map((user: any) => {
        localStorage.setItem('token', user.token)
      })
    )
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigateByUrl('/');
  }
 
  register(data:any) {
    let payload = {
      firstName: data.firstName,
      lastName: data.lastName,
      email: data.email,
      password: data.password,
      role: data.role
    }
     
    return this.http.post<Register>(this.baseUrl + '/Account/register', payload).pipe(
      map((user: any) => {
        localStorage.setItem('token', user.token)
      })
    )
  }
}
