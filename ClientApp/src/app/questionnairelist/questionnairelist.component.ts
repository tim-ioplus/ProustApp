import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ignoreElements } from "rxjs";
import { Questionnaire } from "../Questionnaire";
import { QuestionnaireService } from "../QuestionnaireService";

@Component({
    selector: 'app-questionnairelist',
    templateUrl: './questionnairelist.component.html'
 })
 
 export class QuestionnaireListComponent
 {
   private questionnaires: Questionnaire[] | undefined;

   constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   {
      this.questionnaires = new QuestionnaireService(http).List();
   }
 }
