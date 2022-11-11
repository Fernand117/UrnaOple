import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import Swal from "sweetalert2";

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class AlertasModule {
  public mensajeError(mensaje: string) {
    Swal.fire({
      position: 'top-end',
      icon: 'error',
      title: mensaje,
      showConfirmButton: false,
      timer: 1500
    });
  }

  public mensajeOk(mensaje: string) {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: mensaje,
      showConfirmButton: false,
      timer: 1500
    });
  }

  public mensajeAdvertencia(mensaje: string) {
    Swal.fire({
      position: 'top-end',
      icon: 'warning',
      title: mensaje,
      showConfirmButton: false,
      timer: 1500
    });
  }
}
