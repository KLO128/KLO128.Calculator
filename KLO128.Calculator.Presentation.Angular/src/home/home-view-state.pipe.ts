import { Pipe } from "@angular/core";
import { SharedService } from "../shared/shared.service";

@Pipe({
  name: "homeViewState"
})
export class HomeViewStatePipe {
  constructor(private sharedService: SharedService) {
  }

  transform(val: any, propName: string): any {
    this.sharedService.homeViewState[propName] = val;
    return val;
  }
}
