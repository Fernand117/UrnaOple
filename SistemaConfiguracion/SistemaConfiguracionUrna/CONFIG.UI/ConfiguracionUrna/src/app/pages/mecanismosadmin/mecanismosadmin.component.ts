import { Component, OnInit } from '@angular/core';
import { MecanismosModule } from '../../models/mecanismos/mecanismos.module';
import { PreguntasModule } from '../../models/preguntas/preguntas.module';
import { ApiServiceService } from '../../services/api-service.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-mecanismosadmin',
  templateUrl: './mecanismosadmin.component.html',
  styleUrls: ['./mecanismosadmin.component.scss']
})
export class MecanismosadminComponent implements OnInit {

  public mecanismos: MecanismosModule = new MecanismosModule();
  public pregunta: PreguntasModule;

  public listaPreguntas: any[] = [];
  public listaMecanismos: any[] = [];

  private resData: any;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  addPartido() {
    this.pregunta = new PreguntasModule();
    var modal = document.getElementById("formPartidos");
    modal!.style.display = "block";
  }

  closeModal() {
    var modal = document.getElementById("formPartidos");
    modal!.style.display = "none";
  }

  agregarPregunta() {
    this.listaPreguntas.push(this.pregunta);
    this.closeModal();
  }

  agregarMecanismo() {
    const datos = {
      "TipoMecanismo": this.mecanismos.TipoMecanismo,
      "Nombre": this.mecanismos.Nombre,
      "Objeto": this.mecanismos.Objeto,
      "Preguntas": this.listaPreguntas,
      "CantidadBoletas": this.mecanismos.CantidadBoletas,
      "Presidente": this.mecanismos.Presidente,
      "Secretario": this.mecanismos.Secretario,
      "PrimerEscrutador": this.mecanismos.PrimerEscrutador,
      "SegundoEscrutador": this.mecanismos.SegundoEscrutador,
      "Entidad": this.mecanismos.Entidad,
      "Distrito": this.mecanismos.Distrito,
      "Municipio": this.mecanismos.Municipio,
      "SeccionElectoral": this.mecanismos.Seccion.toString(),
      "Firmas": this.mecanismos.Firmas,
      "Folio": this.mecanismos.Folio.toString()
    }

    this.listaMecanismos.push(datos);
    let json = JSON.stringify(this.listaMecanismos);
    console.log(json)

    this.mecanismos = new MecanismosModule();
    this.pregunta = new PreguntasModule();
    this.listaPreguntas = [];
  }

  guardarConfiguracion() {
    const datos = {
      "Id": 0,
      "Categoria": "Mecanismos de participación ciudadana",
      "Mecanismos": this.listaMecanismos
    }

    let json = JSON.stringify(datos);
    console.log(json)

    this.apiService.guardarMecanismo(json).subscribe(
      res => {
        this.resData = res
        console.log(res)
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: this.resData["ResponseText"],
          showConfirmButton: false,
          timer: 1500
        })
        this.router.navigateByUrl('/elecciones')
      }
    );
  }
}
