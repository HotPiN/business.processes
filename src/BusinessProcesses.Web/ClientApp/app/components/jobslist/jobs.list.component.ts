import { Component, OnInit } from '@angular/core';
import { Job } from "../../models/Job";
import { JobService } from "../../services/JobService";

@Component({
    selector: 'jobs-list',
    templateUrl: './jobs.list.component.html',
    styleUrls: ['./jobs.list.component.css']
})
export class JobsListComponent implements OnInit {
    jobs: Job[];

    constructor(public service: JobService) {}

    ngOnInit(): void {
        this.service.getJobsList().subscribe(
            result => {
                this.jobs = result.json() as Job[];
            },
            error => console.error(error)
        );
    }
}
