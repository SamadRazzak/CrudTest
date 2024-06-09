import { Component, OnInit, Directive, EventEmitter, Input, Output, QueryList, ViewChildren } from '@angular/core';
import { UserParams, UserService } from './user.service';
import { User } from './user';

export type SortColumn = keyof User | '';
export type SortDirection = 'asc' | 'desc' | '';
const rotate: { [key: string]: SortDirection } = { asc: 'desc', desc: '', '': 'asc' };

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

export interface SortEvent {
	column: SortColumn;
	direction: SortDirection;
}

@Directive({
	selector: 'th[sortable]',
	host: {
		'[class.asc]': 'direction === "asc"',
		'[class.desc]': 'direction === "desc"',
		'(click)': 'rotate()',
	},
})

export class NgbdSortableHeader {
	@Input() sortable: SortColumn = '';
	@Input() direction: SortDirection = '';
	@Output() sort = new EventEmitter<SortEvent>();

	rotate() {
		this.direction = rotate[this.direction];
		this.sort.emit({ column: this.sortable, direction: this.direction });
	}
}

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users: User[] = []
  page = 1;
	pageSize = 4;
	collectionSize = 20;
  search = ''
  sort = 'name'
  sortType = 'asc'
  userParams: UserParams = new UserParams();

  constructor(public userService: UserService) {

  }
  ngOnInit(): void {
    this.getUsers()    
  }


  getUsers() {
    this.userService.getUsers().subscribe((res: any) => {
      this.users = res.data || []
      //this.pageSize = res.count
      this.collectionSize = res.count
      console.log(res.data)
    })
  }

  SearchClick() {
    console.log('search clicked')
    const params = this.userService.getShopParams();
    params.search = this.search;
    params.pageNumber = 1;
    this.userService.setUserParams(params);
    this.userParams = params;
    this.getUsers();
  }

  ResetClick() {    
    const params = this.userService.getShopParams();
    params.search = '';
    params.pageNumber = 1;
    this.userService.setUserParams(params);
    this.userParams = params;
    this.getUsers();
  }

  pageChanged() {    
    const params = this.userService.getShopParams();
    params.pageNumber = this.page;
    params.pageSize = this.pageSize;
    this.userService.setUserParams(params);
    this.userParams = params;
    this.getUsers();
  }

  onDelete(id: string) {
    this.userService.deleteUser(id).subscribe(() => {
      this.getUsers()
    })
  }

  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;

	onSort({ column, direction }: SortEvent) {
		// resetting other headers
		this.headers.forEach((header) => {
			if (header.sortable !== column) {
				header.direction = '';
			}
		});

		// sorting countries
		if (direction === '' || column === '') {			
		} else {
		const params = this.userService.getShopParams();
    params.sort = column;
    params.sortType = direction
    params.pageNumber = 1;
    this.userService.setUserParams(params);
    this.userParams = params;
    this.getUsers();
		}
	}

} 
