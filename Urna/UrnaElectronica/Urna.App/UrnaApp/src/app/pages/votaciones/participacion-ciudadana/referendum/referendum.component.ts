import { Component, OnInit,Input } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-referendum',
  templateUrl: './referendum.component.html',
  styleUrls: ['./referendum.component.scss']
})
export class ReferendumComponent implements OnInit {

  @Input() app_name: any;
  voto: boolean = false;

  configuracion: any;

  constructor() { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  
  obtenerConfiguracion() {
    this.configuracion =localStorage.getItem(this.app_name);
    this.configuracion = JSON.parse(this.configuracion);   
    console.log(this.configuracion);
  }  

  enviar() {
    if(!this.voto) {
      this.voto = true;
      Swal.fire(
        'Gracias!',
        'Tu voto ha sido registrado',
        'success'
      )
    } else {
      Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Ya haz realizado tu voto para este mecanismo',
      })
      
    }
    
  }

}
