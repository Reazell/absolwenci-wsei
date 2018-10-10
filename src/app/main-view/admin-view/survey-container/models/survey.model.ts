// tslint:disable:max-classes-per-file
export class Survey {
  title: string;
  id: number;
  createdAt: string;
  // answered: boolean;
  questions: Question[];
  constructor(
    title: string,
    id: number,
    questions: Question[],
    createdAt?: string
  ) {
    this.title = title;
    this.id = id;
    this.createdAt = createdAt;
    this.questions = questions;
  }
}

export class SurveyModel extends Survey {
  created_date: string;
  created_time: string;
  questions: Question[];

  constructor(survey: Survey) {
    super(survey.title, survey.id, survey.questions);
    this.created_date = survey.createdAt
      .split('T')[0]
      .split('-')
      .reverse()
      .join('-');
    this.created_time = survey.createdAt.split('T')[1].split('.')[0];
  }
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
