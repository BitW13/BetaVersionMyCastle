import { Board } from './board';

export class BoardCard {

    public board: Board;

    public users: string[];

    constructor(createrId: string){
        this.board = new Board();
        this.users = [createrId];
    }
}