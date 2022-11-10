import { Component, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-votaciones',
  templateUrl: './votaciones.component.html',
  styleUrls: ['./votaciones.component.scss']
})
export class VotacionesComponent implements OnInit, DoCheck {

  //VARIABLES DONDE SE ALMACENAN LAS CONFIGURACIONES PARA CADA TIPO DE ELECCIÓN
  config_gubernatura: any;
  config_ayuntamiento: any;
  config_diputacion: any;

  //VARIABLES DONDE SE ALMACENAN LA CANTIDAD DE BOLETAS DISPONIBLES PARA CADA TIPO DE ELECCIÓN
  boletas_gubernatura: any;
  boletas_diputacion: any;
  boletas_ayuntamiento: any;

  //VARIABLES DONDE SE ALMACENA EL ESTADO DEL VOTO POR CADA TIPO DE ELECCIÓN 
  voto1: boolean = false; // voto gubernatura
  voto2: boolean = false; // voto diputacion
  voto3: boolean = false; // voto ayuntamiento

  //VARIABLE PARA MANEJAR LAS TABS QUE ESTARAN DESHABILITADAS Y HABILITADAS DENTRO DEL MENU
  disabled = { 1: true, 2: true, 3: true };
  active_tab: string = "gubernatura"; // Tab habilitada por defecto
  classTab = 'nav-link active'; 

  constructor(private route: Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();    
    this.num_boletas();    
  }

  // *********************** METODO PARA DETECTAR CAMBIOS DENTRO DE LA PÁGINA DE VOTACIONES ***********************
  ngDoCheck() {    
    //CASO: EXISTEN LOS TRES TIPOS DE ELECCIONES
    if (this.config_ayuntamiento && this.config_diputacion && this.config_gubernatura) {
      this.cambioDeTres();
      if(this.boletas_gubernatura == 0) {
        this.voto1 = true; this.cambioDeTres();
      }
      if (this.boletas_diputacion ==  0) {
        this.Gub_Ayu();
      } else if (this.boletas_ayuntamiento == 0) {
        this.Gub_Dip();
      } 
      if (this.boletas_ayuntamiento == 0 && this.boletas_diputacion == 0 && this.boletas_gubernatura == 0){
        this.route.navigate(['/no-boletas']);
      }
    } 

    //CASO: SOLO HAY CONFIGURACIONES PARA GUBERNATURA Y DIPUTACIONES
    else if (this.config_gubernatura && this.config_diputacion) {
      this.Gub_Dip();
      if(this.boletas_gubernatura == 0) {
        this.Gub_Dip(); this.voto1 = true;
      } else if (this.boletas_diputacion == 0 ) {
        this.active_tab = 'gubernatura';
        if (this.voto1 === true) {
          this.salir();
        }
      }
      if (this.boletas_gubernatura == 0 && this.boletas_diputacion == 0) {
        this.route.navigate(['/no-boletas']);
      }
    }

    //CASO: SOLO HAY CONFIGURACIONES PARA GUBERNATURA Y AYUNTAMIENTO
    else if (this.config_gubernatura && this.config_ayuntamiento) {
      this.Gub_Ayu();
      if(this.boletas_gubernatura == 0) {
        this.Gub_Ayu(); this.voto1 = true;
        this.voto2 = true;
      } else if (this.boletas_ayuntamiento  == 0) {
        this.active_tab = 'gubernatura';
        if (this.voto1 === true) {
          this.salir();
        }
      }
      if (this.boletas_gubernatura == 0 && this.boletas_ayuntamiento == 0) {
        this.route.navigate(['/no-boletas']);
      }
    }

    //CASO: SOLO HAY CONFIGURACIONES PARA DIPUTACIÓN Y AYUNTAMIENTO
    else if (this.config_diputacion && this.config_ayuntamiento) {
      this.Dip_Ayu();
      if (this.boletas_diputacion == 0) {
        this.voto2 = true; this.Dip_Ayu();
      } else if (this.boletas_ayuntamiento == 0) {
        this.active_tab = 'diputaciones';
        if (this.voto2 === true) {
          this.salir();
        }
      } 
      if (this.boletas_diputacion == 0 && this.boletas_ayuntamiento == 0) {
        this.route.navigate(['/no-boletas']);
      }
    } 
    
    //CASO: SOLO HAY UN TIPO DE ELECCION
    else if (this.config_ayuntamiento || this.config_diputacion || this.config_gubernatura) {
      if (this.config_ayuntamiento) {
        this.active_tab = 'ayuntamiento';
      } else if (this.config_diputacion) {
        this.active_tab = 'diputaciones';
      } else {
        this.active_tab = 'gubernatura';
      }
      if (this.voto1 === true || this.voto2 === true || this.voto3 === true) {
        this.salir();
      }
      if (this.boletas_ayuntamiento == 0 || this.boletas_diputacion == 0 || this.boletas_gubernatura == 0) {
        this.route.navigate(['/no-boletas']);
      }
    }
  }

