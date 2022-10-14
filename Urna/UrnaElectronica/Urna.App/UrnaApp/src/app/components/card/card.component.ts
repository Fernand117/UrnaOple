import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { KeyboardComponent } from '../keyboard/keyboard.component';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  constructor() { }

  @Input() info: any;
  displayRegistrado = "none";
  displayVotoNulo = "none"
  displayNoRegistrado = "none";
  candidatoSeleccionado: any = "";
  @ViewChild(KeyboardComponent)
  hijo: KeyboardComponent = new KeyboardComponent;

  ngOnInit(): void {
  }

  openModalRegistrado(c: any) {
    this.displayRegistrado = "block"; 
    this.candidatoSeleccionado = c;
  }

  openModalNulo(){
    this.displayVotoNulo = "block";    
  }

  openModalNoRegistrado(){
    this.displayNoRegistrado = "block";   
  }

  closePopup() {
    this.displayRegistrado = "none";
    this.displayVotoNulo = "none";
    this.displayNoRegistrado = "none"
  }


  votar() {
    console.log("voto por: ",this.hijo.value);
    this.closePopup();
  }

}
