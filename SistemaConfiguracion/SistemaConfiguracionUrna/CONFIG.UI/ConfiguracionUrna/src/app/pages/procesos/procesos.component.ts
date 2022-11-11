import { Component, OnInit } from '@angular/core';
import {ApiServiceService} from "../../services/api-service.service";
import {Router} from "@angular/router";
import {ProcesoselectoralesModule} from "../../models/procesoselectorales/procesoselectorales.module";
import {EleccionesModule} from "../../models/elecciones/elecciones.module";
import {AlertasModule} from "../../components/alertas/alertas.module";
import {PartidosModule} from "../../models/partidos/partidos.module";
import Swal from "sweetalert2";

@Component({
  selector: 'app-procesos',
  templateUrl: './procesos.component.html',
  styleUrls: ['./procesos.component.scss']
})
export class ProcesosComponent implements OnInit {

  // INSTACIACIÓN DE LOS MODELOS
  public procesos: ProcesoselectoralesModule = new ProcesoselectoralesModule();
  public partidos: PartidosModule = new PartidosModule();
  public elecciones: EleccionesModule = new EleccionesModule();
  private alertas: AlertasModule = new AlertasModule();

  // ARRAYS PARA ENVIAR AL SERVIDOR
  public partidosList: any[] = [];
  public eleccionesList: any[] = [];

  // VARIABLES PARA PUBLICAR LAS FOTOS DE LOS PARTIDOS
  public imgURL: any;
  private formData: FormData;
  private resPic: any;
  public imagePath: any;
  public message: string;

  // VARIABLES PARA PARSEAR LA RESPUESTA DEL SERVIDOR
  private responseServer: any;

  private urlImgPartidoDefault = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";

  // VARIABLES PARA CONSULTAR EL PARTIDO ACTUAL DE LA LISTA DE PARTIDOS
  private consultaPartidoActual: any;
  private resConsultaPartidoActual: any;

  // VARIABLES PARA CONSULTAR LA CONFIGURACION ACTUAL DE LA LISTA DE CONFIGURACIONES
  private consultaConfiguracionActual: any;
  private resConsultaConfiguracionActual: any;

