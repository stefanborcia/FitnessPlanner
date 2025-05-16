import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePlanComponent } from './features/plans/create-plan/create-plan.component';
import { WorkoutPlanComponent } from './features/plans/workout-plan/workout-plan.component';
import { PlanListComponent } from './features/plans/plan-list/plan-list.component';
import { PlanDetailComponent } from './features/plans/plan-detail/plan-detail.component';
const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./features/home/home.component').then(m => m.HomeComponent),
    pathMatch: 'full' // Very important for root route
  },
  {
    path: 'create',
    loadComponent: () =>
      import('./features/plans/create-plan/create-plan.component').then(m => m.CreatePlanComponent)
  },
  {
    path: 'plans',
    loadComponent: () =>
      import('./features/plans/plan-list/plan-list.component').then(m => m.PlanListComponent)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
