import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { LoginModel } from 'src/app/login/login.component';
//const URL:any="https://localhost:7005/Token";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private readonly URL: string = "https://localhost:7196/api/Auth/Token";
  jwtHelperService = new JwtHelperService();
  constructor(private http: HttpClient) { }

  Create(data: LoginModel): Observable<any> {
    return this.http.post<LoginModel>(this.URL, data);
  }
  settoken(token: string) {
    localStorage.setItem("access token", token)
    var role = this.loadcurrentuser();
    return role;
  }
  loadcurrentuser() {
    const token = localStorage.getItem("access token");

    const userInfo = token != null ? this.jwtHelperService.decodeToken(token) : null;

    console.log(userInfo);

    var str = JSON.stringify(userInfo);

    var j = JSON.parse(str);

    var role = j.role;

    return role;
  }
}