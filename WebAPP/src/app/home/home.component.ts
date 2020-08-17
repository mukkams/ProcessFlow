import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor() { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    console.log(this.registerMode);
  }

  // tslint:disable-next-line: typedef
  registerToggle()
  {
    this.registerMode = ! this.registerMode;
    console.log(this.registerMode);
  }

  // tslint:disable-next-line: typedef
  cancelRegisterMode( data: any)
  {
    this.registerMode = data;
  }
}
