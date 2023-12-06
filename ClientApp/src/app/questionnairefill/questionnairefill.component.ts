import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ignoreElements } from "rxjs";
import {Router} from '@angular/router';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";
import { Dialog } from "../Dialog";


@Component({
    selector: 'app-questionnairefill',
    templateUrl: './questionnairefill.component.html'
 })
 
 export class QuestionnaireFillComponent
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
    http: any;
    router: Router;
    
    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string, private routerc: Router)
    {
        this.http = httpc;
        this.mybaseUrl = baseUrl;
        this.router = routerc;
        
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
                    answer: '',
                    number: this.questionnaireAmountQuestions
                };
                
                this.dialogx.push(dx);
            }

            
        }, 
        error => console.error(error));
    }

    onSubmit():void 
    {
        new QuestService(this.http, this.mybaseUrl).GetFromDOM(document)
        .subscribe(newquestionnaire =>{
            new QuestService(this.http, this.mybaseUrl).Create(newquestionnaire)
            .subscribe(
                (result: number) => 
                {
                    this.router.navigate(['questionnaire', result]);                           
                }, 
                (error: any) => 
                    console.log(error)
            );
        }, (error: any) => console.log(error) );        
    } 

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.questionnaire.dialogs);
        return mkeys;
    }
 }
