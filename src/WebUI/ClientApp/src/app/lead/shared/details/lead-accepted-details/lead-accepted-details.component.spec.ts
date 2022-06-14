import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadAcceptedDetailsComponent } from './lead-accepted-details.component';

describe('LeadAcceptedDetailsComponent', () => {
  let component: LeadAcceptedDetailsComponent;
  let fixture: ComponentFixture<LeadAcceptedDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeadAcceptedDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadAcceptedDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
