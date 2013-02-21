'use strict';

/* Controllers */


function PhoneListCtrl($scope) {    
    $scope.phones = [
        { id: "1", name: "Dell Streak 7", img: "../app/img/dell-streak-7.jpg" },
        { id: "2", name: "Dell Venue", img: "../app/img/dell-venue.jpg" },
        { id: "3", name: "Droid 2", img: "../app/img/droid-2-global-by-motorola.jpg" }
    ];
}
//PhoneListCtrl.$inject = [];


function PhoneDetailCtrl($scope, $routeParams, PhoneService) {
    $scope.phoneid = $routeParams.id;
    //$scope.phone = { id: "3", name: "Droid 2", img: "../app/img/droid-2-global-by-motorola.jpg", description: "Adobe Flash Player 10, Quadband GSM Worldphone, Advance Business Security, Complex Password Secure, Review & Edit Documents with Quick Office, Personal 3G Mobile Hotspot for up to 5 WiFi enabled Devices, Advanced Social Networking brings all social content into a single homescreen widget" };
    $scope.phone = PhoneService.getPhone($routeParams.id);    
}
//PhoneDetailCtrl.$inject = [];

function PhoneReviewCtrl($scope) {
    $scope.reviews = [
        { id: "1", phoneid: "1", reviewername: "Henry", description: "This is a good phone for Dell!" },
        { id: "2", phoneid: "3", reviewername: "Joe", description: "This phone does what it's supposed to." },
        { id: "3", phoneid: "3", reviewername: "Sue", description: "What a mediocre phone for Motorola. Bleh." }
    ];
}
//PhoneReviewCtrl.$inject = [];