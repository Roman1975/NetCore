import { Component, OnInit } from '@angular/core';
import { Contract } from '../contract';
import { ContractService } from '../contract.service';

@Component({
  selector: 'app-contracts',
  templateUrl: './contracts.component.html',
  styleUrls: ['./contracts.component.css']
})
export class ContractsComponent implements OnInit {

  contracts: Contract[];

  selectedItem: Contract;

  constructor(private contractService: ContractService) { }

  ngOnInit() {
      this.getContracts();
  }

  onSelect(item: Contract): void {
    this.selectedItem = item;
  }

  getContracts(): void {
    this.contractService.getContracts()
      .subscribe(contracts => this.contracts = contracts);
  }
}
