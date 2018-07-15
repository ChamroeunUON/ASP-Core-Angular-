import { VihicleService } from '../../services/vihicle.service';
import { Component, OnInit } from '@angular/core';



// import {MatCheckboxModule} from '@angular/material/checkbox';

import 'rxjs/Rx';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';


@Component({
  selector: 'app-vihicle-form',
  templateUrl: './vihicle-form.component.html',
  styleUrls: ['./vihicle-form.component.css']
})
export class VihicleFormComponent implements OnInit {
  makes: any=[];
  models: any=[]
  features: any = [];
  vehicle: any = {
    features: [],
    contact:{}
  };
  constructor(
    private route: ActivatedRoute,
    private router :Router,
    private vihicleService: VihicleService
    ) {
      // route.params.subscribe(p=>{
      //   this.vehicle.id= +p['id'];
      // });
     }
  ngOnInit() {
    this.vihicleService.getMakes()
      .subscribe(makes => this.makes = makes);
    this.vihicleService.getFeatures().subscribe(features => {
      this.features = features;
      console.log(this.features);
    });

  }
  onMakechange() {
    var selectMake = this.makes.find(((m: any) => m.id == this.vehicle.makeId));
    this.models = selectMake.models ? selectMake.models : [];
    delete this.vehicle.modelId;
  }
  onFeatureToggle(featureId: any, $event: any) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }
  submit() {
    
    this.vihicleService.create(this.vehicle)
      .subscribe(x => console.log(x));
  }
}