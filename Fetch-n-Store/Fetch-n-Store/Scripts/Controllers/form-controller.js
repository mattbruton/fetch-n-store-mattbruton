app.controller("FormController", function ($scope, $http) {

    $scope.httpMethod;

    $scope.url;

    $scope.returnedRequest = {};

    $scope.showResponse = true;

    $scope.savedResponses;

    $scope.responseList = [];

    $scope.fetch = function () {
       
        var currentTime = new Date();

        $http({
            method: $scope.httpMethod,
            url: $scope.url
        }).then(function successCallback(response) {
            $scope.responseList.push({
                StatusCode: response.status,
                URL: $scope.url,
                HttpMethod: $scope.httpMethod,
                ResponseTimeLength: `${Date.now() - currentTime}ms`,
                TimeOfRequest: `${currentTime.toDateString()} - ${currentTime.getHours()}:${currentTime.getMinutes()}:${currentTime.getSeconds()}`
            })
        }, function errorCallback(response) {
            $scope.responseList.push({
                status: response.status,
                url: $scope.url,
                httpMethod: $scope.httpMethod,
                responseTime: `${Date.now() - currentTime}ms`
            }) 
        }) 
    };

    $scope.store = function (responseObject) {

        var dataToPass = {
            URL: responseObject.URL,
            StatusCode: responseObject.StatusCode,
            HttpMethod: responseObject.HttpMethod,
            ResponseTimeLength: responseObject.ResponseTimeLength,
            TimeOfRequest: responseObject.TimeOfRequest
        };

        $http({
            url: "api/Response/",
            method: "POST",
            data: JSON.stringify(dataToPass),
            contentType: "application/json"
        }).then(function successCallback(response) {
            console.log(responseObject);
            return responseObject;
        }, function errorCallback(response) {
            console.log("bad stuff!")
        });
    };

    $scope.showStoredResponses = function () {
        $http({
            url: "/api/Response/",
            method: "GET"
        }).then(function successCallback(response) {
            $scope.savedResponses = response.data;
        }, function errorCallback(response) {
            console.log("bad stuff!")
        });
    };
    $scope.showStoredResponses();
});