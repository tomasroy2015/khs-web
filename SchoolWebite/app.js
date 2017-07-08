/**
 * Created by Tomas on 25-Jun-16.
 */
var schoolApp = angular.module("schoolApp",["ngRoute","ngResource","ngAnimate","ngSanitize", "ngCookies","smart-table"]);
schoolApp.config(function($routeProvider,$locationProvider){
    $locationProvider.html5Mode(true);
    $routeProvider.when('/',{templateUrl: 'home.html',controller: 'schoolController'}).
    when('/registration',{templateUrl: 'registration.html',controller: 'schoolController'})
});
/* Application Constants
 ======================================================*/
schoolApp.constant("appSettings", {
    API_BASE_URL : 'http://localhost:50622/',
    //API_BASE_URL: 'https://api.gbsextranet.com/',
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
