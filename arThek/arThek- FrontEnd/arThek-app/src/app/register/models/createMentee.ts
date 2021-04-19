export interface IMentee{
    id: string,
    userRole: number,
    userName: string,
    email: string,
    password: string,
    confirmPassword: string,
    domain: string,
    profileImagePath: Uint8Array,
    userCreationDate: string
}

export interface ICreateMentee{
    id: string,
    userRole: number,
    userName: string,
    email: string,
    password: string,
    confirmPassword: string,
    domain: string,
    profileImagePath: File,
    userCreationDate: string
}