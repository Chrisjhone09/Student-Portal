import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-confirmation',
  imports: [],
  templateUrl: './confirmation.component.html',
  styleUrl: './confirmation.component.css'
})
export class ConfirmationComponent {

  constructor(private route : Router, private mat : MatDialog){}

  goToHomeEvaluation() {
    this.mat.closeAll();
    this.route.navigate(["/portal/evaluation"])

  }
}
