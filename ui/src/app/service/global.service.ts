import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Team } from "../model/team";
import { Observable, of } from 'rxjs';
import { Period } from '../model/period';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  constructor(
    private http: HttpClient) { }

  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>("http://localhost:5000/api/team/list");
  }

  getPeriods(teamId: number): Observable<Period[]> {
    return this.http.get<Period[]>("http://localhost:5000/api/period/list?teamid=" + teamId);
  }
}
