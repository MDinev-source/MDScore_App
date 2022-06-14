import { PlayerTournament } from "./PlayerTournament";

export interface TournamentPlayers {
    id: number;
    firstName: string;
    lastName: string;
    town: string;
    country: string;
    playerTournaments?:Array<PlayerTournament>;
}
