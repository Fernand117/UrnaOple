import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { InicioComponent } from './pages/inicio/inicio.component';
import { EleccionesComponent } from './pages/elecciones/elecciones.component';
import { ProcesosComponent } from './pages/procesos/procesos.component';
import { ParticipacionComponent } from './pages/participacion/participacion.component';
import { EscolaresComponent } from './pages/escolares/escolares.component';
import {MecanismosComponent} from "./pages/mecanismos/mecanismos.component";

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'inicio', component: InicioComponent },
  { path: 'elecciones', component: EleccionesComponent },

  // Rutas para acceso a las elecciones
  { path: 'elecciones/procesos', component: ProcesosComponent },
  { path: 'elecciones/mecanismos', component: MecanismosComponent},
  { path: 'elecciones/participacion', component: ParticipacionComponent },
  { path: 'elecciones/escolares', component: EscolaresComponent },

  // Rutas para la administración de las elecciones
  { path: '**', pathMatch: 'full', redirectTo: 'login'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
