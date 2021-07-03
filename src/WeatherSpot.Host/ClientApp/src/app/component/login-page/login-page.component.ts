import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { LoginUser } from '../../modules/loginUser';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  public isValid: boolean = true;
  
  constructor(private service: UserService) { }

  ngOnInit() {
  }

  onSubmit(e) {
    console.log(e);
    
    const user: LoginUser = new LoginUser(e.value.username, e.value.password);

    if (e.valid) {
      this.service.loginUser(user).subscribe(response => {
        console.log(response);
        console.log(document.cookie);
      });


    }
    
    
    
  }
}
