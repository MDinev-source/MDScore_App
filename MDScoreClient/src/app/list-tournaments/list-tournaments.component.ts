import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tournament } from '../models/Tournament';
import { AuthService } from '../services/auth.service';
import { TournamentService } from '../services/tournament.service';

@Component({
  selector: 'app-list-tournaments',
  templateUrl: './list-tournaments.component.html',
  styleUrls: ['./list-tournaments.component.css']
})
export class ListTournamentsComponent implements OnInit {

  tournaments: Array<Tournament>

  constructor(private tournamentService: TournamentService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.fetchTournaments()
  }

  fetchTournaments() {
    this.tournamentService.getTournaments().subscribe(tournaments => {
      this.tournaments = tournaments;
    })
  }

  editTournament(id) {
    this.router.navigate(["tournaments", id, "edit"])
  }

  deleteTournament(id) {
    this.tournamentService.deleteTournament(id).subscribe(res => {
      this.fetchTournaments()
    })
  }

  isOrganizer() {
    return this.authService.isOrganizer();
  }
}
