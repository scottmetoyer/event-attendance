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

.controller('EventCtrl', function($scope, $state, $ionicPlatform, $ionicLoading, $ionicPopup, $ionicModal, dataService) {
  $scope.$on('$ionicView.loaded', function() {
    loadEvents();
  });

  function loadEvents() {

    dataService.getEvents()
      .then(
        function(data) {
          // Add the friendly date description
          data.forEach(function(e) {
            var start = new XDate(e.Start);
            var end = new XDate(e.End);

            if (start.diffDays(end) < 1) {
              e.Date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString('h(:mm)TT');
            } else {
              e.Date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString("MMM d, yyyy ',' h(:mm)TT")
            }
          })

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
