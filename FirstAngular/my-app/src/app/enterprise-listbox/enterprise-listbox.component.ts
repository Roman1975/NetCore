import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-enterprise-listbox',
  templateUrl: './enterprise-listbox.component.html',
  styleUrls: ['./enterprise-listbox.component.css']
})
export class EnterpriseListboxComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  enterprises = [
    {id:'1', name:'Angle'},
    {id:'2', name:'Bar'},
  ];
  
  selectedEnterprise = null;

  onSelect() {
      // log updated value
      console.log(this.selectedEnterprise);
  }
}