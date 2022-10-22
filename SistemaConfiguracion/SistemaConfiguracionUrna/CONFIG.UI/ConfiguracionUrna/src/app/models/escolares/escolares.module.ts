import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class EscolaresModule {
  public presidente: string;
  public secretario: string;
  public primerEscrutador: string;
  public segundoEscrutador: string;
  public nBoletas: string;
  public nombreInstitucion: string;
  public partidos: any[];
}
