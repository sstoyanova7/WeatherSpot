import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RcsService {


  private createRegionUrl: string = '/api/Station/addNewRegion';
  private getRegionsUrl: string = '/api/Station/getRegions';
  private createNewCityUrl: string = '/api/Station/addNewCity';
  private getCitiesUrl: string = '/api/Station/getCities';
  private createNewStation: string = '/api/Station/addNewStation';
  private getStationsUrl: string = '/api/Station/getStations';


  constructor(private http: HttpClient) { }


  addNewRegion(regionName: string) {
    return this.http.post(this.createRegionUrl, JSON.stringify(regionName), {headers : new HttpHeaders({ 'Content-Type': 'application/json' })});
  }

  getRegions() {
    return this.http.get(this.getRegionsUrl);
  }

  addNewCity(cityName) {
    return this.http.post(this.createNewCityUrl, cityName);
  }

  getCities() {
    return this.http.get(this.getCitiesUrl);
  }

  addNewStation(stationName) {
    return this.http.post(this.createNewStation, stationName);
  }

  getStations() {
    return this.http.get(this.getStationsUrl);
  }
}
