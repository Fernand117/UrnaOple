import { Component, OnInit } from '@angular/core';
import {Router } from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

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
  votosgub: any;
  votosayu: any;
  votosdip: any;

  votosref: any;
  votosples: any;
  votoscons: any;

  votosesc: any;

  constructor(private route:Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {  
    this.obtenerConfiguracion();
    this.votosAyu();
    this.votosDip();
    this.votosGub();
    this.votosPlesbicito();
    this.votosConsulta();
    this.votosReferendum();
    this.resultadosEsc();
  }

  votosGub() {
    this.service.getVotosGubernatura().subscribe(resp => {
      this.votosgub = resp;
      this.votosgub = this.votosgub.data;
    });
  }

  votosDip() {
    this.service.getVotosDiputacion().subscribe(resp => {
      this.votosdip = resp;
      this.votosdip = this.votosdip.data;
    });
  }

  votosAyu() {
    this.service.getVotosAyuntamiento().subscribe(resp => {
      this.votosayu = resp;
      
      this.votosayu = this.votosayu.data;
    });
  }

  votosPlesbicito() {
    this.service.getVotosByTipo("presbicito").subscribe(resp => {
      this.votosples = resp;      
      this.votosples = this.votosples.data;
    });
  }

  votosConsulta() {
    this.service.getVotosByTipo("consulta").subscribe(resp => {
      this.votoscons = resp;
      this.votoscons = this.votoscons.data;
    });
  }

  votosReferendum() {
    this.service.getVotosByTipo("referendum").subscribe(resp => {
      this.votosref = resp;
      this.votosref = this.votosref.data;
    });
  }

  resultadosEsc() {
    this.service.getVotosByTipo('escolar').subscribe(resp => {
      this.votosesc = resp;
      this.votosesc = this.votosesc.data;
    })
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
