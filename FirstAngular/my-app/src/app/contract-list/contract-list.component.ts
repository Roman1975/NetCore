import { Component, OnInit, Input } from '@angular/core';
import { ContractSearchResult } from '../contractSearchResult';

@Component({
  selector: 'app-contract-list',
  templateUrl: './contract-list.component.html',
  styleUrls: ['./contract-list.component.css']
})
export class ContractListComponent implements OnInit {

  constructor() { }

  @Input() items: ContractSearchResult[] = [];

  ngOnInit() {
  }

}
