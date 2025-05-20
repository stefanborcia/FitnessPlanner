import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DayPlan } from "../models/day-plan.model";
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class PlanService {
  private baseUrl = 'http://localhost:5258/api/plan'; 

  constructor(private http: HttpClient) { }

  getWeeklyPlan(userId: string): Observable<DayPlan[]> {
    return this.http.get<DayPlan[]>(`${this.baseUrl}/user/${userId}`);
  }
}
