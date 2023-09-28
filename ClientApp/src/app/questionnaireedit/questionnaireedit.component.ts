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
        this.mybaseUrl = baseUrl;
        this.router = routerc;
        var resourceUrl = baseUrl+ 'quest';
        var id = document.URL.replace(resourceUrl+'/','');
        var fullurl = resourceUrl + '/' + id;
        this.questionnaire = new QuestionnaireService(this.http, this.mybaseUrl).Read(id);        
    }

    onSubmit():void 
    {
        var questionnaire = new QuestionnaireService(this.http, this.mybaseUrl).GetFromDOM(document);
        var redir = new QuestionnaireService(this.http, this.mybaseUrl).Update(questionnaire);
        this.router.navigate(['quests', questionnaire.id]);
    }

    public getDictionaryKeys()
    {
        var mkeys: string[] = []; 
        var mkeys = Object.getOwnPropertyNames(this.questionnaire.dialogs);
        return mkeys;
    }
}