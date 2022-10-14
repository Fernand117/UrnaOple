import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-configuracion',
  templateUrl: './configuracion.component.html',
  styleUrls: ['./configuracion.component.scss']
})
export class ConfiguracionComponent implements OnInit {

  form: any;
  respuesta: any;
  configuracion: any;

  constructor(private formBuilder: FormBuilder, private route:Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.form = this.formBuilder.group({
      codigo_configuracion: ['',[Validators.required]]
    })
  }

  serializar(){
    return JSON.parse(this.respuesta);
  }

  enviar() {
    this.service.getConfiguracion(this.form.get('codigo_configuracion').value).subscribe((resp) => {
      this.respuesta = resp;
      this.configuracion = this.respuesta.data.configuraciones;
      this.configuracion = JSON.parse(this.configuracion);
      this.route.navigate(['/boleta-inicializacion']); 
    });
  }
}
