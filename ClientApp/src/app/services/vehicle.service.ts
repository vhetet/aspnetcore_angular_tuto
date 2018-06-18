import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakes() {
    return this.http.get('/api/make/index');
  }

  getFeatures() {
    return this.http.get('/api/feature/index');
  }

}
