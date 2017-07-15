/**
 * Created by Tomas on 25-Jun-16.
 */
var schoolApp = angular.module("schoolApp",[
                "ui.bootstrap",
                "ngRoute",
                "ngResource",
                "ngAnimate",
                "ngSanitize",
                "ngCookies", 
                "blockUI",
                "ui.bootstrap",
                "smart-table"
              ]);
schoolApp.config(function($routeProvider,$locationProvider){
    $locationProvider.html5Mode(true);
    $routeProvider.when('/',{templateUrl: 'Views/home.html',controller: 'schoolController'}).
    when('/registration',{templateUrl: 'Views/registration.html',controller: 'schoolController'}).
    when('/about',{templateUrl: 'Views/about.html',controller: 'schoolController'}).
    when('/contact',{templateUrl: 'Views/contact.html',controller: 'schoolController'})
});
/* Application Constants
 ======================================================*/
schoolApp.constant("appSettings", {
    API_BASE_URL : 'http://163.47.35.165:8085/',
    APPLICATION_VERSION: '1.0.0'

});

/* Notification Constants
 ======================================================*/
schoolApp.constant("Notify", {
    DATA_READY: "dataFactory::dataReady",  
    LOGIN_SUCCESSFUL: "accountFactory::loginSuccessful",
    LOGIN_UNSUCCESSFUL: "accountFactory::loginUnSuccessful",
    LOGOUT_SUCCESSFUL: "accountFactory::logoutSuccessful" 
});
