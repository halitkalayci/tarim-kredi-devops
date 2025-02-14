import { Routes } from '@angular/router';
import { AboutUsComponent } from './pages/about-us/about-us.component';
import { HomepageComponent } from './pages/homepage/homepage.component';

export const routes: Routes = [
  {path:'', pathMatch:'full', redirectTo:'homepage'},
  {path:'homepage', component:HomepageComponent},
  {path:'about-us', component:AboutUsComponent}
];
