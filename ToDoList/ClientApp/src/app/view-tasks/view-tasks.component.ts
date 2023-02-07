import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserClient, UserTaskDTO } from '../shared/apiservice.service';

@Component({
  selector: 'app-view-tasks',
  templateUrl: './view-tasks.component.html',
  styleUrls: ['./view-tasks.component.css'],
  providers: [UserClient]
})
export class ViewTasksComponent implements OnInit {
  gettask!: UserTaskDTO[];
  id!: any;

  constructor(private service: UserClient, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      if (params) {
        this.id = params.id;
        this.viewtasks();
       

      }
    })
  }
  viewtasks() {
    debugger
    this.service.getAllTaskByID(this.id).subscribe((res) => {
      debugger
      this.gettask = res;
    })
  }

}
