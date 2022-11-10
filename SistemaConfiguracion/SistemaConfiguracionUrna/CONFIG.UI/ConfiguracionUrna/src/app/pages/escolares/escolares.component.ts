import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {PartidosModule} from 'src/app/models/partidos/partidos.module';
import {ApiServiceService} from 'src/app/services/api-service.service';
import {EscolaresModule} from '../../models/escolares/escolares.module';
import Swal from "sweetalert2";

@Component({
  selector: 'app-escolares',
  templateUrl: './escolares.component.html',
  styleUrls: ['./escolares.component.scss']
})
export class EscolaresComponent implements OnInit {

  public partidos: PartidosModule;
  public escolares: EscolaresModule = new EscolaresModule();

  public partidosUpdate: PartidosModule = new PartidosModule();
  public escolaresUpdate: EscolaresModule = new EscolaresModule();

  private formData: FormData;

  private resPic: any;

  public imagePath: any;
  public imgURL: any;
  public message: string;

  public partidosList: any[] = [];
  public escolaresList: any[] = [];

  public partidosListUpdate: any[] = [];

  private resData: any;

  private consultaInstitucion: any;
  private resConsultaInstitucion: any;

  private consultaPartido: any;
  private resConsultaPartido: any;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.imgURL = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
  }

  addPartido() {
    this.partidos = new PartidosModule();
    var modal = document.getElementById("formPartidos");
    modal!.style.display = "block";
  }

  closeModal() {
    var modal = document.getElementById("formPartidos");
    modal!.style.display = "none";
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
    this.partidos.Id = 0;
    if (this.resPic) {
      this.partidos.Logotipo = this.resPic["url"];
    } else {
      this.partidos.Logotipo = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
    }
    this.partidosList.push(this.partidos);

    console.log(this.partidosList);
    this.closeModal();
  }

  agregarConfiguracion() {

    if (this.escolares.presidente === "") {
      this.mensajeAdvertencia("Ingrese el nombre del presidente");
      return;
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

  public editarConfiguracionActual(institucion: string) {
    this.consultaInstitucion = this.escolaresList.findIndex(e => e.nombreInstitucion === institucion);
    this.resConsultaInstitucion = this.escolaresList[this.consultaInstitucion];

    this.escolaresUpdate.presidente = this.resConsultaInstitucion["Presidente"];
    this.escolaresUpdate.secretario = this.resConsultaInstitucion["Secretario"];
    this.escolaresUpdate.primerEscrutador = this.resConsultaInstitucion["PrimerEscrutador"];
    this.escolaresUpdate.segundoEscrutador = this.resConsultaInstitucion["SegundoEscrutador"];
    this.escolaresUpdate.nombreInstitucion = this.resConsultaInstitucion["NombreInstitucion"];
    this.escolaresUpdate.nBoletas = this.resConsultaInstitucion["CantidadBoletas"]
    this.partidosListUpdate = this.resConsultaInstitucion["Partidos"];
  }

  public guardarConfiguracionUpdate() {

  }

  public editarPartidoActual(propietario: string) {
    this.consultaPartido = this.partidosList.findIndex(p => p.Propietario === propietario);
    this.resConsultaPartido = this.partidosList[this.consultaPartido];

    this.partidosUpdate.Propietario = this.resConsultaPartido["Propietario"];
    this.partidosUpdate.Suplente = this.resConsultaPartido["Suplente"];
    this.partidosUpdate.Hipocoristico = this.resConsultaPartido["Hipocoristico"];
    this.partidosUpdate.Cargo = this.resConsultaPartido["Cargo"];
    this.partidosUpdate.TipoCandidatura = this.resConsultaPartido["TipoCandidatura"];
    this.partidosUpdate.Logotipo = this.resConsultaPartido["Logotipo"];
  }

  public editarPartidoUpdate(propietario: string) {
    this.consultaPartido = this.partidosListUpdate.findIndex(p => p.Propietario === propietario);
    this.resConsultaPartido = this.partidosListUpdate[this.consultaPartido];

    this.partidosUpdate.Propietario = this.resConsultaPartido["Propietario"];
    this.partidosUpdate.Suplente = this.resConsultaPartido["Suplente"];
    this.partidosUpdate.Hipocoristico = this.resConsultaPartido["Hipocoristico"];
    this.partidosUpdate.Cargo = this.resConsultaPartido["Cargo"];
    this.partidosUpdate.TipoCandidatura = this.resConsultaPartido["TipoCandidatura"];
    this.partidosUpdate.Logotipo = this.resConsultaPartido["Logotipo"];
  }

}
