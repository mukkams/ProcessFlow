import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  users: any;
  constructor( private http: HttpClient) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers()
  {
    return this.http.get('http://localhost:5000/api/values').subscribe( res => {
      this.users = res;

    }, error => {
     console.log(error);
    }
    );
  }
}
