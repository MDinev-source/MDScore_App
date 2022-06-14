import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Player } from '../models/Player';
import { AuthService } from '../services/auth.service';
import { PlayerService } from '../services/player.service';

@Component({
  selector: 'app-list-players',
  templateUrl: './list-players.component.html',
  styleUrls: ['./list-players.component.css']
})
export class ListPlayersComponent implements OnInit {

  players: Array<Player>

  constructor(private playerService: PlayerService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.fetchPlayers()
  }

  fetchPlayers() {
    this.playerService.getPlayers().subscribe(players => {
      this.players = players;
    })
  }

  editPlayer(id) {
    this.router.navigate(["players", id, "edit"])
  }

  deletePlayer(id) {
    this.playerService.deletePlayer(id).subscribe(res => {
      this.fetchPlayers()
    })
  }

  isOrganizer() {
    return this.authService.isOrganizer();
  }
}
