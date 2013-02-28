'use strict';

/* Controllers */


//function PhoneListCtrl($scope, PhoneService) {    
//    $scope.phones = PhoneService.getAllPhones();
//    $scope.orderProp = "name";
//}
//PhoneListCtrl.$inject = [];
function PhoneListCtrl($scope, $http) {
    
    $http.get('phones/phones.json').success(function (data) {
        alert(data);
    }).error(function (data, re) {
        alert("error: " + re);
    });
    
    //$.ajax({
    //    type: "POST",
    //    dataType: "json",
    //    url: "phones/phones.json",
    //    contentType: "application/json; charset=utf-8",
    //    data: "{}"
    //    //,
    //    //success: function (html) {
    //    //    alert(html);
    //    //},
    //    //error: function (response, re) {
    //    //    alert("response: " + response);
    //    //}
        
    //}).done(function (html) { alert("done"); }).fail(function (xhr, error) { alert("fail"); });
    
}


function PhoneDetailCtrl($scope, $routeParams, PhoneService) {    
    $scope.phone = PhoneService.getPhone($routeParams.id);
}
//PhoneDetailCtrl.$inject = [];

function PhoneReviewCtrl($scope, $routeParams, PhoneService) {
    $scope.phone = PhoneService.getPhone($routeParams.id);
    $scope.reviews = PhoneService.getReviews($routeParams.id);    
}
//PhoneReviewCtrl.$inject = [];