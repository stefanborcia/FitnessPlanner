import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkoutPlanService } from '../services/workout-plan.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-plan-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './plan-detail.component.html'
})
export class PlanDetailComponent implements OnInit {
  plan: any;
  message = '';

  constructor(
    private route: ActivatedRoute,
    private planService: WorkoutPlanService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.planService.getPlanById(id).subscribe({
        next: data => this.plan = data,
        error: err => this.message = 'Failed to load plan: ' + err.message
      });
    }
  }
}
