import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../../services/api-service.service';
import {config} from "rxjs";

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.scss']
})
export class InicioComponent implements OnInit {

  public responseServer: any = "";

  public listaElecciones: any[] = [];
  public listaMecanismos: any[] = [];
  public listaEscolares:  any[] = [];

  constructor(
    private apiService: ApiServiceService
  ) { }

  ngOnInit(): void {
    this.getListaElecciones();
  }

  public getListaElecciones() {
    this.apiService.listaConfiguraciones().subscribe(
      res => {
        this.responseServer = res;
        this.responseServer = this.responseServer['data'];

        for (let i = 0; i < this.responseServer.length; i++) {
          if (this.responseServer[i].categoria === "Procesos locales electorales") {
            this.responseServer[i].configuraciones = JSON.parse(this.responseServer[i].configuraciones);
            this.responseServer[i].configuraciones = JSON.parse(this.responseServer[i].configuraciones);
            this.listaElecciones.push(this.responseServer[i]);
          }

          if (this.responseServer[i].categoria === "Mecanismos de participación ciudadana") {
            this.responseServer[i].configuraciones = JSON.parse(this.responseServer[i].configuraciones);
            this.responseServer[i].configuraciones = JSON.parse(this.responseServer[i].configuraciones);
            this.listaMecanismos.push(this.responseServer[i]);
          }

          if (this.responseServer[i].categoria === "Elecciones escolares") {
            this.responseServer[i].configuraciones = JSON.parse(this.responseServer[i].configuraciones);
            this.responseServer[i].configuraciones = JSON.parse(this.responseServer[i].configuraciones);
            this.listaEscolares.push(this.responseServer[i]);
          }
        }

        console.log(this.listaEscolares);
      }
    );
  }
}
