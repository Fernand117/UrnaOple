import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import Swal from 'sweetalert2';
import { KeyboardComponent } from '../keyboard/keyboard.component';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  constructor(private service: ConfiguracionApiService) { }

  //VARIABLES
  @Input() partidos: any;
  @Input() name: any;
  @Output() miEvento = new EventEmitter<boolean>();
  @ViewChild(KeyboardComponent)
  hijo: KeyboardComponent = new KeyboardComponent;
  candidatoSeleccionado: any = "";
  voto: boolean = false;

  ngOnInit(): void { 
    console.log(this.voto, this.name);
    
  }

  openModalRegistrado(c: any) {
    this.candidatoSeleccionado = c;
  }

  votar_registrado() {
    if (!this.voto) {
      const request = {
        "Id": 0,
        "Partido": this.candidatoSeleccionado.Hipocoristico.toString(),
        "Voto": "1"
      }
      this.voto = true;
      this.miEvento.emit(this.voto);
      this.msjSuccess();
      // this.service.setVoto(request).subscribe((resp) => {
      //   this.voto = true;
      //   this.miEvento.emit(this.voto);
      //   this.msjSuccess();
      // }, error => {
      //   this.mostrar_msjError();
      // });
    } else {
      this.mostrar_msjError();
    }
  }

  votar_noRegistrado() {
    if (!this.voto) {
      const request = {
        "Id": 0,
        "Partido": this.hijo.value,
        "Voto": "1"
      }

      this.service.setVoto(request).subscribe((resp) => {
        this.voto = true;
        this.miEvento.emit(this.voto);
        this.msjSuccess();
        this.hijo.value = "";
      }, error => {
        console.log(error);
        this.mostrar_msjError();
      });
    } else {
      this.mostrar_msjError();
    }
  }

  anularVoto() {
    if (!this.voto) {
      const request = {
        "Id": 0,
        "Partido": "Voto nulo",
        "Voto": "1"
      }

      this.service.setVoto(request).subscribe((resp) => {
        this.voto = true;
        this.miEvento.emit(this.voto);
        this.msjSuccess();
        this.hijo.value = "";
      }, error => {
        console.log(error);
        this.mostrar_msjError();
      });
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
