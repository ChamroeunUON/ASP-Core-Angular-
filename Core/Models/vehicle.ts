
export interface KeyValuePare{
    id:number;
    name:string;
}
export interface Contact{
    name:string;
    phone:string;
    email:string;
}
export interface Vehicle{
    id:number;
    model:KeyValuePare;
    make:KeyValuePare;
    isRegistered:boolean;
    features:number[];
    contact:Contact;
    lastUpdate:string;
    
}
export interface SaveVehicle{
    id:number;
    modelId:number;
    makeId:number;
    isRegistered:boolean;
    features:number[];
    contact:Contact;
    
}