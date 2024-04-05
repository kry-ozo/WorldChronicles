
$(document).ready(function () {
	$('#nav-icon1').click(function () {
		$("#nav-list").toggleClass('opened');
	});
	$('#nav-icon1,#nav-icon2,#nav-icon3,#nav-icon4').click(function () {
		$(this).toggleClass('open');
	});

	
});