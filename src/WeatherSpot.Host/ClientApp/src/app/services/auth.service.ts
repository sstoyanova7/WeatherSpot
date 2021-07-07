import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private registerUserUrl: string = '/api/User/createNewUser';
  private loginUserUrl: string = '/api/Authentication/sign-in';
  private logoutUserUrl: string = '/api/Authentication/logout';

  constructor(private http: HttpClient) { }

  registerUser(user) {
    return this.http.post(this.registerUserUrl, user);
  }

  loginUser(user) {
    return this.http.post(this.loginUserUrl, user);
  }

  isLoggedIn() {
    const helper = new JwtHelperService();
    const token = document.cookie;

    if (!token) return false;

    let isExpired = helper.isTokenExpired(token);

    return !isExpired;

  }

  currentUser() {
    const token = document.cookie;
    if (!token) return null;

    return new JwtHelperService().decodeToken(token);
  }

  logout() {
    return this.http.post(this.logoutUserUrl, {});
  }
}
