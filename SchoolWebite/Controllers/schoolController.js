angular.module("schoolApp").controller("schoolController", function ($scope, appSettings, $location,$http,blockUI) {
   $scope.student = this;
   $scope.isTriedSave = false;
   $scope.loaded = false;
   $scope.error = false;
   $scope.registered = false;
   $scope.registrationNo = "";
   
   $scope.clickForRegister = function(view){
        $scope.registered = false;
       $location.path("/"+view);
   }
   function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
   }
   $scope.register = function(){
       $scope.isTriedSave = true;
       $scope.error = false;
        if (!$scope.student.Name){
            toastr.error("Please write your Name.");
            $scope.loaded = true;
            $scope.error = true;
            return;
        }
        if (!$scope.student.Batch){
            toastr.error("Please select a Batch.");
            $scope.loaded = true;
            $scope.error = true;
            return;
        }
        if (!$scope.student.Mobile){
            toastr.error("Please write your Mobile no.");
            $scope.loaded = true;
            $scope.error = true;
            return;
        }
        if ($scope.student.Email && !validateEmail($scope.student.Email)) {
            toastr.error("You entered invalid Email.");
            $scope.loaded = true;
            $scope.error = true;
            return;
        }
        if ($scope.student.Mobile.length < 11 || $scope.student.Mobile.length > 11){
            toastr.error("You entered invalid Mobile no.");
            $scope.loaded = true;
            $scope.error = true;
            return;
        }
      blockUI.start();
      $http.post(appSettings.API_BASE_URL + "student/registration", $scope.student).
      then(function (response) {
          toastr.success("Registration completed successfully.");
          $scope.isTriedSave = false;   
          $scope.loaded = true;
          $scope.registered = true;
          $scope.registrationNo = response.data;
          blockUI.stop();
        }, function (error) {
             toastr.error(error.data.Message);
             $scope.isTriedSave = false;
             $scope.loaded = true;
             $scope.registered = false;
        });
   }
    $scope.rowCollection = [];
    $scope.displayColl = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;

   $scope.getAll = function(){
    $http.get(appSettings.API_BASE_URL + "student/list").
      then(function (response) {
          $scope.rowCollection = response.data;
          $scope.displayColl = [].concat($scope.rowCollection);
        }, function (error) {
            
        });   
   }
});