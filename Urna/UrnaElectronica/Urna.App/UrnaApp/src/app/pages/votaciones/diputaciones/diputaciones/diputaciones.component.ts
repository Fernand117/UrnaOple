import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-diputaciones',
  templateUrl: './diputaciones.component.html',
  styleUrls: ['./diputaciones.component.scss']
})
export class DiputacionesComponent implements OnInit {

  //VARIABLES
  @Output() miEvento = new EventEmitter<boolean>();
  @Input() partidos: any;
  app_name: string = "diputacion";

  constructor() { }

  ngOnInit(): void { }

  getVoto(e: any) {
    this.miEvento.emit(e);
  }
}