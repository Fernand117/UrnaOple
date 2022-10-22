import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { KeyboardComponent } from '../keyboard/keyboard.component';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  constructor(private route:Router) { }

  @Input() partidos: any;
  @Input() name: any;

  candidatoSeleccionado: any = "";
  @ViewChild(KeyboardComponent)
  hijo: KeyboardComponent = new KeyboardComponent;
  voto: boolean = false;

  ngOnInit(): void { }

  openModalRegistrado(c: any) {
    this.candidatoSeleccionado = c;
  }

  votar_registrado() {
    if (!this.voto) {
      // SERVICIO
      this.voto = true;
    } else {
      this.mostrar_msjError();
      this.route.navigate(['/en-espera']);
    }
  }

  votar_noRegistrado() {
    if (!this.voto) {
      // SERVICIO
      this.voto = true;
    } else {
      this.mostrar_msjError();
    }
    // console.log("voto por: ", this.hijo.value);
    // this.hijo.value = "";
  }

  anularVoto() {
    if (!this.voto) {
      // SERVICIO
      this.voto = true;
    } else {
      this.mostrar_msjError();
    }
  }


  mostrar_msjError() {
    Swal.fire({
      icon: 'error',
      title: 'Lo sentimos',
      text: 'Ya has realizado tu voto para este tipo de elección.'
    });
  }
}
