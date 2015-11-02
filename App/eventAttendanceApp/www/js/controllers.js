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
    $ionicLoading.show({
      template: '<ion-spinner class="overlay" icon="lines"></ion-spinner>'
    });

    dataService.getEvents()
      .then(function(result) {
        $ionicLoading.hide();
      })
  });
})
