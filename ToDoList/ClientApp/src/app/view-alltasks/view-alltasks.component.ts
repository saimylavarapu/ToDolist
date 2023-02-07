import { Component, OnInit } from '@angular/core';
import { TaskClient, TaskDTO } from '../shared/apiservice.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-view-alltasks',
  templateUrl: './view-alltasks.component.html',
  styleUrls: ['./view-alltasks.component.css'],
  providers: [TaskClient]
})
export class ViewAlltasksComponent implements OnInit {
  gettask!: TaskDTO[];

  constructor(private service: TaskClient) { }

  ngOnInit(): void {
    this.getalltask();
  }

  getalltask() {
    this.service.getAllTasks().subscribe((res) => {
      this.gettask = res;
    })
  }
  delete(id: any) {
    this.service.deleteTask(id).subscribe((res) => {
      Swal.fire({
        title: 'Task Delete Successfully',
        icon: 'success',
        confirmButtonText: 'Ok'
      })
      this.getalltask();


    }, err => {
      Swal.fire({
        title: 'Request Fail',
        icon: 'error',
        confirmButtonText: 'Ok'
      })
    })
  }
}
    
    
 
