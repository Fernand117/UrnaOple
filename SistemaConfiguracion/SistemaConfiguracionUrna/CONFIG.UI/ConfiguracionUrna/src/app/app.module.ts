import { NgModule } from '@angular/core';
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
import { AdminComponent } from './pages/procesos/admin/admin.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
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
    AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
