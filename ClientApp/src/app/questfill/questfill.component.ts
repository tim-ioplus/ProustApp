import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ignoreElements } from "rxjs";
import {Router} from '@angular/router';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";
import { Dialog } from "../Dialog";


@Component({
    selector: 'app-questfill',
    templateUrl: './questfill.component.html'
 })
 
 export class QuestFillComponent
 {
    public quest: Quest = 
    {
        id: 0,
        author: '',
        topic: '',
        responseAuthor: '',
        dialogs:  new Map<string, string>()  
    }

    public questAmountQuestions: number = 0; 
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
            this.quest = result;
            

            for (const [key, value] of Object.entries(this.quest.dialogs)) 
            {
                this.questAmountQuestions++;
                
                var dx: Dialog = 
                {
                    question: key,
                    answer: '',
                    number: this.questAmountQuestions
                };
                
                this.dialogx.push(dx);
            }

            
        }, 
        error => console.error(error));
    }

    onSubmit():void 
    {
        new QuestService(this.http, this.mybaseUrl).GetFromDOM(document)
        .subscribe(newquest =>{
            new QuestService(this.http, this.mybaseUrl).Create(newquest)
            .subscribe(
                (result: number) => 
                {
                    this.router.navigate(['quest', result]);                           
                }, 
                (error: any) => 
                    console.log(error)
            );
        }, (error: any) => console.log(error) );        
    } 

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.quest.dialogs);
        return mkeys;
    }
 }
