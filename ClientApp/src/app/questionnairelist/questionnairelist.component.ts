import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Questionnaire } from "../Questionnaire";
import { QuestionnaireService } from "../QuestionnaireService";

@Component({
    selector: 'app-questionnairelist',
    templateUrl: './questionnairelist.component.html'
 })
 
 export class QuestionnaireListComponent
 {
   public questionnaires: Questionnaire[] | undefined;

   constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   {
      new QuestionnaireService(http, baseUrl).List("list")
      .subscribe(result => 
         {
             this.questionnaires = result;
             console.log(this.questionnaires);
         }, 
         error => console.error(error));
   }
 }
