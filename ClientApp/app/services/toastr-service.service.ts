import { Injectable } from '@angular/core';
declare var toastr:any;
@Injectable()
export class ToastrService {

  constructor() { }
  Success(title:string,message?:string){
    toastr.success(title,message)
  }
  Info(title:string,message?:string){
    toastr.info(title,message)
  }
  Error(title:string,message?:string){
    toastr.error(title,message)
  }
  Warning(title:string,message?:string){
    toastr.warning(title,message)
  }
}
