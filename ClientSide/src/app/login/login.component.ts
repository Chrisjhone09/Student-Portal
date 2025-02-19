import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { LoginModel } from '../models/login-model';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  errorMessage = "Dili pani functional"
  isBtnClicked = false;
  user : LoginModel = new LoginModel();
  constructor(private service : AuthService, private route : Router) {}
  

  showMessage() {
    this.isBtnClicked =true;
  }

  login(){
    this.service.login(this.user)
  }

}
