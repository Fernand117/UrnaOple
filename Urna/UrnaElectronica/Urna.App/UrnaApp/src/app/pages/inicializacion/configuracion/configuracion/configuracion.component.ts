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

  ngOnInit(): void {
    this.deleteBoletas();
  }

  //ELIMINAR DATOS DE LA BASE DE DATOS LOCAL
  deleteBoletas() {
    this.service.deleteDataBoletas().subscribe(resp => {
    });
  }

  //INSERTAR EN LA BASE DE DATOS LA CANTIDADA DE BOLETAS PARA CADA TIPO DE ELECCIÓN
  setContadorBoletas(info: any) {    
    let request = {
      CantidadBoletas: info.CantidadBoletas,
      TipoEleccion: info.TipoEleccion
    }
    
    if (this.respuesta.categoria === "Mecanismos de participación ciudadana") {
      request = {
        CantidadBoletas: info.CantidadBoletas,
        TipoEleccion: info.MecanismoTipo
      }
    }

    this.service.contadorBoletas(request).subscribe((resp) => {      
    }, error => {
      console.log(error);
    });
  }

  configuracion_eleccioneslocales() {   
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
    let info = this.confi.TipoMecanismos;    
    for (let i = 0; i < info.length; i++) {
      this.setContadorBoletas(info[i]);
      if(info[i].MecanismoTipo === 'Referéndum') {        
      localStorage.setItem('referendum', JSON.stringify(info[i]));
    } else if(info[i].MecanismoTipo === 'Plebiscito') {
      localStorage.setItem('presbicito', JSON.stringify(info[i]));
      } else if(info[i].MecanismoTipo === 'Consulta Popular') {
        localStorage.setItem('consulta', JSON.stringify(info[i]));
      } 
    }
  }

  descargarConfiguracion() {
    this.service.getConfiguracion(this.keyboard.value).subscribe((resp) => {
      this.respuesta = resp;      
      this.respuesta = this.respuesta.data;
      if (this.respuesta.configuraciones == null) {
        this.mostrar_mensaje_error();
      }  
      this.confi = this.respuesta.configuraciones;      
      localStorage.setItem('configeneral', this.confi);          
      this.confi = JSON.parse(this.confi);          
    
      localStorage.setItem('categoria', this.respuesta.categoria);      
      if(this.respuesta.categoria === 'Procesos locales electorales') {
        this.configuracion_eleccioneslocales();
        this.mostrar_mensaje_success();
      } else if (this.respuesta.categoria === "Elecciones escolares") {
        this.mostrar_mensaje_success(); 
        this.configuracion_eleccionesEscolares();
      } else if (this.respuesta.categoria === "Mecanismos de participación ciudadana") {
        this.configuracion_mecanismos_ciudadania();
        this.mostrar_mensaje_success();
      }
    }, error => {
      this.mostrar_mensaje_error();
    });
  }

  mostrar_mensaje_error() {
    Swal.fire({
      icon: 'error',
      title: 'Código de configuración no válido.',
      text: 'Por favor inténtelo de nuevo',
      timer: 1000,
      showConfirmButton: false
    });
  }

  mostrar_mensaje_success() {
    let ruta = this.route;
    Swal.fire(
    {
      title: "Configuración descargada",
      icon: "success",
      timer: 1000,
      showConfirmButton: false
    }
    ).then(function() {
      ruta.navigate(['/boleta-inicializacion']);
    })
  }

}