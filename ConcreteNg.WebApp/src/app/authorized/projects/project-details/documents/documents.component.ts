import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Project } from '../../../../models/project';
import { ProjectDetailsService } from '../project-details.service';
import { File as CustomFile } from '../../../../models/file';

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.less']
})
export class DocumentsComponent implements OnInit {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();

    files: CustomFile[] = []

    constructor(
        private projectDetailsService: ProjectDetailsService
    ) { }

    ngOnInit(): void {
        this.projectDetailsService.getProjectFiles(this.project.projectId).subscribe((res) => {
            this.files = res;
        })
    }

    downloadFile(fileId: number, fileName: string){
        this.projectDetailsService.downloadFile(fileId, fileName);
    }

    onFileSelected(event: any) {
        let files = event.target.files
        if (files) {
            this.projectDetailsService.uploadFile(files, this.project.projectId).subscribe((res) => {
                this.projectDetailsService.getProjectFiles(this.project.projectId).subscribe((res) => {
                    this.files = res;
                })
            })
        }
    }
}