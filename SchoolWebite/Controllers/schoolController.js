angular.module("schoolApp").controller("schoolController", function ($scope, appSettings, $location) {
   $scope.clickForRegister = function(){
       $location.path("/registration");
   }
});