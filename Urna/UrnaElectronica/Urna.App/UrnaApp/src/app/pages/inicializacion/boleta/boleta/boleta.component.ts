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

  constructor(private route:Router) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  obtenerConfiguracion() {
    this.configuracion =localStorage.getItem('config');
    this.configuracion = JSON.parse(this.configuracion);
  }

  continuar() {
    this.route.navigate(['/votaciones']);
  }
}
