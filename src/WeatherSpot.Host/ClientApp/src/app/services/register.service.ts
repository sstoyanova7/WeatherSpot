import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private getUser: string = 'https://localhost:44379/api/User/getUsers';
  private url: string = 'https://localhost:44379/api/User/createNewUser';


  constructor(private http: HttpClient) { }


  registerUser(user) {
    return this.http.post(this.url, user);
  }

  getUsers() {
    return this.http.get(this.getUser);
  }
}
