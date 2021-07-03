import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  private getUsersUrl: string = '/api/User/getUsers';
  private registerUserUrl: string = '/api/User/createNewUser';
  private loginUserUrl: string = '/api/Authentication/sign-in';
  private deactivateUserUrl: string = '/api/User/deactivateUser';
  private changeUserRoleUrl: string = "/api/User/changeUserRole";
  private activateUserUrl: string = '/api/User/activateUser';
  private logoutUserUrl: string = '/api/Authentication/logout';

  constructor(private http: HttpClient) { }

  registerUser(user) {
    return this.http.post(this.registerUserUrl, user);
  }

  getUsers() {
    return this.http.get(this.getUsersUrl);
  }

  loginUser(user) {
    return this.http.post(this.loginUserUrl, user);
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

  logout() {
    return this.http.post(this.logoutUserUrl, {});
  }
}
