import { MentorResponse } from "./mentor-response";

export interface MentorResponseForOutput extends MentorResponse {
  allMentorsInPage: MentorResponse;
}
