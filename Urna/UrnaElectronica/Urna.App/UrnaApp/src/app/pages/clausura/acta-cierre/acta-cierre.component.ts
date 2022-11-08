import { Component, OnInit } from '@angular/core';
import {Router } from '@angular/router';

@Component({
  selector: 'app-acta-cierre',
  templateUrl: './acta-cierre.component.html',
  styleUrls: ['./acta-cierre.component.scss']
})
export class ActaCierreComponent implements OnInit {

  config_gubernatura?: any;
  config_ayuntamiento?: any;
  config_diputacion?: any;
  config_escolares?: any;
  config_referendum?: any;
  config_plebiscito?: any;
  config_consulta?: any;

  constructor(private route:Router) { }

  ngOnInit(): void {  
    this.obtenerConfiguracion();
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

  imprimirBoleta(configuracion: any) { }

  finalizar() {
    this.route.navigate(['/bienvenido']);
  }

}
