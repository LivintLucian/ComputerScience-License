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
  resumeFileName: string;
  isVolunteer: boolean;
  linkdlnUrl: string;
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
  linkdlnUrl: string;
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
  resume: File;
  userName: string;
  domain: string;
  behanceUrl: string;
  carbonMadeUrl: string;
  dribbleUrl: string;
  linkdlnUrl: string;
  aboutMe: string;
  basicPackage: MentorshipPackage;
  standardPackage: MentorshipPackage;
  premiumPackage: MentorshipPackage;
}
