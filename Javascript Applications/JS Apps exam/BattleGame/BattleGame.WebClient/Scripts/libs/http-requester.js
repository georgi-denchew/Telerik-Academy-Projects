﻿/// <reference path="class.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="require.js" />


define(["jquery"], function ($) {

    function getJSON(url, success, error) {

        $.ajax({
            url: url,
            type: "GET",
            timeout: 5000,
            contentType: "application/json",
            success: success,
            error: error,
        });
    }

    function postJSON(url, data, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json",
            timeout: 5000,
            data: JSON.stringify(data),
            success: success,
            error: error
        });
    }


    return {
        getJSON: getJSON,
        postJSON: postJSON
    };
});