import { Component } from '@angular/core';
import { Quest } from '../Quest';
import { QuestService } from '../QuestService';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent 
{

  constructor
  (
    private questService: QuestService,
    private route: ActivatedRoute,
    private router: Router) { }

  quest: Quest = 
  {
      id: 0,
      author: '',
      topic: '',
      responseAuthor: '',
      dialogs:  new Map<string, string>()
   } 
  message = '';
  public isExpanded = false;

  toggleData()
  {
    this.message = '';
    this.getQuest("1");
  }

  getQuest(id: string): void {
    this.questService.Read(id)
      .subscribe({
        next: (data) => {
          this.quest = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }
}
