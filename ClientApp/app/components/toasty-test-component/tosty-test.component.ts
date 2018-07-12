import { Component, OnInit } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-tosty-test',
  templateUrl: './tosty-test.component.html',
  styleUrls: ['./tosty-test.component.css']
})
export class TostyTestComponent implements OnInit {

  constructor(private toastyService:ToastyService) {
    
   }
   Success(){
     this.toastyService.success({
      title: "Toast It!",
      msg: "Mmmm, tasties...",
      showClose: true,
      timeout: 5000,
      theme: "bootstrap"
     })
   }
  ngOnInit() {
  }

}
