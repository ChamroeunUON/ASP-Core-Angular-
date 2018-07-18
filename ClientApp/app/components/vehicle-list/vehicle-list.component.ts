import { async } from '@angular/core/testing';
import { Vehicle, KeyValuePare } from './../../../../Core/Models/vehicle';
import { VihicleService } from './../../services/vihicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[] | undefined;
  allVehicles: Vehicle[] | undefined;
  makes: KeyValuePare[] | undefined;
  filter: any = {};
  constructor(
    private vehiclesService: VihicleService,
  ) { }

  ngOnInit() {
    this.vehiclesService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.populateVehicle();
  }
  populateVehicle() {
    this.vehiclesService.getVehicles()
      .subscribe(vehicles => this.vehicles = this.allVehicles = vehicles);
  }
  onFilterChange() {
    var vehicles = this.allVehicles;
    if (vehicles !== undefined) {
      if (this.filter.makeId)
        vehicles = vehicles.filter(v => v.make.id == this.filter.makeId);
      if (this.filter.modelId)
        vehicles = vehicles.filter(v => v.model.id == this.filter.modelId);
      this.vehicles = vehicles;
    }
  }
  onReset() {
    this.filter = {};
    this.onFilterChange();
  }
}
