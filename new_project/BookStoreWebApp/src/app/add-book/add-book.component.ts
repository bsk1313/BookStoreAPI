import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from '../book.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent implements OnInit {

  public bookFrom!: FormGroup;
  constructor(private fromBuilder : FormBuilder, private service : BookService) { }

  ngOnInit(): void {
    this.init();
  }

public saveBook(): void{
  this.service.addBook(this.bookFrom?.value).subscribe(result => {
    alert('New book added with id = ' + result );
  });
}

  private init() : void{
    this.bookFrom = this.fromBuilder.group({
      title:[],
      description:[]
    });
  }
}
