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
  confi :any;

  constructor(private formBuilder: FormBuilder, private route:Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.form = this.formBuilder.group({
      codigo_configuracion: ['',[Validators.required]]
    })
  }

  configuracion_eleccioneslocales() {
    let info = this.confi.Elecciones;
    for (let i = 0; i < info.length; i++) {
      if(info[i].TipoEleccion === 'Diputaciones') {
      localStorage.setItem('diputacion', JSON.stringify(info[i]));
    } else if(info[i].TipoEleccion === 'Gubernaturas') {
      localStorage.setItem('gubernatura', JSON.stringify(info[i]));
      } else if(info[i].TipoEleccion === 'ayuntamientos') {
        localStorage.setItem('ayuntamiento', JSON.stringify(info[i]));
      } 
    }
  }

  enviar() {
    this.service.getConfiguracion(this.form.get('codigo_configuracion').value).subscribe((resp) => {
      this.respuesta = resp;
      this.confi = this.respuesta.data.configuraciones;
      this.confi = JSON.parse(this.confi);
      localStorage.setItem('categoria', this.confi.Categoria);
      if(this.confi.Categoria === 'Elecciones locales') {
        this.configuracion_eleccioneslocales();
        this.route.navigate(['/boleta-inicializacion']);
      } else if (this.confi.Categoria === "Elecciones escolares") {
        console.log("configurar escolares");
      } else if (this.confi.Categoria === "Mecanismos") {
        console.log("Configurar mecanismos");
      }
    }, error => {
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Código de configuración no valido'
      })
    });
  }
}