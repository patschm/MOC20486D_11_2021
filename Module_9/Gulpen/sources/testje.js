class Person
{
    constructor(name)
    {
        this.name = name;
    }

    introduce(){
        console.log(this.name);
    }
}

class Employee extends Person
{
    constructor(name, jobtitle)
    {
        super(name);
        this.job = jobtitle;
    }
}