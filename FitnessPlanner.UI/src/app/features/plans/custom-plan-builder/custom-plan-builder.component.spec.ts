import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomPlanBuilderComponent } from './custom-plan-builder.component';

describe('CustomPlanBuilderComponent', () => {
  let component: CustomPlanBuilderComponent;
  let fixture: ComponentFixture<CustomPlanBuilderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomPlanBuilderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomPlanBuilderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
