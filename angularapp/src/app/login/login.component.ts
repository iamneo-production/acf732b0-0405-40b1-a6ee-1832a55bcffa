import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { LoginService } from '../service/login.service';
import { from } from 'rxjs';
import { Router } from '@angular/router';
export class LoginModel {
  Email !: string;
  Password !: string;
}
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  login: LoginModel = new LoginModel();
  constructor(private loginservice: LoginService, private router:Router) { }
  onSubmit(userForm: NgForm) {
    if (!userForm.valid) {
      alert('enter valid data');
    }
    if (userForm.valid) {

      console.log(userForm.value);
      this.loginservice.Create(userForm.value).subscribe(res => {
        var str = JSON.stringify(res);
        var r = JSON.parse(str);
        if (r.errorMessage == 'No user found with username') {

          alert("no such user found");

          userForm.resetForm();

        }
        else {
          var role = this.loginservice.settoken(r.message)
         role = role.toLowerCase();
          if (role == "admin") {

           this.router.navigateByUrl('admin/homepage');

          }
          else if(role == "jobseeker")
          {
            this.router.navigateByUrl('user/jobseekernavigation');
          }
          else {

            this.router.navigateByUrl('user/homepage');

          }

          userForm.resetForm();
        }
      });

    }
  }

}
