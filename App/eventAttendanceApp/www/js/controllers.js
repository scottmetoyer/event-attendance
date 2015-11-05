angular.module('eventAttendance.controllers', ['eventAttendance.services'])
  // $cordovaBarcodeScanner
  .controller('HomeCtrl', function($scope, $state, $ionicPlatform) {
    $scope.scan = function() {
      /*
        $ionicPlatform.ready(function() {
            $cordovaBarcodeScanner
            .scan()
            .then(function(result) {
                // Success! Barcode data is here
                vm.scanResults = "We got a barcoden" +
                "Result: " + result.text + "n" +
                "Format: " + result.format + "n" +
                "Cancelled: " + result.cancelled;

                alert(vm.scanResults);
            }, function(error) {
                // An error occurred
                vm.scanResults = 'Error: ' + error;
            });
        });*/
    }

    $scope.events = function() {
      $state.go('events');
    }
  })

.controller('EventCtrl', function($scope, $state, $ionicPlatform, $ionicPopup, dataService) {
  $scope.$on('$ionicView.loaded', function() {
    loadEvents();
  });

  function loadEvents() {
    dataService.getEvents()
      .then(
        function(data) {
          $scope.events = data;
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
  var eventId = $stateParams.eventId;
  var checkinModel = {
    eventId: eventId,
    studentId: '',
    pin: ''
  };
  $scope.checkinModel = checkinModel;

  $scope.$on('$ionicView.loaded', function() {
    var evt = dataService.getEvent(eventId);
    $scope.event = evt;
  });

  function showPopup(title, message) {
    var alertPopup = $ionicPopup.alert({
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
