import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  public users: any;
  public roleData: Array<string> = ['super admin', 'admin', 'normal'];

  constructor(private service: UserService) { }

  ngOnInit() {
    this.service.getUsers().subscribe((res: any) => {
      this.users = res;
    });
  }

  changeUserRole(newRole, userId) {
    /**
     * samo super admin moje da smenq rolq, normalen admin moje da pipa po stanciite
     */
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

  }
}
