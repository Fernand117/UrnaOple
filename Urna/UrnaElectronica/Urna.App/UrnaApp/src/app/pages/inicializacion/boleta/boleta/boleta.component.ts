import { Component, OnInit} from '@angular/core';
import {Router } from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-boleta',
  templateUrl: './boleta.component.html',
  styleUrls: ['./boleta.component.scss']
})

export class BoletaComponent implements OnInit {

  config_gubernatura?: any;
  config_ayuntamiento?: any;
  config_diputacion?: any;
  config_escolares?: any;
  config_referendum?: any;
  config_plebiscito?: any;
  config_consulta?: any;

  constructor(private route:Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  imprimirBoleta(configuracion: any) {
    this.service.imprimirBoleta(configuracion).subscribe(resp => {
      console.log(resp);
    });
  }

  obtenerConfiguracion() {
    //CONFIGURACIONES PARA ELECCIONALES LOCALES
    this.config_gubernatura =localStorage.getItem('gubernatura');
    this.config_gubernatura = JSON.parse(this.config_gubernatura);    
    this.config_ayuntamiento =localStorage.getItem('ayuntamiento');
    this.config_ayuntamiento = JSON.parse(this.config_ayuntamiento);
    this.config_diputacion =localStorage.getItem('diputacion');
    this.config_diputacion = JSON.parse(this.config_diputacion);

    //CONFIGURACIÓN ELECCIONES ESCOLARES
    this.config_escolares =localStorage.getItem('escolares');
    this.config_escolares = JSON.parse(this.config_escolares);

    //CONFIGURACIONES MECANISMOS DE PARTICIPACIÓN CIUDADANA

    this.config_referendum =localStorage.getItem('referendum');
    this.config_referendum = JSON.parse(this.config_referendum);
    this.config_plebiscito =localStorage.getItem('presbicito');
    this.config_plebiscito = JSON.parse(this.config_plebiscito);
    this.config_consulta =localStorage.getItem('consulta');
    this.config_consulta = JSON.parse(this.config_consulta);
  }  

  continuar() {
    let categoria = localStorage.getItem('categoria');
    if (categoria === 'Elecciones escolares') {
      this.route.navigate(['/elecciones-escolares']);
    } else if (categoria === 'Mecanismos de participación ciudadana'){
      this.route.navigate(['/participacion-ciudadana']);
    } else {
      this.route.navigate(['/votaciones']);
    }
  }
}
