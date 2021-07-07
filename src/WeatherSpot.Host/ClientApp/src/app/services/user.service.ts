import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  private getUsersUrl: string = '/api/User/getUsers';
  private deactivateUserUrl: string = '/api/User/deactivateUser';
  private changeUserRoleUrl: string = "/api/User/changeUserRole";
  private activateUserUrl: string = '/api/User/activateUser';
  private changeUsernameUrl: string = '/api/User/changeUsername';
  private changePasswordUrl: string = '/api/User/changePassword';

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(this.getUsersUrl);
  }

  changeUserRole(userData) {
    return this.http.put(this.changeUserRoleUrl, userData);
  }

  deactivateUser(id) {
    return this.http.put(this.deactivateUserUrl, id);
  }

  activateUser(id) {
    return this.http.put(this.activateUserUrl, id);
  }

  changeUsername(user) {
    return this.http.put(this.changeUsernameUrl, user);
  }

  changePassword(user) {
    return this.http.put(this.changePasswordUrl, user);
  }
}
