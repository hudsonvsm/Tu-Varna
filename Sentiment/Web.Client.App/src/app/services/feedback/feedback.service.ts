import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Feedback } from '../../models/feedback';
import { PieChart } from '../../models/pieChart';

@Injectable()
export class FeedbackService {
  private url = 'http://localhost:5000/api/';

  constructor(private httpClient: HttpClient) {  }

  postFeedback(feedback: Feedback) {
    const url = this.url + 'feedback?api-version=1.0';
    return this.httpClient.post<Feedback>(url, feedback, {
      headers: this.getHeader()
    });
  }

  getChartFeedback() {
    const url = this.url + 'feedback/chart?api-version=1.0';

    return this.httpClient.get<Array<PieChart>>(url, {
      headers: this.getHeader()
    });
  }

  getAllFeedback() {
    const url = this.url + 'feedback?api-version=1.0';

    return this.httpClient.get<Array<Feedback>>(url, {
      headers: this.getHeader()
    });
  }

  updateUserFeedback(feedback: Feedback) {
    const url = this.url + 'mlinputfb/confirm?api-version=1.0';

    return this.httpClient.put<boolean>(url, feedback, {
      headers: this.getHeader()
    });
  }

  retrainUserFeedbackModel() {
    const url = this.url + 'mlinputfb/retrain?api-version=1.0';

    return this.httpClient.post<any>(url, {}, {
      headers: this.getHeader()
    });
  }

  private getHeader() {
    return new HttpHeaders({
      // 'Authorization': `Bearer ${this.auth.accessToken}`
    });
  }
}
