import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Player } from '../models/Player';
import { PlayerService } from '../services/player.service';
import { map, mergeMap } from 'rxjs/operators'

@Component({
  selector: 'app-details-player',
  templateUrl: './details-player.component.html',
  styleUrls: ['./details-player.component.css']
})
export class DetailsPlayerComponent implements OnInit {

  id: string;
  player: Player;

  constructor(private route: ActivatedRoute, private playerService: PlayerService) {
    this.fetchData()
  }

  ngOnInit(): void {
  }

  fetchData() {
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id
    }), mergeMap(id => this.playerService.getPlayer(id))).subscribe(res => {
      this.player = res;
    })

  }
}
