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
    $scope.phone = PhoneService.getPhone($routeParams.id);    
}
//PhoneDetailCtrl.$inject = [];

function PhoneReviewCtrl($scope, $routeParams, PhoneService) {
    $scope.phone = PhoneService.getPhone($routeParams.id);
    $scope.reviews = PhoneService.getReviews($routeParams.id);    
}
//PhoneReviewCtrl.$inject = [];