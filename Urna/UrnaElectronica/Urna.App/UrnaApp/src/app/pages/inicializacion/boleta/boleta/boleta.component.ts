import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  configuracion_general: any;

  constructor(private route: Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
    this.registrarCandidatosGub();
    this.registrarCandidatosDip();
    this.registrarCandidatosAyu();
    this.registrarCandidatosEscolares();
  }

  imprimirBoleta(configuracion: any) {
    configuracion.Presidente = this.configuracion_general.Presidente;
    configuracion.Secretario = this.configuracion_general.Secretario;
    configuracion.PrimerEscrutador = this.configuracion_general.PrimerEscrutador;
    configuracion.SegundoEscrutador = this.configuracion_general.SegundoEscrutador;
    configuracion.Distrito = this.configuracion_general.Distrito;
    configuracion.Entidad = this.configuracion_general.Entidad;
    configuracion.Municipio = this.configuracion_general.Municipio;
    configuracion.TipoCasilla = this.configuracion_general.TipoCasilla;
    configuracion.SeccionElectoral = this.configuracion_general.SeccionElectoral;
    this.service.imprimirBoleta(configuracion).subscribe(resp => {
    }, (error) => {
    });
  }

  imprimirBoletaEscolares(configuracion: any) {
    let datos = this.configuracion_general;
    configuracion.Presidente = datos.Presidente;
    configuracion.Secretario = datos.Secretario;
    configuracion.PrimerEscrutador = datos.PrimerEscrutador;
    configuracion.SegundoEscrutador = datos.SegundoEscrutador;
    this.service.imprimirBoletaEscolares(configuracion[0]).subscribe(resp => {
    }, (error) => {
    });
  }

  imprimirBoletaMecanismos(configuracion: any) {
    let nuevo = configuracion;
    nuevo.Presidente = this.configuracion_general.Presidente;
    nuevo.Secretario = this.configuracion_general.Secretario;
    nuevo.PrimerEscrutador = this.configuracion_general.PrimerEscrutador;
    nuevo.SegundoEscrutador = this.configuracion_general.SegundoEscrutador;
    nuevo.Distrito = this.configuracion_general.Distrito;
    nuevo.Entidad = this.configuracion_general.Entidad;
    nuevo.Municipio = this.configuracion_general.Municipio;
    nuevo.SeccionElectoral = this.configuracion_general.SeccionElectoral;
    nuevo.Preguntas.map((p: any) => {
      p[`partido`] = p.Pregunta;
    });

    this.service.imprimirBoletaMecanismos(nuevo).subscribe(resp => {
    }, (error) => {
    });
  }

  obtenerConfiguracion() {
    let requestNulo = {
      "Hipocoristico": "Voto nulo",
      "Voto": "0",
      "Tipo": "Voto nulo"
    }
    let requestNoRegistrado = {
        "Hipocoristico": "No registrado",
        "Voto": "0",
        "Tipo": "No registrado"
    }
    this.configuracion_general = localStorage.getItem('configeneral');
    this.configuracion_general = JSON.parse(this.configuracion_general);
    //CONFIGURACIONES PARA ELECCIONALES LOCALES
    this.config_gubernatura = localStorage.getItem('gubernatura');
    this.config_gubernatura = JSON.parse(this.config_gubernatura);
    this.config_gubernatura.Partidos.push(requestNulo);
    this.config_gubernatura.Partidos.push(requestNoRegistrado);
    console.log(this.config_gubernatura);
    

    this.config_ayuntamiento = localStorage.getItem('ayuntamiento');
    this.config_ayuntamiento = JSON.parse(this.config_ayuntamiento);
    this.config_ayuntamiento.Partidos.push(requestNulo);
    this.config_ayuntamiento.Partidos.push(requestNoRegistrado);

    this.config_diputacion = localStorage.getItem('diputacion');
    this.config_diputacion = JSON.parse(this.config_diputacion);
    this.config_diputacion.Partidos.push(requestNulo);
    this.config_diputacion.Partidos.push(requestNoRegistrado);


    //CONFIGURACIÓN ELECCIONES ESCOLARES
    this.config_escolares = localStorage.getItem('escolares');
    this.config_escolares = JSON.parse(this.config_escolares);

    //CONFIGURACIONES MECANISMOS DE PARTICIPACIÓN CIUDADANA

    this.config_referendum = localStorage.getItem('referendum');
    this.config_referendum = JSON.parse(this.config_referendum);
    this.config_plebiscito = localStorage.getItem('presbicito');
    this.config_plebiscito = JSON.parse(this.config_plebiscito);
    this.config_consulta = localStorage.getItem('consulta');
    this.config_consulta = JSON.parse(this.config_consulta);
  }

  registrarCandidatosEscolares() {
    if (this.config_escolares) {
      for (let i = 0; i < this.config_escolares[0].Partidos.length; i++) {
        let request = {
          "Partido": this.config_escolares[0].Partidos[i].Hipocoristico,
          "Voto": "0"
        }
        this.service.setVoto(request, "escolar/guardar").subscribe((resp) => {
        });
      }
    }
  }

  registrarCandidatosGub() {
    if (this.config_gubernatura) {
      for (let i = 0; i < this.config_gubernatura.Partidos.length; i++) {
        let request = {
          "Partido": this.config_gubernatura.Partidos[i].Hipocoristico,
          "Voto": "0",
          "Tipo": this.config_gubernatura.Partidos[i].Tipo
        }
        this.service.setVoto(request, "gubernatura/guardar").subscribe((resp) => {
        });
      }
    }
  }

  registrarCandidatosDip() {
    if (this.config_diputacion) {
      for (let i = 0; i < this.config_diputacion.Partidos.length; i++) {
        let request = {
          "Partido": this.config_diputacion.Partidos[i].Hipocoristico,
          "Voto": "0",
          "Tipo": this.config_diputacion.Partidos[i].Tipo
        }
        this.service.setVoto(request, "diputacion/guardar").subscribe((resp) => {
        });
      }
    }
  }

  registrarCandidatosAyu() {
    if (this.config_ayuntamiento) {
      for (let i = 0; i < this.config_ayuntamiento.Partidos.length; i++) {
        let request = {
          "Partido": this.config_ayuntamiento.Partidos[i].Hipocoristico,
          "Voto": "0",
          "Tipo": this.config_ayuntamiento.Partidos[i].Tipo
        }
        this.service.setVoto(request, "ayuntamiento/guardar").subscribe((resp) => {
        });
      }
    }
  }

  continuar() {
    this.route.navigate(['/autorizar'])
  }
}
