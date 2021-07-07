import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StationDataService {

  private addStationDataUrl = '/api/StationData/addStationData';
  

  constructor(private  http: HttpClient) { }


  addStationData(data) {
    return this.http.post(this.addStationDataUrl, data);
  }

  getCityData(cityId, month, year) {
    const getCityDataUrl = `/api/StationData/getStationData?cityId=${cityId}&month=${month}&year=${year}`;
    return this.http.get(getCityDataUrl);
  }

}
