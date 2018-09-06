
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { SurveyDefaultComponent } from './survey-default/survey-default.component';
import { SurveyWriteComponent } from './survey-write/survey-write.component';
import { SurveyViewComponent } from './survey-view/survey-view.component';

const SurveyRoutes: Routes = [
    {
        path: '',
        component: SurveyDefaultComponent,
    },
    {
        path: 'write',
        component: SurveyWriteComponent
    },
    {
        path: 'view',
        component: SurveyViewComponent
    }
];

// export const routing = RouterModule.forRoot(appRoutes);

@NgModule({
    imports: [RouterModule.forChild(SurveyRoutes)],
    exports: [RouterModule]
})
export class SurveySpaceRoutingModule { }
