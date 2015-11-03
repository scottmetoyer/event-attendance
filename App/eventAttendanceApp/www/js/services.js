angular.module('eventAttendance.services', [])
  .service('dataService', function($q, $http) {
    var serviceUrl = 'http://event-attendance.azurewebsites.net';
    return ({
      getEvents: getEvents,
      saveCheckin: saveCheckin
    });

    function getEvents() {
      var request = $http({
        method: "get",
        url: serviceUrl + "/events"
      });
      return (request.then(handleSuccess, handleError));
    }

    function saveCheckin(eventId, studentId, pin) {
      var request = $http({
        method: "post",
        url: "/checkin",
        data: {
          eventId: eventId,
          studentId: studentId,
          pin: pin
        }
      });

      function handleError(response) {
        // The API response from the server should be returned in a
        // nomralized format. However, if the request was not handled by the
        // server (or what not handles properly - ex. server error), then we
        // may have to normalize it on our end, as best we can.
        if (!angular.isObject(response.data) ||
          !response.data.message
        ) {
          return ($q.reject("An unknown error occurred."));
        }
        // Otherwise, use expected error message.
        return ($q.reject(response.data.message));
      }
      // I transform the successful response, unwrapping the application data
      // from the API response payload.
      function handleSuccess(response) {
        return (response.data);
      }
    }
  });
