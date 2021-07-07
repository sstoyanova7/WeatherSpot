import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterUser } from '../../modules/registerUser';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})

export class RegisterPageComponent implements OnInit {

  public validatePasswords: boolean = true;
  public status: string;
  constructor(private router: Router, private regService: AuthService) { }

  ngOnInit() {

  }

  onSubmit(e: NgForm) {
    this.validatePasswords = e.value.password === e.value.confirmPassword ? true : false;
    const newUser: RegisterUser = new RegisterUser(
      e.value.username,
      e.value.name,
      e.value.email,
      e.value.password);

    if (e.valid && this.validatePasswords) {
      this.regService.registerUser(newUser).subscribe((res: any) => {
        this.status = res.status;
        if (this.status === '200') {
          setTimeout(() => {
            this.status = '';
            this.router.navigate(['/login'])
          }, 2000);
          
        } else {
          setTimeout(() => {
            this.status = '';
          }, 2000)
        }

      });
    }
  }

}
