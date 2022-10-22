import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gracias',
  templateUrl: './gracias.component.html',
  styleUrls: ['./gracias.component.scss']
})
export class GraciasComponent implements OnInit {

  configuracion: any;
  date: Date = new Date();

  constructor(private route:Router) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
    setTimeout(()=>{    
      this.route.navigate(['/en-espera']);
    }, 5000);
  }

  obtenerConfiguracion() {
    this.configuracion =localStorage.getItem('config');
    this.configuracion = JSON.parse(this.configuracion);
  }

}
