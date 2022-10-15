import { Component, OnInit } from '@angular/core';
import { MecanismosModule } from '../../models/mecanismos/mecanismos.module';
import { PreguntasModule } from '../../models/preguntas/preguntas.module';

@Component({
  selector: 'app-mecanismosadmin',
  templateUrl: './mecanismosadmin.component.html',
  styleUrls: ['./mecanismosadmin.component.scss']
})
export class MecanismosadminComponent implements OnInit {

  public mecanismos: MecanismosModule = new MecanismosModule();
  public listaPreguntas: any[] = [];
  public pregunta: PreguntasModule;

  constructor() { }

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

  guardarConfiguracion() {
    const datos = {
      "TipoMecanismo": this.mecanismos.TipoMecanismo,
      "NombreMecanismo": this.mecanismos.Nombre,
      "ObjetoMecanismo": this.mecanismos.Objeto,
      "Preguntas": this.listaPreguntas,
      "CantidadBoletas": this.mecanismos.CantidadBoletas,
      "Presidente": this.mecanismos.Presidente,
      "Secretario": this.mecanismos.Secretario,
      "PrimerEscrutador": this.mecanismos.PrimerEscrutador,
      "SegundoEscrutador": this.mecanismos.SegundoEscrutador,
      "Entidad": this.mecanismos.Entidad,
      "Distrito": this.mecanismos.Distrito,
      "Municipio": this.mecanismos.Municipio,
      "Seccion": this.mecanismos.Seccion,
      "Firmas": this.mecanismos.Firmas,
      "Folio": this.mecanismos.Folio
    }

    let json = JSON.stringify(datos)
    console.log(json)
  }
}
