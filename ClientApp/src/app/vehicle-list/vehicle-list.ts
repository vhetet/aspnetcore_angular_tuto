import { Vehicle } from './../models/vehicle';
import { Component, OnInit } from "@angular/core";
import { VehicleService } from "../services/vehicle.service";

@Component({
    templateUrl: 'vehicle-list.html'
})
export class VehicleListComponent implements OnInit {
    vehicles: any;
    allVehicles: any;
    makes: any;
    filter: any = {};

    constructor(private vehicleService: VehicleService) { }

    ngOnInit() {
        this.vehicleService.getMakes()
            .subscribe(makes => this.makes = makes);

        this.vehicleService.getVehicles()
            .subscribe(vehicles => this.vehicles = this.allVehicles = vehicles);
    }

    onFilterChange() {
        var vehicles = this.allVehicles;

        if(this.filter.makeID)
            vehicles = vehicles.filter(v => v.make.id == this.filter.makeID);

        this.vehicles = vehicles;
    }

    resetFilter() {
        this.filter = {};
        this.onFilterChange();
    }
}