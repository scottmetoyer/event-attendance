angular.module('eventAttendance.services', [])
  .service('dataService', function($q, $http) {
    var events = {};
    var serviceUrl = 'https://event-attendance.azurewebsites.net/api';
    return ({
      getEvents: getEvents,
      getEvent: getEvent,
      saveCheckin: saveCheckin
    });

    function getEvents() {
      var request = $http({
        method: "get",
        url: serviceUrl + "/event"
      });
      return (request.then(function(response) {
        events = response.data;

        // Add the friendly date description
        events.forEach(function(e) {
          var start = new XDate(e.start);
          var end = new XDate(e.end);

          if (start.diffDays(end) < 1) {
            e.date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString('h(:mm)TT');
          } else {
            e.date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString("MMM d, yyyy ',' h(:mm)TT");
          }
        })

        return (events);
      }, handleError));
    }

    function getEvent(id) {
      var evt = null;

      events.forEach(function(e) {
        if (e.id == id) {
          evt = e;
        }
      });
      return evt;
    }

    function saveCheckin(checkin) {
      var request = $http({
        method: "POST",
        url: serviceUrl + "/checkin",
        data: JSON.stringify(checkin),
        headers: {
          'content-type': 'application/json'
        }
      });
      return(request.then(handleSuccess, handleError));
    }

    function handleSuccess(response) {
      return response.data;
    }

    function handleError(response) {
      if (!angular.isObject(response.data) ||
        !response.data.message
      ) {
        return ($q.reject("An unknown error occurred."));
      }

      return ($q.reject(response.data.message));
    }
  });
