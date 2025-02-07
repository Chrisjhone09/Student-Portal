import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../auth.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-login',
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm : boolean= true;
  registerForm : boolean  = false;
  email : string = "";
  password : string = "";
  errorMessage : string = "";
  constructor(private route: Router, private authService : AuthService) {}

  navigateToRegister(){
    this.loginForm = false;
    this.registerForm = true;
    this.route.navigate(['/register'])
  }
  login(){
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        localStorage.setItem('token', response.token)
        localStorage.setItem('student', JSON.stringify(response));
        this.route.navigate(['/home']);
      },
      error: (err) => {
        this.errorMessage = 'Invalid username or password.';
      }
    });
  }
}
