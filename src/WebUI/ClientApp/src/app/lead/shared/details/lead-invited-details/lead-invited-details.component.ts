import { Component, Input, OnInit } from '@angular/core';
import { LeadDto } from '../../../../web-api-client';
import { LeadService } from '../../../services/lead.service';

@Component({
  selector: 'app-lead-invited-details',
  templateUrl: './lead-invited-details.component.html',
  styleUrls: ['./lead-invited-details.component.scss'],
  providers: [LeadService],
})
export class LeadInvitedDetailsComponent implements OnInit {
  @Input() lead: LeadDto = new LeadDto(); 

  constructor(private service: LeadService) { }

  ngOnInit(): void { }

  public accept(): void {
    this.service.accept(this.lead.id); 
  }

  public decline(): void {
    this.service.decline(this.lead.id);
  }
}
