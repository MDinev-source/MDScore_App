import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Player } from '../models/Player';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent implements OnInit {

  playerForm: FormGroup;
  playerId: number;
  player: Player;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private playerService: PlayerService,
    private router: Router
  ) {
    this.playerForm = this.fb.group({
      'id': [''],
      'firstName': [''],
      'lastName': [''],
      'imageUrl': [''],
      'age': [''],
      'town': [''],
      'country': [''],
      'averageSpeed': ['']
    })
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.playerId = params['id'];

      this.playerService.getPlayer(this.playerId).subscribe(res => {
        this.player = res;
        this.playerForm = this.fb.group({
          'id': [this.player.id],
          'firstName': [this.player.firstName],
          'lastName': [this.player.lastName],
          'imageUrl': [this.player.imageUrl],
          'age': [this.player.age],
          'town': [this.player.town],
          'country': [this.player.country],
          'averageSpeed': [this.player.averageSpeed]
        })
      })
    })
  }

  editPlayer() {
    this.playerService.editPlayer(this.playerForm.value).subscribe(res => {
      this.router.navigate(["players"])
    })
  }
}
