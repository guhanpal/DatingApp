import { Component, Input, OnInit,Output,EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  model:any={};

  constructor(private authService:AuthService,private alertify:AlertifyService,private router:Router) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('Registration successful');  
    },error => {
      this.alertify.error(error);
      ;
    },() => {
     // this.router.navigate(['/home']);
     this.cancel();
    }
    );
  }

  cancel(){
    this.cancelRegister.emit(false);
    //console.log('cancelled');
  }

}
