export class MessageBetweenUsersDto{
    public user: string = '';
    public content: string = '';
    public mentor: string = '';
    public menteeId: string = '';
    public messageDate: string = new Date().toISOString().slice(0, 10);
}