import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  pageTitle = 'Welcome to the SelfService Angular frontend!';

  onNotify(title:string):void {
    this.pageTitle = title;
  }
}
