import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeesService, Employee } from '../../services/employees';

@Component({
  selector: 'app-addempl',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './addempl.html'
})

export class Addempl implements OnInit 
{
  employees: Employee[] = [];

  newEmployee: Employee = { name: '', surname: '', type: '' };

  constructor(private employeesService: EmployeesService) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeesService.getEmployees()
      .subscribe(data => this.employees = data);
  }

  addEmployee() {
    this.employeesService.addEmployee(this.newEmployee)
      .subscribe(() => {
        this.loadEmployees(); 
        this.newEmployee = { name: '', surname: '', type: '' }; 
      });
  }
}