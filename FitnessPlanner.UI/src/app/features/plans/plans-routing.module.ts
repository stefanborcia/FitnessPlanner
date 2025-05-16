import { Routes } from '@angular/router';
import { CreatePlanComponent } from './create-plan/create-plan.component';
import { PlanListComponent } from './plan-list/plan-list.component';
import { PlanDetailComponent } from './plan-detail/plan-detail.component';

export const PlansRoutingModule: Routes = [
  { path: '', component: PlanListComponent },
  { path: 'create', component: CreatePlanComponent },
  { path: ':id', component: PlanDetailComponent },
  {
    path: 'body/:type', // Ectomorph, Mesomorph, Endomorph
    loadComponent: () => import('./plan-list/plan-list.component').then(m => m.PlanListComponent)
  }
];
