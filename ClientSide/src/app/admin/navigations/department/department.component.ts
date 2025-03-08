import { Component, OnInit } from '@angular/core';
import { MatDateFormats } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { DepartmentFormComponent } from '../../department-form/department-form/department-form.component';
import { RouterLink } from '@angular/router';
import { AdminService } from '../../../services/admin.service';
import { CommonModule } from '@angular/common';
import { AcademicProgram } from '../../models-and-DTO/AcademicProgram';

@Component({
  selector: 'app-department',
  imports: [RouterLink, CommonModule],
  templateUrl: './department.component.html',
  styleUrl: './department.component.css'
})
export class DepartmentComponent implements OnInit{

 programList : AcademicProgram[] = []

  constructor(private matDialog: MatDialog, private adminService : AdminService){}
  ngOnInit(): void {
    this.adminService.getDepartmentList().subscribe(data =>{
      this.programList = data as AcademicProgram[]
    })
  }

  addDepartment(){
    this.matDialog.open(DepartmentFormComponent, {
      height: '300px',
      width: '500px'
    })
  }
}
