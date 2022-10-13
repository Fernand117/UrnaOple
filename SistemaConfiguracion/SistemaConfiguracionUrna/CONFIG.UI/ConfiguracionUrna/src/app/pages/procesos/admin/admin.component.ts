import { EleccionesModule } from './../../../models/elecciones/elecciones.module';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PartidosModule } from 'src/app/models/partidos/partidos.module';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  public partidos: PartidosModule = new PartidosModule();
  public elecciones: EleccionesModule = new EleccionesModule();

  public imagePath: any;
  imgURL: any;
  public message: string;
  public partidosList: any[] = [];
  //myForm: FormGroup;

  constructor(
  ) {
  }

  ngOnInit(): void {
  }

  addPartido() {
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
  }


  agregarPartidos(){
    this.partidosList.push(this.partidos);
    console.log(this.partidosList);
  }

  guardarConfiguracion() {
    const datos = {
      "TipoEleccion": this.elecciones.tipoEleccion,
      "Presidente": this.elecciones.presidente,
      "Secretario": this.elecciones.secretario,
      "PrimerEscrutador": this.elecciones.primerEscrutador,
      "SegundoEscrutador": this.elecciones.segundoEscrutador,
      "CantidadBoletas": this.elecciones.nBoletas,
      "Entidad": this.elecciones.entidad,
      "Distrito": this.elecciones.distrito,
      "Municipio": this.elecciones.municipio,
      "SeccionElectoral": this.elecciones.seccion,
      "TipoCasilla": this.elecciones.tipoCasilla,
      "Folio": this.elecciones.folio,
      "Partidos": this.partidosList
    }

    let json = JSON.stringify(datos);
    console.log(datos)
    console.log(json)
  }

}
