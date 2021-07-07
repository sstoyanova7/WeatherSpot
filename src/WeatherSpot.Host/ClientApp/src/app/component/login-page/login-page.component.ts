import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { LoginUser } from '../../modules/loginUser';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  public isValid: boolean = true;

  constructor(private service: AuthService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(e) {
    console.log(e);

    const user: LoginUser = new LoginUser(e.value.username, e.value.password);

    if (e.valid) {
      this.service.loginUser(user).subscribe(() => {
        if (document.cookie) {
          this.router.navigate(['/station']);
        }
      });
    }
  }
}
