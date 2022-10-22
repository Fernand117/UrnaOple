import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-participacion-ciudadana',
  templateUrl: './participacion-ciudadana.component.html',
  styleUrls: ['./participacion-ciudadana.component.scss']
})
export class ParticipacionCiudadanaComponent implements OnInit {

  constructor() { }

  preguntas = [
    {
      pregunta: "¿Estas de acuerdo con el mecanismo de participación ciudadana?"
    },
    {
      pregunta: "¿Estas de acuerdo con el mecanismo de participación ciudadana?"
    },
    {
      pregunta: "¿Estas de acuerdo con el mecanismo de participación ciudadana?"
    },
    {
      pregunta: "¿Estas de acuerdo con el mecanismo de participación ciudadana?"
    }
  ]

  ngOnInit(): void {
  }

}
