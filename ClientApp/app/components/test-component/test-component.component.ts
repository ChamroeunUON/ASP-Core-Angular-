import { ToastrService } from './../../services/toastr-service.service';
import { Component, OnInit } from '@angular/core';

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
  constructor(private toastrService: ToastrService) {
    this.title = 'Baboo';
    this.newHero = 'King Man';
    
   
  }
  addToast() {
    
  this.toastrService.Success("Successfully");
  // Add see all possible types in one shot
  }
  Error() {
    
  this.toastrService.Error("Error While Saving");
  // Add see all possible types in one shot
  }
  Info() {
    
  this.toastrService.Info("Information");
  // Add see all possible types in one shot

  }
  Warning() {
    
  this.toastrService.Warning("Warning While Saving");
  // Add see all possible types in one shot

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
