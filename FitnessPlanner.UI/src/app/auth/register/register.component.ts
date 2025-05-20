import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService, RegisterPayload } from '../services/auth.service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, MatSnackBarModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  payload: RegisterPayload = {
    email: '',
    password: '',
    goal: 'BuildMuscle',
    bodyType: 'Ectomorph',
    subscription: 'Standard',
  };
  errorMessage = '';

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  register() {
    this.authService.register(this.payload).subscribe({
      next: () => {
        this.snackBar.open('Registration successful!', 'Close', { duration: 3000 });
        this.router.navigate(['/login']);
      },
      error: () => {
        this.snackBar.open('Registration failed', 'Close', { duration: 3000 });
        this.errorMessage = 'Registration failed';
      }
    });
  }
}
