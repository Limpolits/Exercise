import { Routes } from '@angular/router';
import { Menu } from './components/menu/menu';
import { Manager } from './components/manager/manager';
import { Addempl } from './components/addempl/addempl';
import { Dsplempl } from './components/dsplempl/dsplempl'; 
import { DelEmpl } from './components/delempl/delempl';

export const routes: Routes = [
  { path: '', redirectTo: 'menu', pathMatch: 'full' },
  { path: 'menu', component: Menu },
  { path: 'manager', component: Manager },
  { path: 'addempl', component: Addempl},
  { path: 'dsplempl', component: Dsplempl},
  { path: 'delempl', component: DelEmpl}
];