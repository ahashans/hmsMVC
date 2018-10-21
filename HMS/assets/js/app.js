
  // creating Angular Module
  var websiteApp = angular.module('websiteApp', []);
  websiteApp.controller('FormController',function($scope, $http,$timeout) {
  	/********************************************/
  	$scope.successStatus = true;
  	$scope.formData = {};
	
	  $scope.submitcotactusForm = function(data) {
	  	
	  	$scope.successStatus = true;
	  //	alert(angular.element("#contact").attr("name"));
	  	if(data == true){
	  		
	  		//$scope.message = "Please fill the option";
	  		if(!$scope.formData.selectOption)
	  		$scope.selectOption = true;
	  		return false;
	  	}
	  	
	  	else{
	  		
	  		$scope.message = ""
		$http({
		method : 'POST',
		url : 'mail.php',
		data : $.param($scope.formData), // pass in data as strings
		headers : { 'Content-Type': 'application/x-www-form-urlencoded' } // set the headers so angular passing info as form data (not request payload)
	  })
		.success(function(data) {
			$scope.successStatus = false;
			 $scope.formData = {};	
			 $('#success').fadeIn(1000);
			 $timeout(function(){
			 $('#success').fadeOut(1000);
			 },2500);
		 });
	
		}
	   };
	
	/******************************************/
	 $scope.footerformData = {};
	 $scope.successStatus = false;	
	  $scope.submitfooterForm = function(data) {
	  	$scope.successStatus = true;
	  	var status = true;
	  	if(data){
	  		
	  	return false;	  	
	  	}
	  	else{	  		
	  		
		$http({
		method : 'POST',
		url : 'mail.php',
		data : $.param($scope.footerformData), // pass in data as strings
		headers : { 'Content-Type': 'application/x-www-form-urlencoded' } // set the headers so angular passing info as form data (not request payload)
	  })
		.success(function(data) {
			$scope.successStatus = false;
			 $scope.footerformData = {};
			
			 $('#msgsuccess').fadeIn(1000);
			 $timeout(function(){
			 	$('#msgsuccess').fadeOut(1000);
			 },2500);
		 });
		};
	   
	   };
});
