import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu.html',
  styleUrl: './menu.css',
})

export class Menu {

  constructor(private router: Router) {}

  Role(role: string) {
    if (role === 'manager') {
      this.router.navigate(['/manager']);
    } else {
      this.router.navigate(['/employee']);
    }
  }
}