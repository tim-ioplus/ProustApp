import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Router} from '@angular/router';
import { Quest } from "../Quest";
import { QuestService } from "../QuestService";

@Component({
    selector: 'app-questcreate',
    templateUrl: './questcreate.component.html'
 })
 
 export class QuestCreateComponent
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
    
    constructor(httpc: HttpClient, @Inject('BASE_URL') baseUrl: string, private routerc: Router)
    {
        this.http = httpc;
        this.mybaseUrl = baseUrl;
        this.router = routerc;
        // Do not laod quest data, its going to be created here        
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
