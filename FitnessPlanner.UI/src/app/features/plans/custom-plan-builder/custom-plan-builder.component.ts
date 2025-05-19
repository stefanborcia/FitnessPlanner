import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { ExerciseDto, MealDto, PlanItem, PlanRequestDto, WorkoutPlanService } from '../services/workout-plan.service';

@Component({
  selector: 'app-custom-plan-builder',
  standalone: true,
  imports: [CommonModule, FormsModule, DragDropModule],
  templateUrl: './custom-plan-builder.component.html',
  styleUrls: ['./custom-plan-builder.component.css']
})
export class CustomPlanBuilderComponent implements OnInit {
  goals = ['LoseWeight', 'BuildMuscle', 'Tone'];
  bodyTypes = ['Ectomorph', 'Mesomorph', 'Endomorph'];

  availableExercises: ExerciseDto[] = [
    {  name: 'Push Ups', sets: 3, reps: 12 },
    {  name: 'Squats', sets: 4, reps: 10 },
  ];

  availableMeals: MealDto[] = [
    { type: 'meal', name: 'Chicken Salad', calories: 400 },
    { type: 'meal', name: 'Oatmeal with Fruits', calories: 350 },
  ];
  isExercise(item: PlanItem): item is ExerciseDto {
    return (item as ExerciseDto).sets !== undefined;
  }

  isMeal(item: PlanItem): item is MealDto {
    return (item as MealDto).calories !== undefined;
  }
  customPlanItems: PlanItem[] = [];
  customPlanName = '';
  selectedGoal = '';
  selectedBodyType = '';
  message = '';

  constructor(private planService: WorkoutPlanService) { }

  ngOnInit(): void { }

  drop(event: any) {
    const item = event.previousContainer.data[event.previousIndex];
    if (!this.customPlanItems.includes(item)) {
      this.customPlanItems.push(item);
    }
  }

  savePlan() {
    if (!this.customPlanName || this.customPlanItems.length === 0) {
      this.message = 'Please enter a name and select at least one item.';
      return;
    }

    const plan: PlanRequestDto = {
      name: this.customPlanName,
      goal: this.selectedGoal || 'BuildMuscle',
      bodyType: this.selectedBodyType || 'Ectomorph',
      userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
      items: this.customPlanItems
    };

    this.planService.savePlan(plan).subscribe({
      next: () => {
        this.message = 'Custom plan saved!';
        this.customPlanName = '';
        this.customPlanItems = [];
      },
      error: (err) => this.message = 'Error saving plan: ' + err.message
    });
  }
}

