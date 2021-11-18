function bla() {
  var h1s = document.querySelectorAll("h1");

  for (var idx = 0; idx < h1s.length; idx++) {
    h1s[idx].textContent = "Boeeeee!!!";
  }
}

class Person2 {
  constructor(fn) {
    this._firstname = fn;
  }

  _firstname : string;

  get FirstName() {
    return this._firstname;
  }

  set FirstName(value) {
    this._firstname = value;
  }

  introduce = async function () {
    if (true) {
      let x = 10;
    } // x = 100;
    //console.log(x);


    let result = await fetch("/css/index2.css");
    console.log(result);
    console.log(this._firstname);
  };
}

var p2 = new Person2("Mees");
p2.FirstName = "Kees";
p2.introduce();
p2["introduce"]();

function Person(fn) {
  this.firstName = fn;

  this.introduce = function () {
    console.log(this.firstName);
  };
}

var p1 = new Person("Patrick");
p1.introduce(); //console.log(x);
