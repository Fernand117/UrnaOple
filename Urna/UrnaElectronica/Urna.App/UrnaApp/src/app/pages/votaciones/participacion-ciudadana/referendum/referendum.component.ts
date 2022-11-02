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

  votar_registrado() {
    for (const prop in this.form.value) {
      let request =
      {
        Pregunta: prop,
        RespuestaSi: this.form.value[prop],
        RespuestaNo: this.form.value[prop],
      }
      this.service.setVoto(request, this.app_name).subscribe((resp) => {
        this.msjSuccess();
      }, error => {
        this.mostrar_msjError
      });
    }
  }

  mostrar_msjError() {
    Swal.fire({
      icon: 'error',
      title: 'Lo sentimos',
      text: 'Ha ocurrido un error, por favor vuelve a intentarlo.'
    });
  }

  msjSuccess() {
    this.voto = true;
    let voto = this.voto;
    let evento = this.miEvento;
    let ruta = this.route;
    Swal.fire(
      '¡Tu voto ha sido registrado con éxito!',
      'Gracias',
      'success'
    )
    .then(function () {
      evento.emit(voto);
      // ruta.navigate(['/gracias']);
    }
    );
  }

}
