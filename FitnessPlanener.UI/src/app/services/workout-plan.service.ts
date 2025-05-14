import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface PlanRequestDto {
  goal: number; // Use enums or constants if needed
  bodyType: number;
}

export interface ExerciseDto {
  name: string;
  reps: number;
  sets: number;
}

export interface WorkoutPlanDto {
  id: string;
  name: string;
  exercises: ExerciseDto[];
}

@Injectable({
  providedIn: 'root'
})
export class WorkoutPlanService {
  private baseUrl = 'http://localhost:5258/api/plan'; // Change if your API base URL is different

  constructor(private http: HttpClient) { }

  generatePlan(request: PlanRequestDto): Observable<WorkoutPlanDto> {
    return this.http.post<WorkoutPlanDto>(`${this.baseUrl}/workout`, request);
  }

  savePlan(request: PlanRequestDto): Observable<any> {
    return this.http.post(`${this.baseUrl}/save-workout?userId=00000000-0000-0000-0000-000000000001`, request);
  }

  getAllPlans(): Observable<WorkoutPlanDto[]> {
    return this.http.get<WorkoutPlanDto[]>(`${this.baseUrl}`);
  }
}
