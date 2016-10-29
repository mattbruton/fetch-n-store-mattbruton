﻿app.controller("FormController", function ($scope, $http) {

    $scope.httpMethod;

    $scope.url;

    $scope.returnedRequest = {};

    $scope.showResponse = true;

    $scope.savedResponses;

    $scope.responseList = [];

    $scope.changeRowOnSuccess = function (event) {
        var target = angular.element(event.target);
        target.parent().parent().addClass('alert alert-success');
        target.addClass('disabled');
    };

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

    $scope.store = function (responseObject, event) {
        $http({
            url: "api/Response/",
            method: "POST",
            data: JSON.stringify(responseObject),
            contentType: "application/json"
        }).then(function successCallback(response) {
            $scope.savedResponses = $scope.getStoredResponses();
            $scope.changeRowOnSuccess(event);
        }, function errorCallback(response) {
            console.log("bad stuff!")
        });
    };

    $scope.getStoredResponses = function () {
        $http({
            url: "/api/Response/",
            method: "GET"
        }).then(function successCallback(response) {
            $scope.savedResponses = response.data;
        }, function errorCallback(response) {
            console.log("bad stuff!")
        });
    };

    $scope.delete = function (id) {
        $http({
            url: `/api/Response/${id}`,
            method: "DELETE"
        }).then(function successCallback(response) {
            $scope.savedResponses = $scope.getStoredResponses();
        }, function errorCallback(response) {
            console.log("bad stuff!")
        });
    };

    $scope.getStoredResponses();
});