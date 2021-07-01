import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  private getUsersUrl: string = 'https://localhost:44379/api/User/getUsers';
  private registerUserUrl: string = 'https://localhost:44379/api/User/createNewUser';
  private loginUserUrl: string = 'https://localhost:44379/api/Authentication/sign-in';
  private deactivateUserUrl: string = 'https://localhost:44379/api/User/deactivateUser';
  private changeUserRoleUrl: string = "https://localhost:44379/api/User/changeUserRole";
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


}
