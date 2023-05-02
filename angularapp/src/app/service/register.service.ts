import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegisterModel } from '../signup/signup.component';
import { Observable } from 'rxjs';
const URL:any="https://localhost:7196/api/Auth/Register";

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http:HttpClient) { }
  Create(data:RegisterModel) : Observable<any>
  {
    return this.http.post<RegisterModel>(URL,data);
  }
  
}
