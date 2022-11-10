import { Component, OnInit, DoCheck} from '@angular/core';
import { Router } from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-participacion-ciudadana',
  templateUrl: './participacion-ciudadana.component.html',
  styleUrls: ['./participacion-ciudadana.component.scss']
})
export class ParticipacionCiudadanaComponent implements OnInit, DoCheck{

  //VARIABLES DONDE SE ALMACENAN LAS CONFIGURACIONES PARA CADA TIPO DE ELECCIÓN
  confi_referendum: any;
  confi_presbicito: any;
  confi_consulta: any;

  //VARIABLES DONDE SE ALMACENAN LA CANTIDAD DE BOLETAS DISPONIBLES PARA CADA TIPO DE ELECCIÓN
  boletas_referendum: any;
  boletas_plesbicito: any;
  boletas_consulta: any;

  //VARIABLES DONDE SE ALMACENA EL ESTADO DEL VOTO POR CADA TIPO DE ELECCIÓN 
  voto1 : boolean = false; // voto referendum
  voto2 : boolean = false; // voto plesbicito
  voto3 : boolean = false; // voto consulta popular

  //PROPIEDAD QUE CARGARA EL COMPONENTE REFERENDUM DENTRO DEL ARCHIVO HTML PARA RECIBIR UN NOMBRE ÚNICO.
  app_name: any;

  //VARIABLE PARA MANEJAR LAS TABS QUE ESTARAN DESHABILITADAS Y HABILITADAS DENTRO DEL MENU
  disabled = {1:true, 2:true, 3:true}
  active_tab : string = "referendum";

  constructor(private route: Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
    this.num_boletas();
   }

