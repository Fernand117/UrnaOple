import { Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-diputaciones',
  templateUrl: './diputaciones.component.html',
  styleUrls: ['./diputaciones.component.scss']
})
export class DiputacionesComponent implements OnInit {

  @Input() partidos: any;

  constructor() { }

  ngOnInit(): void {
  }

}