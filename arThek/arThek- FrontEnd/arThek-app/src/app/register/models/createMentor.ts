import { MentorshipPackage } from './mentorshipPackage';

export interface IMentor {
  id: string;
  userRole: number;
  userName: string;
  email: string;
  password: string;
  confirmPassword: string;
  domain: string;
  profileImagePath: Uint8Array;
  userCreationDate: string;
  aboutMe: string;
  resume: Uint8Array;
  isVolunteer: boolean;
  linkdlUrl: string;
  dribbleUrl: string;
  behanceUrl: string;
  carbonMadeUrl: string;
  basicPackage: MentorshipPackage;
  standardPackage: MentorshipPackage;
  premiumPackage: MentorshipPackage;
  articles: string[];
}

export interface ICreateMentor {
  id: string;
  userRole: number;
  userName: string;
  email: string;
  password: string;
  confirmPassword: string;
  domain: string;
  profileImagePath: File;
  userCreationDate: string;
  aboutMe: string;
  resume: File;
  isVolunteer: boolean;
  linkdlUrl: string;
  dribbleUrl: string;
  behanceUrl: string;
  carbonMadeUrl: string;
  basicPackage: MentorshipPackage;
  standardPackage: MentorshipPackage;
  premiumPackage: MentorshipPackage;
  articles: string[];
}

export interface IMentorVolunteerType {
  isVolunteer: boolean;
}

export interface IMentorAdditionalData {
  linkdlUrl: string;
  dribbleUrl: string;
  behanceUrl: string;
  carbonMadeUrl: string;
  resume: File;
}

export interface IMentorProfile {
  profileImagePath: ArrayBuffer;
  userName: string;
  domain: string;
  behanceUrl: string;
  carbonMadeUrl: string;
  dribbleUrl: string;
  aboutMe: string;
  basicPackage: MentorshipPackage;
  standardPackage: MentorshipPackage;
  premiumPackage: MentorshipPackage;
}
