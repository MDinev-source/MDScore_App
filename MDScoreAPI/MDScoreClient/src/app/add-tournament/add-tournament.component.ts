import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TournamentService } from '../services/tournament.service';

@Component({
  selector: 'app-add-tournament',
  templateUrl: './add-tournament.component.html',
  styleUrls: ['./add-tournament.component.css']
})
export class AddTournamentComponent{
  currentDate:string;

  Style: any = ['Butterfly', 'Breaststroke', 'Freestyle'];
  Distance: any = ['ShortCourse', 'LongCourse'];

  tournamentForm: FormGroup;
  constructor(private fb: FormBuilder, private tournamentService: TournamentService, private router: Router) {
    this.tournamentForm = this.fb.group({
      'name': ['', Validators.required],
      'imageUrl': ['', Validators.required],
      'start': [new Date("MM.dd.yyyy"), Validators.required],
      'end': [new Date("MM.dd.yyyy"), Validators.required],
      'style': ['', [Validators.required]],
      'distance': ['', Validators.required],
      'town': ['', Validators.required],
      'country': ['', Validators.required],
    })

    this.currentDate = new Date().toISOString().slice(0, 10);;
  }


  validateControl = (controlName: string) => {
    return this.tournamentForm.get(controlName).invalid && this.tournamentForm.get(controlName).touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.tournamentForm.get(controlName).hasError(errorName)
  }
  changeStyle(e) {
    console.log(e.value)
    this.style.setValue(e.target.value, {
      onlySelf: true
    })
  }
  changeDistance(e) {
    this.distance.setValue(e.target.value, {
      onlySelf: true
    })
  }

  get name() {
    return this.tournamentForm.get('name');
  }

  get imageUrl() {
    return this.tournamentForm.get('imageUrl');
  }

  get start() {
    return this.tournamentForm.get('start');
  }

  get end() {
    return this.tournamentForm.get('end');
  }

  get style() {
    return this.tournamentForm.get('style');
  }

  get distance() {
    return this.tournamentForm.get('distance');
  }

  get town() {
    return this.tournamentForm.get('town');
  }

  get country() {
    return this.tournamentForm.get('country');
  }

  create() {

    this.tournamentService.create(this.tournamentForm.value).subscribe(res => {
      this.router.navigate(["tournaments"]);
    })
  }

}
