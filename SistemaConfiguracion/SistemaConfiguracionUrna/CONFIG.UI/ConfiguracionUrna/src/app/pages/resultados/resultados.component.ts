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
  public jsonParse: any;

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
          console.log(this.resCategorias)
        }
      }
    );
  }

}
