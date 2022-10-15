import { EleccionesModule } from './../../../models/elecciones/elecciones.module';
import { Component, OnInit } from '@angular/core';
import { PartidosModule } from 'src/app/models/partidos/partidos.module';
import { ApiServiceService } from '../../../services/api-service.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  public partidos: PartidosModule;
  public elecciones: EleccionesModule = new EleccionesModule();
  private formData: FormData;

  private resPic: any;

  public imagePath: any;
  public imgURL: any;
  public message: string;
  public partidosList: any[] = [];
  private resData: any;

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
    this.formData.append('public_id', files[0].name+"696242651689144");
    this.formData.append('upload_preset', 'filesOple');
    this.apiService.uploadSignature(this.formData).subscribe(
      res => {
        console.log(res);
        this.resPic = res;
      }
    );
  }

  agregarPartidos(){
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

  guardarConfiguracion() {
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

    let json = JSON.stringify(datos);
    console.log(datos)
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

}
