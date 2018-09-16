import { SharedService } from './../../../services/shared.service';
import { Router, NavigationEnd } from '@angular/router';
import { SurveyService } from '../../services/survey.services';
import {
  Component,
  OnInit,
  ViewChildren,
  QueryList,
  OnDestroy
} from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import * as cloneDeep from 'lodash/cloneDeep';
import { Select, Value } from './classes/survey-creator.classes';

@Component({
  selector: 'app-survey-creator',
  templateUrl: './survey-creator.component.html',
  styleUrls: ['./survey-creator.component.scss']
})
export class SurveyCreatorComponent implements OnInit, OnDestroy {
  @ViewChildren('inputs')
  inputs: QueryList<any>;
  @ViewChildren('inputs2')
  inputs2: QueryList<any>;

  invoiceForm: FormGroup;
  default = 'multiple-grid';
  disabled = true;
  index = 0;
  questionIndex = 0;
  id: number;
  // subs
  saveSurveySub: any;
  createSurveySub: any;

  selects: Select[] = [
    {
      control: [
        { value: 'short-answer', viewValue: 'Krótka odpowiedź' },
        { value: 'long-answer', viewValue: 'Długa odpowiedź' }
      ]
    },
    {
      control: [
        { value: 'single-choice', viewValue: 'Jednokrotny wybór' },
        { value: 'multiple-choice', viewValue: 'Wielokrotny wybór' }
      ]
    },
    {
      control: [
        { value: 'dropdown-menu', viewValue: 'Menu rozwijane' },
        { value: 'linear-scale', viewValue: 'Skala liniowa' }
      ]
    },
    {
      control: [
        {
          value: 'single-grid',
          viewValue: 'Siatka jednokrotnego wyboru'
        },
        {
          value: 'multiple-grid',
          viewValue: 'Siatka wielokrotnego wyboru'
        }
      ]
    }
  ];

  minValue: Value[] = [{ value: 0 }, { value: 1 }];
  maxValue: Value[] = [
    { value: 2 },
    { value: 3 },
    { value: 4 },
    { value: 5 },
    { value: 6 },
    { value: 7 },
    { value: 8 },
    { value: 9 },
    { value: 10 }
  ];
  info = {
    add: 'Dodaj pytanie',
    copy: 'Duplikuj',
    delete: 'Usuń pytanie'
  };

  sort(sortableList, event) {
    //   if (this.index === 0) {
    //     // console.log(sortableList);
    //     // console.log(event);
    //     const current = sortableList[event.currentIndex];
    //     const swapWith = sortableList[event.newIndex];
    //     sortableList[event.newIndex] = current;
    //     sortableList[event.currentIndex] = swapWith;
    //     this.index++;
    //   } else {
    //     this.index = 0;
    //   }
  }

  constructor(
    private fb: FormBuilder,
    private surveyService: SurveyService,
    private sharedService: SharedService,
    private router: Router
  ) {}

  ngOnInit() {
    const form = this.surveyService.getSurveyToOpen();
    if (form) {
      this.id = form.id;
      this.createQuestionData(form.content);
    } else {
      this.createQuestionData();
    }
    // this.createSurvey();
    this.saveSurveyOnClick();
    this.sharedService.showCreatorButton(true);
  }

  saveSurveyOnClick() {
    this.saveSurveySub = this.sharedService.saveButton.subscribe(() => {
      this.onSubmit();
    });
  }
  createSurvey() {
    this.createSurveySub = this.surveyService.createSurvey().subscribe(() => {
      console.log('created');
    });
  }

  // creating FormGroup  -- Main Form
  createQuestionData(form?) {
    this.invoiceForm = this.fb.group(this.populateQuestionData(form));
    this.createQuestionField(form);
  }
  populateQuestionData(form?) {
    let group;
    if (form) {
      group = {
        Form_Title: [form.Form_Title],
        Created_Date: [form.Created_Date],
        Created_Time: [form.Created_Time],
        QuestionData: this.fb.array([])
      };
    } else {
      group = {
        Form_Title: ['Formularz bez nazwy'],
        Created_Date: [new Date().toLocaleDateString()],
        Created_Time: [new Date().toLocaleTimeString()],
        QuestionData: this.fb.array([])
      };
    }
    return group;
  }
  createQuestionField(form?) {
    if (form) {
      const questionData = form.QuestionData;
      const i = -1;
      questionData.forEach(question => {
        this.addQuestion(i, question);
      });
    } else {
      this.addQuestion(-1);
    }
  }

