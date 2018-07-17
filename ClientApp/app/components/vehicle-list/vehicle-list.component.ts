import { Vehicle, KeyValuePare } from './../../../../Core/Models/vehicle';
import { VihicleService } from './../../services/vihicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[]|undefined;
  makes: KeyValuePare[] | undefined;
  constructor(
    private vehiclesService:VihicleService,
  ) { }

  ngOnInit() {
    this.vehiclesService.getMakes()
      .subscribe(makes=>this.makes = makes);
    this.vehiclesService.getVehicles()
      .subscribe(vehicles=> this.vehicles=vehicles);
  }

}
