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
let firstContainer = document.getElementById("navlinkscontainer1");
let secondContainer = document.getElementById("navlinkscontainer2");
let removeActive = link => link.classList.remove("active");
let headerAfter = document.getElementById("header-after");
let a = "";

if (title == "Home") {
    a = document.getElementById("home-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650019090/undraw_more_music_w-70-e_iwdy5o.svg')";
} else if (title == "Judges") {
    a = document.getElementById("judges-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650019090/undraw_contemplating_re_ynec_eduysz.svg')";
} else if (title == "Dashboard") {
    a = document.getElementById("dashboard-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650019090/undraw_happy_music_g6wc_e27fea.svg')";
} else if (title == "Contact Us") {
    a = document.getElementById("contacts-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650019499/undraw_contact_us_re_4qqt_eejnbs.svg')";
} else if (title == "Profile") {
    a = document.getElementById("profile-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650019090/undraw_music_re_a2jk_egbw9v.svg')";
} else if (title == "Login") {
    a = document.getElementById("login-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650019288/undraw_forgot_password_re_hxwm_x6ff63.svg')";
} else if (title == "Register") {
    a = document.getElementById("register-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650022745/undraw_welcome_cats_thqn_rh2jlr.svg')";
} else if (title == "Admin") {
    a = document.getElementById("admin-navlink");
    headerAfter.style.backgroundImage = "url('https://res.cloudinary.com/donhvedgr/image/upload/v1650045290/undraw_data_processing_yrrv_sigsr0.svg')";
}

[...firstContainer.children, ...secondContainer.children].forEach(removeActive);

a.classList.add("active");