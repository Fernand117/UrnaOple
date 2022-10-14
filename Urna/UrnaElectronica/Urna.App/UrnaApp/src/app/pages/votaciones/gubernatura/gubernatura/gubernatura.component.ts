import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gubernatura',
  templateUrl: './gubernatura.component.html',
  styleUrls: ['./gubernatura.component.scss']
})
export class GubernaturaComponent implements OnInit {

  constructor() { }

  gubernaturas = [
    {
      "Candidato": "Jessica Hernandez",
      "Imagen": "jessica.png",
      "Propietario": "Juan Gonzalez",
      "Suplente": "Andrea Hernandez"
    },
    {
      "Candidato": "Rosario Hernandez",
      "Imagen": "rosy.png",
      "Propietario": "Juan Gonzalez",
      "Suplente": "Andrea Hernandez"
    },
    {
      "Candidato": "Abdiel Labrado",
      "Imagen": "rosy.png",
      "Propietario": "Juan Gonzalez",
      "Suplente": "Andrea Hernandez"
    },
    {
      "Candidato": "Fernando Hernandez",
      "Imagen": "rosy.png",
      "Propietario": "Juan Gonzalez",
      "Suplente": "Andrea Hernandez"
    }
  ]

  ngOnInit(): void {
  }

}
