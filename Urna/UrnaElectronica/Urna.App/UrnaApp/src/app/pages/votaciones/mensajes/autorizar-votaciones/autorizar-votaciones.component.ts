import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import {Router } from '@angular/router';

@Component({
  selector: 'app-autorizar-votaciones',
  templateUrl: './autorizar-votaciones.component.html',
  styleUrls: ['./autorizar-votaciones.component.scss']
})
export class AutorizarVotacionesComponent implements OnInit {

  constructor(private route:Router) { }

  code = "";
  tarjeta_1 = '0002341465';
  tarjeta_2 = '0002341466';
  tarjeta_3 = '0002341467';

  ngOnInit(): void {
  }

  validar() {
    if(this.code == this.tarjeta_1 || this.code == this.tarjeta_2 || this.code == this.tarjeta_3) {
      let categoria = localStorage.getItem('categoria');
      if (categoria === 'Elecciones escolares') {
        this.route.navigate(['/elecciones-escolares']);
      } else if (categoria === 'Mecanismos de participación ciudadana'){
        this.route.navigate(['/participacion-ciudadana']);
      } else {
        this.route.navigate(['/votaciones']);
      }
    } else {
     this.mostrar_mensaje_error();
    }
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
