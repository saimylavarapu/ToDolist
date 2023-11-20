import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskByIDDTO, TaskClient, UpdateDTO, UpdateUerDTO, UserClient, UserDTOALL } from '../shared/apiservice.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-edittasks',
  templateUrl: './edittasks.component.html',
  styleUrls: ['./edittasks.component.css'],
  providers: [TaskClient, UserClient]
  
})
export class EdittasksComponent implements OnInit {
  edit!: TaskByIDDTO;
  users!: UserDTOALL[];
  id!: any;

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
  updatetask() {
    debugger
    var x = new UpdateDTO();
    x.pkTaskID = this.id;
    x.taskName = this.edit.taskName;
    x.fkUserID = this.edit.fkUserID;
    this.service.updateTask(x).subscribe((res) => {
      Swal.fire({
        title: 'Update user Task ',
        icon: 'success',
        confirmButtonText: 'Ok'
      })
    }, err => {
      Swal.fire({
        title: 'Task not Updated',
        icon: 'error',
        confirmButtonText: 'Ok'
      })
    })
  }
   


}
