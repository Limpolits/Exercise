import { Component } from '@angular/core';
import { EmployeesService, Employee } from '../../services/employees';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-delempl',
  standalone:true,
  imports: [FormsModule],
  templateUrl: './delempl.html'
})

export class DelEmpl {
  surname: string = '';

  constructor(private employeesService: EmployeesService) {}

  deleteEmployee() {
    if (!this.surname) {
      alert('Please enter a surname');
      return;
    }

    this.employeesService.deleteEmployee(this.surname).subscribe({
      next: () => {
        alert(`Employee with surname "${this.surname}" deleted`);
        this.surname = ''; // clear input
      },
      error: err => console.error('Delete failed', err)
    });
  }
}