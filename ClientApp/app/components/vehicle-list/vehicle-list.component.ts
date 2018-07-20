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
  columns = [
    {title:'ID'},
    {title:'Make',key:'make',isSortable: true},
    {title:'Model',key:'model',isSortable: true},
    {title:'Contact Name',key:'contactName',isSortable: true},
    {}
  ]
  constructor(
    private vehiclesService: VihicleService,
    private toastyService: ToastyService
  ) { }

  ngOnInit() {
    this.vehiclesService.getMakes()
      .subscribe(makes =>  this.makes = makes);
    this.populateVehicle();
  }
  populateVehicle() {

    this.vehiclesService.getVehicles(this.query)
      .subscribe(vehicles => this.vehicles = vehicles);
  }
  onFilterChange() {
    this.populateVehicle();
  }
  sortBy(columnName: string) {
    if (this.query.SortBy === columnName) {
      this.query.IsSortByAccending = !this.query.IsSortByAccending;
    }
    else {
      this.query.SortBy = columnName;
      this.query.IsSortByAccending = true;
    }
    this.populateVehicle();

  }
  onReset() {
    this.query = {};
    this.onFilterChange();
  }
}
