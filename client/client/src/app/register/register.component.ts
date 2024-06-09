import { Component, OnInit } from '@angular/core';
import { UserAuthService } from '../services/user-auth.service';
import { Router } from '@angular/router';

const ROLES = ['Admin', 'Manager', 'Moderator'];

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  roles = ROLES;
  name: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';
  role: string = '';
  firstName: string = '';
  lastName: string = '';
  isSubmitting: boolean = false;
  validationErrors: any = [];

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

  registerAction() {
    this.isSubmitting = true;
    let payload = {
      name: this.name,
      email: this.email,
      password: this.password,
      role: this.role,
      firstName: this.firstName,
      lastName: this.lastName,
    };

    this.userAuthService.register(payload).subscribe({
      next: () => this.router.navigateByUrl('/users'),
      error: (error) => {
        this.isSubmitting = false;
        if (error.response.data.errors != undefined) {
          this.validationErrors = error.response.data.errors;
        }

        return error;
      },
    });
  }
}
