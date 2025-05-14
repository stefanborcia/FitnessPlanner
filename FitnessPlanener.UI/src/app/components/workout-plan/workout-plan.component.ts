import { Component, OnInit } from '@angular/core';
import { WorkoutPlanService, WorkoutPlanDto } from '../../services/workout-plan.service';

@Component({
  selector: 'app-workout-plan',
  templateUrl: './workout-plan.component.html'
})
export class WorkoutPlanComponent implements OnInit {
  plans: WorkoutPlanDto[] = [];

  constructor(private workoutPlanService: WorkoutPlanService) { }

  ngOnInit() {
    this.workoutPlanService.getAllPlans().subscribe({
      next: (plans) => this.plans = plans,
      error: (err) => console.error(err)
    });
  }
}
