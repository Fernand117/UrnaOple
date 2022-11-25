import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-boleta-datos',
  templateUrl: './boleta-datos.component.html',
  styleUrls: ['./boleta-datos.component.scss']
})
export class BoletaDatosComponent implements OnInit {

  datos: any;
  constructor() { }

  ngOnInit(): void {    
    this.datos = localStorage.getItem('configeneral');
    this.datos = JSON.parse(this.datos);
    console.log(this.datos);
    
  }

}
