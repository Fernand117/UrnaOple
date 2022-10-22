import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tarjetas',
  templateUrl: './tarjetas.component.html',
  styleUrls: ['./tarjetas.component.scss']
})
export class TarjetasComponent implements OnInit {

  constructor(private route:Router) { }

  bandera : boolean = true;

  ngOnInit(): void {
    setTimeout(()=>{    
      if(!this.bandera) {
        this.mostrar_mensaje();
      } else {
        this.route.navigate(['/configuracion']);
      }
    }, 1000);
  }

  mostrar_mensaje() {
    Swal.fire({
      icon: 'error',
      title: 'Tarjeta no autorizada',
      text: 'Por favor inténtelo de nuevo'
    })
  }
}
