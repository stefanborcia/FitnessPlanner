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
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadComponent: () =>
      import('./auth/login/login.component').then(m => m.LoginComponent)
  },
  {
    path: 'register',
    loadComponent: () =>
      import('./auth/register/register.component').then(m => m.RegisterComponent)
  },
  {
    path: 'dashboard',
    loadComponent: () =>
      import('./features/dashboard/dashboard.component').then(m => m.DashboardComponent)
  },
  {
    path: 'plans',
    children: [
      {
        path: 'list',
        loadComponent: () =>
          import('./features/plans/plan-list/plan-list.component').then(m => m.PlanListComponent)
      },
      {
        path: 'create',
        loadComponent: () =>
          import('./features/plans/create-plan/create-plan.component').then(m => m.CreatePlanComponent)
      },
      {
        path: 'custom',
        loadComponent: () =>
          import('./features/plans/custom-plan-builder/custom-plan-builder.component').then(m => m.CustomPlanBuilderComponent)
      },
      {
        path: 'standard',
        loadComponent: () =>
          import('./features/plans/standard-plan/standard-plan.component').then(m => m.StandardPlanComponent)
      },
      {
        path: 'premium',
        loadComponent: () =>
          import('./features/plans/premium-plan/premium-plan.component').then(m => m.PremiumPlanComponent)
      },
      {
        path: 'personalized',
        loadComponent: () =>
          import('./features/plans/personalized-plan/personalized-plan.component').then(m => m.PersonalizedPlanComponent)
      },
      {
        path: ':id',
        loadComponent: () =>
          import('./features/plans/plan-detail/plan-detail.component').then(m => m.PlanDetailComponent)
      }
    ]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
