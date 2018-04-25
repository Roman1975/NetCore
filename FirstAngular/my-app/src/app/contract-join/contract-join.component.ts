import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import {Contract} from '../contract';
import { ContractService }  from '../contract.service';

@Component({
  selector: 'app-contract-join',
  templateUrl: './contract-join.component.html',
  styleUrls: ['./contract-join.component.css']
})
export class ContractJoinComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private contractService: ContractService,
    private location: Location
  ) {}

  ngOnInit(): void {

  }
  
  onSubmit(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.checkPincode(id)
    this.submitted = true;
  }

  pinCorrect = false;
  submitted = false;
  pinCode: string;
  
  // @Input() contract : Contract;

  checkPincode(id:number): void {
    this.contractService.checkPincode(this.pinCode, id)
      .subscribe(item => this.pinCorrect = item);
  }
}
