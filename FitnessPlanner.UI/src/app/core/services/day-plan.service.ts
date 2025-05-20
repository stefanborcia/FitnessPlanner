import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DayPlanService {
  private apiUrl = 'http://localhost:5258/api/dayplans';

  constructor(private http: HttpClient) { }

  getWeekPlans(startDate: string, userId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/week?startDate=${startDate}&userId=${userId}`);
  }
}
