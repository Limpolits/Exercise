import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router'; 
import { NewComponent } from './components/new/new';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NewComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('my1stAngularProject');
}
