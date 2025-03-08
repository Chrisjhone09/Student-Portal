import { Component, OnInit } from '@angular/core';
import { Student } from './student';
import { RegistrarService } from '../../../services/registrar.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { StudentFormComponent } from '../../student-form/student-form.component';

@Component({
  selector: 'app-student-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css'
})
export class StudentListComponent implements OnInit{

  students: Student[] = []

  constructor(private registrarService :RegistrarService, private matDialog: MatDialog){}
  ngOnInit(): void {
    this.registrarService.getStudentList().subscribe({
      next: (response) => {
        this.students = response as Student[]
      }
    })
  }


  addStudent() {
      this.matDialog.open(StudentFormComponent, {
        height: '600px',
        width: '500px'
      })
  }


}
