export class Board {

    public id: number;

    public name: string;

    public imagePath: string;

    public isFavorite: boolean;

    public color: string;

    constructor(){
        
        this.id = 0;

        this.name = '';

        this.imagePath = '';

        this.color = '#3d18e7';

        this.isFavorite = false;
    }
}