import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesService, Employee } from '../../services/employees';

@Component({
  selector: 'app-dsplempl',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dsplempl.html'
})

export class Dsplempl implements OnInit {

  employees: Employee[] = [];

  constructor(private employeesService: EmployeesService) {}

  ngOnInit(): void {
    this.displayEmployees();
  }

  displayEmployees(): void {
    this.employeesService.getEmployees().subscribe({
        next: data => this.employees = data,
        error: err => console.error('Load failed', err)
      });
  }
}