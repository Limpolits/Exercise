import { Routes } from '@angular/router';
import { Menu } from './components/menu/menu';
import { Manager } from './components/manager/manager';
import { Addempl } from './components/addempl/addempl';

export const routes: Routes = [
  { path: '', redirectTo: '/menu', pathMatch: 'full' }, 
  { path: 'menu', component: Menu },
  { path: 'manager', component: Manager },
  { path: 'addempl', component: Addempl}
];