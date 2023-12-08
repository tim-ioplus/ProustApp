import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";

@Component({
    selector: 'app-questionnairelist',
    templateUrl: './questionnairelist.component.html'
 })
 
 export class QuestionnaireListComponent
 {
   public questionnaires: Quest[] | undefined;

   constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   {
      new QuestService(http, baseUrl).ListToRead()
      .subscribe(result => 
         {
             this.questionnaires = result;
             console.log(this.questionnaires);
         }, 
         error => console.error(error));
   }
 }
