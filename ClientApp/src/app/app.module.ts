import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

// @todo remove - Old Quest Component  
import { QuestComponent }               from './quest/quest.component';
//
import { QuestionnaireCreateComponent } from './questionnairecreate/questionnairecreate.component';
import { QuestionnaireDetailComponent } from './questionnairedetail/questionnairedetail.component';
import { QuestionnaireEditComponent }   from './questionnaireedit/questionnaireedit.component'; 
import { QuestionnaireFillComponent }   from './questionnairefill/questionnairefill.component';
import { QuestionnaireListComponent }   from './questionnairelist/questionnairelist.component';

const routes: Routes = [
  //
  { path: '', component: HomeComponent, pathMatch: 'full' },
  //
  // @todo remove - Old Quest Component  
  { path: 'quest', component: QuestComponent },
  //
  // Lists new or filled out Questionnaires 
  { path: 'questionnaires', component: QuestionnaireListComponent },
  // 
  // View a Questionnaire, either blank or filled out
  { path: 'questionnaires/:id', component: QuestionnaireDetailComponent },
  //
  // Create a new Questionnaire
  { path: 'questionnaires/create', component: QuestionnaireCreateComponent },
  //
  // Edit an existing Questionnaire
  { path: 'questionnaires/edit/:id', component: QuestionnaireEditComponent },
  //
  // Fill out an existing Questionnaire
  { path: 'questionnaires/fill/:id', component: QuestionnaireFillComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    QuestComponent,
    QuestionnaireListComponent,
    QuestionnaireDetailComponent,
    QuestionnaireEditComponent,
    QuestionnaireFillComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
