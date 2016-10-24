app.controller("FormController", function ($scope, $http) {

    $scope.httpMethod;

    $scope.url;

    $scope.showResponse = true;

    $scope.responseList = [];

    $scope.fetch = function () {
       
        var currentTime = Date.now();

        $http({
            method: $scope.httpmethod,
            url: $scope.url
        }).then(function successCallback(response) {
            $scope.responseList.push({
                status: response.status,
                statusText: response.statusText,
                url: $scope.url,
                httpMethod: $scope.httpMethod,
                responseTime: `${Date.now() - currentTime}ms`
            })
        }, function errorCallback(response) {
            $scope.responseList.push({
                status: response.status,
                statusText: response.statusText,
                url: $scope.url,
                httpMethod: $scope.httpMethod,
                responseTime: `${Date.now() - currentTime} ms`
            })
        })
    };
});