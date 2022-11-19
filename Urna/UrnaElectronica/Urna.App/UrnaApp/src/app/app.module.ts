import { LOCALE_ID, NgModule } from '@angular/core';
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
import localeEs from '@angular/common/locales/es';
import { registerLocaleData } from '@angular/common';
import { ReferendumComponent } from './pages/votaciones/participacion-ciudadana/referendum/referendum.component';
import { ActaCierreComponent } from './pages/clausura/acta-cierre/acta-cierre.component';
import { NoBoletasComponent } from './pages/votaciones/mensajes/no-boletas/no-boletas.component';
import { AutorizarVotacionesComponent } from './pages/votaciones/mensajes/autorizar-votaciones/autorizar-votaciones.component';
import { NgxQRCodeModule } from '@techiediaries/ngx-qrcode';
import { CloudinaryModule } from '@cloudinary/ng'
registerLocaleData(localeEs, 'es');

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
    ParticipacionCiudadanaComponent,
    ReferendumComponent,
    ActaCierreComponent,
    NoBoletasComponent,
    AutorizarVotacionesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxQRCodeModule,
    CloudinaryModule
  ],
  providers: [{provide: LOCALE_ID, useValue: 'es'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
