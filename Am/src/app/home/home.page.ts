import { Component, ViewChild } from '@angular/core';
import { IonModal } from '@ionic/angular';
import * as L from 'leaflet';
import { WebPointService } from '../services/webpoint.service';
import { WebPoint } from '../interfaces/webpoint.interface';
import { Geolocation } from '@awesome-cordova-plugins/geolocation/ngx';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  @ViewChild(IonModal) modal: IonModal;
  map: any;
  points: number = 0;
  currentWebPoint: WebPoint;
  answer: string;
  finishedWebPointsIds: string[] = [];

  constructor(
    private webPointService: WebPointService
  ) // private geolocation: Geolocation
  {}

  markerClick(webpoint: WebPoint) {
    this.currentWebPoint = webpoint;
    this.modal.present();
  }

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }

  confirm() {
    this.modal.dismiss(null, 'confirm');
    // this.geolocation
    //   .getCurrentPosition()
    //   .then((resp) => {
    //     console.log(resp);
    //   })
    //   .catch((error) => {
    //     console.log('Error getting location', error);
    //   });
    // if (
    //   this.answer === this.currentWebPoint.answer &&
    //   !this.finishedWebPointsIds.find((x) => x === this.currentWebPoint.id)
    // ) {
    //   this.finishedWebPointsIds.push(this.currentWebPoint.id);
    //   this.points += 1;
    // }
  }

  ionViewDidEnter() {
    this.loadMap();
    this.webPointService.getWebPoints().subscribe({
      next: (data) => {
        data.forEach((element) => {
          L.marker([element.lat, element.long])
            .on('click', this.markerClick.bind(this, element))
            .addTo(this.map);
        });
      },
      error: (err) => {},
    });
  }

  loadMap() {
    this.map = L.map('map').setView(
      [49.82114409705989, 19.051729519762308],
      13
    );
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution:
        '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
    }).addTo(this.map);
  }
}
