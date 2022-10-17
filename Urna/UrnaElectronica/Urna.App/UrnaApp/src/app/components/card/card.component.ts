import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { KeyboardComponent } from '../keyboard/keyboard.component';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  constructor() { }

  @Input() partidos: any;
  candidatoSeleccionado: any = "";
  @ViewChild(KeyboardComponent)
  hijo: KeyboardComponent = new KeyboardComponent;

  ngOnInit(): void { }

  openModalRegistrado(c: any) {
    this.candidatoSeleccionado = c;
  }

  votar() {
    console.log("voto por: ", this.hijo.value);
    this.hijo.value = "";
  }
}
