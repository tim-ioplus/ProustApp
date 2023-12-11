import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { QuestService } from "../QuestService";
import { Quest } from "../Quest";
import { Dialog } from "../Dialog";

@Component({
    selector: 'app-questedit',
    templateUrl: './questedit.component.html'
 })
 
 export class questEditComponent
 {    
    public quest: Quest = 
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

    public dialogx: Dialog[] = [];
    public questAmountQuestions: number = 0; 
    
    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string, private routerc: Router)
    {
        this.http = httpc;
        this.router = routerc;
        this.mybaseUrl = baseUrl;

        var splits = document.URL.split('/');
        var id = splits[splits.length-1];         
                
        new QuestService(this.http, this.mybaseUrl).Read(id)
        .subscribe(
            result => {
                this.quest = result;
                
                for (const [key, value] of Object.entries(this.quest.dialogs)) 
                {
                    this.questAmountQuestions++;
                    var dx: Dialog = 
                    {
                        question: key,
                        answer: value,
                        number: this.questAmountQuestions
                    };
                    
                    this.dialogx.push(dx);
                }
            }, 
            error => console.log(error));        
    }

    onSubmit():void 
    {
        new QuestService(this.http, this.mybaseUrl).GetFromDOM(document)
        .subscribe((quest: Quest) => 
            {
                new QuestService(this.http, this.mybaseUrl).Update(quest)
                .subscribe((updateResult : boolean) => 
                {
                   this.router.navigate(['quests', quest.id]);
                }, error => console.log(error))
            },
            error => console.log(error));
    }

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.quest.dialogs);
        return mkeys;
    }
}