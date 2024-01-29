import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';


import { QuestDetailComponent } from './questdetail/questdetail.component';
//import { questEditComponent }   from './questedit/questedit.component'; 
import { QuestFillComponent }   from './questfill/questfill.component';
//import { questChooseComponent } from './questchoose/questchoose.component';
import { QuestListComponent }   from './questlist/questlist.component';
import { AboutComponent }               from './about/about.component';
import { ContactComponent }             from './about/contact.component';
import { ImprintComponent }             from './about/imprint.component';
import { QuestCreateComponent } from './questcreate/questcreate.component';

const routes: Routes = [
  //
  { path: '', component: HomeComponent, pathMatch: 'full' },
  //
  // Lists new or filled out quests 
  
  { path: 'quests', component: QuestListComponent },
  //{ path: 'quests/list', component: questListComponent },
  //{ path: 'quests/choose', component: questChooseComponent },

  // 
  // View a quest, either blank or filled out
  //{ path: 'quests/:id', component: QuestDetailComponent },
  { path: 'quest/read/:id', component: QuestDetailComponent },
  //
  // Create a new quest
  // { path: 'quests/create', component: QuestCreateComponent },
  //
  // Edit an existing quest
  // { path: 'quests/edit/:id', component: questEditComponent },
  //
  // Fill out an existing quest
  { path: 'quests/fill/:id', component: QuestFillComponent },
  //
  // Info about quest
  { path: 'about', component: AboutComponent },
  //
  // Contact about quest
  { path: 'contact', component: ContactComponent },
  //
  // lawly required Info
  { path: 'imprint', component: ImprintComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    QuestDetailComponent,
    QuestFillComponent, 
    QuestListComponent
    /*
    questCreateComponent,
    questEditComponent,
    questChooseComponent
    */
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
