import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {ApiServiceService} from "../../services/api-service.service";

@Component({
  selector: 'app-resultados',
  templateUrl: './resultados.component.html',
  styleUrls: ['./resultados.component.scss']
})
export class ResultadosComponent implements OnInit {

  public resServidor: any;
  public resDatosServidor: any
  public data: any[] = [];
  public resCategorias: any[] = [];

  //VARIABLES PARA SACAR LAS CATEGORIAS
  public TIPO_ELECCION_UNO: string;
  public TIPO_ELECCION_DOS: string;
  public TIPO_ELECCION_TRES: string;

  constructor(
    private route: ActivatedRoute,
    private apiService: ApiServiceService
  ) { }

  private code: any = this.route.snapshot.paramMap.get('code');

  ngOnInit(): void {
    this.apiService.listarResultados(this.code).subscribe(
      res => {
        this.resServidor = res;
        this.resDatosServidor = this.resServidor;
        this.data = this.resDatosServidor['data'];
        console.log(this.data)
        for (let i = 0; i < this.data.length; i++) {
          //this.jsonParse = JSON.parse(this.data[i]['resultados']);
          this.resCategorias.push(JSON.parse(JSON.parse(this.data[i]['resultados'])));
        }
        console.log(this.resCategorias)

        for (let i = 0; i < this.resCategorias.length; i++) {
          if (this.resCategorias[i]['categoria'] === "Elecciones escolares") {
            this.TIPO_ELECCION_UNO = this.resCategorias[i]['categoria'];
          }
          for (let j = 0; j < this.resCategorias[i].length; j++) {
            console.log(this.resCategorias[i][j]['TipoEleccion']);
            if (this.resCategorias[i][j]['TipoEleccion'] === "Gubernatura") {
              this.TIPO_ELECCION_UNO = this.resCategorias[i][j]['TipoEleccion'];
            }

            if (this.resCategorias[i][j]['TipoEleccion'] === "Diputacion") {
              this.TIPO_ELECCION_DOS = this.resCategorias[i][j]['TipoEleccion'];
            }

            if (this.resCategorias[i][j]['TipoEleccion'] === "Ayuntamiento") {
              this.TIPO_ELECCION_TRES = this.resCategorias[i][j]['TipoEleccion'];
            }
          }
        }
      }
    );
  }

}
