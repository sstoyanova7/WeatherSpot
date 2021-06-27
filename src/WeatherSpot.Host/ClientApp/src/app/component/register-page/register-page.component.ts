import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NewUser } from '../../modules/NewUser';
import { RegisterService } from 'src/app/services/register.service';
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

  public validatePasswords: boolean = true;

  constructor(private regService: RegisterService) { }


  ngOnInit() {

  }

  log(e) {
    console.log(e);
  }

  onSubmit(e: NgForm) {
    console.log(e);
    this.validatePasswords = e.value.password === e.value.confirmPassword ? true : false;
    const newUser: NewUser = new NewUser(
      e.value.username,
      e.value.name,
      e.value.email,
      e.value.password
    )

    console.log(newUser);
  }

}
