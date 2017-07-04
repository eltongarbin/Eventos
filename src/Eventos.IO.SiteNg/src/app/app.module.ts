import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// bootstrap
import { CollapseModule } from 'ng2-bootstrap/collapse';
import { CarouselModule } from 'ng2-bootstrap/carousel';

// imports
import { MyDatePickerModule } from "mydatepicker";
import { ToastModule, ToastOptions } from 'ng2-toastr/ng2-toastr';

// shared components
import { MenuSuperiorComponent } from './shared/menu-superior/menu-superior.component';
import { FooterComponent } from './shared/footer/footer.component';
import { MainPrincipalComponent } from './shared/main-principal/main-principal.component';
import { MenuLoginComponent } from './shared/menu-login/menu-login.component';

// components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { InscricaoComponent } from './usuario/inscricao/inscricao.component';
import { LoginComponent } from './usuario/login/login.component';
import { AdicionarEventoComponent } from './eventos/adicionar-evento/adicionar-evento.component';

// services
import { OrganizadorService } from "./usuario/organizador.service";
import { EventoService } from "./eventos/evento.service";
import { ToastrCustomOption } from "./utils/ToastrCustomOption";

// others
import { rootRouterConfig } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    MenuSuperiorComponent,
    FooterComponent,
    MainPrincipalComponent,
    MenuLoginComponent,
    HomeComponent,
    InscricaoComponent,
    LoginComponent,
    AdicionarEventoComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpModule,
    MyDatePickerModule,
    BrowserAnimationsModule,
    ToastModule.forRoot(),
    CollapseModule.forRoot(),
    CarouselModule.forRoot(),
    RouterModule.forRoot(rootRouterConfig, { useHash: false })
  ],
  providers: [
    OrganizadorService,
    EventoService,
    { provide: ToastOptions, useClass: ToastrCustomOption }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
