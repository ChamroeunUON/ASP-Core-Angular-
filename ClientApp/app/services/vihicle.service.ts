import { SaveVehicle } from './../../../Core/Models/vehicle';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map'
import { filter } from '../../../node_modules/rxjs/operator/filter';
@Injectable()
export class VihicleService {
  private readonly vehicleEndPoint = '/api/vehicles';
  private readonly makeEndPoint = '/api/makes/';
  private readonly featureEndPoint = '/api/features/';
  constructor(private http: Http) { }
  getMakes() {
    return this.http.get(this.makeEndPoint)
      .map(res => res.json());
  }
  getFeatures(){
    return this.http.get(this.featureEndPoint)
     .map(res => res.json());
   }
   create(vehicle: {} ){
    return this.http.post(this.vehicleEndPoint, vehicle)
      .map(res => res.json());
  }
  update(vehicle:SaveVehicle){
    return this.http.put(this.vehicleEndPoint+'/'+vehicle.id,vehicle)
    .map(res=>res.json());
  }
  delete(id:number){
    return this.http.delete(this.vehicleEndPoint+'/'+id)
      .map(res=>res.json());
  }
  getVehicle(id:number){
    return this.http.get(this.vehicleEndPoint+'/'+id)
      .map(res=>res.json());
  }
  getVehicles(){
    return this.http.get(this.vehicleEndPoint+'?'+ this.toQueryString(filter))
      .map(res=> res.json());
  }
  toQueryString(obj:any){
    var part = [];
    for(var property in obj)
      var value = obj[property];
    if(value != null && value != undefined)
      part.push(encodeURIComponent(value));
    return part.join('&');
  }
}
