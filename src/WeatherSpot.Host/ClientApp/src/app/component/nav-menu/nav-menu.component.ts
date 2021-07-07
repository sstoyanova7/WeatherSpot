import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;

  public username: string;
  public roleId: boolean;
  constructor(private auth: AuthService, private router: Router) {
    
  }

  ngOnInit() {
  }

  setUsername() {
    const user = this.auth.currentUser();
    this.username = user.sub;

    return this.username;
  }
  
  collapse() {
    this.isExpanded = false;
    
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  isUserAdmin() {
    
    let user = this.auth.currentUser();
    
    if (user !== null && user.RoleId !== '3') return true; 
    
    return false;
  }

  logout() {
    this.auth.logout().subscribe();
  }

}
