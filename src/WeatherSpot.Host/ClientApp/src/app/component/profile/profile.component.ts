import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public newUsername: string;
  public newPassword: string;
  public confirmNewPassword: string;

  public arePasswordsValid: boolean = true;
  constructor(private service: UserService, private auth: AuthService) { }

  ngOnInit() { }


  onChangeUsername() {
    const user = this.auth.currentUser();
    const data = {
      userId: user.UserId,
      username: this.newUsername
    };

    this.service.changeUsername(data).subscribe();
  }

  onChangePassword() {
    if (this.newPassword !== this.confirmNewPassword) {
      this.arePasswordsValid = false;
    } else {
      this.arePasswordsValid = true;
      const user = this.auth.currentUser();
      const data = {
        userId: user.UserId,
        newPassword: this.newPassword
      };

      this.service.changePassword(data).subscribe();
    }
  }

  deactivateAccount() {
    if (confirm('Are you sure you want to diactivate your account?')) {
      const user = this.auth.currentUser();
      this.service.deactivateUser(user.UserId);
    }
  }
}
