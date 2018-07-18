import { ToastyService } from 'ng2-toasty';
import { SaveVehicle, Vehicle } from './../../../../Core/Models/vehicle';
import * as _ from 'underscore';
import { VihicleService } from '../../services/vihicle.service';
import { Component, OnInit, isDevMode } from '@angular/core';



// import {MatCheckboxModule} from '@angular/material/checkbox';

import 'rxjs/Rx';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';
import { Observable } from 'rxjs/Rx';


@Component({
  selector: 'app-vihicle-form',
  templateUrl: './vihicle-form.component.html',
  styleUrls: ['./vihicle-form.component.css']
})
export class VihicleFormComponent implements OnInit {
  makes: any = [];
  models: any = []
  features: any = [];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      phone: '',
      email: '',
    }
  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastyService: ToastyService,
    private vihicleService: VihicleService
  ) {
    route.params.subscribe(p => {
      this.vehicle.id = +p['id'] || 0;
    });

  }
  ngOnInit() {
    var sources = [
      this.vihicleService.getMakes(),
      this.vihicleService.getFeatures()
    ];
    if (this.vehicle.id)
      sources.push(this.vihicleService.getVehicle(this.vehicle.id));


    Observable.forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];
      if (this.vehicle.id) {
        this.setVehicle(data[2]);
        this.populateModels();
      }

    },
      err => {
        if (err.status == 404)
          this.router.navigate(['/home']);
      });
  }
  private setVehicle(v: Vehicle) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.contact = v.contact;
    this.vehicle.features = _.pluck(v.features, 'id');
  }
  onMakechange() {
    this.populateModels();
    delete this.vehicle.modelId;
  }
  private populateModels() {
    var selectMake = this.makes.find(((m: any) => m.id == this.vehicle.makeId));
    this.models = selectMake.models ? selectMake.models : [];
  }
  onFeatureToggle(featureId: any, $event: any) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }
  test() {
    this.toastyService.success({
      title: 'kk',
      msg: 'KK',
      theme: 'bootstrap'
    })
  }
  delete() {
    if (this.vehicle.id) {
      if (confirm("Are you sure?")) {
        this.vihicleService.delete(this.vehicle.id)
          .subscribe(x => {
            this.toastyService.success({
              title: 'Success',
              msg: 'Informaation was deleted',
              theme: 'bootstrap',
              timeout: 5000
            });
          });
        this.router.navigate(['/vihicle/new']);
      }
    }
  }
  submit() {
    var result$ = (this.vehicle.id) ? this.vihicleService.update(this.vehicle) : this.vihicleService.create(this.vehicle);
    result$.subscribe(vehicle => {
      this.toastyService.success({
        title: 'Success',
        msg: 'Data was sucessfully saved.',
        theme: 'bootstrap',
        showClose: true,
        timeout: 5000
      });
        this.router.navigate(['/vihicle/', vehicle.id])
    });
  }
}