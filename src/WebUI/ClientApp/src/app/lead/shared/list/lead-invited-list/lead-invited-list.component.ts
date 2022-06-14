import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { LeadDto } from '../../../../web-api-client'; 
import { LeadService } from '../../../services/lead.service';
import { Store } from '../../lead.store';

@Component({
  selector: 'app-lead-invited-list',
  templateUrl: './lead-invited-list.component.html',
  styleUrls: ['./lead-invited-list.component.scss']
})
export class LeadInvitedListComponent implements OnInit, OnDestroy {
  invitedLeads$: Observable<LeadDto[]>;
  subscription: Subscription;
   
  constructor(private service: LeadService, private store: Store) { }

  ngOnInit(): void { 
    this.invitedLeads$ = this.store.getInvitedLeads();
    this.subscription = this.service.getInvited$.subscribe();
  } 

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
