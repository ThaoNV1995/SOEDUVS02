$(function(){
	/* Mega Menu */
	$('.mega-menu-title').click(function(){
		if($('.mega-menu-category').is(':visible')){
			$('.mega-menu-category').slideUp();
		} else {
			$('.mega-menu-category').slideDown();
		}
	})
    $('.mega-menu-category .nav > li').hover(function(){
    	$(this).addClass("active");
		$(this).find('.popup').stop(true,true).fadeIn('slow');
    },function(){
        $(this).removeClass("active");
		$(this).find('.popup').stop(true,true).fadeOut('slow');
    })
	$('.mega-menu-category .nav > li.view-more').click(function(e){
		if($('.mega-menu-category .nav > li.more-menu').is(':visible')){
			$('.mega-menu-category .nav > li.more-menu').stop().slideUp();
			$(this).find('a').text('More category');
		} else { 
			$('.mega-menu-category .nav > li.more-menu').stop().slideDown();
			$(this).find('a').text('Close menu');
		}
		e.preventDefault();
	})
});
