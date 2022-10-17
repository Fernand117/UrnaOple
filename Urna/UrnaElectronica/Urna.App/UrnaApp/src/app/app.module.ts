import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VotacionesComponent } from './pages/votaciones/votaciones.component';
import { BienvenidoComponent } from './pages/inicializacion/bienvenido/bienvenido/bienvenido.component';
import { TarjetasComponent } from './pages/inicializacion/tarjetas/tarjetas/tarjetas.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { GubernaturaComponent } from './pages/votaciones/gubernatura/gubernatura/gubernatura.component';
import { DiputacionesComponent } from './pages/votaciones/diputaciones/diputaciones/diputaciones.component';
import { AyuntamientoComponent } from './pages/votaciones/ayuntamiento/ayuntamiento/ayuntamiento.component';
import { CardComponent } from './components/card/card.component';
import { ClausuraComponent } from './pages/clausura/clausura/clausura.component';
import { BoletaComponent } from './pages/inicializacion/boleta/boleta/boleta.component';
import { KeyboardComponent } from './components/keyboard/keyboard.component';
import { ConfiguracionComponent } from './pages/inicializacion/configuracion/configuracion/configuracion.component';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { EsperaElectorComponent } from './pages/votaciones/mensajes/espera-elector/espera-elector.component';
import { GraciasComponent } from './pages/votaciones/mensajes/gracias/gracias.component';
import { EleccionesEscolaresComponent } from './pages/votaciones/elecciones-escolares/elecciones-escolares.component';
import { ParticipacionCiudadanaComponent } from './pages/votaciones/participacion-ciudadana/participacion-ciudadana.component';


@NgModule({
  declarations: [
    AppComponent,
    VotacionesComponent,
    BienvenidoComponent,
    TarjetasComponent,
    HeaderComponent,
    FooterComponent,
    GubernaturaComponent,
    DiputacionesComponent,
    AyuntamientoComponent,
    CardComponent,
    ClausuraComponent,
    BoletaComponent,
    KeyboardComponent,
    ConfiguracionComponent,
    EsperaElectorComponent,
    GraciasComponent,
    EleccionesEscolaresComponent,
    ParticipacionCiudadanaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
