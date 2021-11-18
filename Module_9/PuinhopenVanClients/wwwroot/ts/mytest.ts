class Person {
    private age: number;
    private name: string;

    public get Age() {
        return this.age;
    }

    public introx() {
        for (let x = 0; x < 10; x++) {}
    }
    constructor() {

    }
}

class Employee extends Person {
    private job: string;
}