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

  getCityData(regionId, cityId, month, year) {
    const getCityDataUrl = `/api/StationData/getStationData?regionId=${regionId}&cityId=${cityId}&month=${month}&year=${year}`;
    return this.http.get(getCityDataUrl);
  }

}
