import { Component, OnInit } from "@angular/core";
import { CommonModule } from '@angular/common';
import { DayPlanService } from "../../core/services/day-plan.service";
import { AuthService } from '../../auth/services/auth.service'; 

interface DayPlan {
  day: string;
  date: string;
  workout: string;
  meals: string[];
  hydrationTimes: string[];
}

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule], 
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  weeklyPlan: DayPlan[] = [];
  currentWeekStart: Date = this.getStartOfWeek(new Date());

  constructor(private authService: AuthService, private dayPlanService: DayPlanService) { }

  ngOnInit() {
    this.loadWeek();
  }

  getStartOfWeek(date: Date): Date {
    const day = date.getDay(); // 0 = Sunday, 1 = Monday
    const diff = date.getDate() - day + (day === 0 ? -6 : 1); // adjust when Sunday
    return new Date(date.setDate(diff));
  }

  formatDate(date: Date): string {
    return date.toISOString().split('T')[0]; // yyyy-MM-dd
  }

  loadWeek() {
    const token = this.authService.getToken();
    if (!token || token.split('.').length !== 3) {
      console.warn('No valid token found. Skipping loadWeek.');
      return;
    }

    const userId = this.authService.getUserId();
    if (!userId) {
      console.warn('No userId found. Aborting loadWeek.');
      return;
    }

    const startDateStr = this.formatDate(this.currentWeekStart);
    this.dayPlanService.getWeekPlans(startDateStr, userId).subscribe(plans => {
      this.weeklyPlan = plans;
    });
  }

  goToPreviousWeek() {
    const previous = new Date(this.currentWeekStart);
    previous.setDate(previous.getDate() - 7);
    this.currentWeekStart = this.getStartOfWeek(previous);
    this.loadWeek();
  }

  goToNextWeek() {
    const next = new Date(this.currentWeekStart);
    next.setDate(next.getDate() + 7);
    this.currentWeekStart = this.getStartOfWeek(next);
    this.loadWeek();
  }

  getCurrentWeekRange(): string {
    const start = this.formatDate(this.currentWeekStart);
    const end = this.formatDate(new Date(this.currentWeekStart.getTime() + 6 * 86400000));
    return `${start} - ${end}`;
  }
}
