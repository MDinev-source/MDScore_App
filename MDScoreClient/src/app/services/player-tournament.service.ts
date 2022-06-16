import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { Player } from '../models/Player';
import { PlayerTournament } from '../models/PlayerTournament';

@Injectable({
  providedIn: 'root'
})
export class PlayerTournamentService {
  private playerTournamentPath = environment.apiUrl + 'PlayerTournaments';
  constructor(private http: HttpClient) { }

  addPlayerTournament(data): Observable<PlayerTournament> {
    return this.http.post<PlayerTournament>(this.playerTournamentPath, data)
  }
}
