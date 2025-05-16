import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { PlansRoutingModule } from './plans-routing.module';
import { CreatePlanComponent } from './create-plan/create-plan.component';
import { PlanDetailComponent } from './plan-detail/plan-detail.component';
import { PlanListComponent } from './plan-list/plan-list.component';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PlansRoutingModule,
    CreatePlanComponent,
    PlanDetailComponent,
    PlanListComponent
  ]
})
export class PlansModule { }
