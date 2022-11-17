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
        console.log(this.resDatosServidor)
      }
    );
  }

}
