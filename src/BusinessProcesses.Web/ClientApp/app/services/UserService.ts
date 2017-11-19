import { Inject, Injectable } from "@angular/core";
import { Http } from "@angular/http";

@Injectable()
export class UserService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {}

    public getUsersList() {
        return this.http.get(this.baseUrl + 'api/Users/GetUsersList');
    }
}