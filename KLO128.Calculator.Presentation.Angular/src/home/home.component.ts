import { ChangeDetectorRef, Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { SharedService } from '../shared/shared.service';
import { HomeViewStatePipe } from './home-view-state.pipe';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  styles: [`
      :host {
        width: 100%;
      }`]
})
export class HomeComponent implements OnChanges, OnInit {

  errorMessage: string | undefined;
  invalidModel: any[];
  computeError = false;
  tbInputId = "tbInput";
  advanced = true;
  noHistory = false;
  onLoadError = false;
  _loadingText: string;

  charPressed: string | undefined;
  overwrite = false;

  resultState: string | undefined;
  historyResultsState: any[];
  expressionState: string | undefined;
  useSeparatorsState = false;;
  resultAsIntegerState = false;
  loadingState = true;

  viewStatePipe: HomeViewStatePipe;

  //set result(val: string | undefined) { this.sharedService.homeViewState.result = val; } get result() { return this.sharedService.homeViewState.result; }
  //set historyResults(val: any[]) {
  //  this.sharedService.homeViewState.historyResults = val;
  //} get historyResults() {
  //  return this.sharedService.homeViewState.historyResults || [];
  //}
  //set expression(val: string | undefined) { this.sharedService.homeViewState.expression = val; } get expression() { return this.sharedService.homeViewState.expression; }
  //set useSeparators(val: boolean) { this.sharedService.homeViewState.useSeparators = val; } get useSeparators() { return this.sharedService.homeViewState.useSeparators; }
  //set resultAsInteger(val: boolean) { this.sharedService.homeViewState.resultAsInteger = val; } get resultAsInteger() { return this.sharedService.homeViewState.resultAsInteger; }
  //set loading(val: boolean) { this.sharedService.homeViewState.loading = val; } get loading() { return this.sharedService.homeViewState.loading; }

  constructor(public sharedService: SharedService, private cd: ChangeDetectorRef) {
    this._loadingText = sharedService.getTranslation('Loading');

    this.historyResultsState = [];
    this.invalidModel = [];

    this.viewStatePipe = new HomeViewStatePipe(sharedService);
  }

  ngOnInit(): void {

    this.resultState = this.sharedService.homeViewState.result;
    this.historyResultsState = this.sharedService.homeViewState.historyResults;
    this.expressionState = this.sharedService.homeViewState.expression;
    this.useSeparatorsState = this.sharedService.homeViewState.useSeparators;
    this.resultAsIntegerState = this.sharedService.homeViewState.resultAsInteger;
    this.loadingState = this.sharedService.homeViewState.loading;

    if (this.loadingState) {
      this.onLoadIfNeeded();
    } else {
      this.onLoadIfNeededCallback();
    }

    this.updateExpression(this.expressionState, true);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.onLoadIfNeeded();
    this.prettify();
  }

  onKeyPress(event: any): void {
    switch (event.keyCode) {
      case 13:
      case 16:
      case 17:
      case 18:
      case 20:
        return;
    }

    event.preventDefault();
    event.stopPropagation();
    this._charPressed(event['key']?.toString());
  }

  onExpressionChange(val: string | undefined) {
    this.expressionState = this.viewStatePipe.transform(val, 'expression');
    this.charPressed = undefined;
  }

  getResultText(val: string | undefined): string {
    if (val == null) {
      return this.sharedService.getTranslation('Result') + ": n.a.";
    }

    if (new RegExp(/^[0-9]|NaN|-/).test(val)) {
      return this.sharedService.getTranslation('Result') + ": " + val;
    }

    return val.toString();
  }

  showHideAdvanced(): void {
    this.advanced = !this.advanced;
  }

  async pressChar(event: Event): Promise<any> {
    var input = event.currentTarget as HTMLElement;

    this._charPressed(input.dataset?.['char']);
  }

  _charPressed(val: string | undefined) {
    this.overwrite = false;
    this.charPressed = val;
    this.cd.detectChanges();

    this.charPressed = undefined;
    this.cd.detectChanges();
  }

  compute(): void {
    // compute via API and insert result into history
    var elExpression = document.getElementById(this.tbInputId) as HTMLTextAreaElement;
    var that = this;

    if (elExpression.value == null || elExpression.value == '') {
      this.invalidModel = [this.sharedService.getTranslation('msgExpressionRequired')];
      return;
    }

    this.resultState = this.viewStatePipe.transform(this._loadingText, 'result');

    this.sharedService.apiFetch('api/Calculator/Compute', 'GET', { body: { "expression": elExpression.value, "culture": this.sharedService.currentLang, "useSeparators": this.useSeparatorsState }, headers: undefined })
      .then((json: any) => {
        that.onLoadIfNeeded(function () {
          var isError = json.expression == null || json.warning != null;
          that.updateData(0, true, json, that.resultAsIntegerState, !isError, elExpression.value, isError);


          that.noHistory = false;
          that.invalidModel = [];;
          that.computeError = isError;
          if (!isError) {
            that.setAccessToken(json.newAccessToken);
          }

          //setTimeout(function () {

          //}, AppContext.DATA.setResultTimeOut);
        });
      }).catch((err: Error) => {
        that.updateData(-1, true, err.message, that.resultAsIntegerState, false, undefined, true);

        that.invalidModel = [];;
        that.computeError = true;
      });
  }

