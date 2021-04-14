import { MentorshipPackage } from "./mentorshipPackage";

export interface IMentor{
    id: string,
    userRole: number,
    userName: string,
    email: string,
    password: string,
    confirmPassword: string,
    domain: string,
    profileImagePath: string,
    userCreationDate: string,
    aboutMe: string,
    resume: Uint8Array,
    isVolunteer: boolean,
    linkdlUrl: string,
    dribbleUrl: string,
    behanceUrl: string,
    carbonMadeUrl: string,
    basicPackage: MentorshipPackage,
    standardPackage: MentorshipPackage,
    premiumPackage: MentorshipPackage,
    articles: string[]
}

export interface ICreateMentor{
    id: string,
    userRole: number,
    userName: string,
    email: string,
    password: string,
    confirmPassword: string,
    domain: string,
    profileImagePath: string,
    userCreationDate: string,
    aboutMe: string,
    resume: File,
    isVolunteer: boolean,
    linkdlUrl: string,
    dribbleUrl: string,
    behanceUrl: string,
    carbonMadeUrl: string,
    basicPackage: MentorshipPackage,
    standardPackage: MentorshipPackage,
    premiumPackage: MentorshipPackage,
    articles: string[]
}

export interface IMentorVolunteerType{
    isVolunteer: boolean;
}

export interface IMentorAdditionalData{
    linkdlUrl: string,
    dribbleUrl: string,
    behanceUrl: string,
    carbonMadeUrl: string,
    resume: File,
}