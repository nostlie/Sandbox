'use strict';


// Declare app level module which depends on filters, and services
angular.module('PhoneApp', ['PhoneApp.filters', 'PhoneApp.services', 'PhoneApp.directives']).
  config(['$routeProvider', function($routeProvider) {
      $routeProvider.when('/phones', { templateUrl: 'partials/phone-list.html', controller: PhoneListCtrl });
    $routeProvider.when('/phones/:id', { templateUrl: 'partials/phone-details.html', controller: PhoneDetailCtrl });
    $routeProvider.when('/reviews', { templateUrl: 'partials/phone-reviews.html', controller: PhoneReviewCtrl });
    $routeProvider.otherwise({ redirectTo: '/phones' });
  }]);