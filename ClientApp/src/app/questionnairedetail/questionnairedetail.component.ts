import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { Quest } from "../Quest";
import { Dialog } from "../Dialog";
import { QuestService } from "../QuestService";

@Component({
    selector: 'app-questionnairedetail',
    templateUrl: './questionnairedetail.component.html'
 })
 
 export class QuestionnaireDetailComponent
 {    
    public questionnaire: Quest = 
    {
        id: 0,
        author: '',
        topic: '',
        responseAuthor: '',
        dialogs:  new Map<string, string>()
     }

    public questionnaireAmountQuestions: number = 0; 

    public dialogx: Dialog[] = [];


    public mybaseUrl = 'BASE_URL';

    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        var splits = document.URL.split('/');
        var id = splits[splits.length-1];         
        
        new QuestService(httpc, baseUrl).Read(id)
        .subscribe(result => 
            {
                this.questionnaire = result;
                

                for (const [key, value] of Object.entries(this.questionnaire.dialogs)) 
                {
                    this.questionnaireAmountQuestions++;
                    
                    var dx: Dialog = 
                    {
                        question: key,
                        answer: value,
                        number: this.questionnaireAmountQuestions
                    };
                    
                    this.dialogx.push(dx);
                }

                
            }, 
            error => console.error(error));
    }
}