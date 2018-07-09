

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
import { ToastyModule, ToastyService, ToastyComponent } from 'ng2-toasty';
import { BrowserModule } from '@angular/platform-browser';
import { ToastrService } from './services/toastr-service.service';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        // ToastyService,
        VihicleFormComponent,
        ReverseCounterComponent,
        TestComponentComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        ToastyModule.forRoot(),
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
    exports: [BrowserModule, ToastyModule],
    providers: [
        VihicleService,
        ToastyService,
        ToastrService
        
    ],

})
export class AppModuleShared {
}
