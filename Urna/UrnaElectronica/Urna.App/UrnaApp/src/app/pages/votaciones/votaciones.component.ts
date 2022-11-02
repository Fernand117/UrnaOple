import { Component, OnInit, DoCheck } from '@angular/core';
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

  voto1: boolean = false;
  voto2: boolean = false;
  voto3: boolean = false;
  disabled = {1:true, 2:true, 3:true}

  active_tab: string = "gubernatura";

  classTab = 'nav-link active'

  constructor(private route: Router) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  ngDoCheck() {
    if (this.config_ayuntamiento && this.config_diputacion && this.config_gubernatura) {
      if (this.voto1 === true) {
        this.cambiar2();
        this.disabled = {1:true, 2:false, 3:true}
      }
      if (this.voto2 === true) {
        this.cambiar3();
        this.disabled = {1:true, 2:true, 3:false}
      }
      if (this.voto1 === true && this.voto2 === true && this.voto3 === true) {
        this.salir();
      }
    } else if (this.config_ayuntamiento && this.config_diputacion) {
      this.disabled = {1:true, 2:false, 3:true}
      this.active_tab = 'diputaciones';
      if (this.voto2 === true) {
        this.cambiar3();
        this.disabled = {1:true, 2:true, 3:false}
      }
      if (this.voto3 === true) {
        this.salir();
      }
    } else if (this.config_ayuntamiento && this.config_gubernatura) {
      if (this.voto1 === true) {
        this.cambiar3();
        this.disabled = {1:true, 2:true, 3:false}
      }
      if (this.voto3 === true) {
        this.salir();
      }
    } else if (this.config_diputacion && this.config_gubernatura) {
      if (this.voto1 === true) {
        this.cambiar2();
        this.disabled = {1:true, 2:false, 3:true}
      }
      if (this.voto2 === true) {
        this.salir();
      }
    } else if (this.config_ayuntamiento || this.config_diputacion || this.config_gubernatura) {
      if (this.config_ayuntamiento) {
        this.active_tab = 'ayuntamiento';
      } else if (this.config_diputacion){
        this.active_tab = 'diputaciones';
      } else {
        this.active_tab = 'gubernatura';
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
    this.active_tab = "diputaciones";
  }
  cambiar3() {
    this.active_tab = "ayuntamiento";
  }

  obtenerConfiguracion() {
    this.config_gubernatura = localStorage.getItem('gubernatura');
    this.config_gubernatura = JSON.parse(this.config_gubernatura);
    this.config_ayuntamiento = localStorage.getItem('ayuntamiento');
    this.config_ayuntamiento = JSON.parse(this.config_ayuntamiento);
    this.config_diputacion = localStorage.getItem('diputacion');
    this.config_diputacion = JSON.parse(this.config_diputacion);
  }

  statusVotoGub(e: any) {
    this.voto1 = e;
  }

  statusVotoDip(e: any) {
    this.voto2 = e;
  }

  statusVotoAyu(e: any) {
    this.voto3 = e;
  }

}
