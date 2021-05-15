export class MessageDto{
    public user: string = '';
    public msgText: string = '';
    public category: string = '';
    public userType: string = '';
    public messageDate: string = new Date().toISOString().slice(0, 10);
}