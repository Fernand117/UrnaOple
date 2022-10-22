import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-espera-elector',
  templateUrl: './espera-elector.component.html',
  styleUrls: ['./espera-elector.component.scss']
})
export class EsperaElectorComponent implements OnInit {

  configuracion: any;
  date: Date = new Date();

  constructor(private route:Router) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  obtenerConfiguracion() {
    this.configuracion =localStorage.getItem('config');
    this.configuracion = JSON.parse(this.configuracion);
  }

  siguiente_elector() {
    this.route.navigate(['/votaciones']);
  }

}
