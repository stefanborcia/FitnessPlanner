import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WorkoutPlanComponent } from './components/workout-plan/workout-plan.component';
import { WorkoutPlanService } from './services/workout-plan.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    WorkoutPlanComponent 
  ],
  providers: [
    WorkoutPlanService // Make sure your service is provided here or in a root-level Injectable
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
