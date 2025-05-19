import { Routes } from '@angular/router';
import { PlanListComponent } from './plan-list/plan-list.component';
import { PlanDetailComponent } from './plan-detail/plan-detail.component';
import { CreatePlanComponent } from './create-plan/create-plan.component';
import { CustomPlanBuilderComponent } from './custom-plan-builder/custom-plan-builder.component';

export const plansRoutes: Routes = [
  { path: 'plans/list', component: PlanListComponent },
  { path: 'plans/create', component: CreatePlanComponent },
  { path: 'plans/custom', component: CustomPlanBuilderComponent },
  { path: ':id', component: PlanDetailComponent }
];
