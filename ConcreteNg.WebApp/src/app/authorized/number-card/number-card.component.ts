import { Component, Input, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-number-card',
  templateUrl: './number-card.component.html',
  styleUrls: ['./number-card.component.less']
})
export class NumberCardComponent implements OnInit {

    @Input() number: number;
    @Input() positiveMode: boolean;
    @Input() caption: string;
    public styleClasses: any;
    public matIcon: any;

    constructor() { }

    ngOnInit(): void {
        this.setValues()
    }

    ngOnChanges(changes: SimpleChanges) {
        this.setValues();
    }

    private setValues(){
        if(this.positiveMode){
            this.styleClasses = this.number > 0 ? ".material-icons color_green green-text" : ".material-icons color_red red-text";
            this.matIcon = this.number > 0 ? "check_circle_outline" : "error_outline";
        }
        else{
            this.styleClasses = this.number > 0 ? ".material-icons color_red red-text" : ".material-icons color_green green-text";
            this.matIcon = this.number > 0 ? "error_outline" : "check_circle_outline";
        }
    }
}
