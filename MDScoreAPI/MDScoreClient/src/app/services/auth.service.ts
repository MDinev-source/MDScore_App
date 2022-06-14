import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiUrl + "Users/authenticate";
  private registerPath = environment.apiUrl + "Users/register";

  constructor(private http: HttpClient, private router: Router) { }

  login(data): Observable<any> {
    return this.http.post(this.loginPath, data)
  }

  register(data): Observable<any> {
    return this.http.post(this.registerPath, data)
  }

  saveToken(token) {
    localStorage.setItem('token', token)
  }

  saveRole(isOrganizer) {
    localStorage.setItem('isOrganizer', isOrganizer)
  }

  getToken() {
    return localStorage.getItem('token')
  }

  getRole() {
    return localStorage.getItem('isOrganizer');
  }

  isAuthenticated() {
    if (this.getToken()) {
      return true
    }
    return false;
  }

  isOrganizer() {
    if (this.getRole() == 'true') {
      return true;
    }
    return false;
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('isOrganizer');
    this.router.navigate(['/login']);
  }
}
