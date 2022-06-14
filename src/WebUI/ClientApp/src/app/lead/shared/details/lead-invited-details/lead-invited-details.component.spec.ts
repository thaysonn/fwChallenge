import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadInvitedDetailsComponent } from './lead-invited-details.component';

describe('LeadInvitedDetailsComponent', () => {
  let component: LeadInvitedDetailsComponent;
  let fixture: ComponentFixture<LeadInvitedDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeadInvitedDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadInvitedDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
