import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { JobsListComponent } from "./components/jobslist/jobs.list.component";
import { JobService } from "./services/JobService";
import { UsersListComponent } from "./components/userslist/users.list.component";
import { UserService } from "./services/UserService";
import { JobEditComponent } from "./components/jobedit/job.edit.component";
import { ClarityModule } from 'clarity-angular';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        JobsListComponent,
        JobEditComponent,
        UsersListComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'jobs', pathMatch: 'full' },
            { path: 'jobs', component: JobsListComponent },
            { path: 'jobs/:id', component: JobEditComponent },
            { path: 'users', component: UsersListComponent },
            { path: '**', redirectTo: 'jobs' }
        ]),
        ClarityModule.forRoot()
    ],
    providers: [
        JobService,
        UserService
    ]
})
export class AppModuleShared {
}
