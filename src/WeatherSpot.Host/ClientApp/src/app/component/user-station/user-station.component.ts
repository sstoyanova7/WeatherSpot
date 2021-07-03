import { Component, OnInit } from '@angular/core';

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
  public showGrid: boolean = false;
  public date: Date = new Date();
  constructor() { }

  ngOnInit() {
  }


  onSubmit(e) {
    console.log(e);
    console.log(this.checkboxModel);
    this.showGrid = true;
    /**
     * GET DATA from BE
     * ADD STATISTICS
     */
  }

  searchAgain() {
    this.showGrid = false;
  }
}
