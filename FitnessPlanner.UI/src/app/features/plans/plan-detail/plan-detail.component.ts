import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkoutPlanDto, WorkoutPlanService } from './../services/workout-plan.service';
import { HttpErrorResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-plan-detail',
  imports: [CommonModule],
  templateUrl: './plan-detail.component.html'
})
export class PlanDetailComponent implements OnInit {
  plan!: WorkoutPlanDto;
  message = '';

  constructor(
    private route: ActivatedRoute,
    private planService: WorkoutPlanService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.planService.getPlanById(id).subscribe({
        next: (data: WorkoutPlanDto) => {
          this.plan = data;
        },
        error: (err: HttpErrorResponse) => {
          this.message = 'Failed to load plan: ' + err.message;
        }
      });
    }
  }
}
