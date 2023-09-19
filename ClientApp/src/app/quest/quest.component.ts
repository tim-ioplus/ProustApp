import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Component({
    selector: 'app-quest',
    templateUrl: './quest.component.html'
 })
 
 export class QuestComponent
 {    
    public quests: Quest[] = [];
    public mybaseUrl = 'BASE_URL';
    http: any;
    
    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        this.mybaseUrl = baseUrl;
   
        httpc.get<Quest[]>(baseUrl+ 'quest')
        .subscribe(result => 
        {
            this.quests = result;
        }, 
        error => console.error(error));

        this.http = httpc;
    }

    onSubmit():void 
    {
        var newquests = this.GetQuest();  
        console.log(newquests);
        var url = this.mybaseUrl + 'quest';

        this.http.post(url, newquests)
        .subscribe(
            (result: any) => 
            {
            console.log(result);
            alert('success');
            }, 
            (error: any) => 
                console.log(error)
        );
    }


    GetQuest(): any
    {
        var questData : any = {
            quests: [{
                id: 0, 
                questionId: 0, questionAuthor: '', questionText: '', 
                answerId: 0, answerAuthor: '', answerText: ''
            }],
          };
        
        var answers = document.getElementsByName('answer-text');
        var questions = document.getElementsByName('question-text');
        var inputQuestionAuthor = '';
        var inputAnswerAuthor = '';
                
        for (let index = 0; index < answers.length; index++)
        {
            var answerElement = <HTMLTextAreaElement>answers[index];

            var newquest : Quest = 
            {
                id: 0, 
                questionId: index, questionAuthor: inputQuestionAuthor, questionText: '', 
                answerId: 0, answerAuthor: inputAnswerAuthor, answerText: answerElement.value
            };

            questData.quests.push(newquest);
        }

        return questData;
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