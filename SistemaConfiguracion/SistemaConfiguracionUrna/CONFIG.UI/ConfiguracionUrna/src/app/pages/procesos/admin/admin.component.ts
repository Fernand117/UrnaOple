import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  public imagePath: any;
  imgURL: any;
  public message: string;
  //myForm: FormGroup;

  constructor(
  ) {
  }

  ngOnInit(): void {
  }

  addPartido() {
    var modal = document.getElementById("formPartidos");
    modal!.style.display = "block";
  }

  closeModal() {
    var modal = document.getElementById("formPartidos");
    modal!.style.display = "none";
  }

  preview(files: any) {
    if (files.length === 0)
      return;

    var mimeType = files[0].type;
    if (mimeType.match(/image\/*/) == null) {
      this.message = "Only images are supported.";
      return;
    }

    var reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      this.imgURL = reader.result;
    }
  }

}
