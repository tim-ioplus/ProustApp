import { Component, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-questlist',
    templateUrl: './questlist.component.html'
 })
 export class QuestListComponent
 {
    public questlist: Quest[] = [];
    
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
    {
        // @Todo replace subscribe with observable
        var fullurl = baseUrl+ 'questlist';
        http.get<Quest[]>(fullurl).subscribe(result => 
        {            
            this.questlist = result;
            console.log('questlist result:');
            console.log(result);
            console.log(result[0]);
            console.log(result[1]);
        }, 
        error => console.error(error));
        console.log(fullurl);
        console.log('this.questlist:');
        console.log(this.questlist);

        http.get<object[]>(fullurl).subscribe(resultObj => 
            {            
                console.log('questlist resultObj:');
                console.log(resultObj);
                console.log(resultObj[0]);
                console.log(resultObj[1]);
            }, 
            error => console.error(error));
    }
 }

 interface Quest
 {
    answerAuthor: string,
    answerId: number,
    answerText: string,
    id: number,
    questionAuthor: string,
    questionId: number,
    questionText: string    
 }