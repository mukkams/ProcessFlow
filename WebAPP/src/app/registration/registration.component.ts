import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter();

  model: any = {};
  users: any;
 // tslint:disable-next-line: no-trailing-whitespace
 
  constructor( private authservice: AuthService, private alertify: AlertifyService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    
  }

  // tslint:disable-next-line: typedef
  register()
  {
    this.authservice.register(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    });
  }

  // tslint:disable-next-line: typedef
  cancel()
  {
    this.cancelRegister.emit(false);
  }

}
