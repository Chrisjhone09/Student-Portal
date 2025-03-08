import { ChangeDetectorRef, Component, computed, OnInit, signal } from '@angular/core';
import { EvaluationQuestion } from './evaluation-question';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationComponent } from '../../../../../confirmation/confirmation.component';
import { Instructor } from '../../../../../models/instructor';
import { DataService, EvaluationData } from '../../../../../services/data.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-instructor-evaluation',
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './instructor-evaluation.component.html',
  styleUrl: './instructor-evaluation.component.css'
})
export class InstructorEvaluationComponent implements OnInit {
  
  public evaluation = signal<EvaluationQuestion[]>([
    { number: 1, question: "The instructor demonstrates a strong knowledge of the subject matter.", score: 0 },
    { number: 2, question: "The instructor explains concepts clearly and effectively.", score: 0 },
    { number: 3, question: "The instructor encourages student participation and engagement.", score: 0 },
    { number: 4, question: "The instructor provides useful examples to enhance learning.", score: 0 },
    { number: 5, question: "The instructor is well-prepared for each class session.", score: 0 },
    { number: 6, question: "The instructor communicates expectations and objectives clearly.", score: 0 },
    { number: 7, question: "The instructor provides timely and constructive feedback on assignments.", score: 0 },
    { number: 8, question: "The instructor is approachable and available for assistance outside of class.", score: 0 },
    { number: 9, question: "The instructor uses a variety of teaching methods to enhance learning.", score: 0 },
    { number: 10, question: "The instructor creates a positive and inclusive learning environment.", score: 0 },
    { number: 11, question: "The instructor maintains professionalism and respect in interactions with students.", score: 0 },
    { number: 12, question: "The instructor effectively manages class time.", score: 0 },
    { number: 13, question: "The instructor motivates students to perform at their best.", score: 0 },
    { number: 14, question: "The instructor adapts teaching strategies to accommodate different learning styles.", score: 0 },
    { number: 15, question: "The instructor applies fair and objective grading practices.", score: 0 },
    { number: 16, question: "The instructor encourages critical thinking and problem-solving.", score: 0 },
    { number: 17, question: "The instructor incorporates relevant and up-to-date content into lessons.", score: 0 },
    { number: 18, question: "The instructor effectively uses technology and resources in teaching.", score: 0 },
    { number: 19, question: "The instructor maintains a well-organized and structured course.", score: 0 },
    { number: 20, question: "Overall, I am satisfied with the instructor's performance.", score: 0 }
  ]);
  isSubmitBtnCLicked: boolean = false;
  rating: number = 0;
  instructor: any;
  instructorID: number = 0
  feedback: string = ""

  constructor(private mat: MatDialog, private data: DataService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.instructorID = Number(this.route.snapshot.paramMap.get('instructorId'))
    this.feedback = ""
    this.data.getInstructorEvaluationForm(this.instructorID).subscribe({
      next: (response) => {
        this.instructor = response as Instructor
      }
    })
  }


  totalScore = computed(() =>
    this.evaluation().reduce((sum, q) => sum + q.score, 0)
  );
  submit() {
    this.mat.open(ConfirmationComponent, {
      height: '500px',
      width: '500px',
      data: { rating: this.normalizedRating() }
    })

    this.data.submitEvaluation({ instructorId: this.instructorID, rating: this.normalizedRating(), feedback: this.feedback}).subscribe({
      next: (response) => {

      }
    });

  }
  selectScore(questionNumber: number, score: number) {
    this.evaluation.update(questions =>
      questions.map(q =>
        q.number === questionNumber ? { ...q, score } : q
      )
    );
  }
  trackByFn(index: number, item: EvaluationQuestion) {
    return item.number;
  }
  normalizedRating = computed(() => {
    const total = this.evaluation().reduce((sum, q) => sum + q.score, 0);
    const totalQuestions = this.evaluation().length;

    return totalQuestions > 0 ? total / totalQuestions : 0;
  });

}
