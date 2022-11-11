import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ProcesoselectoralesModule {
  public Presidente: string;
  public Secretario: string;
  public PrimerEscrutador: string;
  public SegundoEscrutador: string;
  public Entidad: string;
  public Distrito: string;
  public Municipio: string;
  public SeccionElectoral: string;
  public TipoCasilla: string;
  public CodigoPresidente: string;
  public Elecciones: any[];

  constructor() {
    this.Presidente = "";
    this.Secretario = "";
    this.PrimerEscrutador = "";
    this.SegundoEscrutador = "";
    this.Entidad = "";
    this.Distrito = "";
    this.Municipio = "";
    this.SeccionElectoral = "";
    this.TipoCasilla = "";
    this.CodigoPresidente = "";
    this.Elecciones = [];
  }
}
