import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetByIDDTO, UpdateUerDTO, UserClient, UserDTOALL } from '../shared/apiservice.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [UserClient]
})
export class EditComponent implements OnInit {
  id: any;
  details!: GetByIDDTO;
 
 
  
 
  constructor(private service: UserClient, private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      if (params) {
        this.id = params.id;
        this.getalldetails()

      }
    })
  }
  getalldetails() {
    debugger
    this.service.getByID(this.id).subscribe((res) => {
      this.details = res[0];
    })
  }
  update() {
    debugger
    var x = new UpdateUerDTO();
    x.addresss = this.details.addresss;
    x.emailAddress = this.details.emailAddress;
    x.mobileNo = this.details.mobileNo;
    x.password = this.details.password;
    x.userName = this.details.userName;
    x.userID = this.id;

    this.service.updateUser(x).subscribe((res) => {
      Swal.fire({
        title: 'User Updated Successfully',
        icon: 'success',
        confirmButtonText: 'Ok'
      })
     


    }, err => {
      Swal.fire({
        title: 'User not Updated',
        icon: 'error',
        confirmButtonText: 'Ok'
      })
    })

 
  }

}
