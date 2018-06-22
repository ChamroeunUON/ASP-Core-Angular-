import { Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-vihicle-form',
  templateUrl: './vihicle-form.component.html',
  styleUrls: ['./vihicle-form.component.css']
})
export class VihicleFormComponent implements OnInit {
  public id = 100;
  constructor() { }
  Increase(){
    this.id++;
  }
  ngOnInit() {
  }
}




