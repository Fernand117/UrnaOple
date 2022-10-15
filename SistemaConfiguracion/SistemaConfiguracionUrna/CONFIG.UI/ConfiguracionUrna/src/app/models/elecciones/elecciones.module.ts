import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class EleccionesModule {
  public presidente: string;
  public secretario: string;
  public primerEscrutador: string;
  public segundoEscrutador: string;
  public nBoletas: string;
  public entidad: string;
  public tipoEleccion: string;
  public distrito: string;
  public municipio: string;
  public seccion: string;
  public tipoCasilla: string;
  public folio: string;
  public partidos: any[];
}