  // MANEJADORES DE ESTADOS DE EDICCIÓN
  private MODO_EDICCION_PARTIDO: boolean;
  private MODO_EDICCION_CONFIGURACION: boolean;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.imgURL = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
    this.MODO_EDICCION_PARTIDO = false;
    this.MODO_EDICCION_CONFIGURACION = false;
  }

  preview(files: any) {
    if (files.length === 0)
      return;

    var mimeType = files[0].type;
    if (mimeType.match(/image\/*/) == null) {
      this.message = "Only images are supported.";
      return;
    }

    var reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      this.imgURL = reader.result;
    }

    this.formData = new FormData();
    this.formData.append('file', files[0]);
    this.formData.append('public_id', files[0].name + "696242651689144");
    this.formData.append('upload_preset', 'filesOple');
    this.apiService.uploadSignature(this.formData).subscribe(
      res => {
        console.log(res);
        this.resPic = res;
      }
    );
  }

  public configurarDatosGenerales() {
    if (this.eleccionesList.length === 0) {
      this.alertas.mensajeAdvertencia("No ha registrado ningún tipo de elección");
      return;
    }
    this.procesos.Elecciones = this.eleccionesList;

    const procesos = {
      "Presidente": this.procesos.Presidente,
      "Secretario": this.procesos.Secretario,
      "PrimerEscrutador": this.procesos.PrimerEscrutador,
      "SegundoEscrutador": this.procesos.SegundoEscrutador,
      "Entidad": this.procesos.Entidad,
      "Distrito": this.procesos.Distrito,
      "Municipio": this.procesos.Municipio,
      "SeccionElectoral": this.procesos.SeccionElectoral.toString(),
      "TipoCasilla": this.procesos.TipoCasilla,
      "CodigoPresidente": this.procesos.CodigoPresidente.toString(),
      "Elecciones": this.procesos.Elecciones
    };

    const datosGenerales = {
      "Categoria": "Procesos locales electorales",
      "Procesos": procesos
    };

    console.log(JSON.stringify(datosGenerales));

    this.apiService.guardarConfiguracion(datosGenerales).subscribe(
      res => {
        console.log(JSON.stringify(res));
        this.responseServer = res;
        this.alertas.mensajeOk(this.responseServer['responseText']);
        this.router.navigateByUrl("/inicio");
      }
    );

    this.procesos = new ProcesoselectoralesModule();
    this.eleccionesList = [];
  }

  public agregarPartidosToList() {
    if (this.resPic) {
      this.partidos.Logotipo = this.resPic["url"];
    } else {
      this.partidos.Logotipo = this.urlImgPartidoDefault;
    }
    const datosPartidos = {
      "Logotipo": this.partidos.Logotipo,
      "Propietario": this.partidos.Propietario,
      "Suplente": this.partidos.Suplente,
      "Hipocoristico": this.partidos.Hipocoristico,
      "Cargo": this.partidos.Cargo,
      "TipoCandidatura": this.partidos.TipoCandidatura
    };

    if (this.MODO_EDICCION_PARTIDO === true) {
      this.partidosList[this.consultaPartidoActual].Propietario = this.partidos.Propietario;
      this.partidosList[this.consultaPartidoActual].Suplente = this.partidos.Suplente;
      this.partidosList[this.consultaPartidoActual].Hipocoristico = this.partidos.Hipocoristico;
      this.partidosList[this.consultaPartidoActual].Cargo = this.partidos.Cargo;
      this.partidosList[this.consultaPartidoActual].TipoCandidatura = this.partidos.TipoCandidatura;
      this.partidosList[this.consultaPartidoActual].Logotipo = this.partidos.Logotipo;

      this.partidos = new PartidosModule();
      this.MODO_EDICCION_PARTIDO = false;
      return;
    }
    this.partidosList.push(datosPartidos);

    console.log(this.partidosList)
    this.partidos = new PartidosModule();
    this.imgURL = this.urlImgPartidoDefault;
    this.partidos.Logotipo = this.imgURL;
  }

  public agregarEleccionesToList() {

    if (this.procesos.Presidente === "") {
      this.alertas.mensajeAdvertencia("Ingres el nombre del presidente");
      return
    }

    if (this.procesos.Secretario === "") {
      this.alertas.mensajeAdvertencia("Ingrese el nombre del secretario");
      return;
    }

    if (this.procesos.PrimerEscrutador === "") {
      this.alertas.mensajeAdvertencia("Ingrese el nombre del primer escrutador");
      return;
    }

    if (this.procesos.SegundoEscrutador === "") {
      this.alertas.mensajeAdvertencia("Ingresa el nombre del segundo escrutador")
      return;
    }

    if (this.procesos.TipoCasilla === "") {
      this.alertas.mensajeAdvertencia("Seleccione un tipo de casilla");
      return;
    }

    if (this.procesos.Entidad === "") {
      this.alertas.mensajeAdvertencia("Ingrese la entidad");
      return;
    }

    if (this.procesos.Distrito === "") {
      this.alertas.mensajeAdvertencia("Ingrese el distrito");
      return;
    }

    if (this.procesos.Municipio === "") {
      this.alertas.mensajeAdvertencia("Ingrese el municipio");
      return;
    }

    if (this.procesos.SeccionElectoral === "") {
      this.alertas.mensajeAdvertencia("Ingrese al sección electoral");
      return;
    }

    if (this.elecciones.TipoEleccion === "") {
      this.alertas.mensajeAdvertencia("Seleccione un tipo de elección");
      return;
    }

    if (this.elecciones.CantidadBoletas === "") {
      this.alertas.mensajeAdvertencia("Ingrese el número de boletas");
      return;
    }

    if (this.elecciones.Folio === "") {
      this.alertas.mensajeAdvertencia("Ingrese el número de boletas");
      return;
    }

    if (this.partidosList.length === 0) {
      this.alertas.mensajeAdvertencia("No ha registrado ningún partido");
      return;
    }

    this.elecciones.Partidos = this.partidosList;
    const datosElecciones = {
      "TipoEleccion": this.elecciones.TipoEleccion,
      "Folio": this.elecciones.Folio.toString(),
      "CantidadBoletas": this.elecciones.CantidadBoletas.toString(),
      "Partidos": this.elecciones.Partidos
    };

    this.eleccionesList.push(datosElecciones);
    console.log(this.eleccionesList);
    this.elecciones = new EleccionesModule();
    this.partidosList = [];
  }

  public editarPartidoAcutal(hipocoristico: string) {
    this.MODO_EDICCION_PARTIDO = true;
    this.consultaPartidoActual = this.partidosList.findIndex(p => p.Hipocoristico === hipocoristico);
    this.resConsultaPartidoActual = this.partidosList[this.consultaPartidoActual];

    this.partidos.Propietario = this.resConsultaPartidoActual["Propietario"];
    this.partidos.Suplente = this.resConsultaPartidoActual["Suplente"];
    this.partidos.Hipocoristico = this.resConsultaPartidoActual["Hipocoristico"];
    this.partidos.Cargo = this.resConsultaPartidoActual["Cargo"];
    this.partidos.Logotipo = this.resConsultaPartidoActual["Logotipo"];
    this.partidos.TipoCandidatura = this.resConsultaPartidoActual["TipoCandidatura"];
    this.imgURL = this.partidos.Logotipo;
  }

  public eliminarPartidoAcutal(hipocoristico: string) {

    Swal.fire({
      title: hipocoristico,
      text: "¿Desea eliminar este partido?",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.consultaPartidoActual = this.partidosList.findIndex(p => p.Hipocoristico === hipocoristico);
        this.resConsultaPartidoActual = this.partidosList[this.consultaPartidoActual];
        this.partidosList.splice(this.partidosList.indexOf(this.resConsultaPartidoActual, 1));
        Swal.fire({
          title: hipocoristico,
          text: "Se ha eliminado el partido seleccionado.",
          icon: "success"
        });
      }
    });
  }

  public cancelarAgregarOEdiccionPartido() {
    this.MODO_EDICCION_PARTIDO = false;
    this.partidos = new PartidosModule();
    this.imgURL = this.urlImgPartidoDefault;
    this.partidos.Logotipo = this.imgURL;
  }

}
