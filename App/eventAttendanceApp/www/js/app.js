// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
angular.module('eventAttendance', ['ionic', 'eventAttendance.controllers'])

.run(function($ionicPlatform) {
  $ionicPlatform.ready(function() {
    // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
    // for form inputs)
    if(window.cordova && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
    }
    if(window.StatusBar) {
      StatusBar.styleDefault();
    }
  });
})

.config(function($stateProvider, $urlRouterProvider) {
  $urlRouterProvider.otherwise('/')

  $stateProvider.state('home', {
    url: '/',
    templateUrl: 'templates/home.html',
    controller: 'HomeCtrl'
  })

  $stateProvider.state('events', {
    url: '/events',
    templateUrl: 'templates/events.html',
    controller: 'EventCtrl'
  })

  $stateProvider.state('checkin', {
    url: '/checkin/:eventId',
    templateUrl: 'templates/checkin.html',
    controller: 'CheckInCtrl'
  })

  $stateProvider.state('scan', {
    url: '/scan',
    templateUrl: 'templates/scan.html'
  })
})
