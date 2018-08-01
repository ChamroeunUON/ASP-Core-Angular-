
import { VehicleListComponent } from './components/vehicle-list/vehicle-list.component';
import * as Raven from 'raven-js';
import { ToastyModule } from 'ng2-toasty';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TestComponentComponent } from './components/test-component/test-component.component';
import { VihicleService } from './services/vihicle.service';
import { NgModule, ErrorHandler } from "@angular/core";
import { AppErrorHandler } from './components/app/app.error-handler';
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
import { TostyTestComponent } from './components/toasty-test-component/tosty-test.component'
import { BrowserModule } from '@angular/platform-browser';
import { PaginationComponent } from './components/pagination/pagination.component';
Raven
  .config('https://5294aea1d0c54de7bf2151c68e9056d1@sentry.io/1241890')
  .install();
  
@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VihicleFormComponent,
        ReverseCounterComponent,
        TestComponentComponent,
        TostyTestComponent,
        VehicleListComponent,
        PaginationComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        BrowserAnimationsModule,
        ToastyModule.forRoot(),
        FormsModule,
        RouterModule.forRoot([
            { path: 'reverse-counter', component: ReverseCounterComponent },
            { path: 'vehicles', component: VehicleListComponent },
            { path: 'vihicle/new', component: VihicleFormComponent },
            { path: 'vihicle/:id', component: VihicleFormComponent },
            { path: 'test', component: TestComponentComponent },
            { path: 'tostytest', component: TostyTestComponent },
            { path: "", redirectTo: "vehicles", pathMatch: "full" },
            { path: "home", component: HomeComponent },
            { path: "counter", component: CounterComponent },
            { path: "fetch-data", component: FetchDataComponent },
            { path: "**", redirectTo: "vehicles" }
        ])
    ],
    exports: [
        BrowserModule
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        VihicleService
    ],

})
export class AppModuleShared {

}

