import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-questlist',
    templateUrl: './questlist.component.html'
 })
 
 export class QuestListComponent
 {
   public quests: Quest[] | undefined;

   constructor(private router:Router, private activatedRoute : ActivatedRoute,
    http: HttpClient, @Inject('BASE_URL') baseUrl: string)
   {
      new QuestService(http, baseUrl).ListToRead()
      .subscribe(result => 
         {
             this.quests = result;
             console.log(this.quests);
         }, 
         error => console.error(error));
   }
 }
