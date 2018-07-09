import { ToastrService } from './../../services/toastr-service.service';

import { Component, NgModule } from '@angular/core';


@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    /**
     *
     */
    constructor(private toasterService: ToastrService) {

    }
    Success() {
        this.toasterService.Success("Successfully");
    }

}
