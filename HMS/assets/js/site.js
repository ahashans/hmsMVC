(function($) {
	"use strict";	
		var stickOnScroll;
	
	//Header Option	
	$('#header').addClass('normal');
	//Choose Here Class Name (normal or fixed or intelligent); 
	
	
	$('#file-upload').change(function() {
		var content = $(this).val();
		$('.upload-content').text(content);

	});
	$('.drop-down-parent').on('click', function() {
		if ($(window).width() <= 767) {
			$(this).find('.drop-down').slideToggle();
			$(this).siblings().find('.drop-down').slideUp();
			$(this).toggleClass('active-arrow');
			$(this).siblings().removeClass('active-arrow');
		}
	});

	if ($('.flexslider').length) {
		$(window).load(function() {
			$('.flexslider').flexslider({
				animation : 'slide',
				directionNav : false,
			})
		})
	}
	if ($("#tabs").length) {
		$("#tabs").tabs();
	}
	if ($(".quote-tabs").length) {
		$(".quote-tabs").tabs();
	}
	if ($("#owl-demo").length) {
		var owl = $("#owl-demo");

		owl.owlCarousel({
			items : 1, //1 items above 1000px browser width
			itemsDesktop : [1000, 1], //1 items between 1000px and 901px
			itemsDesktopSmall : [900, 1], // betweem 900px and 601px
			itemsTablet : [600, 1], //1 items between 600 and 0
			itemsMobile : false, // itemsMobile disabled - inherit from itemsTablet option
			nav : true,
			autoplay : true,
			autoplaySpeed : true,
			mouseDrag : false,
			smartSpeed : 500,
		});
	}
	if ($("#owl-demo-2").length) {
		var owl = $("#owl-demo-2");
		owl.owlCarousel({
			items : 1, //1 items above 1000px browser width
			itemsDesktop : [1000, 1], //1 items between 1000px and 901px
			itemsDesktopSmall : [900, 1], // betweem 900px and 601px
			itemsTablet : [600, 1], //1 items between 600 and 0
			itemsMobile : false, // itemsMobile disabled - inherit from itemsTablet option
			nav : true,
			autoplay : true,
			autoplaySpeed : true,
			mouseDrag : false,
			smartSpeed : 500,
		});
	}
	if ($(".owl-demo-3").length) {
		$('.owl-demo-3').owlCarousel({
			loop : true,
			nav : false,
			autoplay : true,
			dots : true,
			responsive : {
				0 : {
					items : 1
				},
				600 : {
					items : 3
				},
				1000 : {
					items : 4
				}
			}
		})
	}
	if ($("#owl-partner").length) {
		$('#owl-partner').owlCarousel({
			nav : true,
			autoplay : true,
			autoplaySpeed : true,
			mouseDrag : false,
			smartSpeed : 500,
			responsive : {
				0 : {
					items : 1
				},
				600 : {
					items : 5
				},
				1000 : {
					items : 5
				}
			}
		})
	}
	if ($('.video-link').length) {
		$('.video-link').on('click', (function() {
			$(this).hide();
			var video_link = $('.video-image img').attr('data-video');
			$('.video-image').append("<iframe src=''> </iframe>");
			$('.video-image iframe').attr('src', video_link);
		}));
	}

	if ($('.dots-two').length) {
		$('.dots-two').on('click', function() {
			$(this).addClass('active-col');
			$('.col-section').addClass('col-sm-4');
			$('.col-section').removeClass('col-sm-6');
			$('.dots-one').removeClass('active-col');
			$('.dots-three').removeClass('active-col');
			$('.grid-fig').removeClass('col-sm-4');
			$('.grid-details').removeClass('col-sm-8 col-sm-offset-4');
			$('.grid-fig').css({
				'padding' : 'initial',
				'position' : 'static',
				'height' : 'auto',
			});
			$('.grid-details').css({
				'border-left' : '1px solid #eceef2',
				'border-top' : 'none',
			});
			$('.grid-fig img').css({
				'height' : 'auto',
				'width' : '100%',
			});
		})
	}
	if ($('.dots-one').length) {
		$('.dots-one').on('click', function() {
			$(this).addClass('active-col');
			$('.col-section').addClass('col-sm-6');
			$('.col-section').removeClass('col-sm-4');
			$('.dots-two').removeClass('active-col');
		})
	}
	if ($('.dots-three').length) {
		$('.dots-three').on('click', function() {
			$(this).addClass('active-col');
			$('.col-section').addClass('col-sm-12');
			$('.grid-fig').addClass('col-sm-4');
			$('.grid-fig.col-sm-4').css({
				'padding' : '0',
				'position' : 'absolute',
				'height' : '100%',
			});
			$('.grid-fig.col-sm-4 img').css({
				'height' : '100%',
				'width' : 'auto',
			});
			$('.grid-details').css({
				'border-top' : '1px solid #eceef2',
				'border-left' : 'none'
			});
			$('.grid-details').addClass('col-sm-8 col-sm-offset-4');
			$('.col-section').removeClass('col-sm-4');
			$('.dots-two').removeClass('active-col');
		})
	}
	if ($(".medical-slides").length) {
		$('.medical-slides').owlCarousel({
			loop : true,
			margin : 10,
			nav : true,
			responsive : {
				0 : {
					items : 1
				},
				600 : {
					items : 1
				},
				1000 : {
					items : 1
				}
			}
		})
	}

	if ($(".owl-demo-4").length) {
		$('.owl-demo-4').owlCarousel({
			loop : true,
			nav : true,
			dots : false,
			navText : ['<i class="fa fa-chevron-left" aria-hidden="true"></i>', '<i class="fa fa-chevron-right" aria-hidden="true"></i>'],
			responsive : {
				0 : {
					items : 1
				},
				600 : {
					items : 1
				},
				1000 : {
					items : 1
				}
			}
		})
	}
	//Custom Map
	if ($('#map-view').length) {
		var map = new GMaps({
			div : '#map-view',
			lat : 44.453436,
			lng : -95.797182,
			disableDefaultUI : true,
			zoom : 17,
			scrollwheel : false
		});
		map.drawOverlay({
			lat : map.getCenter().lat(),
			lng : map.getCenter().lng(),
			content : '<a href="#" class="mapmarker"><img src="assets/images/map-marker.png" alt="" /></a>',
			verticalAlign : 'top',
			horizontalAlign : 'left'
		});
	}

	if ($(".single-fancybox").length) {
		$(".single-fancybox").fancybox({
			openEffect : 'elastic',
			closeEffect : 'elastic',

			helpers : {
				title : {
					type : 'inside'
				}
			}
		});
	}

	if ($(".medical-slides").length) {
		$('.medical-slides').owlCarousel({
			loop : true,
			margin : 10,
			nav : true,
			responsive : {
				0 : {
					items : 1
				},
				600 : {
					items : 1
				},
				1000 : {
					items : 1
				}
			}
		})
	}

	// datepicker js
	if ($('.date-pick').length) {
		$('.date-pick').datepicker({
			format : "dd/mm/yyyy"
		});
	}

	//=======Loader Function======

	$(window).load(function(){
	$('.loader').delay(50).fadeOut();
})
	// Svg implement
	jQuery('img.svg').each(function() {
		var $img = jQuery(this);
		var imgID = $img.attr('id');
		var imgClass = $img.attr('class');
		var imgURL = $img.attr('src');

		jQuery.get(imgURL, function(data) {
			// Get the SVG tag, ignore the rest
			var $svg = jQuery(data).find('svg');

			// Add replaced image's ID to the new SVG
			if ( typeof imgID !== 'undefined') {
				$svg = $svg.attr('id', imgID);
			}
			// Add replaced image's classes to the new SVG
			if ( typeof imgClass !== 'undefined') {
				$svg = $svg.attr('class', imgClass + ' replaced-svg');
			}

			// Remove any invalid XML tags as per http://validator.w3.org
			$svg = $svg.removeAttr('xmlns:a');

			// Replace image with new SVG
			$img.replaceWith($svg);

		}, 'xml');

	});
		
		
//=================Header Style function================
		if ($('#header').hasClass('fixed')) {
			$('#header').next().addClass('top-m');
		}
		if ($('#header').hasClass('intelligent')) {
			$('#header').next().addClass('top-m');
		};

	var class_pr = $('body').attr('class');
	var headerHeight = $('#header').outerHeight();
	var st = $(window).scrollTop();
	stickOnScroll = function() {

		if ($('#header').hasClass("intelligent")) {

			$('#header').removeClass('normal');
			$('#header').next().addClass('top-m');
			var pos = $(window).scrollTop();

			if (pos > headerHeight) {
				if (pos > st) {
					$('#header').addClass('simple')
					$('#header.simple').removeClass('down');
					$('#header.simple').addClass('fixed up');

				} else {
					$('#header.simple').removeClass('up');
					$('#header.simple').addClass('fixed down');

				}
				st = pos;

			} else {
				$('#header.simple').removeClass('fixed down up simple');
			}
			if (pos == $(document).height() - $(window).height()) {
				$('#header.simple').removeClass('up');
				$('#header.simple').addClass('fixed down');
			}

		} else if ($('body').hasClass("fix")) {

			$('#header').next().addClass('top-m');
			$('#header').addClass('simple fixed');
			$('#header').removeClass('down up');
			$('#wrapper').css({
				paddingTop : 0
			});
		} else {

			$('#header.simple').removeClass('fixed down up simple');
			$('#header').addClass('normal');
			
			$('#wrapper').css({
				paddingTop : 0
			});
		}
	};
	stickOnScroll();
	$(window).scroll(function() {
		stickOnScroll();
	});

	// end for sticky header

})(jQuery);

