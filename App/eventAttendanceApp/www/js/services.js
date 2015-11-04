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
          var start = new XDate(e.Start);
          var end = new XDate(e.End);

          if (start.diffDays(end) < 1) {
            e.Date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString('h(:mm)TT');
          } else {
            e.Date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString("MMM d, yyyy ',' h(:mm)TT");
          }
        })

        return (events);
      }, handleError));
    }

    function getEvent(id) {
      var evt = null;

      events.forEach(function(e) {
        if (e.Id == id) {
          evt = e;
        }
      });
      return evt;
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
