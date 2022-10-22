import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-votaciones',
  templateUrl: './votaciones.component.html',
  styleUrls: ['./votaciones.component.scss']
})
export class VotacionesComponent implements OnInit {

  codigo_configuracion: any;
  configuracion: any;

  constructor() { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  obtenerConfiguracion() {
    this.configuracion =localStorage.getItem('config');
    this.configuracion = JSON.parse(this.configuracion);
  }  
}
