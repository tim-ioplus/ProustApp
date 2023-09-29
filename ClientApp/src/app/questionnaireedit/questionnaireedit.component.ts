import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { QuestionnaireService } from "../QuestionnaireService";
import { Questionnaire } from "../Questionnaire";

@Component({
    selector: 'app-questionnaireedit',
    templateUrl: './questionnaireedit.component.html'
 })
 
 export class QuestionnaireEditComponent
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
        this.http = httpc;
        this.router = routerc;
        this.mybaseUrl = baseUrl;

        var splits = document.URL.split('/');
        var id = splits[splits.length-1];         
                
        new QuestionnaireService(this.http, this.mybaseUrl).Read(id)
        .subscribe(
            result => {
                this.questionnaire = result;
            }, 
            error => console.log(error));        
    }

    onSubmit():void 
    {
        new QuestionnaireService(this.http, this.mybaseUrl).GetFromDOM(document)
        .subscribe((questionnaire: Questionnaire) => 
            {
                new QuestionnaireService(this.http, this.mybaseUrl).Update(questionnaire)
                .subscribe((updateResult : boolean) => 
                {
                   this.router.navigate(['quests', questionnaire.id]);
                }, error => console.log(error))
            },
            error => console.log(error));
    }

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.questionnaire.dialogs);
        return mkeys;
    }
}