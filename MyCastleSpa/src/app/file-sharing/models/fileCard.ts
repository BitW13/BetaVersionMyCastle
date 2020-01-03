import { FileAccess } from './fileAccess';
import { File } from './file';
import { FileCategory } from './fileCategory';
import { FileUrl } from './fileUrl';

export class FileCard {
    
    public file: File;

    public fileAccess: FileAccess;

    public fileCategory: FileCategory;

    public fileUrl: FileUrl; 
}