import { Component, OnInit } from '@angular/core';
import { UserService } from "../../../services/UserService";
import { User } from "../../../models/User";

@Component({
    selector: 'users-list',
    templateUrl: './users.list.component.html',
    styleUrls: ['./users.list.component.css']
})
export class UsersListComponent implements OnInit {
    users: User[];

    constructor(public service: UserService) {}

    ngOnInit(): void {
        this.service.getUsersList().subscribe(
            result => {
                this.users = result.json() as User[];
            },
            error => console.error(error)
        );
    }
}
