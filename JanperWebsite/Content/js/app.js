const
  gMobileViewSize = 1279,
  gTransitionDuration = 300

var
  gMobileView = Modernizr.mq('(max-width: ' + gMobileViewSize - 5 + 'px)')

resetView()

jQuery('#menuHamburger').on('click', () => {
  resetView()
})

jQuery(window).on('resize', () => {
  resetView()
})

$(() => {
  resetView()

  jQuery('#menuHamburger').on('click', (e) => {
    if (gMobileView) {
      jQuery('#menuHamburger, .subMenu').hide();
      jQuery('#closeMenu, .subMenu span').show();
      jQuery('#menu').addClass('show');
      jQuery('body').css('overflow', 'hidden');
      jQuery('container').css('overflow', 'hidden');
    }
  })

  jQuery('#closeMenu').on('click', (e) => {
    if (gMobileView) {
      jQuery('#menuHamburger').show();
      jQuery('#closeMenu').hide();
      jQuery('#menu').removeClass('show');
      jQuery('body').removeAttr('style');
      jQuery('container').removeAttr('style');
    }
  })

  jQuery('.closeSubMenu').on('click', (e) => {
    if (gMobileView) {
      jQuery('.subMenu').slideToggle();
    }
  })

  jQuery('#mainMenu li').on('click', (e) => {
    if (gMobileView) {
      if (jQuery(e.currentTarget).attr('id') == 'duraMenu') {
        jQuery('#Dura').slideToggle();
        handleDuraFormLoad(jQuery(e.currentTarget).attr('id'), false)
      }
      else {
        jQuery('#menuHamburger').show();
        jQuery('#closeMenu').hide();
        jQuery('#menu').removeClass('show');
        jQuery('body').removeAttr('style');
      }
    }
    jQuery(document).ajaxComplete(() => {
      resetView()

      if (gMobileView && jQuery('#Dura').length) {
        jQuery('.mobile-sub-menu').removeAttr('style')
          .off('click')
          .on('click', (e) => {
            jQuery(e.currentTarget)
              .find('.mobile-sub-menu-title')
              .fadeToggle()
            jQuery(e.currentTarget)
              .find('.mobile-sub-menu-control')
              .toggleClass('glyphicons-remove')
              .toggleClass('glyphicons-chevron-down')
            jQuery(e.currentTarget)
              .find('.mobile-sub-menu-expanded')
              .slideToggle()
          })

        assignDuraClickEvent('.mobile-sub-menu')
        resetMobileSubMenuTitle()

        jQuery(window)
          .off('scroll')
          .on('scroll', () => {
            resetMobileSubMenuTitle()
          })

        function resetMobileSubMenuTitle() {
          var currentHeading = jQuery('h2').first(),
            title = jQuery('.mobile-sub-menu-title span')
          let currentValue = jQuery(window).scrollTop() + jQuery(window).height() / 2

          if (jQuery('#Options').length) {
            jQuery('h3').each((i, e) => {
              if (jQuery(e).offset().top < currentValue) {
                currentHeading = jQuery(e)
              }
            })
          }
          else {
            jQuery('h2').each((i, e) => {
              if (jQuery(e).offset().top < currentValue) {
                currentHeading = jQuery(e)
              }
            })
          }

          if (currentHeading.text() != title.text())
            title.fadeOut(() => {
              title.text(currentHeading.text())
              title.fadeIn(() => {
                if (title.width() > title.parent().width() * 0.8)
                  title.css('font-size', '0.95rem')
                else
                  title.css('font-size', '')
              })
            })
        }
      }
    })
  })
})

function resetView() {
  gMobileView = Modernizr.mq('(max-width: ' + gMobileViewSize + 'px)')

  if (!gMobileView) {
    jQuery('body, #logo').removeAttr('style')
    jQuery('.mobile-move-element').removeClass('mobile-move-element')
    setTimeout(() => {
      jQuery('#Dura').insertAfter('#mainMenu')
      jQuery('#Dura').removeClass('mobileSubMenu')
    }, 10)
  }
  else {
    jQuery('header, header *, #menu, #container').removeAttr('style');
    jQuery('#Dura').insertAfter('#duraMenu')
    jQuery('#Dura').addClass('mobileSubMenu')

    if (jQuery('#DuraForm').length || jQuery('#JanperAcrylic').length || jQuery('#JanperEdge').length || jQuery('#TradePortal').length || jQuery('#TradeArea').length)
      jQuery('#logo').hide()
    else
      jQuery('#logo').show()

    if (jQuery('#TradePortal').length) {
      jQuery('#acceptCheck').off('change')
      jQuery('#acceptCheck').on('change', () => {
        jQuery('#acceptButton').toggleClass('enabled')
      })
    }
    if (jQuery('#TradeArea').length) {
      jQuery('#SamplesFormContainer').insertAfter('#SamplesList')

      jQuery('#SampleSelect').click(() => {
        scrollToElement('#Samples');
      })
      jQuery('#FormSelect').click(() => {
        scrollToElement('#Forms');
      })
      jQuery('#BrochureSelect').click(() => {
        scrollToElement('#brochures');
      })
    }
  }
}

function scrollToElement(element) {
  try {
    jQuery('html, body').animate({
      scrollTop: jQuery(element).offset().top - jQuery('header').height()
    }, gTransitionDuration * 2, 'swing');
  }
  catch (e) {
    console.error(e);
  }
}
