import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../../services/api-service.service';
import {config} from "rxjs";

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.scss']
})
export class InicioComponent implements OnInit {

  resData: any = "";
  configuracion: any;
  config: any;
  public listaConfiguracionesLocales: any[] = [];
  public listaConfiguracionesMecanismos: any[] = [];
  public listaConfiguracionesEscolares: any[] = [];

  constructor(
    private apiService: ApiServiceService
  ) { }

  ngOnInit(): void {
    this.listar();
  }

  listar() {
    this.apiService.listaConfiguraciones().subscribe(
      res => {
        this.resData = res;
        this.resData = this.resData['data'];
        console.log(this.resData)
        for (let i = 0; i < this.resData.length; i++) {
          if (this.resData[i].categoria === 'Procesos locales electorales') {
            this.listaConfiguracionesLocales.push(this.resData[i]);
            console.log(this.listaConfiguracionesLocales)
          } else if (this.resData[i].categoria === 'Mecanismos de participación ciudadana') {
            this.listaConfiguracionesMecanismos.push(this.resData[i]);
          } else {
            this.listaConfiguracionesEscolares.push(this.resData[i]);
          }
        }
      }
    );
  }

  viewItem(item: any) {
    this.apiService.getOneConfiguracion(item).subscribe(resp => {
      this.configuracion = resp;

      this.configuracion = this.configuracion.data['configuraciones'];
      this.config = JSON.parse(this.configuracion);
      console.log(this.config)
    });
  }
}
