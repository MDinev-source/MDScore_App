import { PlayerTournament } from "./PlayerTournament";

export interface Tournament {
    id: number;
    name: string;
    imageUrl: string;
    start: Date;
    end: Date;
    style: string;
    distance: string;
    town: string;
    country: string;
    winnerData?: string;
    playerTournaments?:Array<PlayerTournament>;
}
