import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-espera-elector',
  templateUrl: './espera-elector.component.html',
  styleUrls: ['./espera-elector.component.scss']
})
export class EsperaElectorComponent implements OnInit {

  categoria = localStorage.getItem('categoria');

  constructor(private route:Router) { }

  ngOnInit(): void { }

  siguiente_elector() {
    switch (this.categoria) {
      case 'Elecciones escolares':
        this.route.navigate(['/elecciones-escolares']);
        break;
      case 'Mecanismos de participación ciudadana':
        this.route.navigate(['/participacion-ciudadana']);
        break;
      default: 
      this.route.navigate(['/votaciones']);
        break;
    }
  }
}
