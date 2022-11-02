import { Component, OnInit, DoCheck} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-participacion-ciudadana',
  templateUrl: './participacion-ciudadana.component.html',
  styleUrls: ['./participacion-ciudadana.component.scss']
})
export class ParticipacionCiudadanaComponent implements OnInit, DoCheck{

  confi_referendum: any = localStorage.getItem('referendum');
  confi_presbicito: any = localStorage.getItem('presbicito');
  confi_consulta: any = localStorage.getItem('consulta');
  active_tab : string = "referendum";
  voto1 : boolean = false;
  voto2 : boolean = false;
  voto3 : boolean = false;
  app_name: any;
  disabled = {1:true, 2:true, 3:true}

  constructor(private route: Router) { }

  ngOnInit(): void { }

  ngDoCheck() {

    if (this.confi_referendum && this.confi_presbicito && this.confi_consulta) {
      if (this.voto1 === true) {
        this.cambiar2();
      }
      if (this.voto2 === true) {
        this.cambiar3();
      }
      if (this.voto1 === true && this.voto2 === true && this.voto3 === true) {
        this.salir();
      }
    } else if (this.confi_referendum && this.confi_presbicito) {
      if (this.voto1 === true) {
        this.cambiar2();
        this.disabled = {1:true, 2:false, 3:true}
      }
      if (this.voto2 === true) {
        this.salir();
      }
    } else if (this.confi_referendum && this.confi_consulta) {
      if (this.voto1 === true) {
        this.cambiar3();
        this.disabled = {1:true, 2:true, 3:false}
      }
      if (this.voto3 === true) {
        this.salir();
      }
    } else if (this.confi_presbicito && this.confi_consulta) {
      this.disabled = {1:true, 2:false, 3:true}
      this.active_tab = 'presbicito';
      if (this.voto2 === true) {
        this.cambiar3();
        this.disabled = {1:true, 2:true, 3:false}
      }
      if (this.voto3 === true) {
        this.salir();
      }
    } else if (this.confi_referendum || this.confi_presbicito || this.confi_consulta) {
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
    }
  }

  salir() {
    setTimeout(() => {
      this.route.navigate(['/gracias'])
    }, 1500);
  }

  cambiar2() {
    this.active_tab = "presbicito";
  }

  cambiar3() {
    this.active_tab = "consulta";
  }

  statusVotoReferendum(e: any) {
    this.voto1 = e;    
  }

  statusVotoPresbicito(e: any) {
    this.voto2 = e;    
  }

  
  statusVotoConsulta(e: any) {
    this.voto3 = e;    
  }

}
