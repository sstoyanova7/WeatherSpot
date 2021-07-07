import { Component, OnInit } from '@angular/core';
import { RcsService } from 'src/app/services/rcs.service';

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
 
  public regions: any = [];
  public cities: any = [];
  public stations: any = [];

  public selection: any = {
    region: Object,
    city: Object,
    station: Object
  }

  public showGrid: boolean = false;
  public date: Date = new Date();

  constructor(private service: RcsService) { }

  ngOnInit() {
    this.service.getRegions().subscribe((regions: any) => {
      this.regions = regions;
    });

    this.service.getCities().subscribe((cities: any) => {
      this.cities = cities;
    });

    this.service.getStations().subscribe((stations: any) => {
      this.stations = stations;
    });
  }


  onSubmit(e) {
    console.log(e);
    this.showGrid = true;
    /**
     * GET DATA from BE
     * ADD STATISTICS
     */
  }

  searchAgain() {
    this.showGrid = false;
    this.selection = {region: '', city: '', station: ''};
  }
}
