import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vihicle-form',
  templateUrl: './vihicle-form.component.html',
  styleUrls: ['./vihicle-form.component.css']
})
export class VihicleFormComponent implements OnInit {
  makes: any;
  models: any;
  vehicle: any = {};
  constructor(private makeService: MakeService) { }
  ngOnInit() {
    this.makeService.getMake()
      .subscribe(makes => this.makes = makes);
  }
  onMakechange() {
    var selectMake = this.makes.find(((m: any) => m.id == this.vehicle.make));
    this.models = selectMake.models;
  }
}
