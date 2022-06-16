import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(private authService: AuthService) { }

  isSignedIn() {
    return this.authService.isAuthenticated();
  }

  isOrganizer() {
    return this.authService.isOrganizer();
  }

  logout() {
    this.authService.logout();
  }
}
