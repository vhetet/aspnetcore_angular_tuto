import { Vehicle } from './../models/vehicle';
import { Component, OnInit } from "@angular/core";
import { VehicleService } from "../services/vehicle.service";

@Component({
    templateUrl: 'vehicle-list.html'
})
export class VehicleListComponent implements OnInit {
    vehicles: any;
    makes: any;
    query: any = {};

    constructor(private vehicleService: VehicleService) { }

    ngOnInit() {
        this.vehicleService.getMakes()
            .subscribe(makes => this.makes = makes);

        this.populateVehicles();
    }

    onFilterChange() {
        this.populateVehicles();
    }

    resetFilter() {
        this.query = {};
        this.onFilterChange();
    }

    private populateVehicles() {
        this.vehicleService.getVehicles(this.query)
            .subscribe(vehicles => this.vehicles = vehicles);
    }

    sortBy(columnName) {
        if(this.query.sortBy === columnName) {
            this.query.isSortAscending = !this.query.isSortAscending;
        }
        else {
            this.query.sortBy = columnName
            this.query.isSortAscending = true;
        } 
        this.populateVehicles();
    }
}