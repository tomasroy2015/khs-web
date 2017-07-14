angular.module("schoolApp").controller("schoolController", function ($scope, appSettings, $location,$http) {
   $scope.student = this;
   $scope.isTriedSave = false;
   $scope.loaded = false;
   $scope.registered = false;
   $scope.registrationNo = "";
   $scope.clickForRegister = function(view){
       $location.path("/"+view);
   }
   $scope.register = function(){
       $scope.isTriedSave = true;
        if (!$scope.student.Name){
            toastr.error("Name is required.");
            $scope.loaded = true;
            return;
        }
        if (!$scope.student.Batch){
            toastr.error("Please select a Batch.");
           $scope.loaded = true;
            return;
        }
        if (!$scope.student.Mobile){
            toastr.error("Please write your mobile no.");
            $scope.loaded = true;
            return;
        }
     
      $http.post(appSettings.API_BASE_URL + "student/registration", $scope.student).
      then(function (response) {
          toastr.success("You registered successfully.");
          $scope.isTriedSave = false;   
          $scope.loaded = true;
          $scope.registered = true;
          $scope.registrationNo = response.data;
        }, function (error) {
             toastr.error(error.data.Message);
             $scope.isTriedSave = false;
             $scope.loaded = true;
             $scope.registered = false;
        });
   }
});