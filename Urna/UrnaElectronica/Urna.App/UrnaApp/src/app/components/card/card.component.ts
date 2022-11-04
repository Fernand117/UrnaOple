import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import Swal from 'sweetalert2';
import { KeyboardComponent } from '../keyboard/keyboard.component';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';
import { Router } from '@angular/router';

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
  num_boletas: number = 10;

  ngOnInit(): void {
    if (this.num_boletas = 0) {
      this.route.navigate(['/clausura']);
    }
  }

  openModalRegistrado(c: any) {
    this.candidatoSeleccionado = c;
  }

  votar_registrado() {
    if (!this.voto) {
      console.log(this.partidos);
      
      const request = {
        "Partido": this.candidatoSeleccionado.Hipocoristico.toString(),
        "Voto": "1",
        "TipoEleccion": this.partidos.TipoEleccion,
        "Entidad": this.partidos.Entidad,
        "Distrito": this.partidos.Distrito,
        "Municipio": this.partidos.Municipio,
        "Seccion": this.partidos.SeccionElectoral,
        "Casilla": this.partidos.TipoCasilla,
        "Folio": this.partidos.Folio
      }
      this.service.setVoto(request, this.name).subscribe((resp) => {
        this.updateCantidadBoletas();
        this.msjSuccess();
      }, error => {
        this.error();
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
        this.updateCantidadBoletas();
        this.msjSuccess();
        this.keyboard.value = "";
      }, error => {
        this.error();
      });
    } else {
      this.keyboard.value = "";
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
        this.updateCantidadBoletas();
        this.msjSuccess();
        this.keyboard.value = "";
      }, error => {
        this.error();
      });
    } else {
      this.mostrar_msjError();
    }
  }

  updateCantidadBoletas() {
    let TipoEleccion: string = "";
    if (this.name === "gubernatura") {
      TipoEleccion = "Gubernatura"
    } else if (this.name === "diputacion") {
      TipoEleccion = "Diputaciones"
    } else if (this.name === "ayuntamiento") {
      TipoEleccion = "Ayuntamientos"
    }

    let request = {
      TipoEleccion: TipoEleccion
    }
    this.service.updateContadorBoletas(request).subscribe((resp) => {
      console.log(resp);
    }, error => {
      console.log(error);
    });
  }

  mostrar_msjError() {
    Swal.fire({
      icon: 'error',
      title: 'Lo sentimos',
      text: 'Ya has realizado tu voto para este tipo de elección.'
    });
  }

  error() {
    Swal.fire({
      icon: 'error',
      title: 'Lo sentimos',
      text: 'No se ha podido registrar tu voto, intentalo de nuevo'
    });
  }

  msjSuccess() {
    let app = this.name;
    let ruta = this.route;
    this.voto = true;
    let voto = this.voto;
    let evento = this.miEvento;
    Swal.fire(
      '¡Tu voto ha sido registrado con éxito!',
      'Te direccionaremos a la siguiente categoría de votaciones para que puedas seguir efectuando tus votos.',
      'success'
    ).then(function () {
      evento.emit(voto);
      if (app === 'escolar') {
        ruta.navigate(['/gracias']);
      }
    }
    );
  }
}
