import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPlayerComponent } from './add-player/add-player.component';
import { AddTournamentComponent } from './add-tournament/add-tournament.component';
import { DetailsPlayerComponent } from './details-player/details-player.component';
import { DetailsTournamentComponent } from './details-tournament/details-tournament.component';
import { EditPlayerComponent } from './edit-player/edit-player.component';
import { HomeComponent } from './home/home.component';
import { ListPlayersComponent } from './list-players/list-players.component';
import { ListTournamentsComponent } from './list-tournaments/list-tournaments.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'create/player', component: AddPlayerComponent, canActivate: [AuthGuardService] },
  { path: 'create/tournament', component: AddTournamentComponent, canActivate: [AuthGuardService] },
  { path: 'tournaments/:id', component: DetailsTournamentComponent },
  { path: 'players/:id', component: DetailsPlayerComponent },
  { path: 'players', component: ListPlayersComponent },
  { path: 'tournaments', component: ListTournamentsComponent },
  { path: 'players/:id/edit', component: EditPlayerComponent},
  {path: '',component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
