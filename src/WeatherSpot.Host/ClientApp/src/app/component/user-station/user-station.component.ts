import { Component, OnInit } from '@angular/core';
import { RcsService } from 'src/app/services/rcs.service';
import { StationDataService } from 'src/app/services/station-data.service';

@Component({
  selector: 'app-user-station',
  templateUrl: './user-station.component.html',
  styleUrls: ['./user-station.component.css']
})
export class UserStationComponent implements OnInit {


  public checkboxModel: any = {
    rain: false,
    temperature: false,
    stats: false
  };

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
}