  // *********************** METODO PARA DETECTAR CAMBIOS DENTRO DE LA PÁGINA DE VOTACIONES ***********************
  ngDoCheck() {
    //CASO: EXISTEN LOS TRES TIPOS DE ELECCIONES
    if (this.confi_referendum && this.confi_presbicito && this.confi_consulta) {
      this.cambioDeTres();
      if(this.boletas_referendum == 0) {
        this.voto1 = true; this.cambioDeTres();
      }
      if (this.boletas_plesbicito ==  0) {
        this.Ref_Con();
      } else if (this.boletas_consulta == 0) {
        this.Ref_Ples();
      } 
      if (this.boletas_referendum == 0 && this.boletas_plesbicito == 0 && this.boletas_consulta == 0){
        this.route.navigate(['/no-boletas']);
      }
    }
    
    //CASO: SOLO HAY CONFIGURACIONES PARA REFERENDUM Y PLESBICITO
    else if (this.confi_referendum && this.confi_presbicito) {
      this.Ref_Ples();
      if(this.boletas_referendum == 0) {
        this.Ref_Ples(); this.voto1 = true;
      } else if (this.boletas_plesbicito == 0 ) {
        this.active_tab = 'referendum';
        if (this.voto1 === true) {
          this.salir();
        }
      }
      if (this.boletas_referendum == 0 && this.boletas_plesbicito == 0) {
        this.route.navigate(['/no-boletas']);
      }
    }
    
    //CASO: SOLO HAY CONFIGURACIONES PARA REFERENDUM Y CONSULTA POPULAR
    else if (this.confi_referendum && this.confi_consulta) {
     this.Ref_Con();
      if(this.boletas_referendum == 0) {
        this.Ref_Con(); this.voto1 = true;
        this.voto2 = true;
      } else if (this.boletas_consulta  == 0) {
        this.active_tab = 'referendum';
        if (this.voto1 === true) {
          this.salir();
        }
      }
      if (this.boletas_referendum == 0 && this.boletas_consulta == 0) {
        this.route.navigate(['/no-boletas']);
      }
    }
    
    //CASO: SOLO HAY CONFIGURACIONES PARA PRESBICITO Y CONSULTA POPULAR
    else if (this.confi_presbicito && this.confi_consulta) {
     this.Ples_Con();
     if (this.boletas_plesbicito == 0) {
      this.voto2 = true; this.Ples_Con();
    } else if (this.boletas_consulta == 0) {
      this.active_tab = 'presbicito';
      if (this.voto2 === true) {
        this.salir();
      }
    } 
    if (this.boletas_plesbicito == 0 && this.boletas_consulta == 0) {
      this.route.navigate(['/no-boletas']);
    }
    }
    
    else if (this.confi_referendum || this.confi_presbicito || this.confi_consulta) {
      if (this.confi_referendum) {
        this.active_tab = 'referendum';
      } else if (this.confi_presbicito) {
        this.active_tab = 'presbicito';
      } else {
        this.active_tab = 'consulta';
      }
      if (this.voto1 === true || this.voto2 === true || this.voto3 === true) {
        this.salir();
      }
      if (this.boletas_referendum == 0 || this.boletas_plesbicito == 0 || this.boletas_consulta == 0) {
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

  //NAVEGAR ENTRE REFERENDUM Y PLESBICITO
  Ref_Ples() {
    if (this.voto1 === true) {
      this.cambiar2();
      this.disabled = {1:true, 2:false, 3:true}
    }
    if (this.voto2 === true) {
      this.salir();
    }
  }

  //NAVEGAR ENTRE REFERENDUM Y CONSULTA
  Ref_Con() {
    if (this.voto1 === true) {
      this.cambiar3();
      this.disabled = {1:true, 2:true, 3:false}
    }
    if (this.voto3 === true) {
      this.salir();
    }
  }

  //NAVEGAR ENTRE PLESBICITO Y CONSULTA
  Ples_Con() {
    this.disabled = {1:true, 2:false, 3:true}
      this.active_tab = 'presbicito';
      if (this.voto2 === true) {
        this.cambiar3();
        this.disabled = {1:true, 2:true, 3:false}
      }
      if (this.voto3 === true) {
        this.salir();
      }
  }

 //TERMINAR LA VOTACIÓN Y ESPERARA AL SIGUIENTE ELECTOR 
  salir() {
    this.route.navigate(['/gracias'])
  }

  //ACTIVAR TAB DE PRESBICITO
  cambiar2() {
    this.active_tab = "presbicito";
  }

  //ACTIVAR TAB DE CONSULTA POPULAR
  cambiar3() {
    this.active_tab = "consulta";
  }

  //OBTENER LAS CONFIGURACIONES
  obtenerConfiguracion() {
    this.confi_referendum = localStorage.getItem('referendum');
    this.confi_referendum = JSON.parse(this.confi_referendum);
    this.confi_presbicito = localStorage.getItem('presbicito');
    this.confi_presbicito = JSON.parse(this.confi_presbicito);
    this.confi_consulta = localStorage.getItem('consulta');
    this.confi_consulta = JSON.parse(this.confi_consulta);
  }
  
    //OBTENER EL NUMERO DE BOLETAS DISPONIBLES
    num_boletas() {
      this.service.getContadorBoletas().subscribe((resp) => {
        let info: any = resp;
        info = info.data;
        for (let i = 0; i < info.length; i++) {
          if (info[i].tipoEleccion === this.confi_referendum.TipoMecanismo) {
            this.boletas_referendum = info[i].cantidadBoletas;     
            console.log(this.boletas_referendum);
          } else if (info[i].tipoEleccion === this.confi_presbicito.TipoMecanismo) {
            this.boletas_plesbicito = info[i].cantidadBoletas;
            console.log(this.boletas_plesbicito);
          } else if (info[i].tipoEleccion === this.confi_consulta.TipoMecanismo) {
            this.boletas_consulta = info[i].cantidadBoletas;
            console.log(this.boletas_consulta);
          }
        }
      });      
    }

  //OBTENER EL ESTADO DEL VOTO 1
  statusVotoReferendum(e: any) {
    this.voto1 = e;    
  }
  
  //OBTENER EL ESTADO DEL VOTO 2
  statusVotoPresbicito(e: any) {
    this.voto2 = e;    
  }

  //OBTENER EL ESTADO DEL VOTO 3
  statusVotoConsulta(e: any) {
    this.voto3 = e;    
  }

}
