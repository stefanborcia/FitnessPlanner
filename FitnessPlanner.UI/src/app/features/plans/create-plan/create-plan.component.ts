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

  constructor(
    private fb: FormBuilder,
    private planService: WorkoutPlanService
  ) {
    this.planForm = this.fb.group({
      name: ['', Validators.required],  // Add the name field
      goal: ['', Validators.required],
      bodyType: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.planForm.valid) {
      const raw = this.planForm.value;

      // Pass the form values directly to the request
      const request: PlanRequestDto = {
        goal: raw.goal,
        bodyType: raw.bodyType,
        name: raw.name,  // Include the name in the request
        userId: ''  // Use a valid userId
      };

      this.planService.savePlan(request).subscribe({
        next: () => this.message = 'Plan saved successfully!',
        error: err => this.message = 'Failed to save plan: ' + err.message
      });
    }
  }
}

