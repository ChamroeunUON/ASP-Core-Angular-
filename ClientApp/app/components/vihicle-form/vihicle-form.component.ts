import { FormsModule } from '@angular/forms';
import { ServerModule } from '@angular/platform-server';
import { FeatureService } from './../../services/feature.service';
import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';


// import {MatCheckboxModule} from '@angular/material/checkbox';

import 'rxjs/Rx'; 


@Component({
  selector: 'app-vihicle-form',
  templateUrl: './vihicle-form.component.html',
  styleUrls: ['./vihicle-form.component.css']
})
export class VihicleFormComponent implements OnInit {
  makes: any;
  models: any;
  features: any=[];
  vehicle: any = {};
  constructor(
    private makeService: MakeService,
    private featureService: FeatureService) { }
  ngOnInit() {
    this.makeService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.featureService.getFeatures().subscribe( features =>{
    this.features = features;
      console.log(this.features);
    } );

  }
  onMakechange() {
    var selectMake = this.makes.find(((m: any) => m.id == this.vehicle.make));
    this.models = selectMake.models;
  }
}

