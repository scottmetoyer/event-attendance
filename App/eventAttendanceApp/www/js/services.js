angular.module('eventAttendance.services', [])
  .service('dataService', function($q, $http) {
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
        var events = response.data;
        events.forEach(function(e) {
          parseDate(e);
        })

        return (events);
      }, handleError));
    }

    function getEvent(id) {
      var request = $http({
        method: "get",
        url: serviceUrl + "/event/" + id
      });

      return (request.then(function(response) {
        var evt = response.data;
        parseDate(evt);
        return (evt);
      }, handleError));
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

    function parseDate(e) {
      var start = new XDate(e.start);
      var end = new XDate(e.end);

      if (start.diffDays(end) < 1) {
        e.date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString('h(:mm)TT');
      } else {
        e.date = start.toString("MMM d, yyyy ',' h(:mm)TT ' - '") + end.toString("MMM d, yyyy ',' h(:mm)TT");
      }
    }
  });
