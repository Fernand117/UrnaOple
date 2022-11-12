import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { InicioComponent } from './pages/inicio/inicio.component';
import { HeaderComponent } from './components/header/header.component';
import { MenuComponent } from './components/menu/menu.component';
import { EleccionesComponent } from './pages/elecciones/elecciones.component';
import { ProcesosComponent } from './pages/procesos/procesos.component';
import { ParticipacionComponent } from './pages/participacion/participacion.component';
import { EscolaresComponent } from './pages/escolares/escolares.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { CloudinaryModule } from '@cloudinary/ng';

import localeEs from '@angular/common/locales/es';

import { registerLocaleData } from '@angular/common';
import { MecanismosComponent } from './pages/mecanismos/mecanismos.component';
registerLocaleData(localeEs, 'es');

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    InicioComponent,
    HeaderComponent,
    MenuComponent,
    EleccionesComponent,
    ProcesosComponent,
    ParticipacionComponent,
    EscolaresComponent,
    MecanismosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CloudinaryModule,
  ],
  providers: [{provide: LOCALE_ID, useValue: 'es'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
