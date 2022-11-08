import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-no-boletas',
  templateUrl: './no-boletas.component.html',
  styleUrls: ['./no-boletas.component.scss']
})
export class NoBoletasComponent implements OnInit {

  constructor(private route:Router) {}

  ngOnInit(): void {
  }

  clausurar() {
    this.route.navigate(['/clausura']);
  }

}
