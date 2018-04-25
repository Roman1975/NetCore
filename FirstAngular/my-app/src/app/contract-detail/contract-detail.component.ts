import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import {Contract} from '../contract';
import { ContractService }  from '../contract.service';

@Component({
  selector: 'app-contract-detail',
  templateUrl: './contract-detail.component.html',
  styleUrls: ['./contract-detail.component.css']
})
export class ContractDetailComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private contractService: ContractService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.findContract();
  }
  
  findContract(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.contractService.findContract(id)
      .subscribe(item => this.contract = item);
  }

  @Input() contract : Contract;

}
