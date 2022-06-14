import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadInvitedListComponent } from './lead-invited-list.component';

describe('LeadInvitedListComponent', () => {
  let component: LeadInvitedListComponent;
  let fixture: ComponentFixture<LeadInvitedListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeadInvitedListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadInvitedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
