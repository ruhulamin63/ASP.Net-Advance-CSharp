/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "../../../themes/metronic/html/demo1/src/js/custom/intro.js":
/*!******************************************************************!*\
  !*** ../../../themes/metronic/html/demo1/src/js/custom/intro.js ***!
  \******************************************************************/
/***/ ((module) => {



// Class definition
var KTIntro = function () {
    // Private functions
    var initIntro1 = function(timeout) {
        var element = document.querySelector('#kt_explore_toggle_label');

        if (!element) {
            return;
        }

        var popover = new bootstrap.Popover(element, {
            customClass: 'popover-dark',
            trigger: 'hover',
            container: 'body',
            boundary: 'window',
            placement: 'right',
            html: true,
            title: 'Explore Metronic',
            content: 'Looking for more layouts? Check out Metronic\'s other amazingly unique demos to better suit your project needs.'
        });

        popover.show();

        // Remove
        setTimeout(function(params) {
            if (popover) {
                popover.dispose();
            } 
        }, timeout);
    }

    var initIntro2 = function(timeout) {
        var element = document.querySelector('#kt_header_search_toggle');

        if (!element) {
            return;
        }

        var popover = new bootstrap.Popover(element, {
            customClass: 'popover-dark',
            container: 'body',
            trigger: 'hover',
            boundary: 'window',
            placement: 'left',
            html: true,
            title: 'Quick Search',
            content: 'Click here to check out our brand new, frontend ready Quick Search feature.'
        });

        popover.show();

        // Remove
        setTimeout(function(params) {
            if (popover) {
                popover.dispose();
            } 
        }, timeout);
    }

    var initIntro3 = function(timeout) {
        var element = document.querySelector('#kt_toolbar_primary_button');

        if (!element) {
            return;
        }

        var popover = new bootstrap.Popover(element, {
            customClass: 'popover-dark',
            container: 'body',
            trigger: 'hover',
            boundary: 'window',
            placement: 'left',
            html: true,
            title: 'Modal Form Wizard',
            content: 'Completely improved from the ground up, our new Wizard Modals provides an exceptional solution for any ad-hoc form requirement.'
        });

        popover.show();

        // Remove
        setTimeout(function(params) {
            if (popover) {
                popover.dispose();
            } 
        }, timeout);
    }

    var initIntro4 = function(timeout) {
        var element = document.querySelector('#kt_header_user_menu_toggle');

        if (!element) {
            return;
        }

        var popover = new bootstrap.Popover(element, {
            customClass: 'popover-dark',
            container: 'body',
            trigger: 'hover',
            boundary: 'window',
            placement: 'left',
            html: true,
            title: 'Advanced User Menu',
            content: 'Explore our updated User Menus that fits perfectly within any project.'
        });

        popover.show();

        // Remove
        setTimeout(function(params) {
            if (popover) {
                popover.dispose();
            }            
        }, timeout);
    }

    var handleIntrosDisplay = function(params) {
        var date, expires;

        if (!KTCookie.get('show_intro_popovers')) {
            // Intro 1
            setTimeout(function() {
                initIntro1(1000 * 5); // hide in 10 secondas
            }, 1000 * 3); // show in 3 seconds

            // Intro 2
            setTimeout(function() {
                initIntro2(1000 * 5); // hide in 10 secondas
            }, 1000 * 10); // show in 3 seconds

            // Intro 3
            setTimeout(function() {
                initIntro3(1000 * 5); // hide in 10 secondas
            }, 1000 * 17); // show in 3 seconds

            // Intro 4
            setTimeout(function() {
                initIntro4(1000 * 5); // hide in 10 secondas
            }, 1000 * 24); // show in 3 seconds
           

            date = new Date();
            expires = 1000 * 60 * 60 * 24 * 10; // 1 day
            KTCookie.set("show_intro_popovers", 1, {expires: new Date(date.getTime() + expires)});
        }        
    }

    var handleExplorePanelDisplay = function(params) {
        var date, expires;
        var drawerEl = document.querySelector("#kt_explore");

        if (!drawerEl) {
            return;
        }

        if (!KTCookie.get('show_explore_panel')) {
            setTimeout(function() {
                KTDrawer.getInstance(drawerEl).show();
            }, 1000 * 40); //  40 seconds

            date = new Date();
            expires = 1000 * 60 * 60 * 24 * 2; // 1 day
            KTCookie.set("show_explore_panel", 1, {expires: new Date(date.getTime() + expires)});
        }        
    }

    // Public methods
    return {
        init: function () {
            handleIntrosDisplay();
            //handleExplorePanelDisplay();            
        }   
    }
}();

// Webpack support
if (true) {
    module.exports = KTIntro;
}

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTIntro.init();
});


/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module is referenced by other modules so it can't be inlined
/******/ 	var __webpack_exports__ = __webpack_require__("../../../themes/metronic/html/demo1/src/js/custom/intro.js");
/******/ 	
/******/ })()
;
//# sourceMappingURL=intro.js.map