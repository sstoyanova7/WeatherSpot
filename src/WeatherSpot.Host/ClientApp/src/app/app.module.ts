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
import { StationAdminComponent } from './component/station-admin/station-admin.component';
import { AddNewRcsComponent } from './component/add-new-rcs/add-new-rcs.component';
import { UserStationComponent } from './component/user-station/user-station.component';
import { RcsService } from './services/rcs.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { AdminAuthGuard } from './services/admin-auth-guard.service';
import { NoAccessComponent } from './component/no-access/no-access.component';
import { StationDataService } from './services/station-data.service';
import { ChartsModule } from '@progress/kendo-angular-charts';
import 'hammerjs';
import { DialogsModule } from '@progress/kendo-angular-dialog';













@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginPageComponent,
    UserStationComponent,
    RegisterPageComponent,
    LoginPageComponent,
    RegisterPageComponent,
    ProfileComponent,
    AdminPanelComponent,
    StationAdminComponent,
    AddNewRcsComponent,
    NoAccessComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      // { path: '', component: LoginPageComponent, pathMatch: 'full' }, after login
      { path: 'register', component: RegisterPageComponent },
      { path: 'login', component: LoginPageComponent },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
      { path: 'user-panel', component: AdminPanelComponent, canActivate: [AuthGuard, AdminAuthGuard] },
      { path: 'station', component: UserStationComponent, canActivate: [AuthGuard] },
      { path: 'station-panel', component: StationAdminComponent, canActivate: [AuthGuard, AdminAuthGuard] },
      { path: 'add-rcs-panel', component: AddNewRcsComponent, canActivate: [AuthGuard, AdminAuthGuard] },
      { path: 'no-access', component: NoAccessComponent }

      // { path: '**', component: RegisterPageComponent } add 404 page
    ]),
    LayoutModule,
    BrowserAnimationsModule,
    ButtonsModule,
    InputsModule,
    LabelModule,
    GridModule,
    DropDownsModule,
    ChartsModule,
    DialogsModule
  ],
  providers: [UserService, RcsService, AuthService, AuthGuard, AdminAuthGuard, StationDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
