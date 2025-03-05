import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-confirmation',
  imports: [FormsModule, CommonModule],
  templateUrl: './confirmation.component.html',
  styleUrl: './confirmation.component.css'
})
export class ConfirmationComponent {
  rating : number;

  constructor(
    public dialogRef: MatDialogRef<ConfirmationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { rating: number }, private mat : MatDialog, private route : Router
  ) {
    this.rating = data.rating; // Get the rating
  }
  goToHomeEvaluation() {
    this.mat.closeAll();
    this.route.navigate(["/portal/evaluation"])
  }
  
}
