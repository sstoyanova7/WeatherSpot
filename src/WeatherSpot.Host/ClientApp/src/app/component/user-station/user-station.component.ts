import { Component, OnInit } from '@angular/core';
import { RcsService } from 'src/app/services/rcs.service';
import { StationDataService } from 'src/app/services/station-data.service';

@Component({
  selector: 'app-user-station',
  templateUrl: './user-station.component.html',
  styleUrls: ['./user-station.component.css']
})
export class UserStationComponent implements OnInit {


  public opened: boolean = false;
  public checkboxModel: any = {
    rain: false,
    temperature: false,
    stats: false
  };

  public statChoices: Array<{ text: string, value: string }> = [
    { text: 'Тср', value: 'temperatureData.average' },
    { text: 'Т Делта', value: 'temperatureData.delta' },
    { text: 'Тмакс', value: 'temperatureData.max' },
    { text: 'Тмин', value: 'temperatureData.min' },
    { text: 'Сума', value: 'rainData.total' },
    { text: 'Q/Qn', value: 'rainData.qQn' },
    { text: 'Макс Валежи', value: 'rainData.max' },
    { text: 'Валежи >= 1мм', value: 'statisticsData.daysRainOver1mm' },
    { text: 'Валежи >= 10мм', value: 'statisticsData.daysRainOver10mm' },
    { text: 'Вятър >= 14мс', value: 'statisticsData.daysWindOver14ms' },
    { text: 'Гръмотевици', value: 'statisticsData.daysThunderboltss' },
  ]
  public choosedStat: any;
  public statValues: Array<any> = [];
  public stationValues: Array<number> = [];
  public stationNames: Array<string> = [];
  public statisticChart: string;
  public min: number;
  public max: number;
  public data = [];

  public regions: any = [];
  public cities: any = [];

  public selectedRegion: any;
  public selectedCity: any;

  public showGrid: boolean = false;

  constructor(private service: RcsService, private stationData: StationDataService) { }

  ngOnInit() {
    this.service.getRegions().subscribe((regions: any) => {
      this.regions = regions;
    });
  }

  onRegionSelect(region) {
    this.selectedRegion = region;

    this.service.getCities(region.id).subscribe((cities: any) => {
      this.cities = cities;
    });
  }


  onSubmit(e) {
    console.log(e);
    this.stationData.getCityData(this.selectedCity.id, e.value.month, e.value.year).subscribe((res: any) => {
      console.log(res);
      this.data = res;
      this.showGrid = true;
    })
  }

  searchAgain() {
    this.showGrid = false;
  }

  showStat() {
    console.log(this.stationValues);

    const value = this.choosedStat.value;
    console.log(this.choosedStat);
    
    const stat = value.split('.');
    this.statisticChart = stat[1];
    
    this.data.map(station => {
      this.stationValues.push(station[stat[0]][stat[1]]);
      this.stationNames.push(station.stationName);
      this.statValues.push({
        station: station.stationName,
        value: station[stat[0]][stat[1]]
      });
      this.opened = true;
    });

    this.min = this.stationValues[0];
    this.max = this.stationValues[this.stationValues.length - 1];

    console.log(this.stationValues);
    

    return this.stationValues;
  }

  onClose() {
    this.stationValues = [];
    this.stationNames = [];
    this.opened = false;
  }
}
