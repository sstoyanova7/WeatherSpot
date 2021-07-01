import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  public users: any;
  constructor(private service: UserService, private _cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.service.getUsers().subscribe((res: any) => {
      this.users = res;
      console.log(this.users);
    });
  }

  deactivateUser(id) {
    this.service.deactivateUser(id).subscribe(res => {
      console.log(res);
      this.ngOnInit();
    });
  }

}
