import { VehicleService } from '../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  features: any;
  models: any[];
  vehicle: any = {};

  constructor(
    private makeService: VehicleService, 
  ) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes => this.makes = makes);
    this.makeService.getFeatures().subscribe(features => this.features = features)
  }

  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.carModels : [];
  }
}
