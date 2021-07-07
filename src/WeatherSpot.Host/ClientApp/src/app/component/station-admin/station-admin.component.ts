import { Component, OnInit } from '@angular/core';
import { RcsService } from 'src/app/services/rcs.service';

@Component({
  selector: 'app-station-admin',
  templateUrl: './station-admin.component.html',
  styleUrls: ['./station-admin.component.css']
})
export class StationAdminComponent implements OnInit {

  public regions: any = [];
  public cities: any = [];
  public stations: any = [];
  public date: Date = new Date();
  public isWeightValid: boolean = false;

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
    this.isWeightValid = e.value.weight <= 1 ? e.value.weight >= 0 ? true : false : false;    

    //kontroleri ot monkata i testove 
    
  }
}
