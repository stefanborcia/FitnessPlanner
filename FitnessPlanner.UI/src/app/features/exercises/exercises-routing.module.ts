import { Routes } from '@angular/router';
import { CreatePlanComponent } from '../plans/create-plan/create-plan.component';
import { PlanListComponent } from '../plans/plan-list/plan-list.component';
import { PlanDetailComponent } from '../plans/plan-detail/plan-detail.component';

export const PlansRoutingModule: Routes = [
  { path: '', component: PlanListComponent },
  { path: 'create', component: CreatePlanComponent },
  { path: ':id', component: PlanDetailComponent }
];
