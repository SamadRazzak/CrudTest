import { Component, OnInit } from '@angular/core';
import { UserAuthService } from '../services/user-auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  email: string = '';
  password: string = '';
  isSubmitting: boolean = false;
  validationErrors: Array<any> = [];

  constructor(
    public userAuthService: UserAuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (
      localStorage.getItem('token') != '' &&
      localStorage.getItem('token') != null
    ) {
      this.router.navigateByUrl('/dashboard');
    }
  }

  loginAction() {
    this.isSubmitting = true;
    let payload = {
      email: this.email,
      password: this.password,
    };
    this.userAuthService.login(payload).subscribe({
      next: () => this.router.navigateByUrl('/users'),
    });
  }
}
