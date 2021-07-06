import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-station-admin',
  templateUrl: './station-admin.component.html',
  styleUrls: ['./station-admin.component.css']
})
export class StationAdminComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }


  onSubmit(e) {
    console.log(e);
    
  }
}
