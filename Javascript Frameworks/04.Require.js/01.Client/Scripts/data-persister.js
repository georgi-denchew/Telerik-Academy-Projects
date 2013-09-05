/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/rsvp.min.js" />
/// <reference path="http-requester.js" />

define(["httpRequester"], function (httpRequester) {
	function getStudents() {		
	    var students = httpRequester.getJSON("http://localhost:24652/api/students");

	    return students;
	}

    function getMarks(studentId) {
        var marks = httpRequester.getJSON(
            "http://localhost:24652/api/students/" + studentId + "/marks");

        return marks;
    }

	return {
	    students: getStudents,
        marks: getMarks
	}
});