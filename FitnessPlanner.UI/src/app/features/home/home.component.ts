import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ExerciseDto, PlanRequestDto, WorkoutPlanService } from '../plans/services/workout-plan.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  bodyTypes = ['Ectomorph', 'Mesomorph', 'Endomorph'];
  goals = ['LoseWeight', 'BuildMuscle', 'Tone'];

  selectedBodyType = '';
  selectedGoal = '';
  customPlanName = '';
  selectedExercises: ExerciseDto[] = [];

  message = '';

  constructor(private planService: WorkoutPlanService, private router: Router) { }

  premadePlans = [
    {
      id: 1,
      name: 'Build Muscle Plan A',
      goal: 'BuildMuscle',
      bodyType: 'Mesomorph',
      description: '6-day hypertrophy-focused split with progressive overload'
    },
    {
      id: 2,
      name: 'Fat Loss Shred',
      goal: 'LoseWeight',
      bodyType: 'Endomorph',
      description: '4-day HIIT + resistance plan for quick fat loss'
    },
    {
      id: 3,
      name: 'Tone & Sculpt',
      goal: 'Tone',
      bodyType: 'Ectomorph',
      description: 'Light weight, high rep split with cardio'
    }
  ];

  get filteredPlans() {
    return this.premadePlans.filter(p =>
      (!this.selectedGoal || p.goal === this.selectedGoal) &&
      (!this.selectedBodyType || p.bodyType === this.selectedBodyType)
    );
  }

  choosePlan(type: string) {
    this.router.navigate([`/plans/${type}`]); // ⬅️ This handles navigation
  }

  resetFilters() {
    this.selectedGoal = '';
    this.selectedBodyType = '';
  }

  saveCustomPlan() {
    const plan: PlanRequestDto = {
        name: this.customPlanName,
        goal: this.selectedGoal || 'BuildMuscle',
        bodyType: this.selectedBodyType || 'Ectomorph',
        userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
        items: []
    };

    this.planService.savePlan(plan).subscribe({
      next: () => {
        this.message = 'Plan saved successfully!';
        this.customPlanName = '';
        this.selectedExercises = [];
      },
      error: (err: any) => this.message = 'Failed to save: ' + err.message
    });
  }
}
