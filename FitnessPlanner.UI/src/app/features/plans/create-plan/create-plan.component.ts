import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WorkoutPlanService, PlanRequestDto } from '../services/workout-plan.service';

@Component({
  selector: 'app-create-plan',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './create-plan.component.html'
})
export class CreatePlanComponent {
  planForm: FormGroup;
  message = '';

  constructor(private fb: FormBuilder, private planService: WorkoutPlanService) {
    this.planForm = this.fb.group({
      name: ['', Validators.required],
      goal: ['', Validators.required],
      bodyType: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.planForm.invalid) return;

    const plan: PlanRequestDto = {
      ...this.planForm.value,
      userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6'
    };

    this.planService.savePlan(plan).subscribe({
      next: () => this.message = 'Plan saved successfully!',
      error: (err) => this.message = 'Failed to save plan: ' + err.message
    });
  }
}