  addQuestion(i, question?) {
    const questionData: FormArray = this.invoiceForm.get(
      `QuestionData`
    ) as FormArray;
    this.addQuestionDataControls(questionData, i, question);
  }
  copyQuestion(question, index) {
    const sortableList = this.invoiceForm.controls.QuestionData as FormArray;
    const length = sortableList.length;
    const clonedObject = cloneDeep(question);
    const newIndex = index + 1;
    if (index !== length - 1) {
      const questionList = sortableList.controls;
      for (let i = newIndex; i < length; i++) {
        questionList[newIndex]['controls'].QuestionPosition.setValue(i + 1);
      }
    }
    clonedObject.controls.QuestionPosition.setValue(newIndex);
    sortableList.insert(newIndex, clonedObject);
  }
  removeQuestion(i) {
    const questionArr = this.invoiceForm.controls.QuestionData as FormArray;
    const length = questionArr.controls.length;
    if (questionArr.controls.length > 1) {
      questionArr.removeAt(i);
      if (i !== length - 1) {
        this.setCurrentQuestionPositions(i, questionArr.controls, length - 1);
      }
    } else {
      questionArr.removeAt(0);
      this.addQuestionDataControls(questionArr, -1);
    }
  }
  setCurrentQuestionPositions(index, array, length) {
    for (let i = index; i < length; i++) {
      array[i].controls.QuestionPosition.setValue(i);
    }
  }

  addQuestionDataControls(questionData, i, question?) {
    const group = this.fb.group(this.populateQuestionDataControls(i, question));
    this.createFieldData(group.controls, question);
    questionData.push(group);
  }
  populateQuestionDataControls(i, question?) {
    let group;
    if (question) {
      group = {
        question: [question.question],
        select: [question.select],
        lastSelect: [undefined],
        QuestionPosition: [question.QuestionPosition],
        FieldData: this.fb.array([])
      };
    } else {
      group = {
        question: [''],
        select: [this.default],
        lastSelect: [undefined],
        QuestionPosition: [i + 1],
        FieldData: this.fb.array([])
      };
    }
    return group;
  }
  createFieldData(controls, question?) {
    if (question) {
      const FieldData = question.FieldData;
      // const i = -1;
      FieldData.forEach(data => {
        this.addGroup(controls.FieldData, controls.select.value, data, true);
      });
    } else {
      this.addGroup(controls.FieldData, controls.select.value);
    }
  }
  addGroup(FieldData, select: string, data?, isForm?) {
    switch (select) {
      case 'short-answer':
      case 'long-answer':
        this.addInput(FieldData);
        break;
      case 'linear-scale':
        this.addLinearScaleField(FieldData, data);
        break;
      case 'dropdown-menu':
      case 'single-choice':
      case 'multiple-choice':
        this.addArray(FieldData, data, isForm);
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.addSelectionGridField(FieldData, data, isForm);
        break;
    }
  }
  addArray(FieldData, data?, isForm?) {
    console.log(data);
    const group = this.fb.group({
      choiceOptions: this.fb.array([])
    });
    this.createChoiceControls(
      group.controls.choiceOptions,
      'opcja',
      data,
      isForm
    );
    FieldData.push(group);
  }
  createChoiceControls(choiceOptionsField, name, data?, isForm?) {
    if (data) {
      if (isForm === true) {
        const choiceData = data.choiceOptions;
        choiceData.forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      } else {
        data.forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      }
    } else {
      this.addChoiceField(choiceOptionsField, name);
    }
  }
  addInput(FieldData) {
    const group = this.fb.group({
      input: [{ value: '', disabled: this.disabled }]
    });
    FieldData.push(group);
  }
  addSelectionGridField(FieldData, data?, isForm?) {
    const group = this.fb.group({
      columns: this.fb.array([]),
      rows: this.fb.array([])
    });
    this.addField(group.controls.columns, group.controls.rows, isForm, data);
    FieldData.push(group);
  }

  addField(choiceData, choiceData2, isForm?, data?) {
    console.log(data);
    if (isForm !== undefined && data !== undefined) {
      if (isForm === true) {
        data.columns.forEach(column => {
          this.addChoiceField(choiceData, 'kolumna', column);
        });
        data.rows.forEach(row => {
          this.addRowControl(choiceData2, 'wiersz', row);
        });
      } else if (isForm === false) {
        data.forEach(column => {
          this.addChoiceField(choiceData, 'kolumna', column);
        });
        this.addRowControl(choiceData2, 'wiersz');
      }
    } else {
      this.addChoiceField(choiceData, 'kolumna');
      this.addRowControl(choiceData2, 'wiersz');
    }
  }

