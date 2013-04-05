var people = [
{ firstname: "pesho", lastname: "peshev", age: 15 },
{ firstname: "gosho", lastname: "goshev", age: 20 },
{ firstname: "vancho", lastname: "vanchev", age: 12 }];

findYoungest(people);

function findYoungest(arr) {
    var youngestPersonPosition = 0;
    var youngestPersonAge = 9007199254740992;

    var i = 0;
    var length = people.length;
    for (i; i < length; i++) {
        if (people[i].age < youngestPersonAge) {
            youngestPersonPosition = i;
            youngestPersonAge = people[i].age;
        }
    }
    jsConsole.writeLine(people[youngestPersonPosition].firstname + " " + people[youngestPersonPosition].lastname + " " + people[youngestPersonPosition].age);

}