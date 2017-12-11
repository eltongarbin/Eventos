import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { InscricaoComponent } from "./usuario/inscricao/inscricao.component";
import { LoginComponent } from "./usuario/login/login.component";
import { AdicionarEventoComponent } from "./eventos/adicionar-evento/adicionar-evento.component";
import { ListaEventosComponent } from "./eventos/lista-eventos/lista-eventos.component";
import { MeusEventosComponent } from "./eventos/meus-eventos/meus-eventos.component";
import { AcessoNegadoComponent } from "./shared/acesso-negado/acesso-negado.component";

import { AuthService } from './shared/auth-service';

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'inscricao', component: InscricaoComponent },
    { path: 'entrar', component: LoginComponent },
    { path: 'novo-evento', canActivate: [AuthService], component: AdicionarEventoComponent, data: [{ claim: { nome: 'Eventos', valor: 'Gravar'}}]},
    { path: 'proximos-eventos', component: ListaEventosComponent },
    { path: 'meus-eventos', canActivate: [AuthService], component: MeusEventosComponent },
    { path: 'acesso-negado', component: AcessoNegadoComponent }
]