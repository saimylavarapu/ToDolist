import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskByIDDTO, TaskClient, TaskDTO, UserClient, UserDTOALL } from '../shared/apiservice.service';

@Component({
  selector: 'app-edittask',
  templateUrl: './edittask.component.html',
  styleUrls: ['./edittask.component.css'],
  providers: [TaskClient]
})
export class EdittaskComponent implements OnInit {
  edit!: TaskByIDDTO;
  id!: any;
  users!: UserDTOALL[];


  constructor(private service: TaskClient, private route: ActivatedRoute,
    private router: Router, private Service: UserClient) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      if (params) {
        this.id = params.id;
        this.gettask();
        this.getallemployee()

      }
    })


  }

  gettask() {
    debugger
    this.service.getByID(this.id).subscribe((res) => {
      this.edit = res[0];
    })
  }
  getallemployee() {
    this.Service.getAllUsers().subscribe((res) => {
      this.users = res;
    })
  }

}
