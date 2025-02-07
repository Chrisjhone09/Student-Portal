import { Component } from '@angular/core';
import { Route, Router, RouterOutlet } from '@angular/router';
import { NavigationComponent } from "./navigation/navigation.component";
import { FooterComponent } from "./footer/footer.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavigationComponent, FooterComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ClientSide';
  constructor(private route: Router) {
  };

  navigateToRegister() {
    this.route.navigate(['/register']);
  }
}
