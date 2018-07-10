import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import{ToastOptions} from 'ng2-toastr';

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
  constructor(
    public toastr: ToastsManager,
    vcr: ViewContainerRef
    
   ) {
    this.title = 'Baboo';
    this.newHero = 'King Man';
    this.toastr.setRootViewContainerRef(vcr);
  }
  showSuccess() {
    this.toastr.success('You are awesome!','Title', 
        {
          toastLife: 1000,
          showCloseButton: true,
          animate:'flyRight',
          positionClass:'toast-bottom-right'
        });
  }

  showError() {
    this.toastr.error('This is not good! Please Click me to continue', 'Oops!',{dismiss: 'click'});
  }

  showWarning() {
    this.toastr.warning('You are being warned.', 'Alert!');
  }

  showInfo() {
    this.toastr.info('Just some information for you.');
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
