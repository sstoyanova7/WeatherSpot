import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './component/nav-menu/nav-menu.component';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { LoginPageComponent } from './component/login-page/login-page.component';
import { RegisterPageComponent } from './component/register-page/register-page.component';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { UserService } from './services/user.service';
import { ProfileComponent } from './component/profile/profile.component';
import { AdminPanelComponent } from './component/admin-panel/admin-panel.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';










@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginPageComponent,
    RegisterPageComponent,
    LoginPageComponent,
    RegisterPageComponent,
    ProfileComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      // { path: '', component: LoginPageComponent, pathMatch: 'full' }, after login
      { path: 'login', component: LoginPageComponent },
      { path: 'register', component: RegisterPageComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'admin', component: AdminPanelComponent }

      // { path: '**', component: RegisterPageComponent } add 404 page
    ]),
    LayoutModule,
    BrowserAnimationsModule,
    ButtonsModule,
    InputsModule,
    LabelModule,
    GridModule,
    DropDownsModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
