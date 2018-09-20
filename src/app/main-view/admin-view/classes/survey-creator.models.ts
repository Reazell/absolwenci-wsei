import { Question } from './survey.model';
import { FormArray } from '../../../../../node_modules/@angular/forms';

export class Control {
  value: any;
  viewValue: string;
  constructor(value: any, viewValue: string) {
    this.value = value;
    this.viewValue = viewValue;
  }
}
export class Select {
  control: Control[];
  constructor(control: Control[]) {
    this.control = control;
  }
}

export class Value {
  value: number;
  constructor(value: number) {
    this.value = value;
  }
}
export class Tooltip {
  add: string;
  copy: string;
  delete: string;
  constructor(add: string, copy: string, deletee: string) {
    this.add = add;
    this.copy = copy;
    this.delete = deletee;
  }
}

export class Update {
  id: number;
  Title: string;
  Questions: Question[];
}

export class QuestionData {
  content: string;
  select: string;
  lastSelect: string;
  QuestionPosition: number;
  FieldData: FormArray;
}

export class ChoiceOptions {
  viewValue: string;
  value: boolean;
  ChoicePosition: number;
}

export class MainForm {
  title: string;
  questions: FormArray;
}
export class RowData {
  rowPosition: number;
  input: string;
}
