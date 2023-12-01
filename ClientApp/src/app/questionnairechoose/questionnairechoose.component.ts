import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";
import {RouterModule} from '@angular/router';

@Component({
    selector: 'app-questionnairechoose',
    templateUrl: './questionnairechoose.component.html'
 })
 
 export class QuestionnaireChooseComponent
 {
   public questionnaires: Quest[] | undefined;

   constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   {
      new QuestService(http, baseUrl).List("choose")
      .subscribe(result => 
         {
             this.questionnaires = result;
             console.log(this.questionnaires);
         }, 
         error => console.error(error));
   }
 }