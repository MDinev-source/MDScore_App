import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './services/auth.service';
import { AuthGuardService } from './services/auth-guard.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AddPlayerComponent } from './add-player/add-player.component';
import { AddTournamentComponent } from './add-tournament/add-tournament.component';
import { DetailsTournamentComponent } from './details-tournament/details-tournament.component';
import { DetailsPlayerComponent } from './details-player/details-player.component';
import { PlayerService } from './services/player.service';
import { TournamentService } from './services/tournament.service';
import { PlayerTournamentService } from './services/player-tournament.service';
import { ListPlayersComponent } from './list-players/list-players.component';
import { ListTournamentsComponent } from './list-tournaments/list-tournaments.component';
import { EditPlayerComponent } from './edit-player/edit-player.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    AddPlayerComponent,
    AddTournamentComponent,
    DetailsTournamentComponent,
    DetailsPlayerComponent,
    ListPlayersComponent,
    ListTournamentsComponent,
    EditPlayerComponent,
    HomeComponent,
    FooterComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    AuthService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    PlayerService,
    TournamentService,
    PlayerTournamentService],
    
  bootstrap: [AppComponent]
})
export class AppModule { }
