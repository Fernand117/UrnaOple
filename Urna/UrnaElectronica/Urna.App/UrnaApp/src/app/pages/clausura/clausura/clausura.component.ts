import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-clausura',
  templateUrl: './clausura.component.html',
  styleUrls: ['./clausura.component.scss']
})
export class ClausuraComponent implements OnInit {
  code = "";
  tarjeta_presidente: string = "";
  configuracion: any;

  constructor(private route:Router) { }

  ngOnInit(): void {
    this.obtenerCodigoAutorizacion();
   }

  validar() {
    if(this.code == this.tarjeta_presidente) {
      this.mostrar_mensaje_success();
    } else {
     this.mostrar_mensaje_error();
    }
  }

  obtenerCodigoAutorizacion() {
    this.configuracion =localStorage.getItem('configeneral');
    this.configuracion = JSON.parse(this.configuracion);
    this.tarjeta_presidente = this.configuracion.CodigoPresidente;
  }

  mostrar_mensaje_success() {
    let ruta = this.route;
    Swal.fire(
    {
      title: "Tarjeta autorizada",
      icon: "success",
      timer: 2000,
      showConfirmButton: false
    }
    ).then(function() {
      ruta.navigate(['/acta-cierre']);
    })
  }

  mostrar_mensaje_error() {
    Swal.fire({
      icon: 'error',
      title: 'Tarjeta no autorizada',
      text: 'Por favor inténtelo de nuevo',
      timer: 2000,
      showConfirmButton: false
    });
    this.code = "";
  }

}
