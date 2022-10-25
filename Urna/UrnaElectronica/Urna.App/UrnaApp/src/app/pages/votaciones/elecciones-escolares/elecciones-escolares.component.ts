import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-elecciones-escolares',
  templateUrl: './elecciones-escolares.component.html',
  styleUrls: ['./elecciones-escolares.component.scss']
})
export class EleccionesEscolaresComponent implements OnInit {

  configuracion: any;
  app_name: string = "escolares";

  constructor() { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }
    
  obtenerConfiguracion() {
    this.configuracion =localStorage.getItem('escolares');
    this.configuracion = JSON.parse(this.configuracion);   
    console.log(this.configuracion);
    
  }  
}
