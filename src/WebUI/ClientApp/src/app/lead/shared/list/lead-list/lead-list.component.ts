import { Component, Input, OnInit } from '@angular/core';
import { LeadStatus } from '../../../../web-api-client';

@Component({
  selector: 'app-lead-list',
  templateUrl: './lead-list.component.html',
  styleUrls: ['./lead-list.component.scss']
})
export class LeadListComponent implements OnInit {
  @Input() leadStatus: number = 0; 
  optionsLeadStatus = LeadStatus;

  constructor() {
  }

  ngOnInit(): void {
  }
}
