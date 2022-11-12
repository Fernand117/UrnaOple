import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class MecanismosModule {
  public Presidente: string;
  public Secretario: string;
  public PrimerEscrutador: string;
  public SegundoEscrutador: string;
  public Entidad: string;
  public Distrito: string;
  public Municipio: string;
  public Seccion: string;
  public TipoMecanismos: any[];

  constructor() {
    this.Presidente = "";
    this.Secretario = "";
    this.PrimerEscrutador = "";
    this.SegundoEscrutador = "";
    this.Entidad = "";
    this.Distrito = "";
    this.Municipio = "";
    this.Seccion = "";
    this.TipoMecanismos = [];
  }
}
