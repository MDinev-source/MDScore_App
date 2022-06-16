import { Component} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-add-player',
  templateUrl: './add-player.component.html',
  styleUrls: ['./add-player.component.css']
})
export class AddPlayerComponent {

  playerForm: FormGroup;
  constructor(private fb: FormBuilder, private playerService: PlayerService, private router: Router) {
    this.playerForm = this.fb.group({
      'firstName': ['', Validators.required],
      'lastName': ['', Validators.required],
      'imageUrl': ['', Validators.required],
      'age': ['', Validators.required],
      'town': ['', Validators.required],
      'country': ['', Validators.required],
      'averageSpeed': ['', Validators.required]
    })
  }

  validateControl = (controlName: string) => {
    return this.playerForm.get(controlName).invalid && this.playerForm.get(controlName).touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.playerForm.get(controlName).hasError(errorName)
  }

  get firstName() {
    return this.playerForm.get('firstName');
  }

  get lastName() {
    return this.playerForm.get('lastName');
  }

  get imageUrl() {
    return this.playerForm.get('imageUrl');
  }

  get age() {
    return this.playerForm.get('age');
  }

  get town() {
    return this.playerForm.get('town');
  }

  get country() {
    return this.playerForm.get('country');
  }

  get averageSpeed() {
    return this.playerForm.get('averageSpeed');
  }
  create() {
    this.playerService.create(this.playerForm.value).subscribe(res => {
      this.router.navigate(["players"]);
    })
  }
}


