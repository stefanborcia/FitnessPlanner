import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutPlanService, WorkoutPlanDto } from '../../plans/services/workout-plan.service';
import { RouterModule } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  standalone: true,
  selector: 'app-plan-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './plan-list.component.html',
})
export class PlanListComponent implements OnInit {
  plans: WorkoutPlanDto[] = [];
  message = '';

  constructor(private planService: WorkoutPlanService) { }

  ngOnInit(): void {
    this.planService.getAllPlans().subscribe({
      next: (data: WorkoutPlanDto[]) => {
        this.plans = data;
      },
      error: (err: HttpErrorResponse) => {
        this.message = 'Failed to load plans: ' + err.message;
      }
    });
  }
}
