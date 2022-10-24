import { Component, OnInit, Input, ViewChild, Output, EventEmitter} from '@angular/core';
import Swal from 'sweetalert2';
import { KeyboardComponent } from '../keyboard/keyboard.component';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  constructor() { }

  @Input() partidos: any;
  @Input() name: any;
  @Output() miEvento = new EventEmitter<boolean>();

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
      this.miEvento.emit(this.voto);
      this.msjSuccess();
    } else {
      this.mostrar_msjError();
    }
  }

  votar_noRegistrado() {
    if (!this.voto) {
      // SERVICIO
      this.voto = true;
      this.miEvento.emit(this.voto);
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
      this.miEvento.emit(this.voto);
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

  msjSuccess() {
    Swal.fire(
      '¡Tu voto ha sido registrado con éxito!',
      'Te direccionaremos a la siguiente categoría de votaciones para que puedas seguir efectuando tus votos.',
      'success'
    );
  }
}
