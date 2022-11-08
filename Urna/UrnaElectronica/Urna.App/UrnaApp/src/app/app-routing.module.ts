import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClausuraComponent } from './pages/clausura/clausura/clausura.component';
import { BienvenidoComponent } from './pages/inicializacion/bienvenido/bienvenido/bienvenido.component';
import { BoletaComponent } from './pages/inicializacion/boleta/boleta/boleta.component';
import { ConfiguracionComponent } from './pages/inicializacion/configuracion/configuracion/configuracion.component';
import { TarjetasComponent } from './pages/inicializacion/tarjetas/tarjetas/tarjetas.component';
import { EleccionesEscolaresComponent } from './pages/votaciones/elecciones-escolares/elecciones-escolares.component';
import { EsperaElectorComponent } from './pages/votaciones/mensajes/espera-elector/espera-elector.component';
import { GraciasComponent } from './pages/votaciones/mensajes/gracias/gracias.component';
import { VotacionesComponent } from './pages/votaciones/votaciones.component';
import { ParticipacionCiudadanaComponent } from './pages/votaciones/participacion-ciudadana/participacion-ciudadana.component';
import { ActaCierreComponent } from './pages/clausura/acta-cierre/acta-cierre.component';
import { NoBoletasComponent } from './pages/votaciones/mensajes/no-boletas/no-boletas.component';

const routes: Routes = [
  { path: '', redirectTo: '/bienvenido', pathMatch: 'full' },
  { path: 'votaciones', component: VotacionesComponent },
  { path: 'bienvenido', component: BienvenidoComponent },
  { path: 'boleta-inicializacion', component: BoletaComponent},
  { path: 'tarjetas', component: TarjetasComponent},
  { path: 'clausura', component: ClausuraComponent},
  { path: 'configuracion', component: ConfiguracionComponent},
  { path: 'en-espera', component: EsperaElectorComponent},
  { path: 'gracias', component: GraciasComponent},
  { path: 'elecciones-escolares', component: EleccionesEscolaresComponent},
  { path: 'participacion-ciudadana', component: ParticipacionCiudadanaComponent},
  { path: 'acta-cierre', component: ActaCierreComponent},
  { path: 'no-boletas', component: NoBoletasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
