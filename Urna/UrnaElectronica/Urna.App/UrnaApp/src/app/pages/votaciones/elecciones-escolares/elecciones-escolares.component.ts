import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-elecciones-escolares',
  templateUrl: './elecciones-escolares.component.html',
  styleUrls: ['./elecciones-escolares.component.scss']
})
export class EleccionesEscolaresComponent implements OnInit {

  configuracion: any;
  app_name: string = "escolar";
  num_boletas: any;
  @Output() miEvento = new EventEmitter<boolean>();

  constructor(private service: ConfiguracionApiService) { }

  ngOnInit(): void {
    this.obtenerConfiguracion();
    this.getNum_boletas();
  }

  obtenerConfiguracion() {
    this.configuracion = localStorage.getItem('escolares');
    this.configuracion = JSON.parse(this.configuracion);
    this.configuracion = this.configuracion[0];
  }

  getNum_boletas() {
    this.service.getContadorBoletas().subscribe((resp) => {
      let info: any = resp;
      info = info.data;
      for (let i = 0; i < info.length; i++) {
        if (info[i].tipoEleccion === 'Escolares') {
          this.num_boletas = info[i].cantidadBoletas;
        }
      }
    });
  }

}
