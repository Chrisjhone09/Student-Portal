import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EvaluationHomeComponent } from './evaluation-home.component';

describe('EvaluationHomeComponent', () => {
  let component: EvaluationHomeComponent;
  let fixture: ComponentFixture<EvaluationHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EvaluationHomeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EvaluationHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
