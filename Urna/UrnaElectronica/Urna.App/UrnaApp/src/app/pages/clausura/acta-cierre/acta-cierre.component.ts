import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-acta-cierre',
  templateUrl: './acta-cierre.component.html',
  styleUrls: ['./acta-cierre.component.scss']
})
export class ActaCierreComponent implements OnInit {

  constructor() { }

  // gubernaturas : any ;
  // ayuntamientos :any = "h"
  // diputacines :any;

  ngOnInit(): void {
    // document.querySelectorAll('.nav-link').item(0).className = "nav-link active";
  }


  // crear() {    
  //   const clasesMenu = document.querySelectorAll('.nav-link');
  //   const clasesContenido = document.querySelectorAll('.tab-pane');
  //   let item =0;
  //   clasesMenu.item(item).className = "nav-link";
  //   clasesMenu.item(item+1).className = "nav-link active";
  //   clasesContenido.item(item).className = "tab-pane fade"
  //   clasesContenido.item(item+1).className = "tab-pane fade show active";
  // }
}
