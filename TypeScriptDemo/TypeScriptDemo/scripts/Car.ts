export class Car {
    engine: string;
    constructor(engine: string) {
        this.engine = engine;
    }

    start() {
        console.log("engine started!");
    }

    stop() {
    }
}