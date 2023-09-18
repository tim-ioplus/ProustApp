import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-questlist',
    templateUrl: './questlist.component.html'
 })
 export class QuestListComponent
 {
    public questlist: Quest[] = [];
    
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        // @Todo replace subscribe with observable
        var fullurl = baseUrl+ 'questlist';
        http.get<Quest[]>(fullurl).subscribe(result => 
        {            
            this.questlist = result;
        }, 
        error => console.error(error));
    }
 }

 interface Quest
 {
    answerAuthor: string,
    answerId: number,
    answerText: string,
    id: number,
    questionAuthor: string,
    questionId: number,
    questionText: string    
 }