import { Component, OnInit } from '@angular/core';
import { RcsService } from 'src/app/services/rcs.service';
import { StationDataService } from 'src/app/services/station-data.service';

@Component({
  selector: 'app-station-admin',
  templateUrl: './station-admin.component.html',
  styleUrls: ['./station-admin.component.css']
})
export class StationAdminComponent implements OnInit {

  public regions: any = [];
  public cities: any = [];
  public stations: any = [];
  public selectedRegion: any;
  public selectedCity: any;
  public selectedStation: any;

  public date: Date = new Date();
  public isWeightValid: boolean = false;


  constructor(private service: RcsService, private stationData: StationDataService) { }


  ngOnInit() {
    this.service.getRegions().subscribe((regions: any) => {
      this.regions = regions;
    });

  }

  onRegionSelect(region) {
    this.selectedRegion = region;
    this.cities = [];

    this.service.getCities(region.id).subscribe(cities => {
        this.cities = cities;
    });


  }

  onCitySelect(city) {
    this.selectedCity = city;
    this.service.getStations(city.id).subscribe((stations: any) => {
      this.stations = stations;
    });

  }

  onStationSelect(station) {
    this.selectedStation = station;

  }

  onSubmit(e) {
    this.isWeightValid = e.value.weight <= 1 ? e.value.weight >= 0 ? true : false : false;

    if(e.valid && this.isWeightValid) {

      const data = {
        stationId: +this.selectedStation.id,
        month: +e.value.month,
        year: +e.value.year,
        weight: +e.value.weight,
        temperatureAverage: +e.value.tAvg,
        temperatureDelta: +e.value.temperatureDeviation,
        temperatureMax: +e.value.tMax,
        temperatureMin: +e.value.tMin,
        temperatureDayMax: +e.value.dateOne,
        temperatureDayMin: +e.value.dateTwo,
        rainTotal: +e.value.amount,
        rainQQn: +e.value.percentT,
        rainMax: +e.value.maxRain,
        rainDayMax: +e.value.dateThree,
        daysRainOver1mm: +e.value.rainBelow,
        daysRainOver10mm: +e.value.rainAbove,
        daysWindOver14ms: +e.value.wind,
        daysThunderbolts: +e.value.thunders 
      };

      
      this.stationData.addStationData(data).subscribe(()=> {
        e.resetForm();
      })  
    }


    //kontroleri ot monkata i testove 

  }
}
