import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Quest } from './Quest';

@Injectable({
  providedIn: 'root',
})

export class QuestService 
{
    private resourceFragment = 'api/quest';
    private httpClient: HttpClient;
    private fullUrl=''; 

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = http;
        this.fullUrl = baseUrl + this.resourceFragment;
    }

   
    public Create(quest: Quest): Observable<number> 
    {
        return this.httpClient.post<number>(this.fullUrl, quest);
    }

    public Read(id: string): Observable<Quest> 
    {
        var resourceUrl = this.fullUrl + '/' + id;
        console.log("Read quest " + resourceUrl);
        return this.httpClient.get<Quest>(resourceUrl);
    }

    public Update(quest: Quest): Observable<boolean> 
    {
        return this.httpClient.put<boolean>(this.fullUrl, quest);
    }

    public Delete(id: number): Observable<boolean> 
    {
        var resourceUrl = this.fullUrl + '/' + id;
        return this.httpClient.delete<boolean>(resourceUrl);
    }

    // 
    // Gets List-View of quests 
    // 1. 'choose' empty quests 
    // 2. 'read' filled out quests  
    // 
    public List(datafilter: string = ''): Observable<Quest[]>  
    {
        return this.httpClient.get<Quest[]>(this.fullUrl + '/list/' + datafilter);
    }

    public ListToFill()
    {
        return this.List("fill");
    }

    public ListToRead()
    {
        return this.List("read");
    }

    //
    //
    //
    GetFromDOM(document: any) : Observable<Quest> 
    {
        return new Observable<Quest>((observer) => {          
            var questIdElement = <HTMLInputElement> document.getElementsByName('quest-id')[0];
            var questAuthorElement = <HTMLInputElement> document.getElementsByName('quest-author')[0];
            var questTopicElement = <HTMLInputElement> document.getElementsByName('quest-topic')[0];
            var questResponseAuthorElement = <HTMLInputElement> document.getElementsByName('quest-responseauthor')[0];

            var newquest: Quest = 
            {
                id: parseInt(questIdElement.value),
                author: questAuthorElement.value,
                topic: questTopicElement.value,
                responseAuthor: questResponseAuthorElement.value,
                dialogs:  new Map<string, string>()
            }

            var answers = document.getElementsByName('answer-text');
            var questions = document.getElementsByName('question-text');
                    
            for (let index = 0; index < answers.length; index++)
            {
                var answerElement = <HTMLTextAreaElement>answers[index];
                var answerText = answerElement.value;

                var questionElement = <HTMLTextAreaElement>questions[index];
                var questionText = questionElement.value;

                newquest.dialogs.set(questionText, answerText);
            }

            observer.next(newquest);

            observer.complete();
        });        
    }
}