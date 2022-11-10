import {EleccionesModule} from './../../../models/elecciones/elecciones.module';
import {Component, OnInit} from '@angular/core';
import {PartidosModule} from 'src/app/models/partidos/partidos.module';
import {ApiServiceService} from '../../../services/api-service.service';
import Swal from 'sweetalert2';
import {Router} from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  public partidos: PartidosModule = new PartidosModule();
  public partidosUpdate: PartidosModule = new PartidosModule();

  public elecciones: EleccionesModule = new EleccionesModule();
  public eleccionesUpdate: EleccionesModule = new EleccionesModule();

  private formData: FormData;

  private resPic: any;

  public imagePath: any;
  public imgURL: any;
  public message: string;

  public partidosList: any[] = [];
  public partidosListUpdate: any[] = [];

  public eleccionesList: any[] = [];

  private resData: any;

  private urlImgPartidoDefault = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
  private contador: number;

  private modoEdiccion: boolean;
  private modoEdiccionPartido: boolean;
  private modoEdiccionPartidoActual: boolean;

  private foundEleccion: any;
  private resFoundEleccion: any;

  private foundPartido: any;
  private resFoundPartido: any;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.imgURL = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
    this.contador = 0;
    this.modoEdiccion = false;
    this.modoEdiccionPartidoActual = false;
    this.modoEdiccionPartido = false;
  }

  addPartido() {
    this.partidosUpdate = new PartidosModule();
    this.partidos = new PartidosModule();
    var modal = document.getElementById("formPartidos");
    modal!.style.display = "block";
    modal!.style.zIndex = "200";
  }

  editEleccionModal() {
    this.modoEdiccion = true;
    this.modoEdiccionPartido = true;
    var modal = document.getElementById("formElecciones");
    modal!.style.display = "block";
  }

  editPartidoModel() {
    this.modoEdiccion = true;
    this.partidosUpdate = new PartidosModule();
    var modal = document.getElementById("formPartidosU");
    modal!.style.display = "block";
    modal!.style.zIndex = "100";
  }

  closePartidoModal() {
    var modal = document.getElementById("formPartidosU");
    modal!.style.display = "none";
  }

  closeEleccionModal() {
    var modal = document.getElementById("formElecciones");
    modal!.style.display = "none";
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

    if (this.modoEdiccionPartido === true) {
      this.partidosListUpdate[this.foundPartido].Propietario = this.partidosUpdate.Propietario;
      this.partidosListUpdate[this.foundPartido].Suplente = this.partidosUpdate.Suplente;
      this.partidosListUpdate[this.foundPartido].Hipocoristico = this.partidosUpdate.Hipocoristico;
      this.partidosListUpdate[this.foundPartido].Cargo = this.partidosUpdate.Cargo;
      this.partidosListUpdate[this.foundPartido].TipoCandidatura = this.partidosUpdate.TipoCandidatura;
      this.partidosListUpdate[this.foundPartido].Logotipo = this.partidosUpdate.Logotipo;

      console.log(this.partidosListUpdate[this.foundPartido]);

      var modal = document.getElementById("formPartidosU");
      modal!.style.display = "none";
      this.modoEdiccionPartido = false;
      this.mensajeSwalSuccess("Partido actualizado correctamente");
      return;
    }

    if (this.modoEdiccionPartidoActual === true) {
      this.partidosList[this.foundPartido].Propietario = this.partidos.Propietario;
      this.partidosList[this.foundPartido].Suplente = this.partidos.Suplente;
      this.partidosList[this.foundPartido].Hipocoristico = this.partidos.Hipocoristico;
      this.partidosList[this.foundPartido].Cargo = this.partidos.Cargo;
      this.partidosList[this.foundPartido].TipoCandidatura = this.partidos.TipoCandidatura;
      this.partidosList[this.foundPartido].Logotipo = this.partidos.Logotipo;

      console.log(this.partidosList[this.foundPartido]);

      var modal = document.getElementById("formPartidos");
      modal!.style.display = "none";
      this.modoEdiccionPartidoActual = false;
      this.mensajeSwalSuccess("Partido actualizado correctamente");
      return;
    }

    if (this.modoEdiccion === true) {
      console.log("updating....")

      if (this.resPic) {
        this.partidos.Logotipo = this.resPic["url"];
      } else {
        this.partidos.Logotipo = this.urlImgPartidoDefault;
      }

      if (this.partidos.Propietario === "" || this.partidos.Propietario === null) {
        this.mensajeSwal("Ingrese el nombre del propietario.");
        return;
      }

      if (this.partidos.Suplente === "" || this.partidos.Suplente === null) {
        this.mensajeSwal("Ingrese el nombre del suplente.");
        return;
      }

      if (this.partidos.Hipocoristico === "" || this.partidos.Hipocoristico === null) {
        this.mensajeSwal("Ingrese el hipocoristico.");
        return;
      }

      if (this.partidos.Cargo === "" || this.partidos.Cargo === null) {
        this.mensajeSwal("Ingrese el nombre del cargo.");
        return;
      }

      if (this.partidos.TipoCandidatura === "" || this.partidos.TipoCandidatura === null) {
        this.mensajeSwal("Seleccione el tipo de candidatura.");
        return;
      }

      if (this.partidos.Logotipo === "" || this.partidos.Logotipo === this.urlImgPartidoDefault) {
        this.mensajeSwal("Seleccione el logotipo del partido");
        return;
      }

      this.partidosListUpdate.push(this.partidos);
      this.closeModal();
      this.mensajeSwalSuccess("Partido registrado correctamente");
      return;
    }

    this.partidos.Id = 0;
    if (this.resPic) {
      this.partidos.Logotipo = this.resPic["url"];
    } else {
      this.partidos.Logotipo = this.urlImgPartidoDefault;
    }

    if (this.partidos.Propietario === "" || this.partidos.Propietario === null) {
      this.mensajeSwal("Ingrese el nombre del propietario.");
      return;
    }

    if (this.partidos.Suplente === "" || this.partidos.Suplente === null) {
      this.mensajeSwal("Ingrese el nombre del suplente.");
      return;
    }

    if (this.partidos.Hipocoristico === "" || this.partidos.Hipocoristico === null) {
      this.mensajeSwal("Ingrese el hipocoristico.");
      return;
    }

    if (this.partidos.Cargo === "" || this.partidos.Cargo === null) {
      this.mensajeSwal("Ingrese el nombre del cargo.");
      return;
    }

    if (this.partidos.TipoCandidatura === "" || this.partidos.TipoCandidatura === null) {
      this.mensajeSwal("Seleccione el tipo de candidatura.");
      return;
    }

    if (this.partidos.Logotipo === "" || this.partidos.Logotipo === this.urlImgPartidoDefault) {
      this.mensajeSwal("Seleccione el logotipo del partido");
      return;
    }

    this.partidosList.push(this.partidos);

    this.mensajeSwalSuccess("Partido registrado correctamente");

    console.log(this.partidosList);
    this.closeModal();
  }

  agregarConfiguracion() {

    if (this.modoEdiccion === true) {
      this.eleccionesList[this.foundEleccion].TipoEleccion = this.eleccionesUpdate.tipoEleccion;
      this.eleccionesList[this.foundEleccion].Presidente = this.eleccionesUpdate.presidente;
      this.eleccionesList[this.foundEleccion].Secretario = this.eleccionesUpdate.secretario;
      this.eleccionesList[this.foundEleccion].PrimerEscrutador = this.eleccionesUpdate.primerEscrutador;
      this.eleccionesList[this.foundEleccion].SegundoEscrutador = this.eleccionesUpdate.segundoEscrutador;
      this.eleccionesList[this.foundEleccion].CantidadBoletas = this.eleccionesUpdate.nBoletas.toString();
      this.eleccionesList[this.foundEleccion].Entidad = this.eleccionesUpdate.entidad;
      this.eleccionesList[this.foundEleccion].Distrito = this.eleccionesUpdate.distrito;
      this.eleccionesList[this.foundEleccion].Municipio = this.eleccionesUpdate.municipio;
      this.eleccionesList[this.foundEleccion].SeccionElectoral = this.eleccionesUpdate.seccion.toString();
      this.eleccionesList[this.foundEleccion].TipoCasilla = this.eleccionesUpdate.tipoCasilla;
      this.eleccionesList[this.foundEleccion].Folio = this.eleccionesUpdate.folio.toString();
      this.eleccionesList[this.foundEleccion].Partidos = this.partidosListUpdate;

      console.log(this.eleccionesList[this.foundEleccion]);

      var modal = document.getElementById("formElecciones");
      modal!.style.display = "none";
      this.modoEdiccion = false;
      this.modoEdiccionPartido = false;
      this.modoEdiccionPartidoActual = false;
    } else {

      if (this.elecciones.tipoEleccion === "" || this.elecciones.tipoEleccion === null) {
        this.mensajeSwal("Seleccione un tipo de proceso electoral.");
        return;
      }

      if (this.elecciones.presidente === "" || this.elecciones.presidente === null) {
        this.mensajeSwal("Ingrese el nombre del presidente.");
        return;
      }

      if (this.elecciones.secretario === "" || this.elecciones.secretario === null) {
        this.mensajeSwal("Ingrese el nombre del secretario.");
        return;
      }

      if (this.elecciones.primerEscrutador === "" || this.elecciones.primerEscrutador === null) {
        this.mensajeSwal("Ingrese el nombre del primer escrutador.");
        return;
      }

      if (this.elecciones.segundoEscrutador === "" || this.elecciones.segundoEscrutador === null) {
        this.mensajeSwal("Ingrese el nombre del segundo escrutador.");
        return;
      }

      if (this.elecciones.nBoletas === "" || this.elecciones.nBoletas === null || this.elecciones.nBoletas === "0") {
        this.mensajeSwal("Ingrese un número de boletas mayor a cero.");
        return;
      }

      if (this.elecciones.tipoCasilla === "" || this.elecciones.tipoCasilla === null) {
        this.mensajeSwal("Ingrese el tipo de casilla.");
        return;
      }

      if (this.elecciones.entidad === "" || this.elecciones.entidad === null) {
        this.mensajeSwal("Ingrese la entidad.");
        return;
      }

      if (this.elecciones.distrito === "" || this.elecciones.distrito === null) {
        this.mensajeSwal("Ingrese el distrito.");
        return;
      }

      if (this.elecciones.municipio === "" || this.elecciones.municipio === null) {
        this.mensajeSwal("Ingrese el municipio.");
        return;
      }

      if (this.elecciones.seccion === "" || this.elecciones.seccion === null) {
        this.mensajeSwal("Ingrese la sección electoral.");
        return;
      }

      if (this.elecciones.folio === "" || this.elecciones.folio === null) {
        this.mensajeSwal("Ingrese el número de folio.");
        return;
      }

      if (this.partidosList.length === 0 || this.partidosList === []) {
        this.mensajeSwal("Registre al menos un partido.");
        return;
      }

      const datos = {
        "Id": 0,
        "TipoEleccion": this.elecciones.tipoEleccion,
        "Presidente": this.elecciones.presidente,
        "Secretario": this.elecciones.secretario,
        "PrimerEscrutador": this.elecciones.primerEscrutador,
        "SegundoEscrutador": this.elecciones.segundoEscrutador,
        "CantidadBoletas": this.elecciones.nBoletas.toString(),
        "Entidad": this.elecciones.entidad,
        "Distrito": this.elecciones.distrito,
        "Municipio": this.elecciones.municipio,
        "SeccionElectoral": this.elecciones.seccion.toString(),
        "TipoCasilla": this.elecciones.tipoCasilla,
        "Folio": this.elecciones.folio.toString(),
        "Partidos": this.partidosList
      }
      this.eleccionesList.push(datos);
    }

    let jsonRes = JSON.stringify(this.eleccionesList);
    this.contador = 1;
    console.log(jsonRes);

    this.mensajeSwalSuccess("Configuración de " + this.elecciones.tipoEleccion + " guardada correctamente.");

    this.elecciones = new EleccionesModule();
    this.partidos = new PartidosModule();
    this.partidosList = [];
  }

  guardarConfiguracion() {

    if (this.contador === 0) {
      this.mensajeSwal("No tiene al menos 1 tipo de proceso electoral configurado.")
      return;
    }

    const datos = {
      "Id": 0,
      "Categoria": "Procesos locales electorales",
      "Elecciones": this.eleccionesList
    }

    let json = JSON.stringify(datos);
    console.log(json)

    this.apiService.guardarConfiguracion(json).subscribe(
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

  private mensajeSwal(mensaje: string): void {
    Swal.fire({
      title: "Advertencia",
      icon: "warning",
      text: mensaje
    });
  }

  private mensajeSwalSuccess(mensaje: string): void {
    Swal.fire({
      title: "Advertencia",
      icon: "success",
      text: mensaje
    });
  }

  public editEleccion(tipo: string): void {
    this.editEleccionModal();

    this.modoEdiccion = true;
    this.foundEleccion = this.eleccionesList.findIndex(e => e.TipoEleccion === tipo);
    this.resFoundEleccion = this.eleccionesList[this.foundEleccion];

    this.eleccionesUpdate.tipoEleccion = this.resFoundEleccion["TipoEleccion"];
    this.eleccionesUpdate.presidente = this.resFoundEleccion["Presidente"];
    this.eleccionesUpdate.secretario = this.resFoundEleccion["Secretario"];
    this.eleccionesUpdate.primerEscrutador = this.resFoundEleccion["PrimerEscrutador"];
    this.eleccionesUpdate.segundoEscrutador = this.resFoundEleccion["SegundoEscrutador"];
    this.eleccionesUpdate.nBoletas = this.resFoundEleccion["CantidadBoletas"];
    this.eleccionesUpdate.entidad = this.resFoundEleccion["Entidad"];
    this.eleccionesUpdate.distrito = this.resFoundEleccion["Distrito"];
    this.eleccionesUpdate.municipio = this.resFoundEleccion["Municipio"];
    this.eleccionesUpdate.seccion = this.resFoundEleccion["SeccionElectoral"];
    this.eleccionesUpdate.tipoCasilla = this.resFoundEleccion["TipoCasilla"];
    this.eleccionesUpdate.folio = this.resFoundEleccion["Folio"];

    this.partidosListUpdate = this.resFoundEleccion["Partidos"];
    console.log(this.resFoundEleccion);
    console.log(this.resFoundEleccion["Partidos"]);
  }

  public editPartido(propietario: string): void {

    this.modoEdiccionPartido = true;

    this.editPartidoModel();
    this.foundPartido = this.partidosListUpdate.findIndex(p => p.Propietario === propietario);
    this.resFoundPartido = this.partidosListUpdate[this.foundPartido];

    this.partidosUpdate.Propietario = this.resFoundPartido["Propietario"];
    this.partidosUpdate.Suplente = this.resFoundPartido["Suplente"];
    this.partidosUpdate.Cargo = this.resFoundPartido["Cargo"];
    this.partidosUpdate.Hipocoristico = this.resFoundPartido["Hipocoristico"];
    this.partidosUpdate.TipoCandidatura = this.resFoundPartido["TipoCandidatura"];
    this.partidosUpdate.Logotipo = this.resFoundPartido["Logotipo"];

    console.log(this.resFoundPartido);
  }

  public editPartidoActual(propietario: string): void {
    this.addPartido();
    this.modoEdiccionPartidoActual = true;
    this.foundPartido = this.partidosList.findIndex(p => p.Propietario === propietario);
    this.resFoundPartido = this.partidosList[this.foundPartido];

    this.partidos.Propietario = this.resFoundPartido["Propietario"];
    this.partidos.Suplente = this.resFoundPartido["Suplente"];
    this.partidos.Cargo = this.resFoundPartido["Cargo"];
    this.partidos.Hipocoristico = this.resFoundPartido["Hipocoristico"];
    this.partidos.TipoCandidatura = this.resFoundPartido["TipoCandidatura"];
    this.partidos.Logotipo = this.resFoundPartido["Logotipo"];

    console.log(this.resFoundPartido);
  }

  deletePartidoEdit(propietario: string) {
    this.foundPartido = this.partidosListUpdate.findIndex(p => p.Propietario === propietario);
    this.resFoundPartido = this.partidosListUpdate[this.foundPartido];
    this.partidosListUpdate.splice(this.partidosListUpdate.indexOf(this.resFoundPartido), 1);
    console.log(this.partidosListUpdate);
    this.modoEdiccionPartido = false;
  }

  deletePartidoActual(propietario: string) {
    console.log(propietario)
    this.foundPartido = this.partidosList.findIndex(p => p.Propietario === propietario);
    this.resFoundPartido = this.partidosList[this.foundPartido];
    console.log(this.partidosList.indexOf(this.resFoundPartido))
    this.partidosList.splice(this.partidosList.indexOf(this.resFoundPartido), 1);
    console.log(this.partidosList)
  }

}
