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

export class Addempl implements OnInit {

  employees: Employee[] = [];

  newEmployee: Employee = {name: '', surname: '', type: ''};

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

  addEmployee(): void {
    if (!this.newEmployee.name.trim() ||
        !this.newEmployee.surname.trim() ||
        !this.newEmployee.type.trim()) {
      alert('All fields are required!');
      return;
    }

    this.employeesService.addEmployee(this.newEmployee).subscribe({
        next: () => {
          this.newEmployee = {name: '', surname: '', type: ''};
          this.displayEmployees(); 
        },
        error: err => console.error('Insert failed', err)
      });
  }
}