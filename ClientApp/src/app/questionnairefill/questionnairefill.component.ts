import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ignoreElements } from "rxjs";
import {Router} from '@angular/router';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";

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

    public mybaseUrl = 'BASE_URL';
    http: any;
    router: Router;
    
    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string, private routerc: Router)
    {
        this.http = httpc;
        this.mybaseUrl = baseUrl;
        this.router = routerc;
        // Do not laod questionnaire data, its going to be created here        
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
