import { Component, OnInit, ɵsetCurrentInjector } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Tournament } from '../models/Tournament';
import { TournamentService } from '../services/tournament.service';
import { map, mergeMap } from 'rxjs/operators'
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { TournamentPlayers } from '../models/TournamentPlayers';
import { PlayerService } from '../services/player.service';
import { PlayerTournamentService } from '../services/player-tournament.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-details-tournament',
  templateUrl: './details-tournament.component.html',
  styleUrls: ['./details-tournament.component.css']
})
export class DetailsTournamentComponent implements OnInit {

  id: string;
  isWinnerAdded: boolean = false;
  tournamentId: number;
  tournament: Tournament;
  listPlayersForm: FormGroup;
  playersList: Array<TournamentPlayers>;
  playersListParticipants: any = [];


  constructor(private route: ActivatedRoute
    , private tournamentService: TournamentService
    , private playerTournamentService: PlayerTournamentService
    , private fb: FormBuilder
    , private playerService: PlayerService
    , private authService: AuthService) {

    this.listPlayersForm = this.fb.group({
      players: this.fb.array([]),
    })

  }

  ngOnInit(): void {
    this.fetchData()
    this.fetchListPlayersData();
  }

  fetchData() {
    this.route.params.pipe(map(params => {
      const id = params['id'];
      this.tournamentId = params['id']
      return id
    }), mergeMap(id => this.tournamentService.getTournament(id))).subscribe(res => {
      this.tournament = res;
    })
  }

  fetchListPlayersData() {
    this.playerService.getPlayers().subscribe(playersList => {
      this.playersList = playersList;

      let count = 0;

      for (let i = 0; i < playersList.length; i++) {
        for (let j = 0; j < playersList[i].playerTournaments.length; j++) {
          if (playersList[i].playerTournaments[j].tournamentId === Number(this.tournamentId)) {
            this.playersListParticipants[count] = playersList[i];
            count++;
          }
        }
      }
    })
  }

  players(): FormArray {
    return this.listPlayersForm.get("players") as FormArray
  }

  newPlayer(): FormGroup {
    return this.fb.group({
      id: '',
    })
  }

  addPlayer() {
    this.players().push(this.newPlayer());
  }

  removePlayer(playerIndex: number) {
    this.players().removeAt(playerIndex);
  }

  get player() {
    return this.listPlayersForm.get('player');
  }

  changePlayer(e) {
    this.player.setValue(e.target.value, {
      onlySelf: true
    })
  }

  isOrganizer() {
    return this.authService.isOrganizer();
  }

  addWinner(playerId, tournamentId) {
    let data = {};

    let strPlayerId = JSON.stringify(playerId);
    let strTournamentId = JSON.stringify(tournamentId);

    data['playerId'] = strPlayerId;
    data['tournamentId'] = strTournamentId;

    this.playerService.addWiner(data).subscribe(res => {
    })

    this.isWinnerAdded = true;
    this.fetchData()
    window.location.reload()
  }

  onSubmit() {
    console.log(JSON.stringify(this.listPlayersForm.value))

    let ids = JSON.stringify(this.listPlayersForm.value);
    let tournamentId = JSON.stringify(this.tournament.id);

    let data = {};
    data['tournamentId'] = tournamentId;
    data['ids'] = ids;

    this.playerTournamentService.addPlayerTournament(data).subscribe(res => {
      this.fetchListPlayersData()
    })
  }
}
