export class Name {
    id: string = '';
    text: string = '';
    createdAt: Date = new Date();

    copyFrom(t: IName){
        this.id = t.id;
        this.text = t.text;
        this.createdAt = new Date(t.createdAt);
    }
}
export interface IName{
    id: string;
    text: string;
    createdAt: string;
}

