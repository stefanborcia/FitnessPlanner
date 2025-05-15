import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePlanComponent } from './components/create-plan/create-plan.component';
import { WorkoutPlanComponent } from './components/workout-plan/workout-plan.component';

const routes: Routes = [
  { path: 'create', component: CreatePlanComponent },
  { path: 'plans', component: WorkoutPlanComponent },
  { path: '', redirectTo: 'plans', pathMatch: 'full' }, // Default to "View Plans"
  { path: '**', redirectTo: 'plans' } // Fallback for unknown routes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
