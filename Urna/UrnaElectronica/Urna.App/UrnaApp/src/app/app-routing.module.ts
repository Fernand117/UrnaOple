import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClausuraComponent } from './pages/clausura/clausura/clausura.component';
import { BienvenidoComponent } from './pages/inicializacion/bienvenido/bienvenido/bienvenido.component';
import { BoletaComponent } from './pages/inicializacion/boleta/boleta/boleta.component';
import { ConfiguracionComponent } from './pages/inicializacion/configuracion/configuracion/configuracion.component';
import { TarjetasComponent } from './pages/inicializacion/tarjetas/tarjetas/tarjetas.component';
import { VotacionesComponent } from './pages/votaciones/votaciones.component';

const routes: Routes = [
  { path: '', redirectTo: '/bienvenido', pathMatch: 'full' },
  { path: 'votaciones', component: VotacionesComponent },
  { path: 'bienvenido', component: BienvenidoComponent },
  { path: 'boleta-inicializacion', component: BoletaComponent},
  { path: 'tarjetas', component: TarjetasComponent},
  { path: 'clausura', component: ClausuraComponent},
  { path: 'configuracion', component: ConfiguracionComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
