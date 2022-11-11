import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class EleccionesModule {
  public TipoEleccion: string;
  public CantidadBoletas: string;
  public Folio: string;
  public Partidos: any[];

  constructor() {
    this.TipoEleccion = "";
    this.CantidadBoletas = "";
    this.Folio = "";
    this.Partidos = [];
  }
}
