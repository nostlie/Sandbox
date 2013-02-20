/// <reference path="../lib/jquery-1.9.1.min.js" />
'use strict';

/* Services */


// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('PhoneApp.services', ['ngResource']).
    factory('PhoneService', function ($resource) {
        var phones = [{ id: "1", name: "Dell Streak 7", img: "../app/img/dell-streak-7.jpg" },
        { id: "2", name: "Dell Venue", img: "../app/img/dell-venue.jpg" },
        { id: "3", name: "Droid 2", img: "../app/img/droid-2-global-by-motorola.jpg" }];
        return phones.filter(function (phone) {
            if (phone.id == $resource.id) return phone, {}, {
                query: { method: 'GET', params: { id: 'phones' }, isArray: true }
            }
        });
    });
