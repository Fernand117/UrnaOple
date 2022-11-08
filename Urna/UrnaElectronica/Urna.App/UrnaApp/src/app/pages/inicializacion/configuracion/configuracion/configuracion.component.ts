import { Component, OnInit, ViewChild} from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { KeyboardComponent } from 'src/app/components/keyboard/keyboard.component';
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
  name = 'configuracion';
  @ViewChild(KeyboardComponent)
  keyboard: KeyboardComponent = new KeyboardComponent;

  constructor(private route:Router, private service: ConfiguracionApiService) { }

  ngOnInit(): void {}

  setContadorBoletas(info: any) {
    let request = {
      CantidadBoletas: info.CantidadBoletas,
      TipoEleccion: info.TipoEleccion
    }

    if (this.confi.Categoria === "Mecanismos de participación ciudadana") {
      request = {
        CantidadBoletas: info.CantidadBoletas,
        TipoEleccion: info.TipoMecanismo
      }
    }

    this.service.contadorBoletas(request).subscribe((resp) => {
    }, error => {
      console.log(error);
    });
  }

  configuracion_eleccioneslocales() {   
    localStorage.setItem('categoria', this.confi.Categoria);       
    let info = this.confi.Elecciones;
    for (let i = 0; i < info.length; i++) {
      this.setContadorBoletas(info[i]);
      if(info[i].TipoEleccion === 'Diputaciones') {
      localStorage.setItem('diputacion', JSON.stringify(info[i]));
    } else if(info[i].TipoEleccion === 'Gubernatura') {
      localStorage.setItem('gubernatura', JSON.stringify(info[i]));
      } else if(info[i].TipoEleccion === 'Ayuntamientos') {
        localStorage.setItem('ayuntamiento', JSON.stringify(info[i]));
      } 
    }
  }

  configuracion_eleccionesEscolares() {
    localStorage.setItem('categoria', this.confi.Categoria);           
    let info = this.confi.Escolares;
    localStorage.setItem('escolares', JSON.stringify(info));    
    let request = {
      CantidadBoletas: info[0].CantidadBoletas,
      TipoEleccion: "Escolares"
    }
    this.service.contadorBoletas(request).subscribe((resp) => {
    }, error => {
      console.log(error);
    });    
  }

  configuracion_mecanismos_ciudadania() {
    localStorage.setItem('categoria', this.confi.Categoria);       
    let info = this.confi.Mecanismos;
    for (let i = 0; i < info.length; i++) {
      this.setContadorBoletas(info[i]);
      if(info[i].TipoMecanismo === 'Referéndum') {        
      localStorage.setItem('referendum', JSON.stringify(info[i]));
    } else if(info[i].TipoMecanismo === 'Plebiscito') {
      localStorage.setItem('presbicito', JSON.stringify(info[i]));
      } else if(info[i].TipoMecanismo === 'Consulta Popular') {
        localStorage.setItem('consulta', JSON.stringify(info[i]));
      } 
    }
  }

  descargarConfiguracion() {
    this.service.getConfiguracion(this.keyboard.value).subscribe((resp) => {
      this.respuesta = resp;
      this.confi = this.respuesta.data.configuraciones;
      this.confi = JSON.parse(this.confi);
      
      localStorage.setItem('categoria', this.confi.Categoria);      
      if(this.confi.Categoria === 'Procesos locales electorales') {
        this.configuracion_eleccioneslocales();
        this.route.navigate(['/boleta-inicializacion']);
      } else if (this.confi.Categoria === "Elecciones escolares") {
        localStorage.clear();
        this.route.navigate(['/boleta-inicializacion']);  
        this.configuracion_eleccionesEscolares();
      } else if (this.confi.Categoria === "Mecanismos de participación ciudadana") {
        localStorage.clear();
        this.configuracion_mecanismos_ciudadania();
        this.route.navigate(['/boleta-inicializacion']);
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