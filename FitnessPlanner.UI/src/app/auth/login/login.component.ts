import { Component } from '@angular/core';
import { AuthService, LoginPayload } from '../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  payload: LoginPayload = { email: '', password: '' };
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    this.authService.login(this.payload).subscribe({
      next: (res: { token: string }) => {
        console.log('Received token:', res.token);
        this.authService.storeToken(res.token);

        setTimeout(() => {
          this.router.navigate(['/dashboard']);
        }, 100);
      },
      error: () => {
        this.errorMessage = 'Invalid credentials';
      }
    });
  }
}
