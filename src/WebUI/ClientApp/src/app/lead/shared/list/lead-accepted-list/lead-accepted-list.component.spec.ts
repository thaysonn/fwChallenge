import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadAcceptedListComponent } from './lead-accepted-list.component';

describe('LeadAcceptedListComponent', () => {
  let component: LeadAcceptedListComponent;
  let fixture: ComponentFixture<LeadAcceptedListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeadAcceptedListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadAcceptedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
