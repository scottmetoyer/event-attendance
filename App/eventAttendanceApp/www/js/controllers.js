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

.controller('EventCtrl', function($scope, $state, $ionicPlatform, dataService) {
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
          console.warn(errorMessage);
        }
      )
  }

  $scope.doRefresh = function() {
    loadEvents();
    $scope.$broadcast('scroll.refreshComplete');
  }
})

.controller('CheckInCtrl', function($scope, $state, $ionicPlatform, $stateParams, dataService) {
  var eventId = $stateParams.eventId;

  $scope.$on('$ionicView.loaded', function() {
    var evt = dataService.getEvent(eventId);
    $scope.event = evt;
  });
});
