import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AdminService } from '../../../../services/admin.service';

@Component({
  selector: 'app-user',
  imports: [CommonModule, FormsModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {
  user : {id: string, firstName: string, middleName: string, lastName: string, email: string }[] = []

  constructor(private adminService: AdminService) {}


  ngOnInit(): void {
    this.adminService.getUserList().subscribe({
      next: (response) => {
        this.user = response as {id: string, firstName: string, middleName: string, lastName: string, email: string }[];
      }
    })
  }

}
