var schoolRepository = (function () {

    var School = {
        init: function (name, town, classes) {
            this.name = name;
            this.town = town;
            this.classes = classes;
        }
    };

    var Class = {
        init: function (name, studentCapacity, students, formTeacher) {
            this.name = name;
            this.studentCapacity = studentCapacity;
            this.students = students;
            this.formTeacher = formTeacher;
        },
    };

    // I've made this class only to practice prototypal inheritance 
    var Person = {
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },
        introduce: function () {
            return "Name: " + this.firstName + " " + this.lastName +
            ", Age: " + this.age;
        }
    }

    var Teacher = Person.extend({
        init: function (firstName, lastName, age, speciality) {
            Person.init.apply(this, arguments);
            this.speciality = speciality;
        },
        introduce: function () {
            return Person.introduce.apply(this) + ", Speciality: " + this.speciality;
        }
    });

    var Student = Person.extend ({
        init: function (firstName, lastName, age, grade) {
            Person.init.apply(this, arguments);
            this.grade = grade;
        },
        introduce: function () {
            return Person.introduce.apply(this) + ", Grade: " + this.grade;
        }
    });

    return {
        CreateSchool: function () {
            return Object.create(School);
        },
        CreateTeacher: function () {
            return Object.create(Teacher);
        },
        CreateStudent: function () {
            return Object.create(Student);
        },
        CreateClass: function () {
            return Object.create(Class);
        }
    }
})();