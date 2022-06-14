import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { LeadDto } from '../../../../web-api-client'; 
import { LeadService } from '../../../services/lead.service';
import { Store } from '../../lead.store';

@Component({
  selector: 'app-lead-accepted-list',
  templateUrl: './lead-accepted-list.component.html',
  styleUrls: ['./lead-accepted-list.component.scss']
})
export class LeadAcceptedListComponent implements OnInit, OnDestroy {
  acceptedLeads$: Observable<LeadDto[]>;
  subscription: Subscription;

  constructor(private service: LeadService, private store: Store) { }

  ngOnInit(): void {
    this.acceptedLeads$ = this.store.getAcceptedLeads();
    this.subscription = this.service.getAccepted$.subscribe();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
