import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-base-container',
  templateUrl: './base-container.component.html',
  styleUrls: ['./base-container.component.less']
})
export class BaseContainerComponent implements OnInit {

    public isExpanded = false;

    constructor() { }

    ngOnInit(): void {

    }

    public toggleMenu() {
        this.isExpanded = !this.isExpanded;
    }

}
