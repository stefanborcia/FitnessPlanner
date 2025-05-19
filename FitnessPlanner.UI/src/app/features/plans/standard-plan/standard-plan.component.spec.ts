import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardPlanComponent } from './standard-plan.component';

describe('StandardPlanComponent', () => {
  let component: StandardPlanComponent;
  let fixture: ComponentFixture<StandardPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StandardPlanComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StandardPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
