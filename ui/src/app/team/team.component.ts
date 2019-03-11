import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Period } from '../model/period';
import { GlobalService } from '../service/global.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {
  periods: Period[];

  constructor(
    private route: ActivatedRoute,
    private globalService: GlobalService
  ) { }

  ngOnInit(): void {
    this.getPeriods();
  }

  getPeriods(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.globalService.getPeriods(id)
      .subscribe(periods => this.periods = periods);
  }

}
