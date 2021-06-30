import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterUser } from '../../modules/registerUser';
import { RegisterService } from 'src/app/services/register.service';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})

export class RegisterPageComponent implements OnInit {

  public validatePasswords: boolean = true;
  public status: string;
  constructor(private router: Router, private regService: RegisterService) { }
  
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
      this.regService.registerUser(newUser).subscribe(res => {
        this.status = res.status;
        setTimeout(() => {
          this.status = '';
          this.router.navigate(['/login']);
        }, 2000)

      });
    }
  }

}
