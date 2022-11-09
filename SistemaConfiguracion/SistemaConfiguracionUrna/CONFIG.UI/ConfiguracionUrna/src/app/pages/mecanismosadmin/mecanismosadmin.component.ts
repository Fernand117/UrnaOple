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
  public mecanismosUpdate: MecanismosModule = new MecanismosModule();

  public preguntaUpdate: PreguntasModule = new PreguntasModule();
  public pregunta: PreguntasModule;

  public listaPreguntas: any[] = [];
  public listaMecanismos: any[] = [];

  public listaPreguntasUpdate: any[] = [];
  public listaMecanismosUpdate: any[] = [];

  private resData: any;

  private contador: number;
  private modoEdiccionPregunta: boolean;

  private consultaMecanismo: any;
  private resConsultaMecanismo: any;

  private consultaPregunta: any;
  private resConsultaPregunta: any;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.contador = 0;
    this.modoEdiccionPregunta = false;
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

  openModalEditMecanismo() {
    var modal = document.getElementById("formPartidosUpdate");
    modal!.style.display = "block";
  }

  closeModalEditMecanismos() {
    var modal = document.getElementById("formPartidosUpdate");
    modal!.style.display = "none";
  }

  openModalEditPregunta() {
    var modal = document.getElementById("formPartidosU");
    modal!.style.display = "block";
    modal!.style.zIndex = "100";
  }

  closeModalEditPregunta() {
    var modal = document.getElementById("formPartidosU");
    modal!.style.display = "none";
  }

  agregarPregunta() {
    if (this.pregunta.pregunta === "") {
      this.mensajeError("Debe registrar una pregunta.");
      return;
    }
    this.listaPreguntas.push(this.pregunta);
    this.closeModal();
  }

  private mensajeError(mensaje: string): void {
    Swal.fire({
      title: "Advertencia",
      icon: "warning",
      text: mensaje
    });
  }

  agregarMecanismo() {

    if (this.mecanismos.TipoMecanismo === "") {
      this.mensajeError("Por favor seleccione un tipo de mecanismo de participación ciudadana.");
      return;
    }

    if (this.mecanismos.Nombre === "") {
      this.mensajeError("Ingrese el nombre del mecanismo.");
      return
    }

    if (this.mecanismos.Objeto === "") {
      this.mensajeError("Ingrese el objeto del mecanismo.");
      return;
    }

    if (this.mecanismos.Presidente === "") {
      this.mensajeError("Ingrese el nombre del presidente.");
      return;
    }

    if (this.mecanismos.Secretario === "") {
      this.mensajeError("Ingrese el nombre del secretario.");
      return;
    }

    if (this.mecanismos.PrimerEscrutador === "") {
      this.mensajeError("Ingrese el nombre del primer escrutador.")
      return;
    }

    if (this.mecanismos.SegundoEscrutador === "") {
      this.mensajeError("Ingrese el nombre del segundo escrutador");
      return;
    }

    if (this.mecanismos.Entidad === "") {
      this.mensajeError("Ingrese el nombre de la entidad.");
      return;
    }

    if (this.mecanismos.Distrito === "") {
      this.mensajeError("Ingrese el nombre del distrito.")
      return;
    }

    if (this.mecanismos.Municipio === "") {
      this.mensajeError("Ingres el nombre del municipio");
      return;
    }

    if (this.mecanismos.Seccion === "") {
      this.mensajeError("Ingrese el nombre de lugar");
      return
    }

    if (this.mecanismos.Folio === "") {
      this.mensajeError("Ingrese el folio.");
      return;
    }

    if (this.mecanismos.CantidadBoletas === "") {
      this.mensajeError("Ingrese el número de boletas para este mecanismo.");
      return;
    }

    if (this.listaPreguntas.length === 0) {
      this.mensajeError("Aún no añadido preguntas al mecanismo que desea configurar.");
      return;
    }

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

    if (this.listaMecanismos.length === 0) {
      this.mensajeError("Aún no ha guardado ningún tipo de mecanismo de participación ciudadana.");
      return
    }

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

  public editarConfiguracion(nombre: string) {
    this.consultaMecanismo = this.listaMecanismos.findIndex(m => m.Nombre === nombre);
    this.resConsultaMecanismo = this.listaMecanismos[this.consultaMecanismo];

    console.log(this.consultaMecanismo)
    console.log(this.resConsultaMecanismo)

    this.mecanismosUpdate.TipoMecanismo = this.resConsultaMecanismo["TipoMecanismo"];
    this.mecanismosUpdate.Nombre = this.resConsultaMecanismo["Nombre"];
    this.mecanismosUpdate.Objeto = this.resConsultaMecanismo["Objeto"];
    this.mecanismosUpdate.Presidente = this.resConsultaMecanismo["Presidente"];
    this.mecanismosUpdate.Secretario = this.resConsultaMecanismo["Secretario"];
    this.mecanismosUpdate.PrimerEscrutador = this.resConsultaMecanismo["PrimerEscrutador"];
    this.mecanismosUpdate.SegundoEscrutador = this.resConsultaMecanismo["SegundoEscrutador"];
    this.mecanismosUpdate.Entidad = this.resConsultaMecanismo["Entidad"];
    this.mecanismosUpdate.Distrito = this.resConsultaMecanismo["Distrito"];
    this.mecanismosUpdate.Municipio = this.resConsultaMecanismo["Municipio"];
    this.mecanismosUpdate.Seccion = this.resConsultaMecanismo["SeccionElectoral"];
    this.mecanismosUpdate.Folio = this.resConsultaMecanismo["Folio"];
    this.mecanismosUpdate.CantidadBoletas = this.resConsultaMecanismo["CantidadBoletas"];
    this.listaPreguntasUpdate = this.resConsultaMecanismo["Preguntas"];
    console.log(this.mecanismosUpdate)

    this.openModalEditMecanismo();
  }

  public eliminarConfiguracion(nombre: string) {
    this.consultaMecanismo = this.listaMecanismos.findIndex(m => m.Nombre === nombre);
    this.resConsultaMecanismo = this.listaMecanismos[this.consultaMecanismo];
    this.listaMecanismos.splice(this.listaMecanismos.indexOf(this.resConsultaPregunta), 1);
  }

  public guardarConfiguracionActualizada() {
    this.listaMecanismos[this.consultaMecanismo].TipoMecanismo = this.mecanismosUpdate.TipoMecanismo;
    this.listaMecanismos[this.consultaMecanismo].Nombre = this.mecanismosUpdate.Nombre;
    this.listaMecanismos[this.consultaMecanismo].Objeto = this.mecanismosUpdate.Objeto;
    this.listaMecanismos[this.consultaMecanismo].Presidente = this.mecanismosUpdate.Presidente;
    this.listaMecanismos[this.consultaMecanismo].Secretario = this.mecanismosUpdate.Secretario;
    this.listaMecanismos[this.consultaMecanismo].PrimerEscrutador = this.mecanismosUpdate.PrimerEscrutador;
    this.listaMecanismos[this.consultaMecanismo].SegundoEscrutador = this.mecanismosUpdate.SegundoEscrutador;
    this.listaMecanismos[this.consultaMecanismo].Entidad = this.mecanismosUpdate.Entidad;
    this.listaMecanismos[this.consultaMecanismo].Distrito = this.mecanismosUpdate.Distrito;
    this.listaMecanismos[this.consultaMecanismo].Municipio = this.mecanismosUpdate.Municipio;
    this.listaMecanismos[this.consultaMecanismo].Seccion = this.mecanismosUpdate.Seccion;
    this.listaMecanismos[this.consultaMecanismo].Folio = this.mecanismosUpdate.Folio;
    this.listaMecanismos[this.consultaMecanismo].CantidadBoletas = this.mecanismosUpdate.CantidadBoletas;
    this.listaMecanismos[this.consultaMecanismo].Preguntas = this.listaPreguntasUpdate;

    console.log(this.listaMecanismos);

    this.closeModalEditMecanismos();
  }

  public editarPreguntaActual(pregunta: string) {
    this.consultaPregunta = this.listaPreguntas.findIndex(p => p.pregunta === pregunta);
    this.resConsultaPregunta = this.listaPreguntas[this.consultaPregunta];
    console.log(this.resConsultaPregunta);
    this.preguntaUpdate.pregunta = this.resConsultaPregunta["pregunta"];

    this.openModalEditPregunta();
  }

  public eliminarPreguntaActual(pregunta: string) {
    this.consultaPregunta = this.listaPreguntas.findIndex(p => p.pregunta === pregunta);
    this.resConsultaPregunta = this.listaPreguntas[this.consultaPregunta];
    console.log(this.resConsultaPregunta);
    this.listaPreguntas.splice(this.listaPreguntas.indexOf(this.resConsultaPregunta), 1);
  }

  public guardarPreguntaActual() {
    if (this.modoEdiccionPregunta === true) {
      this.listaPreguntasUpdate[this.consultaPregunta].pregunta = this.preguntaUpdate.pregunta;
      this.closeModalEditPregunta();
      return;
    }
    this.listaPreguntas[this.consultaPregunta].pregunta = this.preguntaUpdate.pregunta;
    this.closeModalEditPregunta();
  }

  public editarPreguntaUpdate(pregunta: string) {
    this.modoEdiccionPregunta = true;
    this.consultaPregunta = this.listaPreguntasUpdate.findIndex(p => p.pregunta === pregunta);
    this.resConsultaPregunta = this.listaPreguntasUpdate[this.consultaPregunta];

    this.preguntaUpdate.pregunta = this.resConsultaPregunta["pregunta"];
    this.openModalEditPregunta();
  }

  public eliminarPreguntaUpdate(pregunta: string) {
    this.consultaPregunta = this.listaPreguntasUpdate.findIndex(p => p.pregunta === pregunta);
    this.resConsultaPregunta = this.listaPreguntasUpdate[this.consultaPregunta];

    this.listaPreguntasUpdate.splice(this.listaPreguntasUpdate.indexOf(this.resConsultaPregunta), 1);
  }
}
