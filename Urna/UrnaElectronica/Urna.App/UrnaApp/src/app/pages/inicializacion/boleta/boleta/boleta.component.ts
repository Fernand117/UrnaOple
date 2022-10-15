import { Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-boleta',
  templateUrl: './boleta.component.html',
  styleUrls: ['./boleta.component.scss']
})

export class BoletaComponent implements OnInit {

  codigo_configuracion: any;
  configuracion: any;

  constructor(private route:Router, private rutaActiva: ActivatedRoute, private service: ConfiguracionApiService) {
    this.codigo_configuracion = this.rutaActiva.snapshot.paramMap.get('code');
   }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  obtenerConfiguracion() {
    this.service.getConfiguracion(this.codigo_configuracion).subscribe((resp) => {
      this.configuracion = resp;
      this.configuracion = this.configuracion.data.configuraciones;
      this.configuracion = JSON.parse(this.configuracion);    
    });
  }

  continuar() {
    this.route.navigate([`/${this.codigo_configuracion}/votaciones`]);
  }

}
