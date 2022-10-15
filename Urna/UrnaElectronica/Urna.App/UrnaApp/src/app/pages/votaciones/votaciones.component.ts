import { Component, OnInit,  ViewChild} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfiguracionApiService } from 'src/app/services/configuracion-api.service';

@Component({
  selector: 'app-votaciones',
  templateUrl: './votaciones.component.html',
  styleUrls: ['./votaciones.component.scss']
})
export class VotacionesComponent implements OnInit {

  codigo_configuracion: any;
  configuracion: any;

  constructor(private rutaActiva: ActivatedRoute, private service: ConfiguracionApiService) { 
    this.codigo_configuracion = this.rutaActiva.snapshot.paramMap.get('code');
  }

  @ViewChild('content') content: any;

  ngOnInit(): void {
    this.obtenerConfiguracion();
  }

  obtenerConfiguracion() {
    this.service.getConfiguracion(this.codigo_configuracion).subscribe((resp) => {
      this.configuracion = resp;
      this.configuracion = this.configuracion.data.configuraciones;
      this.configuracion = JSON.parse(this.configuracion);
    });
  }  

}
