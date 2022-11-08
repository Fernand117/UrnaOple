import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-espera-elector',
  templateUrl: './espera-elector.component.html',
  styleUrls: ['./espera-elector.component.scss']
})
export class EsperaElectorComponent implements OnInit {

  categoria = localStorage.getItem('categoria');
  code = "";
  tarjeta_1 = '0002341465';
  tarjeta_2 = '0002341466';
  tarjeta_3 = '0002341467';
  constructor(private route: Router) { }

  ngOnInit(): void { }

  validar() {
    if(this.code == this.tarjeta_1 || this.code == this.tarjeta_2 || this.code == this.tarjeta_3) {
      this.siguiente_elector();
    } else {
     this.mostrar_mensaje_error();
    }
  }

  mostrar_mensaje_error() {
    Swal.fire({
      icon: 'error',
      title: 'Tarjeta no autorizada',
      text: 'Por favor inténtelo de nuevo'
    });
    this.code = "";
  }

  siguiente_elector() {
    switch (this.categoria) {
      case 'Elecciones escolares':
        this.route.navigate(['/elecciones-escolares']);
        break;
      case 'Mecanismos de participación ciudadana':
        this.route.navigate(['/participacion-ciudadana']);
        break;
      default:
        this.route.navigate(['/votaciones']);
        break;
    }
  }
}
