import { Component, OnInit } from '@angular/core';
import { User } from '../../modules/User';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  public user: User;
  public username: string = "";
  public password: string = "";
  public confirmPassword: string = "";

  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    this.user = new User(this.username, this.password);

    console.log(this.user);
  }
}
