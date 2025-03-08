import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../services/admin.service';
import { CreateDepartmentDTO } from '../../models-and-DTO/create-department-dto';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FacultyListAndCountDTO } from '../../models-and-DTO/faculty-list-and-count-dto';
import { MatDialog } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-department-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './department-form.component.html',
  styleUrl: './department-form.component.css'
})
export class DepartmentFormComponent implements OnInit {
  dataObj : CreateDepartmentDTO = new CreateDepartmentDTO()

  objDTO : FacultyListAndCountDTO | undefined
  constructor(private adminService : AdminService, private matDialog: MatDialog, private route: Router){}


  ngOnInit(): void {
    this.adminService.getFacultyList().subscribe({
      next: (response) => {
        this.objDTO = response as FacultyListAndCountDTO
      }
    })

  }

  onSubmit(){
    console.log(this.dataObj.facultyId)
    this.adminService.createDepartment(this.dataObj).subscribe()
    this.matDialog.closeAll();
    this.route.navigate(['/admin/'])
  }

}
