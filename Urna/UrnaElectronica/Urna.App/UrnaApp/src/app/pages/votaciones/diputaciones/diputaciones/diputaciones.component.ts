import { Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-diputaciones',
  templateUrl: './diputaciones.component.html',
  styleUrls: ['./diputaciones.component.scss']
})
export class DiputacionesComponent implements OnInit {

  @Input() partidos: any;
  app_name: string = "diputaciones";

  constructor() { }

  ngOnInit(): void {
  }

}