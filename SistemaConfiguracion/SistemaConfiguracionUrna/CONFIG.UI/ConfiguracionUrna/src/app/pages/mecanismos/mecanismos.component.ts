import { Component, OnInit } from '@angular/core';
import {MecanismosModule} from "../../models/mecanismos/mecanismos.module";
import {TiposmecanismosModule} from "../../models/tiposmecanismos/tiposmecanismos.module";
import {PreguntasModule} from "../../models/preguntas/preguntas.module";
import {AlertasModule} from "../../components/alertas/alertas.module";
import {ApiServiceService} from "../../services/api-service.service";
import {Router} from "@angular/router";
import Swal from "sweetalert2";

@Component({
  selector: 'app-mecanismos',
  templateUrl: './mecanismos.component.html',
  styleUrls: ['./mecanismos.component.scss']
})
export class MecanismosComponent implements OnInit {

  // INICIALIZACIÓN DE LOS MODELOS
  public mecanismos: MecanismosModule = new MecanismosModule();
  public tiposMecanismos: TiposmecanismosModule = new TiposmecanismosModule();
  public preguntas: PreguntasModule = new PreguntasModule();

  // ALERTAS
  private alertas: AlertasModule = new AlertasModule();

  // LISTAS DE PREGUNTAS Y MECANISMOS
  public listaPreguntas: any[] = [];
  public listaMecanismos: any[] = [];

  // MANEJADOR DE RESPUESTA DEL SERVIDOR
  private responseServer: any;

  // VARIABLES PARA CONSULTAR LAS PREGUNTAS ACTUALES
  private consultaPreguntaActual: any;
  private resConsultaPreguntaActual: any;

