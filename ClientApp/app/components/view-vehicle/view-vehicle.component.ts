import { Vehicle } from './../../../../Core/Models/vehicle';
import { VihicleService } from './../../services/vihicle.service';
import { ToastyService } from 'ng2-toasty';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.css']
})
export class ViewVehicleComponent implements OnInit {
  vehicle: any;
  vehicelId: number = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastyService: ToastyService,
    private vehecleService: VihicleService
  ) {
    route.params.subscribe(p => {
      this.vehicelId = +p['id'];
      if (isNaN(this.vehicelId) || this.vehicelId <= 0) {
        this.router.navigate(['/vehicles']);
        return;
      }
    });
  }

  ngOnInit() {
    this.vehecleService.getVehicle(this.vehicelId)
      .subscribe(
        v => this.vehicle = v,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/vehicles']);
            return;
          }
        }
      );

  }
  delete() {
    if (confirm('Are you sure?')) {
      this.vehecleService.delete(this.vehicle.id)
        .subscribe(p=>{
          this.router.navigate(['vehicles']),
          this.toastyService.success({
            title:'Information',
            msg:'Data was deleted',
            theme:'bootstrap',
            timeout:5000,
            showClose:true
          })

        });
       
    }
  }
}
