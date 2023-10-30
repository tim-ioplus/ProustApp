import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { QuestionnaireCreateComponent } from './questionnairecreate/questionnairecreate.component';
import { QuestionnaireDetailComponent } from './questionnairedetail/questionnairedetail.component';
import { QuestionnaireEditComponent }   from './questionnaireedit/questionnaireedit.component'; 
import { QuestionnaireFillComponent }   from './questionnairefill/questionnairefill.component';
import { QuestionnaireListComponent }   from './questionnairelist/questionnairelist.component';
import { AboutComponent }   from './about/about.component';
import { ContactComponent }   from './about/contact.component';
import { ImprintComponent } from './about/imprint.component';

const routes: Routes = [
  //
  { path: '', component: HomeComponent, pathMatch: 'full' },
  //
  // Lists new or filled out Questionnaires 
  { path: 'questionnaires', component: QuestionnaireListComponent },
  { path: 'questionnaires/list', component: QuestionnaireListComponent },
  // 
  // View a Questionnaire, either blank or filled out
  { path: 'questionnaires/:id', component: QuestionnaireDetailComponent },
  { path: 'questionnaires/read/:id', component: QuestionnaireDetailComponent },
  //
  // Create a new Questionnaire
  { path: 'questionnaires/create', component: QuestionnaireCreateComponent },
  //
  // Edit an existing Questionnaire
  { path: 'questionnaires/edit/:id', component: QuestionnaireEditComponent },
  //
  // Fill out an existing Questionnaire
  { path: 'questionnaires/fill/:id', component: QuestionnaireFillComponent },
  //
  // Info about Questionnaire
  { path: 'about', component: AboutComponent },
  //
  // Contact about Questionnaire
  { path: 'contact', component: ContactComponent },
  //
  // lawly required Info
  { path: 'imprint', component: ImprintComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
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
