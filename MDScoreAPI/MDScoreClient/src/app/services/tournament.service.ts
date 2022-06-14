import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { Tournament } from '../models/Tournament';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {

  private tournamentPath = environment.apiUrl + 'Tournaments';

  constructor(private http: HttpClient) { }

  create(data): Observable<Tournament> {
    return this.http.post<Tournament>(this.tournamentPath, data)
  }

  getTournament(id): Observable<Tournament> {
    return this.http.get<Tournament>(this.tournamentPath + '/' + id)
  }

  getTournaments(): Observable<Array<Tournament>> {
    return this.http.get<Array<Tournament>>(this.tournamentPath)
  }

  deleteTournament(id) {
    return this.http.delete(this.tournamentPath + '/' + id)
  }
}
