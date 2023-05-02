import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { RegisterService } from '../service/register.service';

export class RegisterModel {
  Email!: string;
  Password!: string;
  UserName!: string;
  MobileNumber!: string;
  UserRole!: any;
}
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  registerForm!: FormGroup;


  constructor(private formBuilder: FormBuilder, public registerservice: RegisterService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      
      Email: ['', [Validators.required, Validators.email]],
      UserName: ['', Validators.required],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      MobileNumber: ['', Validators.required],
      UserRole: ['', Validators.required]

    });
  }
  onSubmit(): void {
    if (this.registerForm.valid) {
      this.registerservice.Create(this.registerForm.value).subscribe(res=>{console.log(res)}); 
      this.registerForm.reset(); 

    } else {
      alert('Form should not be null');
    }
    
    
      
  }
}

