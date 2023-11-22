import { Pipe } from "@angular/core";
import { SharedService } from "../shared/shared.service";

@Pipe({
  name: "resultText"
})
export class ResultTextPipe {

  constructor(private sharedService: SharedService) {

  }

  transform(val: any): any {
    if (val == null) {
      return this.sharedService.getTranslation('Result') + ": n.a.";
    }

    if (new RegExp(/^[0-9]|NaN|-/).test(val)) {
      return this.sharedService.getTranslation('Result') + ": " + val;
    }

    return val.toString();
  }
}
