/**
 * Created by yogen on 21/03/2016.
 */
/*Creating a Angular.module*/
angular.module('MainController',[])
.controller('MainController',function($scope){
    $scope.fristname='Yogendra';
    
    console.log($scope.fristname);
})

