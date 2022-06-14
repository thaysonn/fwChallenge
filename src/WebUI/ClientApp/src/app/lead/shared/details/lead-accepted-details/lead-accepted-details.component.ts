import { Component, Input, OnInit } from '@angular/core';
import { LeadDto } from '../../../../web-api-client';
 
@Component({
  selector: 'app-lead-accepted-details',
  templateUrl: './lead-accepted-details.component.html',
  styleUrls: ['./lead-accepted-details.component.scss']
})
export class LeadAcceptedDetailsComponent implements OnInit {
  @Input() lead: LeadDto = new LeadDto();

  constructor() {
  }

  ngOnInit(): void { 
  }
}
