import { ToastyService } from 'ng2-toasty';
import { async } from '@angular/core/testing';
import { Vehicle, KeyValuePare, Contact } from './../../../../Core/Models/vehicle';
import { VihicleService } from './../../services/vihicle.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '../../../../node_modules/@angular/platform-browser';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[] | undefined;
  makes: KeyValuePare[] | undefined;
  query: any = {};
  constructor(
    private vehiclesService: VihicleService,
    private toastyService: ToastyService
  ) { }

  ngOnInit() {
    this.vehiclesService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.populateVehicle();
  }
  populateVehicle() {

    this.vehiclesService.getVehicles(this.query)
      .subscribe(vehicles => this.vehicles= vehicles);
  }
  onFilterChange() {
    // var vehicles = this.allVehicles;
    // if (vehicles !== undefined) {
    //   if (this.filter.makeId)
    //     vehicles = vehicles.filter(v => v.make.id == this.filter.makeId);
    //   if (this.filter.modelId)
    //     vehicles = vehicles.filter(v => v.model.id == this.filter.modelId);
      
    //   this.vehicles = vehicles;
    // }
    // this.filter.modelId = 1; // Will Sorting bu ModelId
    this.populateVehicle();
    
  }
  sortBy(columnName:string){
    if(this.query.SortBy === columnName){
      this.query.IsSortByAccending  = !this.query.IsSortByAccending;
    }
    else{
      this.query.SortBy = columnName;
      this.query.IsSortByAccending  = true;
    }
    this.populateVehicle();

  }
  onReset() {
    this.query = {};
    this.onFilterChange();
  }
}
