import { Component, OnInit } from '@angular/core';
import { UserClient, UserDTOALL, UserTaskDTO } from '../shared/apiservice.service';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrls: ['./getall.component.css'],
  providers: [UserClient]
})
export class GetallComponent implements OnInit {
  users!: UserDTOALL[];
  task!: UserTaskDTO[];

  constructor(private service: UserClient, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getalluserdetails();

  }
  getalluserdetails() {
    debugger
    this.service.getAllUsers().subscribe((res) => {
      this.users = res;
    })
  }
  delete(id: any) {
    this.service.deleteUser(id).subscribe((res) => {
      Swal.fire({
        title: 'User Delete Successfully',
        icon: 'success',
        confirmButtonText: 'Ok'
      })
      this.getalluserdetails();


    }, err => {
      Swal.fire({
        title: 'user not deleate',
        icon: 'error',
        confirmButtonText: 'Ok'
      })
    
    })
  }
 

}
