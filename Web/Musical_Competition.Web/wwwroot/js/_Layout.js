(function ($) {
    "use strict";
    
    // Initiate the wowjs
    new WOW().init();        
        
    // Sticky Navbar
    $(window).scroll(function () {
        if ($(this).scrollTop() > 0) {
            $('.navbar').addClass('nav-sticky');
        } else {
            $('.navbar').removeClass('nav-sticky');
        }
    });
        
    // Dropdown on mouse hover
    $(document).ready(function () {
        function toggleNavbarMethod() {
            if ($(window).width() > 992) {
                $('.navbar .dropdown').on('mouseover', function () {
                    $('.dropdown-toggle', this).trigger('click');
                }).on('mouseout', function () {
                    $('.dropdown-toggle', this).trigger('click').blur();
                });
            } else {
                $('.navbar .dropdown').off('mouseover').off('mouseout');
            }
        }
        toggleNavbarMethod();
        $(window).resize(toggleNavbarMethod);
    });


    // Testimonials carousel
    $(".testimonials-carousel").owlCarousel({
        center: true,
        autoplay: true,
        dots: true,
        loop: true,
        responsive: {
            0:{
                items:1
            },
            576:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:3
            }
        }
    });
    
    
    // Blogs carousel
    $(".blog-carousel").owlCarousel({
        autoplay: true,
        dots: false,
        loop: true,
        nav : true,
        navText : [
            '<i class="fa fa-angle-left" aria-hidden="true"></i>',
            '<i class="fa fa-angle-right" aria-hidden="true"></i>'
        ],
        responsive: {
            0:{
                items:1
            },
            576:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:3
            }
        }
    });
    
    
    // Class filter
    var classIsotope = $('.class-container').isotope({
        itemSelector: '.class-item',
        layoutMode: 'fitRows'
    });

    $('#class-filter li').on('click', function () {
        $("#class-filter li").removeClass('filter-active');
        $(this).addClass('filter-active');
        classIsotope.isotope({filter: $(this).data('filter')});
    });
    
    
    // Portfolio filter
    var portfolioIsotope = $('.portfolio-container').isotope({
        itemSelector: '.portfolio-item',
        layoutMode: 'fitRows'
    });

    $('#portfolio-filter li').on('click', function () {
        $("#portfolio-filter li").removeClass('filter-active');
        $(this).addClass('filter-active');
        portfolioIsotope.isotope({filter: $(this).data('filter')});
    });
    
})(jQuery);

let title = document.title;
let a = "";

if (title == "Home") {
    a = document.getElementById("home-navlink");
} else if (title == "Judges") {
    a = document.getElementById("judges-navlink");
} else if (title == "Dashboard") {
    a = document.getElementById("dashboard-navlink");
} else if (title == "Contact Us") {
    a = document.getElementById("contacts-navlink");
} else if (title == "Profile") {
    a = document.getElementById("profile-navlink");
} else if (title == "Login") {
    a = document.getElementById("login-navlink");
} else if (title == "Register") {
    a = document.getElementById("register-navlink");
}

[...a.parentElement.children].forEach(link => link.classList.remove("active"));
a.classList.add("active");