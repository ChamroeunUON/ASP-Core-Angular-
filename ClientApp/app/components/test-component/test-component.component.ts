import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-test-component',
  templateUrl: './test-component.component.html',
  styleUrls: ['./test-component.component.css'],

})
export class TestComponentComponent implements OnInit {
  title: string = "";
  newHero:string ='';
  data: AppComponent ={
    title1:'King Man',
    myHero:'My Hero'
    
  }
  constructor() { 
    this.title = 'Baboo';
    this.newHero = 'King Man';
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
