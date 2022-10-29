import { Component, OnInit, Input } from '@angular/core';
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
  voto: boolean = false;
  form: any = [];
  configuracion: any;
  RespuestaSi: string[] = [];
  RespuestaNo: boolean[] = [];
  test : boolean[] = [] ;

  constructor(private service: ConfiguracionApiService, private route: Router, private formBuilder: FormBuilder) { }

  private buildForm() {
    this.form = this.formBuilder.group({
      respuesta: ['0', [Validators.required]],
    })
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

    let info = this.configuracion.Preguntas;
    for (let i = 0; i < info.length; i++) {
      console.log(this.form.value);
      
      // console.log(this.RespuestaNo[i]);
      // console.log(this.RespuestaSi[i]);
    }
      // let request =
      // {
      //   Pregunta: info[i].Pregunta,
      //   RespuestaSi: this.RespuestaSi[i],
      //   RespuestaNo: this.RespuestaNo[i],
      // }      
      
      // this.service.setVoto(request, this.app_name).subscribe((resp) => {
      //   console.log(resp);
      // }, error => {
      // });
    }
  

  mostrar_msjError() {
    Swal.fire({
      icon: 'error',
      title: 'Lo sentimos',
      text: 'Ya has realizado tu voto para este tipo de elección.'
    });
  }

  msjSuccess() {
    let ruta = this.route;
    Swal.fire(
      '¡Tu voto ha sido registrado con éxito!',
      'Te direccionaremos a la siguiente categoría de votaciones para que puedas seguir efectuando tus votos.',
      'success'
    ).then(function () {
      ruta.navigate(['/gracias']);

    }
    );
  }

}
