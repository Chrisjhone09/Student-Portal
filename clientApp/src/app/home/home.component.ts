import { Component } from '@angular/core';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AuthService } from '../auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [RouterOutlet, RouterLink, RouterLinkActive, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  /**
   *
   */
  constructor(public service: AuthService, private route: Router) {
   }

  logout() {
    this.service.logout().subscribe({
      next: (success) => {
        localStorage.removeItem('token');
        console.log("User has logged out");
        this.route.navigate(['/login']);
      }, error: (error) => { console.log(error) }
    })
  }
}
