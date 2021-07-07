import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  public users: any;
  public roleData: Array<string> = ['super admin', 'admin', 'normal'];

  constructor(private service: UserService, private auth: AuthService) { }

  ngOnInit() {
    this.service.getUsers().subscribe((res: any) => {
      this.users = res;
    });
  }

  canAdminChangeRole() {
    const admin = this.auth.currentUser();
    if (admin.RoleId === 1) return true;

    return false;
  }

  changeUserRole(newRole, userId) {
    let changeRole = {
      userId: userId,
      roleId: this.roleData.indexOf(newRole) + 1
    };
    
    this.service.changeUserRole(changeRole).subscribe(() => {
      this.ngOnInit();
    });
  }

  deactivateUser(id) {
    this.service.deactivateUser(id).subscribe(() => {
      this.ngOnInit();
    });
  }

  activateUser(id) {
    this.service.activateUser(id).subscribe(() => {
      this.ngOnInit();      
    })
    }
}
