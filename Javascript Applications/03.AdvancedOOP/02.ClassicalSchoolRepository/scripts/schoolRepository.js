
var schoolRepository = (function () {

    var School = Class.create({
        init: function (name, town, classes) {
            this.name = name;
            this.town = town;
            this.classes = classes;
        }
    });

    var SchoolClass = Class.create({
        init: function (name, studentCapacity, students, formTeacher) {
            this.name = name;
            this.studentCapacity = studentCapacity;
            this.students = students;
            this.formTeacher = formTeacher;
        }
    });

    var Person = Class.create({
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },
        introduce: function () {
            return "Name: " + this.firstName + " " + this.lastName +
                ", Age: " + this.age;
        }
    });

    var Teacher = Class.create({
        init: function (firstName, lastName, age, speciality) {
            this._super.init(firstName, lastName, age);
            this.speciality = speciality;
        },
        introduce: function () {
            return this._super.introduce() + ", Speciality: " + this.speciality;
        }
    });

    Teacher.inherit(Person);

    var Student = Class.create({
        init: function (firstName, lastName, age, grade) {
            this._super.init(firstName, lastName, age);
            this.grade = grade;
        },
        introduce: function () {
            return this._super.introduce() + ", Grade: " + this.grade;
        }
    });

    Student.inherit(Person);

    return {
        School: School,
        SchoolClass: SchoolClass,
        Teacher: Teacher,
        Student: Student,
    }
})();