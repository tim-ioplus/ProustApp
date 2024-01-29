import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";
import {RouterModule} from '@angular/router';

@Component({
    selector: 'app-questchoose',
    templateUrl: './questschoose.component.html'
 })
 
 export class QuestChooseComponent
 {
   public quests: Quest[] | undefined;

   constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   {
      new QuestService(http, baseUrl).ListToFill()
      .subscribe(result => 
         {
             this.quests = result;
             console.log(this.quests);
         }, 
         error => console.error(error));
   }
 }