import { Component, OnInit } from '@angular/core';
import { AddTaskDTO, TaskClient, UserClient, UserDTOALL } from '../shared/apiservice.service';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css'],
  providers: [TaskClient, UserClient]
})
export class AddTaskComponent implements OnInit {
  users!: UserDTOALL[];
  addtask: AddTaskDTO = new AddTaskDTO();


  constructor(private service: TaskClient, private Service: UserClient, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getallemployee();

  }
  getallemployee() {
    this.Service.getAllUsers().subscribe((res) => {
      this.users = res;
    })
  }

  assigntask() {
    debugger
   
    this.service.addIteam(this.addtask).subscribe((res) => {
      Swal.fire({
        title: 'Task Added To the User',
        icon: 'success',
        confirmButtonText: 'Ok'
      })
      this.router.navigate(["/home"])


    }, err => {
      Swal.fire({
        title: 'fail',
        icon: 'error',
        confirmButtonText: 'Ok'
      })
    })
  }

}
