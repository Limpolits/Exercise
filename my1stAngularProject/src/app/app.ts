import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router'; 
import { Addempl } from './components/addempl/addempl';
import { Manager } from './components/manager/manager';
import { Menu } from './components/menu/menu';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  protected readonly title = signal('my1stAngularProject');
}
