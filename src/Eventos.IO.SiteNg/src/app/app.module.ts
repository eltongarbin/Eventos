import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

// bootstrap
import { CollapseModule } from 'ng2-bootstrap/collapse';
import { CarouselModule } from 'ng2-bootstrap/carousel';

// shared components
import { MenuSuperiorComponent } from './shared/menu-superior/menu-superior.component';
import { FooterComponent } from './shared/footer/footer.component';
import { MainPrincipalComponent } from './shared/main-principal/main-principal.component';

// components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

// others
import { rootRouterConfig } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,
    MenuSuperiorComponent,
    FooterComponent,
    MainPrincipalComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    CollapseModule.forRoot(),
    CarouselModule.forRoot(),
    RouterModule.forRoot(rootRouterConfig, { useHash: false })
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