  // VARIABLE PARA MANEJAR ESTADOS DE EDICCIÓN
  private MODO_EDICCION_PREGUNTA: boolean;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.MODO_EDICCION_PREGUNTA = false;
  }

  public agregarPregunta() {

    if (this.preguntas.Pregunta === "") {
      this.alertas.mensajeAdvertencia("Ingrese una pregunta por favor");
      return;
    }

    const pregunta = {
      "Pregunta": this.preguntas.Pregunta
    };

    if (this.MODO_EDICCION_PREGUNTA === true) {
      this.listaPreguntas[this.consultaPreguntaActual].Pregunta = this.preguntas.Pregunta;

      this.preguntas = new PreguntasModule();
      this.MODO_EDICCION_PREGUNTA = false;
      return;
    }

    this.listaPreguntas.push(pregunta);
    this.preguntas = new PreguntasModule();
  }

  public agregarTipoMecanismo() {

    if (this.tiposMecanismos.TipoMecanismo === "") {
      this.alertas.mensajeAdvertencia("Seleccione un tipo de mecanismo");
      return;
    }

    if (this.tiposMecanismos.Nombre === "") {
      this.alertas.mensajeAdvertencia("Ingrese el nombre del mecanismo");
      return;
    }

    if (this.tiposMecanismos.Objeto === "") {
      this.alertas.mensajeAdvertencia("Ingrese el objeto del mecanismo");
      return;
    }

    if (this.tiposMecanismos.Folio === "") {
      return this.alertas.mensajeAdvertencia("Ingrese un número de folio");
    }

    if (this.tiposMecanismos.CantidadBoletas === "") {
      return this.alertas.mensajeAdvertencia("Ingrese el número de boletas");
    }

    if (this.listaPreguntas.length === 0) {
      return this.alertas.mensajeAdvertencia("Ingrese al menos una pregunta");
    }

    this.tiposMecanismos.Preguntas = this.listaPreguntas;
    const mecanismo = {
      "TipoMecanismo": this.tiposMecanismos.TipoMecanismo,
      "Nombre": this.tiposMecanismos.Nombre,
      "Objeto": this.tiposMecanismos.Objeto,
      "Folio": this.tiposMecanismos.Folio.toString(),
      "CantidadBoletas": this.tiposMecanismos.CantidadBoletas.toString(),
      "Preguntas": this.tiposMecanismos.Preguntas
    };

    this.listaMecanismos.push(mecanismo);
    console.log(JSON.stringify(this.listaMecanismos))
    this.tiposMecanismos = new TiposmecanismosModule();
    this.listaPreguntas = [];
  }

  public guardarConfiguracion() {

    if (this.listaMecanismos.length === 0) {
      return this.alertas.mensajeError("No ha registrado ningún tipo de mecanismo");
    }

    if (this.mecanismos.Presidente === "") {
      return this.alertas.mensajeError("Ingrese el nombre del presidente");
    }

    if (this.mecanismos.Secretario === "") {
      return this.alertas.mensajeError("Ingrese el nombre del secretario");
    }

    if (this.mecanismos.PrimerEscrutador === "") {
      return this.alertas.mensajeError("Ingrese el nombre del primer escrutador");
    }

    if (this.mecanismos.SegundoEscrutador === "") {
      return this.alertas.mensajeError("Ingrese el nombre del segundo escrutador");
    }

    if (this.mecanismos.Entidad === "") {
      return this.alertas.mensajeError("Ingrese una entidad");
    }

    if (this.mecanismos.Municipio === "") {
      return this.alertas.mensajeError("Ingrese el municipio");
    }

    if (this.mecanismos.Distrito === "") {
      return this.alertas.mensajeError("Ingrese el distrito");
    }

    if (this.mecanismos.Seccion === "") {
      return this.alertas.mensajeError("Ingrese la sección electoral");
    }


    this.mecanismos.TipoMecanismos = this.listaMecanismos;
    const configuracion = {
      "Presidente": this.mecanismos.Presidente,
      "Secretario": this.mecanismos.Secretario,
      "PrimerEscrutador": this.mecanismos.PrimerEscrutador,
      "SegundoEscrutador": this.mecanismos.SegundoEscrutador,
      "Entidad": this.mecanismos.Entidad,
      "Municipio": this.mecanismos.Municipio,
      "Distrito": this.mecanismos.Distrito,
      "SeccionElectoral": this.mecanismos.Seccion.toString(),
      "TipoMecanismo": this.mecanismos.TipoMecanismos
    };

    const datosGenerales = {
      "Categoria": "Mecanismos de participación ciudadana",
      "Mecanismos": configuracion
    };

    console.log(JSON.stringify(datosGenerales))

    this.apiService.guardarMecanismo(datosGenerales).subscribe(
      res => {
        this.responseServer = res;
        this.alertas.mensajeOk(this.responseServer['responseText']);
        this.router.navigateByUrl("/inicio");
      }
    );
  }

  public editarPreguntaActual(pregunta: string) {
    this.MODO_EDICCION_PREGUNTA = true;
    this.consultaPreguntaActual = this.listaPreguntas.findIndex(p => p.Pregunta === pregunta);
    this.resConsultaPreguntaActual = this.listaPreguntas[this.consultaPreguntaActual];

    this.preguntas.Pregunta = this.resConsultaPreguntaActual["Pregunta"];
  }

  public eliminarPreguntaActual(pregunta: string) {
    Swal.fire({
      title: pregunta,
      text: "¿Desea eliminar esta pregunta?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.consultaPreguntaActual = this.listaPreguntas.findIndex(p => p.Pregunta === pregunta);
        this.resConsultaPreguntaActual = this.listaPreguntas[this.consultaPreguntaActual];
        this.listaPreguntas.splice(this.listaPreguntas.indexOf(this.resConsultaPreguntaActual, 1));
        Swal.fire({
          title: pregunta,
          text: "Se ha eliminado el partido seleccionado.",
          icon: "success"
        });
      }
    });
  }

  public cancelarAgregarOEditarPregunta() {
    this.MODO_EDICCION_PREGUNTA = false;
    this.preguntas = new PreguntasModule();
  }

}
