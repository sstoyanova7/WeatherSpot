import { Component, OnInit } from '@angular/core';
import { TypedRule } from 'tslint/lib/rules';
import { LoginUser } from '../../modules/loginUser';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  public isValid: boolean = true;
  
  constructor() { }

  ngOnInit() {
  }

  onSubmit(e) {
    console.log(e);
    
    const user: LoginUser = new LoginUser(e.value.username, e.value.password);

    if (e.valid) {
      //post user to backend
    } else {
      // username || password incorrect 
      this.isValid = false;
      setTimeout(() => {
        this.isValid = true;
      }, 3000)
    }
    
    
    
  }
}
