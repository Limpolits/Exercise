import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Employee {
  name: string;
  surname: string;
  type: string;
}

@Injectable({
  providedIn: 'root'
})

export class EmployeesService 
{
  private apiUrl = 'https://localhost:44353/employees';

  constructor(private http: HttpClient) {}

  addEmployee(employee: Employee) {
    return this.http.post<Employee>(this.apiUrl, employee);
  }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }
}