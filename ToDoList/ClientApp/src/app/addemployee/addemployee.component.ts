import { Component, OnInit } from '@angular/core';
import { AddUserDTO, UserClient } from '../shared/apiservice.service';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-addemployee',
  templateUrl: './addemployee.component.html',
  styleUrls: ['./addemployee.component.css'],
  providers: [UserClient]
})
export class AddemployeeComponent implements OnInit {
  adduser: AddUserDTO = new AddUserDTO();

  constructor(private service: UserClient, private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit(): void {
  }
  addemployee() {
    debugger
    //this.adduser.isActive = true;
    //this.adduser.isDelete = false;
    this.service.addUserDTO(this.adduser).subscribe((res) => {
      
        Swal.fire({
          title: 'User Added Successfully',
          icon: 'success',
          confirmButtonText: 'Ok'
        })
      this.router.navigate(["/home"])
        
      
    }, err => {
      Swal.fire({
        title: 'user not creed',
        icon: 'error',
        confirmButtonText: 'Ok'
      })
    })
   
  }

}
