// Interface
export interface IPoint {
    getDist(): number;
}

// Class
export class Point implements IPoint {
    // Constructor
    constructor(public x: number, public y: number) { }

    // Instance member
    getDist() {
        return Math.sqrt(this.x * this.x + this.y * this.y);
    }

    // Static member
    static origin = new Point(0, 0);
}


// Local variables
var p: IPoint = new Point(3, 4);
var dist = p.getDist();

console.log("dist", dist);

import { Car } from "./Car";

var car = new Car("engine");
console.log("car", car);
car.start();


var fn: (name?: string) => void;
