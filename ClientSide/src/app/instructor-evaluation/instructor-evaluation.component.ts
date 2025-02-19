import { Component, computed } from '@angular/core';
import { EvaluationQuestion } from './evaluation-question';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { PortalComponent } from '../portal/portal.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';

@Component({
  selector: 'app-instructor-evaluation',
  imports: [CommonModule, RouterLink],
  templateUrl: './instructor-evaluation.component.html',
  styleUrl: './instructor-evaluation.component.css'
})
export class InstructorEvaluationComponent {
  evaluation: EvaluationQuestion[] = [
    { number: 1, question: "The instructor demonstrates a strong knowledge of the subject matter." },
    { number: 2, question: "The instructor explains concepts clearly and effectively." },
    { number: 3, question: "The instructor encourages student participation and engagement." },
    { number: 4, question: "The instructor provides useful examples to enhance learning." },
    { number: 5, question: "The instructor is well-prepared for each class session." },
    { number: 6, question: "The instructor communicates expectations and objectives clearly." },
    { number: 7, question: "The instructor provides timely and constructive feedback on assignments." },
    { number: 8, question: "The instructor is approachable and available for assistance outside of class." },
    { number: 9, question: "The instructor uses a variety of teaching methods to enhance learning." },
    { number: 10, question: "The instructor creates a positive and inclusive learning environment." },
    { number: 11, question: "The instructor maintains professionalism and respect in interactions with students." },
    { number: 12, question: "The instructor effectively manages class time." },
    { number: 13, question: "The instructor motivates students to perform at their best." },
    { number: 14, question: "The instructor adapts teaching strategies to accommodate different learning styles." },
    { number: 15, question: "The instructor applies fair and objective grading practices." },
    { number: 16, question: "The instructor encourages critical thinking and problem-solving." },
    { number: 17, question: "The instructor incorporates relevant and up-to-date content into lessons." },
    { number: 18, question: "The instructor effectively uses technology and resources in teaching." },
    { number: 19, question: "The instructor maintains a well-organized and structured course." },
    { number: 20, question: "Overall, I am satisfied with the instructor's performance." }
  ];
isSubmitBtnCLicked: boolean = false;
rating : number = 0;

constructor(private mat: MatDialog) {}

  submit(){
    this.mat.open(ConfirmationComponent, { 
      height: '400px',
      width: '400px'})
  }

  onSelect(value : number) {
    this.rating = (this.rating + value) / 20;
  }
}
