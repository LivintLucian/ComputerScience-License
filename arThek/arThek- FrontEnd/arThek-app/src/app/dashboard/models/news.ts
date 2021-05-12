export interface INews{
    id: string;
    image: Uint8Array;
    title: string,
    content: string,
    category: string,
    publishDate: string,
    authorId: string,
    authorName: string
}

export interface ICreateArticle{
    image: File;
    title: string,
    content: string,
    category: string,
    publishDate: string,
    authorId: string
}