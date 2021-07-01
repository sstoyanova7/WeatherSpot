import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public newUsername: string;
  public newPassword: string;
  public confirmNewPassword: string;
  constructor() { }

  ngOnInit() {
  }


  onChangeUsername() {
    console.log(this.newUsername);
    /**
     * check if current username !== new username
     */
  }

  onChangePassword() {
    console.log(this.newPassword + ' ' + this.confirmNewPassword);
    /**
     * check if passwords match
     * API - /api/User/changePassword
     */
  }

  deactivateAccount() {
    console.log('account diactivated.');
    /**
     * API - /api/User/deactivateUser
     */
  }
}
