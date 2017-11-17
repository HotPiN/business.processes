import { Component, Input, OnInit } from '@angular/core';
import { Job } from "../../../models/Job";
import { JobService } from "../../../services/JobService";
import {ActivatedRoute, Params} from "@angular/router";

@Component({
    selector: 'job-edit',
    templateUrl: './job.edit.component.html',
    styleUrls: ['./job.edit.component.css']
})
export class JobEditComponent implements OnInit {
    job: Job;
    id: number;

    constructor(public service: JobService, public route: ActivatedRoute) {
        this.route.params.subscribe(params => {
            this.id = parseInt(params["id"]);
        });
    }

    ngOnInit(): void {
        this.service.getJobById(this.id).subscribe(
            result => {
                this.job = result.json() as Job;
            },
            error => console.error(error)
        );
    }
}