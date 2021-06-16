import { Component, OnInit } from '@angular/core';
import { NewUser } from '../../modules/NewUser';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  // TODO
  /**
   * Implement Service for Register
   * Http requests to backend
   * Validations
   * 
   */

  public user: NewUser;
  public username: string = "";
  public password: string = "";
  public confirmPassword: string = "";

  constructor() { }

  ngOnInit() {}

  onSubmit() {
    this.user = new NewUser(this.username, this.password); 
    console.log(
     this.user, this.confirmPassword
    );
  }

}