  //NAVEGAR ENTRE LAS 3 TABS 
  cambioDeTres() {
    if (this.voto1 === true) {
      this.cambiar2();
      this.disabled = { 1: true, 2: false, 3: true }
    }
    if (this.voto2 === true) {
      this.cambiar3();
      this.disabled = { 1: true, 2: true, 3: false }
    }
    if (this.voto1 === true && this.voto2 === true && this.voto3 === true) {
      this.salir();
    }
  }

  //NAVEGAR ENTRE TAB DE GUBERNATURA Y DIPUTACIÓN
  Gub_Dip() {
    if (this.voto1 === true) {
      this.cambiar2();
      this.disabled = { 1: true, 2: false, 3: true }
    }
    if (this.voto2 === true) {
      this.salir();
    }
  }

  //NAVEGAR ENTRE TAB DE GUBERNATURA Y AYUNTAMIENTO
  Gub_Ayu() {
  if (this.voto1 === true) {
      this.cambiar3();
      this.disabled = { 1: true, 2: true, 3: false }
    }
  if (this.voto3 === true) {
      this.salir();
    }
  }

  //NAVEGAR ENTRE TAB DE DIPUTACIÓN Y AYUNTAMIENTO
  Dip_Ayu() {
    this.disabled = { 1: true, 2: false, 3: true }
    this.active_tab = 'diputaciones';
    if (this.voto2 === true) {
      this.cambiar3();
      this.disabled = { 1: true, 2: true, 3: false }
    }
    if (this.voto3 === true) {
      this.salir();
    }
  }

  //TERMINAR LA VOTACIÓN Y ESPERARA AL SIGUIENTE ELECTOR 
  salir() {
      this.route.navigate(['/gracias']);
  }

  //ACTIVAR TAB DE DIPUTACIONES
  cambiar2() {
    this.active_tab = "diputaciones";
  }

  //ACTIVAR TAB DE AYUNTAMIENTOS
  cambiar3() {
    this.active_tab = "ayuntamiento";
  }

  //OBTENER EL NUMERO DE BOLETAS DISPONIBLES
  num_boletas() {
    this.service.getContadorBoletas().subscribe((resp) => {
      let info: any = resp;
      info = info.data;
      for (let i = 0; i < info.length; i++) {
        if (info[i].tipoEleccion === this.config_gubernatura.TipoEleccion) {
          this.boletas_gubernatura = info[i].cantidadBoletas;          
        } else if (info[i].tipoEleccion === this.config_diputacion.TipoEleccion) {
          this.boletas_diputacion = info[i].cantidadBoletas;
        } else if (info[i].tipoEleccion === this.config_ayuntamiento.TipoEleccion) {
          this.boletas_ayuntamiento = info[i].cantidadBoletas;
        }
      }
    });   
  }

  //OBTENER LAS CONFIGURACIONES
  obtenerConfiguracion() {
    this.config_gubernatura = localStorage.getItem('gubernatura');
    this.config_gubernatura = JSON.parse(this.config_gubernatura);    
    this.config_ayuntamiento = localStorage.getItem('ayuntamiento');
    this.config_ayuntamiento = JSON.parse(this.config_ayuntamiento);    
    this.config_diputacion = localStorage.getItem('diputacion');
    this.config_diputacion = JSON.parse(this.config_diputacion);   
  }

  //OBTENER EL ESTADO DEL VOTO 1
  statusVotoGub(e: any) {
    this.voto1 = e;
  }

  //OBTENER EL ESTADO DEL VOTO 2
  statusVotoDip(e: any) {
    this.voto2 = e;
  }

  //OBTENER EL ESTADO DEL VOTO 3
  statusVotoAyu(e: any) {
    this.voto3 = e;
  }

}