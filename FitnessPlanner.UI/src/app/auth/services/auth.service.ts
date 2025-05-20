import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { jwtDecode } from 'jwt-decode';

export interface RegisterPayload {
  email: string;
  password: string;
  goal: string;
  bodyType: string;
  subscription: string;
}

export interface LoginPayload {
  email: string;
  password: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'http://localhost:5258/api/auth';

  constructor(private http: HttpClient) { }

  getUserId(): string {
    const token = this.getToken();
    if (!token || token.split('.').length !== 3) {
      console.warn('Token is missing or malformed.');
      return '';
    }

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      console.log('Decoded JWT payload:', payload);
      // Extract user ID using the correct claim name
      return payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] || '';
    } catch (error) {
      console.error('Failed to decode user ID from token:', error);
      return '';
    }
  }

  register(payload: RegisterPayload): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, payload);
  }

  login(payload: LoginPayload): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, payload);
  }

  storeToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getUserRole(): string | null {
    const token = this.getToken();
    if (!token || token.split('.').length !== 3) {
      console.warn('Token is missing or malformed.');
      return null;
    }

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload["Subscription"] || null;
    } catch (error) {
      console.error('Failed to decode role from token:', error);
      return null;
    }
  }

  logout() {
    localStorage.removeItem('token');
  }
}
