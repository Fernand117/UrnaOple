import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-ayuntamiento',
  templateUrl: './ayuntamiento.component.html',
  styleUrls: ['./ayuntamiento.component.scss']
})
export class AyuntamientoComponent implements OnInit {

  @Input() partidos: any;

  constructor() { }

  ngOnInit(): void {
  }

}
