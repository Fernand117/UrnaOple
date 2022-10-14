import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-boleta',
  templateUrl: './boleta.component.html',
  styleUrls: ['./boleta.component.scss']
})
export class BoletaComponent implements OnInit {

  constructor(private route:Router) { }

  boleta = [
    {
      "id": 1,
      "Candidato": "Jessica Denisse",
      "Num_votos": 0
    },
    {
      "id": 2,
      "Candidato": "María del Rosario",
      "Num_votos": 0
    },
    {
      "id": 3,
      "Candidato": "Fernando Leyva",
      "Num_votos": 0
    },
    {
      "id": 4,
      "Candidato": "Abdiel Labrado",
      "Num_votos": 0
    },
    {
      "id": 5,
      "Candidato": "Oscar Galvan",
      "Num_votos": 0
    }
  ]

  ngOnInit(): void {
  }

  continuar() {
    this.route.navigate(['/votaciones']);
  }

}
