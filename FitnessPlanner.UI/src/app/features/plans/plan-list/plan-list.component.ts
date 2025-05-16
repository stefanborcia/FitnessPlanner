import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutPlanService } from '../services/workout-plan.service';
import { RouterModule } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-plan-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './plan-list.component.html',
})
export class PlanListComponent implements OnInit {
  plans: any[] = [];
  message = '';

  constructor(private planService: WorkoutPlanService) { }

  ngOnInit(): void {
    this.planService.getAllPlans().subscribe({
      next: (data) => (this.plans = data),
      error: (err) => (this.message = 'Failed to load plans: ' + err.message)
    });
  }
}
