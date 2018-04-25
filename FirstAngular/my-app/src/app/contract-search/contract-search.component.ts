import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {ContractSearch} from '../contractSearch';
import {KeyValue} from '../keyValue';
import {ContractSearchResult} from '../contractSearchResult';
import { EnterpriseService }  from '../enterprise.service';
import { ContractService }  from '../contract.service';

@Component({
  selector: 'app-contract-search',
  templateUrl: './contract-search.component.html',
  styleUrls: ['./contract-search.component.css']
})

export class ContractSearchComponent implements OnInit {

  constructor(
    private entService: EnterpriseService,
    private contractService: ContractService
  ) {}

  ngOnInit() {
    this.loadEnterpises();
  }
  
  model = new ContractSearch();
  enterprises: KeyValue[];
  contracts: ContractSearchResult[];

  onSubmit(){
    this.findContracts();
    // console.log(this.contracts.length);
  }

  loadEnterpises(): void {
    this.entService.getEnterpriseList()
      .subscribe(items => this.enterprises = items);
  }

  findContracts(): void{
    this.contractService.findContracts(this.model)
      .subscribe(items => this.contracts = items);
  }

  get diagnostic() { return JSON.stringify(this.model); }
}