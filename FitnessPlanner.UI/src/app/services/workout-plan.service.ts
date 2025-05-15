import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export type Goal = 'BuildMuscle' | 'LoseWeight' | 'Tone';
export type BodyType = 'Ectomorph' | 'Mesomorph' | 'Endomorph';

export interface PlanRequestDto {
  goal: string;        // "BuildMuscle", "LoseWeight", "Tone"
  bodyType: string;    // "Ectomorph", "Mesomorph", "Endomorph"
  name: string;        // The name of the workout plan
  userId: string;      // Use a valid UUID
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
  providedIn: 'root' // ✅ Ensures singleton without needing providers
})
export class WorkoutPlanService {
  private baseUrl = 'http://localhost:5258/api/plan';

  constructor(private http: HttpClient) { }

  generatePlan(request: PlanRequestDto): Observable<WorkoutPlanDto> {
    return this.http.post<WorkoutPlanDto>(`${this.baseUrl}/workout`, request);
  }

  savePlan(request: PlanRequestDto): Observable<any> {
    return this.http.post(`${this.baseUrl}`, request); 
  }

  getAllPlans(): Observable<WorkoutPlanDto[]> {
    return this.http.get<WorkoutPlanDto[]>(this.baseUrl);
  }
}
