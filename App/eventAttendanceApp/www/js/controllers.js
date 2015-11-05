angular.module('eventAttendance.controllers', ['ngCordova', 'eventAttendance.services'])
  .controller('HomeCtrl', function($scope, $state, $stateParams, $ionicPlatform, $ionicPopup, $cordovaBarcodeScanner) {
    $scope.scan = function() {
      $ionicPlatform.ready(function() {
        $cordovaBarcodeScanner
          .scan()
          .then(function(result) {
              if (!result.cancelled) {
                $state.go('checkin', {
                  eventId: result.text
                });
              }
            }, function(error) {
              showPopup("Error scanning QR code", error);
          });
      });
    }

    $scope.events = function() {
      $state.go('events');
    }

    function showPopup(title, message) {
      var alertPopup = $ionicPopup.alert({
        title: title,
        template: message
      });
    }
  })

.controller('EventCtrl', function($scope, $state, $ionicPlatform, $ionicPopup, dataService) {
  $scope.ready = false;
  $scope.$on('$ionicView.afterEnter', function() {
    loadEvents();
  });

  function loadEvents() {
    dataService.getEvents()
      .then(
        function(data) {
          $scope.events = data;
          $scope.ready = true;
        },
        function(errorMessage) {
          var alertPopup = $ionicPopup.alert({
            title: 'Error loading events',
            template: errorMessage
          });
        }
      )
  }

  $scope.doRefresh = function() {
    loadEvents();
    $scope.$broadcast('scroll.refreshComplete');
  }
})

.controller('CheckInCtrl', function($scope, $state, $ionicPlatform, $ionicPopup, $stateParams, dataService) {
  var ready = false;
  var eventId = $stateParams.eventId;
  var checkinModel = {
    eventId: eventId,
    studentId: '',
    pin: ''
  };
  $scope.checkinModel = checkinModel;

  $scope.$on('$ionicView.enter', function() {
    dataService.getEvent(eventId).then(
      function(data) {
        $scope.event = data;
        $scope.ready = true;
      },
      function(error) {
        showPopup('Error loading event', 'Please check your QR code and try again.').then(function(res) {
          $state.go('home');
        });
      }
    );
  });

  function showPopup(title, message) {
    return $ionicPopup.alert({
      title: title,
      template: message
    });
  }

  $scope.checkin = function() {
    if (checkinModel.studentId == '') {
      showPopup('Missing required field', 'Please enter your Student Id and the event PIN to check-in.')
    } else {
      dataService.saveCheckin(checkinModel)
        .then(
          function(data) {
            $state.go('success');
          },
          function(errorMessage) {
            showPopup('Error checking in', errorMessage);
          }
        )
    }
  }
})

.controller('SuccessCtrl', function($scope, $state) {
  $scope.home = function() {
    $state.go('home');
  }
});
