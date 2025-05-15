import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkoutPlanService, WorkoutPlanDto } from '../../services/workout-plan.service';

@Component({
  selector: 'app-workout-plan',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './workout-plan.component.html'
})
export class WorkoutPlanComponent implements OnInit {
  plans: WorkoutPlanDto[] = [];

  constructor(private workoutPlanService: WorkoutPlanService) { }

  ngOnInit(): void {
    this.workoutPlanService.getAllPlans().subscribe({
      next: (plans) => this.plans = plans,
      error: (err) => console.error('Failed to load plans:', err)
    });
  }
}
