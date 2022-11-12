import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {PartidosModule} from 'src/app/models/partidos/partidos.module';
import {ApiServiceService} from 'src/app/services/api-service.service';
import {EscolaresModule} from '../../models/escolares/escolares.module';
import Swal from "sweetalert2";
import {AlertasModule} from "../../components/alertas/alertas.module";

@Component({
  selector: 'app-escolares',
  templateUrl: './escolares.component.html',
  styleUrls: ['./escolares.component.scss']
})
export class EscolaresComponent implements OnInit {

  public partidos: PartidosModule = new PartidosModule();
  public escolares: EscolaresModule = new EscolaresModule();

  public partidosUpdate: PartidosModule = new PartidosModule();
  public escolaresUpdate: EscolaresModule = new EscolaresModule();

  private alertas: AlertasModule = new AlertasModule();

  private formData: FormData;

  private resPic: any;

  public imagePath: any;
  public imgURL: any;
  private urlImgPartidoDefault = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
  public message: string;

  public partidosList: any[] = [];
  public escolaresList: any[] = [];

  private resData: any;

  private consultaPartido: any;
  private resConsultaPartido: any;

  // VARIABLES PARA CONSULTAR EL PARTIDO ACTUAL DE LA LISTA DE PARTIDOS
  private consultaPartidoActual: any;
  private resConsultaPartidoActual: any;

  // MANEJADORES DE ESTADOS DE EDICCIÓN
  private MODO_EDICCION_PARTIDO: boolean;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.imgURL = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
    this.partidos.Logotipo = this.urlImgPartidoDefault;
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

  agregarPartidos() {

    if (this.resPic) {
      this.partidos.Logotipo = this.resPic["url"];
    }

    if (this.MODO_EDICCION_PARTIDO === true) {
      this.partidosList[this.consultaPartido].Propietario = this.partidos.Propietario;
      this.partidosList[this.consultaPartido].Suplente = this.partidos.Suplente;
      this.partidosList[this.consultaPartido].Hipocoristico = this.partidos.Hipocoristico;
      this.partidosList[this.consultaPartido].Cargo = this.partidos.Cargo;
      this.partidosList[this.consultaPartido].TipoCandidatura = this.partidos.TipoCandidatura;

      if (this.resPic) {
        this.partidosList[this.consultaPartido].Logotipo = this.resPic["url"];
      }
      else {
        this.partidosList[this.consultaPartido].Logotipo = this.partidos.Logotipo;
      }

      this.partidos = new PartidosModule();
      this.imgURL = this.urlImgPartidoDefault;
      this.partidos.Logotipo = this.imgURL;
      this.MODO_EDICCION_PARTIDO = false;
      return;
    }

    if (this.partidos.Propietario === "") {
      return this.alertas.mensajeError("Ingrese el nombre del propietario");
    }

    if (this.partidos.Suplente === "") {
      return this.alertas.mensajeError("Ingrese el nombre del suplente");
    }

    if (this.partidos.Hipocoristico === "") {
      return this.alertas.mensajeError("Ingrese el hipocoristico");
    }

    if (this.partidos.Cargo === "") {
      return this.alertas.mensajeError("Ingrese el cargo");
    }

    if (this.partidos.TipoCandidatura === "") {
      return this.alertas.mensajeError("No ha seleccionado el tipo de candidatura");
    }

    const datosPartidos = {
      "Logotipo": this.partidos.Logotipo,
      "Propietario": this.partidos.Propietario,
      "Suplente": this.partidos.Suplente,
      "Hipocoristico": this.partidos.Hipocoristico,
      "Cargo": this.partidos.Cargo,
      "TipoCandidatura": this.partidos.TipoCandidatura
    };

    this.partidosList.push(datosPartidos);

    console.log(this.partidosList)
    this.partidos = new PartidosModule();

    this.imgURL = this.urlImgPartidoDefault;
    this.partidos.Logotipo = this.imgURL;
    this.resPic["url"] = this.partidos.Logotipo;
  }

  agregarConfiguracion() {

    if (this.escolares.presidente === "") {
      this.mensajeAdvertencia("Ingrese el nombre del presidente");
      return;
    }

    if (this.escolares.codigo === "") {
      return this.alertas.mensajeError("Ingrese el código RFID del presidente");
    }

    if (this.escolares.secretario === "") {
      this.mensajeAdvertencia("Ingrese el nombre del secretario");
      return;
    }

    if (this.escolares.primerEscrutador === "") {
      this.mensajeAdvertencia("Ingrese el nombre del primer escrutador");
      return;
    }

    if (this.escolares.segundoEscrutador === "") {
      this.mensajeAdvertencia("Ingrese el nombre del segundo escrutador");
      return;
    }

    if (this.escolares.nombreInstitucion === "") {
      this.mensajeAdvertencia("Ingrese el nombre de la institución");
      return;
    }

    if (this.escolares.nBoletas === "") {
      this.mensajeAdvertencia("Ingrese el número de boletas");
      return;
    }

    if (this.partidosList.length === 0) {
      this.mensajeAdvertencia("Aún no hay ningún candidato registrado");
      return;
    }

    const datos = {
      "Presidente": this.escolares.presidente,
      "Secretario": this.escolares.secretario,
      "PrimerEscrutador": this.escolares.primerEscrutador,
      "SegundoEscrutador": this.escolares.segundoEscrutador,
      "NombreInstitucion": this.escolares.nombreInstitucion,
      "CantidadBoletas": this.escolares.nBoletas.toString(),
      "CodigoPresidente": this.escolares.codigo.toString(),
      "Partidos": this.partidosList
    };
    this.escolaresList.push(datos);
    let jsonRes = JSON.stringify(this.escolaresList);
    console.log(jsonRes)
    this.escolares = new EscolaresModule();
    this.partidos = new PartidosModule();
    this.partidosList = [];
  }

  guardarConfiguracion() {

    this.agregarConfiguracion();

    if (this.escolaresList.length === 0) {
      return this.alertas.mensajeError("Aún no hay ninguna elección escolar configurada");
    }

    const datos = {
      "Id": 0,
      "Categoria": "Elecciones escolares",
      "Escolares": this.escolaresList
    };

    let json = JSON.stringify(datos);

    console.log(json)

    this.apiService.guardarEscolares(json).subscribe(
      res => {
        this.resData = res;
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

  private mensajeAdvertencia(mensaje: string) {
    Swal.fire({
      title: "Advertencia",
      text: mensaje,
      icon: "warning"
    });
  }

  public editarPartidoActual(propietario: string) {
    this.MODO_EDICCION_PARTIDO = true;
    this.consultaPartido = this.partidosList.findIndex(p => p.Propietario === propietario);
    this.resConsultaPartido = this.partidosList[this.consultaPartido];

    this.partidos.Propietario = this.resConsultaPartido["Propietario"];
    this.partidos.Suplente = this.resConsultaPartido["Suplente"];
    this.partidos.Hipocoristico = this.resConsultaPartido["Hipocoristico"];
    this.partidos.Cargo = this.resConsultaPartido["Cargo"];
    this.partidos.TipoCandidatura = this.resConsultaPartido["TipoCandidatura"];
    this.partidos.Logotipo = this.resConsultaPartido["Logotipo"];
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
