import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.registerForm = this.fb.group({
      'firstName': ['', Validators.required],
      'lastName': ['', Validators.required],
      'username': ['', Validators.required],
      'password': ['', Validators.required]
    })
  }

  ngOnInit() { }

  validateControl = (controlName: string) => {
    return this.registerForm.get(controlName).invalid && this.registerForm.get(controlName).touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName).hasError(errorName)
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      this.router.navigate(["login"])
    })
  }

  get firstName() {
    return this.registerForm.get('firstName')
  }

  get lastName() {
    return this.registerForm.get('lastName')
  }

  get username() {
    return this.registerForm.get('username')
  }

  get password() {
    return this.registerForm.get('password')
  }
}