  addLinearScaleField(choiceArr, data?) {
    const group = this.fb.group(this.populateLinearScale(data));
    choiceArr.push(group);
  }
  populateLinearScale(data?) {
    let group;
    if (data) {
      group = {
        minValue: [data.minValue],
        maxValue: [data.maxValue],
        minLabel: [data.minLabel],
        maxLabel: [data.maxLabel]
      };
    } else {
      group = {
        minValue: [1],
        maxValue: [5],
        minLabel: [''],
        maxLabel: ['']
      };
    }
    return group;
  }
  addRowControl(selectArr, name, data?) {
    const length = selectArr.controls.length;
    const group = this.fb.group(this.populateRowControl(name, length, data));
    selectArr.push(group);
    this.autofocusField(this.inputs2, length);
  }
  populateRowControl(name, length, data?) {
    let group;
    if (data) {
      group = {
        RowPosition: [data.RowPosition],
        input: [data.input]
      };
    } else {
      group = {
        RowPosition: [length],
        input: [`${name} ${length + 1}`]
      };
    }
    return group;
  }
  addChoiceField(selectArr, name, data?) {
    const length = selectArr.controls.length;
    const group = this.fb.group(this.populateChoiceField(name, length, data));
    selectArr.push(group);
    this.autofocusField(this.inputs);
  }
  populateChoiceField(name, length, data?) {
    let group;
    if (data) {
      group = {
        value: [{ value: false, disabled: this.disabled }],
        viewValue: [data.viewValue],
        ChoicePosition: [data.ChoicePosition]
      };
    } else {
      group = {
        value: [{ value: false, disabled: this.disabled }],
        viewValue: [`${name} ${length + 1}`],
        ChoicePosition: [length]
      };
    }
    return group;
  }
  autofocusField(inputs, i?) {
    setTimeout(() => {
      if (inputs && inputs.last) {
        if (!i) {
          inputs.last.nativeElement.focus();
        } else {
          inputs.toArray()[i].nativeElement.focus();
        }
      }
    }, 0);
  }

  removeField(index, FieldData, row?) {
    const length = FieldData.controls.length - 1;
    FieldData.removeAt(index);
    if (index !== length) {
      this.setCurrentFieldPositions(index, FieldData.controls, length, row);
    }
  }
  setCurrentFieldPositions(index, arr, length, row?) {
    {
      if (!row) {
        for (let i = index; i < length; i++) {
          arr[i].controls.ChoicePosition.setValue(i);
        }
      } else {
        for (let i = index; i < length; i++) {
          arr[i].controls.RowPosition.setValue(i);
        }
      }
    }
  }

  updateSelection(SingleChoice, choice, e) {
    SingleChoice.controls.forEach(el => {
      el.controls.value.setValue(false);
    });
    choice.controls.value.setValue(true);
    e.source.checked = true;
  }

  saveLastSelect(lastSelect, select: string) {
    lastSelect.setValue(select);
  }

  changeControl(question, i) {
    console.log(question);
    const FieldData = question.controls.FieldData;
    const select = question.value.select;
    const lastSelect = question.value.lastSelect;
    if (lastSelect !== select) {
      switch (lastSelect) {
        case 'single-choice':
        case 'multiple-choice':
        case 'dropdown-menu':
          switch (select) {
            case 'single-choice':
            case 'multiple-choice':
            case 'dropdown-menu':
              break;
            case 'single-grid':
            case 'multiple-grid':
              const control = FieldData.controls[
                i
              ].controls.choiceOptions.getRawValue();
              this.fieldRemoving(FieldData, select, control, false);
              break;
            default:
              this.fieldRemoving(FieldData, select);
              break;
          }
          break;
        case 'single-grid':
        case 'multiple-grid':
          switch (select) {
            case 'single-grid':
            case 'multiple-grid':
              break;
            case 'single-choice':
            case 'multiple-choice':
            case 'dropdown-menu':
              const control = FieldData.controls[
                i
              ].controls.columns.getRawValue();
              this.fieldRemoving(FieldData, select, control);
              break;
            default:
              this.fieldRemoving(FieldData, select);
              break;
          }
          break;
        default:
          this.fieldRemoving(FieldData, select);
          break;
      }
    }
  }
  fieldRemoving(FieldData, select, data?, isForm?) {
    const length = FieldData.controls.length - 1;
    for (let i = length; i >= 0; i--) {
      FieldData.removeAt(i);
    }
    this.addGroup(FieldData, select, data, isForm);
  }
  onSubmit() {
    console.log(JSON.stringify(this.invoiceForm.getRawValue()));
    console.log(this.invoiceForm.getRawValue());

    this.saveInLocalStorage();
    this.surveyService.saveSurveyToOpen(this.invoiceForm.getRawValue());
    this.router.navigateByUrl(`/app/admin/viewform`);
    // window.open('http://localhost:4200/app/admin/viewform', '_blank');
  }

  saveInLocalStorage() {
    const array = JSON.parse(localStorage.getItem('surveys')) || [];
    let isSurveySaved = false;
    const length = array.length;
    // const surveyObj = {
    //   id:
    // }
    if (this.id !== undefined) {
      for (let i = 0; i < length; i++) {
        if (array[i].id === this.id) {
          isSurveySaved = true;
          array[i].content = this.invoiceForm.getRawValue();
          break;
        }
      }
    }
    if (isSurveySaved === false) {
      const surveyObj = {
        id: length,
        content: this.invoiceForm.getRawValue()
      };
      array.push(surveyObj);
    }
    localStorage.setItem('surveys', JSON.stringify(array));
  }

  ngOnDestroy() {
    // this.createSurveySub.unsubscribe();
    this.surveyService.openCreator(undefined);
    this.saveSurveySub.unsubscribe();
    this.sharedService.showCreatorButton(false);
  }

  see(f) {
    console.log(f);
  }
}
