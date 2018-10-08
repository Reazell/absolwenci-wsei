// tslint:disable:max-classes-per-file
export class SurveyModel implements Survey {
  title: string;
  id: number;
  createdAt: string;
  created_date: string;
  created_time: string;
  // answered: boolean;
  questions: Question[];

  constructor(survey: Survey) {
    this.title = survey.title;
    this.id = survey.id;
    // this.answered = survey.answered;
    this.questions = survey.questions;
    this.createdAt = survey.createdAt;
    this.created_date = this.createdAt
      .split('T')[0]
      .split('-')
      .reverse()
      .join('-');
    this.created_time = this.createdAt.split('T')[1].split('.')[0];
  }
}

export class Survey {
  title: string;
  id: number;
  createdAt: string;
  // answered: boolean;
  questions: Question[];
}

export class Question {
  id: number;
  surveyId: number;
  questionPosition: number;
  content: string;
  select: string;
  fieldData: FieldData[];
}

export class FieldData {
  id: number;
  input: string;
  maxLabel: string;
  minLabel: string;
  maxValue: number;
  minValue: number;
  questionId: number;
  rows: Row[];
  choiceOptions: Choice[];
}

export class Row {
  id: number;
  input: string;
  fieldDataId: number;
  rowPosition: number;
}

export class Choice {
  id: number;
  optionPosition: number;
  value: boolean;
  viewValue: string;
  fieldDataId: number;
}
