import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
@Component({
    selector: 'app-quest',
    templateUrl: './quest.component.html'
 })
 
 export class QuestComponent
 {    
    public questionnaire: Questionnaire = 
    {
        id: 0,
        author: '',
        topic: '',
        responseAuthor: '',
        dialogs:  new Map<string, string>()  
     }

    public mybaseUrl = 'BASE_URL';
    http: any;
    router: Router;
    
    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string, private routerc: Router)
    {
        this.mybaseUrl = baseUrl;
        this.router = routerc;
        var resourceUrl = baseUrl+ 'quest';
        var id = document.URL.replace(resourceUrl+'/','');
        var fullurl = resourceUrl + '/' + id;

        httpc.get<Questionnaire>(fullurl)
        .subscribe(result => 
        {
            this.questionnaire = result;
        }, 
        error => console.error(error));

        this.http = httpc;
    }

    onSubmit():void 
    {
        var newquestionnaire = this.GetQuest();  
        console.log(newquestionnaire);
        var url = this.mybaseUrl + 'quest';

        this.http.post(url, newquestionnaire)
        .subscribe(
            (result: any) => 
            {
                console.log("Success   " + result);
                var redirectId = result[0] != null ? result[0] : '';
                if(redirectId != null && redirectId != '')
                {
                    this.Redirect(redirectId);
                }                            
            }, 
            (error: any) => 
                console.log(error)
        );
    }

    Redirect(redirectId: string): void
    {
        this.router.navigate(['quests', redirectId]);
    }


    GetQuest(): any
    {
        var newquestionnaire: Questionnaire = 
        {
            id: 0,
            author: '',
            topic: '',
            responseAuthor: '',
            dialogs:  new Map<string, string>()
        }
        
        var questionnaireIdElement = <HTMLInputElement> document.getElementsByName('questionnaire-id')[0];
        var questionnaireAuthorElement = <HTMLInputElement> document.getElementsByName('questionnaire-author')[0];
        var questionnaireTopicElement = <HTMLInputElement> document.getElementsByName('questionnaire-topic')[0];
        var questionnaireResponseAuthorElement = <HTMLInputElement> document.getElementsByName('questionnaire-responseauthor')[0];
        
        newquestionnaire.id = parseInt(questionnaireIdElement.value);
        newquestionnaire.author = questionnaireAuthorElement.value;
        newquestionnaire.topic = questionnaireTopicElement.value;
        newquestionnaire.responseAuthor = questionnaireResponseAuthorElement.value;

        var answers = document.getElementsByName('answer-text');
        var questions = document.getElementsByName('question-text');
                   
        for (let index = 0; index < answers.length; index++)
        {
            var answerElement = <HTMLTextAreaElement>answers[index];
            var answerText = answerElement.value;

            var questionElement = <HTMLTextAreaElement>questions[index];
            var questionText = questionElement.value;

            newquestionnaire.dialogs.set(questionText, answerText);
        }

        newquestionnaire.dialogs.get

        return newquestionnaire;
    }

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.questionnaire.dialogs);
        return mkeys;
    }
}

// @todo extract in one single class
interface Questionnaire
 {
    id: number;
    author: string;
    topic: string;
    responseAuthor: string;
    dialogs: Map<string, string>; 
 }