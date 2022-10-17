import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-configuracion',
  templateUrl: './configuracion.component.html',
  styleUrls: ['./configuracion.component.scss']
})
export class ConfiguracionComponent implements OnInit {

  form: any;
  respuesta: any;
  configuracion: any;
  code :any;

  constructor(private formBuilder: FormBuilder, private route:Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.form = this.formBuilder.group({
      codigo_configuracion: ['',[Validators.required]]
    })
  }

  enviar() {
    this.service.getConfiguracion(this.form.get('codigo_configuracion').value).subscribe((resp) => {
      this.respuesta = resp;
      console.log(this.respuesta);
      this.code = this.respuesta.data.codigo; 
      this.route.navigate([`/${this.code}/boleta-inicializacion`]);
    }, error => {
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Código de configuración no valido'
      })
    });
  }
}
