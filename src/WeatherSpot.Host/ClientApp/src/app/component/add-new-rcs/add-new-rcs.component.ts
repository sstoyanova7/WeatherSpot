import { Component, OnInit } from '@angular/core';
import { RcsService } from 'src/app/services/rcs.service';

@Component({
  selector: 'app-add-new-rcs',
  templateUrl: './add-new-rcs.component.html',
  styleUrls: ['./add-new-rcs.component.css']
})
export class AddNewRcsComponent implements OnInit {

  public newRegion: string = '';
  public newCity: string = '';
  public newStation: string = '';

  public regions: any = [];
  public selectedRegion: any;

  public cities: any = [];
  public selectedCity: any;

  constructor(private service: RcsService) { }

  ngOnInit() {
    this.service.getRegions().subscribe((regions: any) => {
      this.regions = regions;
    });

    this.service.getCities().subscribe((cities: any) => {
      this.cities = cities;
    });
  }

  onAddNewRegion() {
    this.service.addNewRegion(this.newRegion).subscribe();
  }

  onAddnewCity() {
    const city = {
      name: this.newCity,
      regionId: this.selectedRegion
    }
    this.service.addNewCity(city).subscribe();
  }

  onAddNewStation() {
    const station = {
      name: this.newStation,
      cityId: this.selectedCity
    };
    this.service.addNewStation(station).subscribe();
  }
}

