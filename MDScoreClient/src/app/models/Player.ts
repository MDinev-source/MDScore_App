import { PlayerTournament } from "./PlayerTournament";

export interface Player {
    id: number;
    firstName: string;
    lastName: string;
    imageUrl: string;
    age: number;
    town: string;
    country: string;
    averageSpeed: number;
    win?: number;
    losses?: number;
    tournamentsCount?: number;
    playerTournaments?:Array<PlayerTournament>;
}
