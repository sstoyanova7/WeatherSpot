import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuard implements CanActivate {


  constructor(private router: Router, private auth: AuthService) { }

  canActivate() {
    const user = this.auth.currentUser();

    if (user.RoleId !== '3') return true;

    this.router.navigate(['/no-access']);
    return false;
  }
}
