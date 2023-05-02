import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
const routes:Routes=[
     {path:'',redirectTo:'user/login',pathMatch:'full'},

  { path: 'user/login', component:LoginComponent},
  { path: 'logout', component: LoginComponent },
  { path: 'user/signup', component:SignupComponent},
  { path : 'admin', component :AdminComponent }
 ]

@NgModule({
  declarations: [
    AppComponent,
     SignupComponent,
     LoginComponent,
     AdminComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
