import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';

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
        
        /* *...* */

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