import { Inject, Injectable } from "@angular/core";
import { Http } from "@angular/http";

@Injectable()
export class JobService {
    
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {}
    
    public getJobsList() {
        return this.http.get(this.baseUrl + 'api/JobApi/GetJobsList');
    }

    public getJobById(id: number) {
        return this.http.get(this.baseUrl + 'api/JobApi/GetJobById?id=' + id);
    }
}