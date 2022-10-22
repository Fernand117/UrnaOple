import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PartidosModule } from 'src/app/models/partidos/partidos.module';
import { ApiServiceService } from 'src/app/services/api-service.service';
import { EscolaresModule } from '../../models/escolares/escolares.module';

@Component({
  selector: 'app-escolares',
  templateUrl: './escolares.component.html',
  styleUrls: ['./escolares.component.scss']
})
export class EscolaresComponent implements OnInit {

  public partidos: PartidosModule;
  public escolares: EscolaresModule;
  private formData: FormData;

  private resPic: any;

  public imagePath: any;
  public imgURL: any;
  public message: string;
  public partidosList: any[] = [];
  private resData: any;

  constructor(
    private apiService: ApiServiceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.imgURL = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
  }

  addPartido() {
    this.partidos = new PartidosModule();
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

    this.formData = new FormData();
    this.formData.append('file', files[0]);
    this.formData.append('public_id', files[0].name+"696242651689144");
    this.formData.append('upload_preset', 'filesOple');
    this.apiService.uploadSignature(this.formData).subscribe(
      res => {
        console.log(res);
        this.resPic = res;
      }
    );
  }

  agregarPartidos(){
    this.partidos.Id = 0;
    if (this.resPic) {
      this.partidos.Logotipo = this.resPic["url"];
    } else {
      this.partidos.Logotipo = "https://www.oplever.org.mx/wp-content/uploads/2018/08/logo-ople.jpg";
    }
    this.partidosList.push(this.partidos);

    console.log(this.partidosList);
    this.closeModal();
  }


}
