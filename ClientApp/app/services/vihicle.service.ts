import { SaveVehicle } from './../../../Core/Models/vehicle';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map'
@Injectable()
export class VihicleService {
  private readonly vehicleEndPoint = '/api/vehicles/';
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
    return this.http.put(this.vehicleEndPoint+vehicle.id,vehicle)
    .map(res=>res.json());
  }
  delete(id:number){
    return this.http.delete(this.vehicleEndPoint+id)
      .map(res=>res.json());
  }
  getVehicle(id:number){
    return this.http.get(this.vehicleEndPoint+id)
      .map(res=>res.json());
  }
  getVehicles(){
    return this.http.get(this.vehicleEndPoint)
      .map(res=> res.json());
  }
}
