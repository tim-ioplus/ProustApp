import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { Questionnaire } from "../Questionnaire";
import { Dialog } from "../Dialog";
import { QuestionnaireService } from "../QuestionnaireService";

@Component({
    selector: 'app-questionnairedetail',
    templateUrl: './questionnairedetail.component.html'
 })
 
 export class QuestionnaireDetailComponent
 {    
    public questionnaire: Questionnaire = 
    {
        id: 0,
        author: '',
        topic: '',
        responseAuthor: '',
        dialogs:  new Map<string, string>()
     }

    public dialogx: Dialog[] = [];


    public mybaseUrl = 'BASE_URL';

    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        var splits = document.URL.split('/');
        var id = splits[splits.length-1];         
        
        new QuestionnaireService(httpc, baseUrl).Read(id)
        .subscribe(result => 
            {
                /*console.log('<service')
                console.log(result);
                console.log(JSON.stringify(result));*/
                this.questionnaire = result;

                for (const [key, value] of Object.entries(this.questionnaire.dialogs)) 
                {
                    //console.log(`${key}: ${value}`);
                    var dx: Dialog = 
                    {
                        question: key,
                        answer: value
                    };
                    
                    this.dialogx.push(dx);
                }
                
            }, 
            error => console.error(error));
    }
}