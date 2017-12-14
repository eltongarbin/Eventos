import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { rootRouterConfig } from './app.routes';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Modules
import { ToastModule, ToastOptions } from 'ng2-toastr/ng2-toastr';

// bootstrap
import { AlertModule } from 'ngx-bootstrap';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { CarouselModule } from 'ngx-bootstrap/carousel';

// shared
import { AcessoNegadoComponent } from './shared/acesso-negado/acesso-negado.component';

// components
import { HomeComponent } from './home/home.component';
import { InscricaoComponent } from './usuario/inscricao/inscricao.component';
import { LoginComponent } from './usuario/login/login.component';

// services
import { SeoService } from './services/seo.service';
import { OrganizadorService } from "./services/organizador.service";

// modules
import { SharedModule } from "./shared/shared.module";

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    InscricaoComponent,
    LoginComponent,
    AcessoNegadoComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    /* EventosModule, <- Não precisa declarar se for usar lazy load */
    SharedModule,
    ReactiveFormsModule,
    ToastModule.forRoot(),
    AlertModule.forRoot(),
    CollapseModule.forRoot(),
    CarouselModule.forRoot(),
    RouterModule.forRoot(rootRouterConfig, { useHash: false })
  ],
  providers: [
    Title,
    SeoService,
    OrganizadorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
