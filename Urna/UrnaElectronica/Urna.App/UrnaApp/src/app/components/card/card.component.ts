import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import Swal from 'sweetalert2';
import { KeyboardComponent } from '../keyboard/keyboard.component';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';
import { Router } from '@angular/router';
import { BrowserDynamicTestingModule } from '@angular/platform-browser-dynamic/testing';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  constructor(private service: ConfiguracionApiService, private route: Router) { }

  //VARIABLES
  @Input() partidos: any;
  @Input() name: string = "";
  @Output() miEvento = new EventEmitter<boolean>();
  @ViewChild(KeyboardComponent)
  keyboard: KeyboardComponent = new KeyboardComponent;
  candidatoSeleccionado: any = "";
  voto: boolean = false;


  ngOnInit(): void { }

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
      this.service.setVoto(request, this.name).subscribe((resp) => {      
          
        const mywindow = document.getElementById("prueba")?.innerHTML;
        var contenidoOriginak = document.body.innerHTML;
        window.print();
        document.body.innerHTML = contenidoOriginak;


        this.voto = true;
        this.miEvento.emit(this.voto);
        this.msjSuccess();
      }, error => {
        // this.mostrar_msjError();
      });
    } else {
      this.mostrar_msjError();
    }
  }

  votar_noRegistrado() {
    if (!this.voto) {
      const request = {
        "Id": 0,
        "Partido": this.keyboard.value,
        "Voto": "1"
      }

      this.service.setVoto(request, this.name).subscribe((resp) => {
        this.voto = true;
        this.miEvento.emit(this.voto);
        this.msjSuccess();
        this.keyboard.value = "";
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

      this.service.setVoto(request, this.name).subscribe((resp) => {
        this.voto = true;
        this.miEvento.emit(this.voto);
        this.msjSuccess();
        this.keyboard.value = "";
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
    let x = this.name;
    let ruta = this.route;
    Swal.fire(
      '¡Tu voto ha sido registrado con éxito!',
      'Te direccionaremos a la siguiente categoría de votaciones para que puedas seguir efectuando tus votos.',
      'success'
    ).then(function () {
      if (x === 'escolar') {
        ruta.navigate(['/gracias']);
      }
    }
    );
  }
}
