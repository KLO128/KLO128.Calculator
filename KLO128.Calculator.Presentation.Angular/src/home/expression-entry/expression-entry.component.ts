import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { SharedService } from '../../shared/shared.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'expression-entry',
  templateUrl: './expression-entry.component.html',
  styleUrls: ['./expression-entry.component.css'],
  styles: [`
    :host {
        padding: 0;
      }
  `]
})
export class ExpressionEntryComponent implements OnChanges, OnInit {

  tbInputId = "tbInput";
  cursorIndex = 0;
  selectionLength = 0;
  expression: string | undefined;
  @Input() overwrite = false;
  @Input() charPressed: string | undefined;
  @Output() expressionChange = new EventEmitter<string | undefined>();

  constructor(private sharedService: SharedService) {
  }

  ngOnInit(): void {

  }

  ngOnChanges(changes: SimpleChanges): void {
   this._solveCharPressed();
    this._expressionInit();
  }

  getInput(): HTMLTextAreaElement | undefined {
    return document.getElementById(this.tbInputId) as HTMLTextAreaElement;
  }

  onFocus(event: Event) {
    var currTarget = this.getInput();

    if (currTarget != null) {
      if (event.currentTarget == currTarget) {
        this.onClick();
      } else {
        this.onBlur();
      }
    }

    event.stopPropagation();
  }

  onClick(): void {
    var currTarget = this.getInput();

    if (currTarget != null) {
      //currTarget.selectionStart = this.cursorIndex;
      //currTarget.selectionEnd = this.cursorIndex + this.selectionLength;
      this.cursorIndex = currTarget.selectionStart!;
      this.selectionLength = currTarget.selectionEnd - this.cursorIndex;
    }
  }

  onBlur(): void {
    var currTarget = this.getInput();

    if (currTarget) {
      //currTarget.value = this.expression || '';
      currTarget.setSelectionRange(this.cursorIndex, this.cursorIndex + this.selectionLength);
    }
  }

  onExpressionChanged(event: Event): void {
    var currTarget = this.getInput();

    if (currTarget != null) {
      this.expression = currTarget.value;
      this.expressionChange.emit(currTarget.value);
      this.onFocus(event);
    }
  }

  _solveCharPressed(): void {
    if (this.charPressed != undefined) {

      if (this.overwrite) {
        this.expression = this.charPressed;
        this.cursorIndex = this.expression.length;
      } else if (this.charPressed === 'C') {
        this.expression = "";
        this.cursorIndex = 0;
      } else if (this.charPressed === 'del') {
        if (this.selectionLength === 0) {
          this.cursorIndex -= 1;
          this.expression = (this.expression?.substring(0, this.cursorIndex) || "") + this.expression?.substring(this.cursorIndex + 1);
        } else {
          this.expression = (this.expression?.substring(0, this.cursorIndex) || "") + this.expression?.substring(this.cursorIndex + this.selectionLength);
        }
      } else {
        if (this.charPressed === '.') {
          this.charPressed = this.sharedService.getTranslation('decimalPoint');
        }

        this.expression = this.expression?.substring(0, this.cursorIndex) + this.charPressed + this.expression?.substring(this.cursorIndex + this.selectionLength);
        this.cursorIndex += this.charPressed.length;
      }

      this.selectionLength = 0;
      this.onBlur();

      this.expressionChange.emit(this.expression);
    }
  }

  _expressionInit(): void {
    if (this.expression === undefined) {
      this.expression = '';
    }
  }
}