  prettify(hideError?: boolean): void {
    var elExpression = document.getElementById(this.tbInputId) as HTMLTextAreaElement;
    var that = this;
    this.sharedService.apiFetch('api/Calculator/PrettyPrint', 'GET', { body: { "expression": elExpression.value, "result": this.resultState || '', "normalize": false, "culture": this.sharedService.currentLang, "useSeparators": this.useSeparatorsState }, headers: undefined })
      .then((json: any) => {
        if (json.expression == null) {

          if (hideError) {
            return;
          }

          if (json.detail == null) {
            alert(json);
          } else {
            alert(json.detail);
          }

          return;
        }

        that.updateExpression(json.expression, true);
        that.updateResultAsync(json.result, true, false);
      }).catch((err: Error) => {
        if (!hideError) {
          alert(that.sharedService.getTranslation("Error") + ": " + err.message);
      }
    });
  }

  updateUseSeparators(): void {
    this.useSeparatorsState = this.viewStatePipe.transform(!this.useSeparatorsState, 'useSeparators');
  }

  displayIntegers(): void {
    this.resultAsIntegerState = this.viewStatePipe.transform(this.resultAsIntegerState, 'resultAsInteger');
  }

  setAccessToken(token: string): void {
    this.sharedService.setCookie("accessToken", token);
  }

  async onLoadIfNeeded(callback?: Function): Promise<any> {
    if (this.loadingState || this.onLoadError) {
      var elHistory = document.getElementById("history") as HTMLElement;
      var that = this;

      await this.sharedService.apiFetch('api/Calculator', 'GET', { headers: {}, body: { "culture": this.sharedService.currentLang, "useSeparators": this.useSeparatorsState } })
        .then((json: any) => {
          this.onLoadIfNeededCallback(json.entriesToPrint as any[], callback);
        }).catch((err: Error) => {
          that.loadingState = this.viewStatePipe.transform(false, 'loading');
          that.onLoadError = true;
          that.noHistory = false;
          that.invalidModel = [];

          if (callback != null) {
            callback();
          }
        });
    } else if (callback != null) {
      callback();
    }
  }

  onLoadIfNeededCallback(entriesToPrint?: any[], callback?: Function): void {

    if (entriesToPrint == null || entriesToPrint.length == 0) {
      if (this.historyResultsState.length == 0) {
        this.noHistory = true;
      } else {
        this.historyResultsState = this.viewStatePipe.transform([...this.historyResultsState], 'historyResults');
      }
    } else {
      this.noHistory = false;

      for (var item of entriesToPrint) {
        this.updateData(1, false, item, this.resultAsIntegerState, false, undefined, false);
      }
    }

    this.loadingState = this.viewStatePipe.transform(false, 'loading');
    this.onLoadError = false;
    this.invalidModel = [];

    if (callback != null) {
      callback();
    }
  }

  updateData(historyAppend: number, updateResult: boolean, json: any, asInteger: boolean, overwriteExpression: boolean, originalExpression: string | undefined, isError: boolean, updateStateAsync?: boolean): void {
    var p = "";
    var msg = "";
    if (json.detail != null) {
      msg = json.detail;
      p = (originalExpression != null ? (originalExpression + " == ") : "") + msg;
    } else if (json.errorCode != null || json.warning != null) {
      msg = this.sharedService.formatErrorMessage(json.warning?.code || json.errorCode, json.warning?.args || json.errorArgs);
      p = (json.expressionNormalized != null ? (json.expressionNormalized + " == ") : json.expression != null ? (json.expression + " == ") : originalExpression != null ? (originalExpression + " == ") : "") + msg;
    } else if (json.resultToPrint != null) {
      msg = overwriteExpression && asInteger ? json.resultAsInteger : json.resultToPrint || json.result;

      msg = this._consolidateNumberString(msg);

      if (overwriteExpression) {
        this.updateExpression(json.expression, true);
      }
      p = (json.expression != null ? (json.expression + " == ") : (json.expressionNormalized + " == ")) + msg
    } else {
      msg = json;
      p = msg;
    }

    if (updateResult) {
      this.updateResultAsync(msg, updateStateAsync || false, isError);
    }

    if (historyAppend != -1) {
      if (historyAppend) {
        this.historyResultsState.push(p)
      } else {
        this.historyResultsState.unshift(p)
      }

      this.historyResultsState = this.viewStatePipe.transform(this.historyResultsState, 'historyResults');
    }
  }

  updateResultAsync(res: string, updateStateAsync: boolean, isError: boolean): void {
    if (updateStateAsync) {
      setTimeout(() => this._updateResult(res, isError), 250);
    } else {
      this._updateResult(res, isError);
    }
  }

  _updateResult(res: string, isError: boolean) {
    if (isError) {
      this.errorMessage = res;
      this.resultState = this.viewStatePipe.transform(this.sharedService.getTranslation("Error"), 'result');
    } else {
      this.errorMessage = undefined;
      this.resultState = this.viewStatePipe.transform(res, 'result');
    }

    this.resultState = this.viewStatePipe.transform(this._consolidateNumberString(this.resultState || ''), 'result');
  }

  _consolidateNumberString(val: string): string {
    if (val == Number.MAX_VALUE.toString().toLocaleUpperCase()) {
      val = "NaN";
    }

    return val;
  }

  updateExpression(text: string | undefined, overwrite: boolean): void {
    if (overwrite) {
      this.charPressed = text;
      this.overwrite = true;
    } else {
      this.charPressed = text;
      this.overwrite = false;
    }
  }
}
