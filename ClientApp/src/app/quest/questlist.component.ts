import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-questlist',
    templateUrl: './questlist.component.html'
 })
 export class QuestListComponent
 {
    public quests: Quest[] = [];
    
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        http.get<Quest[]>(baseUrl+ 'quest/1').subscribe(result => 
        {
            this.quests = result;
        }, error => console.error(error));
    }
 }

 interface Quest
 {
    id: number,
    questionId: number,
    questionAuthor: string,
    questionText: string,
    answerId: number,
    answerAuthor: string,
    answerText: string
 }