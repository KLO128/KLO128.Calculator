import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { SharedService } from '../shared/shared.service';

@Component({
  selector: 'about',
  templateUrl: './about.component.html'
})
export class AboutComponent implements OnInit {

  loading = true;
  error = false;
  version: string | undefined;

  constructor(public sharedService: SharedService) {

  }
    ngOnInit(): void {
      if (this.loading) {
        this.setVersion();
      }
    }

  setVersion(): void {
    var that = this;
    this.sharedService.apiFetch('api/Version/', 'GET', { body: { }, headers: undefined })
      .then((json: any) => {
        that.version = json.value;
        that.error = false;
        that.loading = false;
      }).catch((err: Error) => {
        that.error = true;
        that.loading = false;
      });
  }
}
