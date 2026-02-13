import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent {

  contactForm: FormGroup;
  message = '';

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService
  ) {

    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [
  Validators.required,
  Validators.pattern('^[0-9]{10}$')
]],

      message: ['', Validators.required]
    });

  }

  onSubmit() {

    if (this.contactForm.valid) {

      this.contactService.sendContact(this.contactForm.value)
        .subscribe({
          next: (response) => {
            console.log(response);
            this.message = "Message sent successfully ✅";
            alert("Email sent successfully ✅");
            this.contactForm.reset();
          },
          error: (error) => {
            console.error(error);
            this.message = "Error sending message ❌";
            alert("Error sending email ❌");
          }
        });

    } else {
      alert("Please fill all required fields");
    }

  }

}
