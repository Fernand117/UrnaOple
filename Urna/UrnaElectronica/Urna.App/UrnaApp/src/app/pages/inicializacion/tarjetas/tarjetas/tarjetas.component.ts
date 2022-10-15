import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

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
        console.log("NO AUTORIZADO");
      } else {
        this.route.navigate(['/configuracion']);
      }
    }, 5000);
  }
}
