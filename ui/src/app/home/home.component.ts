import { Component, OnInit } from '@angular/core';
import { Team } from "../model/team";
import { GlobalService } from "../service/global.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  teams: Team[];

  constructor(private teamService: GlobalService) { }

  ngOnInit(): void {
    this.getTeams();
  }

  getTeams(): void {
    this.teamService.getTeams()
      .subscribe(teams => this.teams = teams);
  }
}
