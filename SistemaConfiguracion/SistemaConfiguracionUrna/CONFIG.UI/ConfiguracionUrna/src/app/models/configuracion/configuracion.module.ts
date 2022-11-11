import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ProcesoselectoralesModule} from "../procesoselectorales/procesoselectorales.module";
import any = jasmine.any;



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ConfiguracionModule {
  public Categoria: string;
  public Procesos: any;

  constructor() {
    this.Categoria = "";
    this.Procesos = any;
  }
}
