import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-referendum',
  templateUrl: './referendum.component.html',
  styleUrls: ['./referendum.component.scss']
})
export class ReferendumComponent implements OnInit {

  @Input() app_name: any;
  @Output() miEvento = new EventEmitter<boolean>();
  voto: boolean = false;
  form: any = [];
  configuracion: any;

  constructor(private service: ConfiguracionApiService, private route: Router, private formBuilder: FormBuilder) { }

  private buildForm() {
    let form: any = {};
    this.configuracion?.Preguntas.map((item: any) => form[item.Pregunta] = ['0', [Validators.required]]);
    this.form = this.formBuilder.group(form);
  }

  ngOnInit(): void {
    this.obtenerConfiguracion();
    this.buildForm();
  }

  obtenerConfiguracion() {
    this.configuracion = localStorage.getItem(this.app_name);
    this.configuracion = JSON.parse(this.configuracion);
  }

  anularVoto() {
    let request = {
      Pregunta: 'Voto nulo',
      RespuestaSi: '1'
    }
    this.service.setVoto(request, this.app_name).subscribe((resp) => {
      this.msjVotoNulo();
      this.updateCantidadBoletas();
    });
  }

  votar_registrado() {    
    for (const prop in this.form.value) {
      let request =
      {
        Pregunta: prop,
        RespuestaSi: this.form.value[prop],
      }            
      this.service.setVoto(request, this.app_name).subscribe((resp) => {
        this.msjSuccess();
      }, error => {
        this.mostrar_msjError
      });
    }
    this.updateCantidadBoletas();
  }

  updateCantidadBoletas() {
    let TipoEleccion: string = "";
    if (this.app_name === "referendum") {
      TipoEleccion = "Referéndum"
    } else if (this.app_name === "presbicito") {
      TipoEleccion = "Plebiscito"
    } else if (this.app_name === "consulta") {
      TipoEleccion = "Consulta Popular"
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
      text: 'Ha ocurrido un error, por favor vuelve a intentarlo.',
      timer: 2000,
      showConfirmButton: false
    });
  }

  msjVotoNulo() {
    this.voto = true;
    let voto = this.voto;
    let evento = this.miEvento;
    let ruta = this.route;
    Swal.fire(
      {
        title: "¡Tu voto ha sido anulado!",
        icon: "success",
        timer: 2000,
        showConfirmButton: false
      }
    )
    .then(function () {
      evento.emit(voto);
    }
    );

  }

  msjSuccess() {
    this.voto = true;
    let voto = this.voto;
    let evento = this.miEvento;
    let ruta = this.route;
    Swal.fire(
      {
        title: "¡Tu voto ha sido registrado con éxito!",
        icon: "success",
        timer: 2000,
        showConfirmButton: false
      }
    )
    .then(function () {
      evento.emit(voto);
    }
    );
  }

}
