import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../app/auth/services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './app.component.html'
})
export class AppComponent {
  constructor(public authService: AuthService) { }

  isLoggedIn(): boolean {
    return !!this.authService.getToken();
  }

  getUserRole(): string | null {
    return this.authService.getUserRole();
  }

  logout() {
    this.authService.logout();
    window.location.href = '/'; // or use router.navigate
  }
}
