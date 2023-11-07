import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Questionnaire } from "../Questionnaire";
import { QuestionnaireService } from "../QuestionnaireService";
import {RouterModule} from '@angular/router';

@Component({
    selector: 'app-questionnairechoose',
    templateUrl: './questionnairechoose.component.html'
 })
 
 export class QuestionnaireChooseComponent
 {
   public questionnaires: Questionnaire[] | undefined;

   constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   {
      new QuestionnaireService(http, baseUrl).List("choose")
      .subscribe(result => 
         {
             this.questionnaires = result;
             console.log(this.questionnaires);
         }, 
         error => console.error(error));
   }
 }