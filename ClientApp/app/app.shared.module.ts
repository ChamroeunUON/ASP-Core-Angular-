
import {ToastModule} from 'ng2-toastr/ng2-toastr';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { TestComponentComponent } from './components/test-component/test-component.component';
import { VihicleService } from './services/vihicle.service';
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./components/app/app.component";
import { NavMenuComponent } from "./components/navmenu/navmenu.component";
import { HomeComponent } from "./components/home/home.component";
import { FetchDataComponent } from "./components/fetchdata/fetchdata.component";
import { CounterComponent } from "./components/counter/counter.component";
import { ReverseCounterComponent } from './components/reverse-counter/reverse-counter.component';
import { VihicleFormComponent } from './components/vihicle-form/vihicle-form.component';
import { BrowserModule } from '@angular/platform-browser';
import {ToastOptions} from 'ng2-toastr';

export class CustomOption extends ToastOptions {
    animate = 'flyRight'; // you can override any options available
    newestOnTop = false;
    showCloseButton = true;
    // positionClass= 'toast-top-center';
  }
@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VihicleFormComponent,
        ReverseCounterComponent,
        TestComponentComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        BrowserAnimationsModule,
        ToastModule.forRoot(),
        FormsModule,
        RouterModule.forRoot([
            { path: 'reverse-counter', component: ReverseCounterComponent },
            { path: 'vihicle/new', component: VihicleFormComponent },
            { path: 'test', component: TestComponentComponent },
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "home", component: HomeComponent },
            { path: "counter", component: CounterComponent },
            { path: "fetch-data", component: FetchDataComponent },
            { path: "**", redirectTo: "home" }
            
        ])
    ],
    exports: [
        BrowserModule,
        ToastModule
    ],
    providers: [
        VihicleService,
        {provide: ToastOptions, useClass: CustomOption},
    ],

})
export class AppModuleShared {
    
}

