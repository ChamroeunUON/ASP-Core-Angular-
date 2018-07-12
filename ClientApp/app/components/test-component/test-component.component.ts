import { ToastyService } from 'ng2-toasty';
import { Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-test-component',
  templateUrl: './test-component.component.html',
  styleUrls: ['./test-component.component.css'],
})
export class TestComponentComponent implements OnInit {
  title: string = "";
  newHero: string = '';
  data: AppComponent = {
    title1: 'King Man',
    myHero: 'My Hero'

  }
  constructor(private toastyService:ToastyService
   ) {
  }
  showSuccess() {
    this.toastyService.success({
      title:'Success',
      msg:'You are awsome',
      theme:'bootstrap',
      timeout:5000,
      showClose:true
    })
  }

  showError() {
    this.toastyService.error({
      title:'Success',
      msg:'You are awsome',
      theme:'bootstrap',
      timeout:5000,
      showClose:true
    })
  }

  showWarning() {
    this.toastyService.warning({
      title:'Success',
      msg:'You are awsome',
      theme:'bootstrap',
      timeout:5000,
      showClose:true
    })
  }
  showInfo() {
    this.toastyService.info({
      title:'Success',
      msg:'You are awsome',
      theme:'bootstrap',
      timeout:5000,
      showClose:true
    })
  }
  ngOnInit() {
  }
  value = '';
  onEnter(value: string) { this.value = value; }
}
export class AppComponent {
  title1 = 'Tour of Heroes';
  myHero = 'Windstorm';

}
