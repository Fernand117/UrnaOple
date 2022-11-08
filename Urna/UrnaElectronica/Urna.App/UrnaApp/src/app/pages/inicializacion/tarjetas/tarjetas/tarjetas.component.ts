import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tarjetas',
  templateUrl: './tarjetas.component.html',
  styleUrls: ['./tarjetas.component.scss']
})
export class TarjetasComponent implements OnInit {

  constructor(private route:Router) { }
  code = "";
  tarjeta_1 = '0002341465';
  tarjeta_2 = '0002341466';
  tarjeta_3 = '0002341467';

  ngOnInit(): void {
    localStorage.clear();
  }

  validar() {
    if(this.code == this.tarjeta_1 || this.code == this.tarjeta_2 || this.code == this.tarjeta_3) {
      this.mostrar_mensaje_success();
    } else {
     this.mostrar_mensaje_error();
    }
  }

  mostrar_mensaje_success() {
    let ruta = this.route;
    Swal.fire(
    'Tarjeta autorizada',      
    'Da clic para comenzar con el proceso de inicialización',
    'success'
    ).then(function() {
      ruta.navigate(['/configuracion']);
    })
  }

  mostrar_mensaje_error() {
    Swal.fire({
      icon: 'error',
      title: 'Tarjeta no autorizada',
      text: 'Por favor inténtelo de nuevo'
    });
    this.code = "";
  }
}
