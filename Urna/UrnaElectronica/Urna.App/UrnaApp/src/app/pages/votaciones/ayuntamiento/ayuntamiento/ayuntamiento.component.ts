import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-ayuntamiento',
  templateUrl: './ayuntamiento.component.html',
  styleUrls: ['./ayuntamiento.component.scss']
})
export class AyuntamientoComponent implements OnInit {

  @Output() miEvento = new EventEmitter<boolean>();
  voto: boolean = false;

  @Input() partidos: any;
  app_name: string = "ayuntamiento";

  constructor() { }

  ngOnInit(): void { }

  getVoto(e: any) {
    this.voto = e;
    this.miEvento.emit(this.voto);
  }

}
