import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { InscricaoComponent } from "./usuario/inscricao/inscricao.component";
import { LoginComponent } from "./usuario/login/login.component";
import { AdicionarEventoComponent } from "./eventos/adicionar-evento/adicionar-evento.component";
import { ListaEventosComponent } from "./eventos/lista-eventos/lista-eventos.component";
import { MeusEventosComponent } from "./eventos/meus-eventos/meus-eventos.component";
import { AcessoNegadoComponent } from "./shared/acesso-negado/acesso-negado.component";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'inscricao', component: InscricaoComponent },
    { path: 'entrar', component: LoginComponent },
    { path: 'proximos-eventos', component: ListaEventosComponent },
    { path: 'acesso-negado', component: AcessoNegadoComponent }
]