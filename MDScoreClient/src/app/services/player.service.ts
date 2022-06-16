import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Player } from '../models/Player';


@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  private playerPath = environment.apiUrl + 'Players';

  constructor(private http: HttpClient) { }


  create(data): Observable<Player> {
    return this.http.post<Player>(this.playerPath, data)
  }

  getPlayer(id): Observable<Player> {
    return this.http.get<Player>(this.playerPath + '/' + id)
  }

  getPlayers(): Observable<Array<Player>> {
    return this.http.get<Array<Player>>(this.playerPath)
  }


  editPlayer(data) {
    return this.http.post(this.playerPath, data)
  }

  deletePlayer(id) {
    return this.http.delete(this.playerPath + '/' + id)
  }

  addWiner(data) {
    return this.http.post(this.playerPath + '/' + data.playerId + '/winner', data)
  }
}
