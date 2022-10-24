import { Component, OnInit} from '@angular/core';
import {Router } from '@angular/router';

@Component({
  selector: 'app-boleta',
  templateUrl: './boleta.component.html',
  styleUrls: ['./boleta.component.scss']
})

export class BoletaComponent implements OnInit {

  configuracion: any;
  date: Date = new Date();
  config_gubernatura: any;
  config_ayuntamiento: any;
  config_diputacion: any;

  constructor(private route:Router) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  obtenerConfiguracion() {
    this.config_gubernatura =localStorage.getItem('gubernatura');
    this.config_gubernatura = JSON.parse(this.config_gubernatura);    

    this.config_ayuntamiento =localStorage.getItem('ayuntamiento');
    this.config_ayuntamiento = JSON.parse(this.config_ayuntamiento);

    this.config_diputacion =localStorage.getItem('diputacion');
    this.config_diputacion = JSON.parse(this.config_diputacion);
  }  

  continuar() {
    this.route.navigate(['/votaciones']);
  }
}
