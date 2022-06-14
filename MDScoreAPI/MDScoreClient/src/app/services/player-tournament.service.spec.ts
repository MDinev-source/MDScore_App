import { TestBed } from '@angular/core/testing';

import { PlayerTournamentService } from './player-tournament.service';

describe('PlayerTournamentService', () => {
  let service: PlayerTournamentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlayerTournamentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
