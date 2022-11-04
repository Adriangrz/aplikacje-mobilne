import { Component } from '@angular/core';
import * as L from 'leaflet';
import { WebPointService } from '../services/webpoint.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  map: any;

  constructor(private webPointService: WebPointService) {}

  ionViewDidEnter() {
    this.loadMap();
    this.webPointService
      .getWebPoints('f5b2e3e1-7bb6-4b2b-a650-30795cff936c')
      .subscribe({
        next: (data) => {
          data.forEach((element) => {
            L.marker([element.lat, element.long])
              .bindPopup(element.task)
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
