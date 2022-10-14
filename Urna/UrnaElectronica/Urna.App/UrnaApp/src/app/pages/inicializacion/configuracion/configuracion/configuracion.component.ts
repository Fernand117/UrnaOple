import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-configuracion',
  templateUrl: './configuracion.component.html',
  styleUrls: ['./configuracion.component.scss']
})
export class ConfiguracionComponent implements OnInit {

  form: any;

  constructor(private formBuilder: FormBuilder, private route:Router) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm() {
    this.form = this.formBuilder.group({
      codigo_configuracion: ['',[Validators.required]]
    })
  }

  enviar() {
    console.log(this.form.value);
    this.route.navigate(['/boleta-inicializacion']);
  }
}
