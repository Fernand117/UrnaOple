import { Component, OnInit, DoCheck} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-votaciones',
  templateUrl: './votaciones.component.html',
  styleUrls: ['./votaciones.component.scss']
})
export class VotacionesComponent implements OnInit, DoCheck {

  codigo_configuracion: any;
  config_gubernatura: any;
  config_ayuntamiento: any;
  config_diputacion: any;

  votos = {};

  voto1 : boolean = false;
  voto2 : boolean = false;
  voto3 : boolean = false;

  constructor(private route:Router) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  ngDoCheck() {
    if(this.voto1 == true && this.voto2 == true && this.voto3 == true) {
      setTimeout(()=>{    
        this.route.navigate(['/gracias']);
      }, 1000);
    }
  } 

  obtenerConfiguracion() {
    this.config_gubernatura =localStorage.getItem('gubernatura');
    this.config_gubernatura = JSON.parse(this.config_gubernatura);

    this.config_ayuntamiento =localStorage.getItem('ayuntamiento');
    this.config_ayuntamiento = JSON.parse(this.config_ayuntamiento);

    this.config_diputacion =localStorage.getItem('diputacion');
    this.config_diputacion = JSON.parse(this.config_diputacion);
  }  
  
  statusVotoGub(e: any) {
    this.voto1 = e;
    this.votos = {...this.votos, "gubernatura": e}    
  }

  statusVotoDip(e: any) {
    this.voto2 = e;
    this.votos = {...this.votos, "diputacion": e}
  }

  statusVotoAyu(e: any) {
    this.voto3 = e;
    this.votos = {...this.votos, "ayuntamiento": e}
  }
  
}
