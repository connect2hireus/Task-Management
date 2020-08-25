$(document).ready(function(e) {
	
	//aside nav	
	$('.naviconside').click(function(){
		if($('.asidenav').width() > 0){
		   $('.asidenav').animate({width: '0px'})
            $('.topsec').css("margin-left", "0");
            $('.bodysec').css("margin-left", "0");
		}
	else{
		$('.asidenav').animate({width: '230px'})
            $('.topsec').css("margin-left", "230px");
            $('.bodysec').css("margin-left", "230px");
      }
	});


   
    if ($(window).width() <= 991) {
        $('.naviconside').click(function () {
            if ($('.asidenav').width() > 0) {
                $('.bodysec').css("margin-left", "0");
            }
            else {
                $('.bodysec').css("margin-left", "0px");
            }
        });

    }
   
	
  //slide toggle
  $('.serachdrop span a').click(function(e) {
	  $('.serachdrop ul').slideToggle();   
  }); 
  $('.userdropdown span a').click(function(e) {
	  $('.userdropdown ul').slideToggle(200);   
  });  
   

  
	
	//$('.navigation ul').hide();
	$('.navigation ul').hide();
	$(".navigation h2").click(function () {
		$('.navigation ul').not($(this).siblings()).slideUp();
		$(this).siblings(".navigation ul").slideToggle();
		//$('.navigation h2').toggleClass('plus');
	}); 





	//responsive table
	$('.table').cardtable();
	
	//full height
	(function($){
	  $.fn.fullHeight = function(){
	
		var self = this;
		var windowHeight = window.innerHeight;
	
		var fullHeightFunction = function(){
		  return self.css({
			'height': windowHeight
		  });
		}
		$(window).on('resize', function(){
		  windowHeight = window.innerHeight;
		  fullHeightFunction();
		});
		fullHeightFunction();
		return self;    
	  }
	
	})(jQuery);
	
	$('.full-height').fullHeight();
});


//first chart
var ctx = document.getElementById('myChart').getContext('2d');
var chart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["January", "February", "March", "April", "May", "June", "July"],		 
        datasets: [{
            label: '',
            backgroundColor: 'rgba(255, 99, 132, 0)',
            borderColor: 'rgb(255, 99, 132, 0.5)',
            data: [0, 10, 5, 2, 20, 30, 45],
        },
		{
            label: '',
            backgroundColor: 'rgba(255, 99, 132, 0)',
            borderColor: 'rgba(147,35,205,0.5)',
            data: [10, 15, 80, 12, 30, 35, 50],
        }
		],
    },    
    options: {
		legend: {
            display: false
         },		  
		}
});


//second chart
var ctx = document.getElementById('myChart2').getContext('2d');
var chart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["January", "February", "March", "April", "May", "June", "July"],	
        datasets: [{
            label: '',
            backgroundColor: 'rgba(194,43,114,1)',
            borderColor: 'rgba(0,0,0,1)',
            data: [0, 10, 5, 2, 20, 30, 45],
        }],
    },    
    options: {
		legend: {
            display: false
         },		  
		}
});