/*--------------------------------------------------------------------------------------------------------- 
*@function: loadAjax
*@description : Agrega la clase loading al body, la clase loading tiene los estilos para la carga.
**//*---------------------------------------------------------------------------------------------------- */
function loadAjax(){
    try{
        $.xAjaxPool = [];
        $.ajaxSetup({    
            beforeSend: function (jqXAjax) {
                $('body').addClass('loading'); 
                $.xAjaxPool.push(jqXAjax);
            },
            complete: function (jqXAjax) {
                var index = $.xAjaxPool.indexOf(jqXAjax);
                if (index > -1) {
                    $.xAjaxPool.splice(index, 1);
                }
                if ($.xAjaxPool.length == 0) {
                    $('body').removeClass('loading');
                }       
            },
            error: function (jqXAjax) {
                var index = $.xAjaxPool.indexOf(jqXAjax);
                if (index > -1) {
                    $.xAjaxPool.splice(index, 1);
                }
                $('body').removeClass('loading');
            }
        });

    }catch(mierror){
       //hago algo cuando el error se ha detectado
    }
};
loadAjax();
/*--------------------------------------------------------------------------------------------------------- 
*@function: scrollTop
*@description : Muestra flecha para scrollear hacia arriba
**//*---------------------------------------------------------------------------------------------------- */
function scrollTop(){
    $(window).scroll(function () {
        if ($(this).scrollTop() > 250) {
            $('.upPage').fadeIn();
        } else {
            $('.upPage').fadeOut();
        }
    });

    // scroll body to 0px on click
    $('.upPage').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        $(this).blur();
        return false;
    });
};
scrollTop();
    
$('body').tooltip({
    selector: "[data-toggle='tooltip']"
});
$('body').popover({
    selector: "[data-toggle='popover']"
});
    
/*--------------------------------------------------------------------------------------------------------- 
*@function: navAjax 
*@description : Navegacion utilizando Ajax para el menu izquierdo
**//*---------------------------------------------------------------------------------------------------- */
;(function ( $, window, document, undefined ) {
    
    var urlIni = "Categoria/Index",
    defaults = {
       urlDefault : '' || urlIni 
    };
       
    // The actual plugin constructor
    function navAjax( element, options ) {

        //SELECTORES
        $element = $(element); 
        $navAjaxBtn = $('[data-navAjax]');   
        $navAjaxContent = $('[data-navajaxcontent]');
        this.element = element;


        this.options = $.extend( {}, defaults, options);        
        this._defaults = defaults;
        this._name = 'navAjax';
        
        this.init();
    }

    navAjax.prototype = {
        init : function(){
            var that = this;
            that.constructor();
        },
        constructor : function(){
            var that = this;
            //that.ajax(this._defaults.urlDefault)
            that.eventos();
        },
        eventos : function(){
            var that = this;
            $element.on('click', function(e){
                e.preventDefault();
                var $el = $(this),
                    url = $(this).attr('href');

                $('.menu-dropdown').removeClass('active');
                $navAjaxBtn.removeClass('active');

                
                $el.addClass('active');
                $el.closest('.menu-dropdown').addClass('active');

                if(url == '#' || url == ''){
                    alert("Ingresar url valida")
                }else{
                    that.ajax(url)
                }
                    
            })
        },
        addClass : function(){

        },
        ajax : function(url){
            var that = this;
            $.ajax({
                url : url,
                success : function(data){
                    $navAjaxContent.empty()
                    $navAjaxContent.append(data);
                   
                }
            })
            
        }       
    };

    

    $.fn.naxAjax = function ( options ) {
        return this.each(function () {
            if (!$.data(this, 'plugin_' + 'navAjax')) {
                $.data(this, 'plugin_' + 'navAjax', 
                new navAjax( this, options ));
            }
        });
    }

    var iniNav = new navAjax();

    iniNav.ajax(urlIni);

})( jQuery, window, document );


/*--------------------------------------------------------------------------------------------------------- 
*@function: menuMultinivel
*@description : Menu Multinivel
**//*---------------------------------------------------------------------------------------------------- */
;(function ( $, window, document, undefined ) {
    
    
    defaults = {
        type : '' || 'dropdown',
        speed : '' || 600,
        fx : ''
    };

    // The actual plugin constructor
    function menuMultinivel( element, options ) {

        //SELECTORES
        $body = $('body'),
        $allElement = $('[data-menu]'),
        $element = $(element); 
        $elementBtn = $element.children('a');
        $elementSubMenu = $allElement.find('.sub-menu');
        
        this.element = element;


        this.options = $.extend( {}, defaults, options);        
        this._defaults = defaults;
        
        this.init();
    }

    menuMultinivel.prototype = {
        init : function(){
            var that = this;
            that.constructor();
        },
        constructor : function(){
            var that = this;
            that.eventos();
        },
        eventos : function(){
            var that = this;
            $elementBtn.on('click', function(e){    

                if($(this).closest('.menu-dropdown').data("menu") != "disabled" && !$body.hasClass('aside-closed'))
                    that.fx(that.options.type, $(this))                                 
            })
            
        },
        fx : function(optionType){   
            
            var $el = arguments[1],
                $elLi = $el.closest('.menu-dropdown'),
                $elUl = $el.next('.sub-menu');
            
            switch(optionType){
                case 'dropdown' : {
                    if(!$elLi.hasClass('active')){
                        $allElement.removeClass('active');
                        $elementSubMenu.slideUp();  
                        $elLi.addClass('active');
                        $elUl.stop().slideDown(this.options.speed);                 
                    }else{
                        $elLi.removeClass('active');
                        $elUl.stop().slideUp(this.options.speed);                   
                    }
                }   
            }
        }           
    };


    $.fn.menuMultinivel = function ( options ) {
        return this.each(function () {
            if (!$.data(this, 'plugin_' + 'menuMultinivel')) {
                $.data(this, 'plugin_' + 'menuMultinivel', 
                new menuMultinivel( this, options ));
            }
        });
    }

})( jQuery, window, document );


/*--------------------------------------------------------------------------------------------------------- 
*@function: asideSlide
*@description : Efecto de slide al menu
**//*---------------------------------------------------------------------------------------------------- */
;(function ( $, window, document, undefined ) {
    
    
    defaults = {
        speed : '' || 400,
        fx : ''
    };

    // The actual plugin constructor
    function asideSlide( element, options ) {

        //SELECTORES
        $body = $('body');
        $element = $(element); 
        $btn = $('[data-asideslide="button"]'),
        $slide = $('[data-asideslide="slide"]');
        
        this.element = element;


        this.options = $.extend( {}, defaults, options);        
        this._defaults = defaults;
        
        this.init();
    }

    asideSlide.prototype = {
        init : function(){
            var that = this;
            that.constructor();
        },
        constructor : function(){
            var that = this;
            if($body.hasClass('aside-closed')){
                $('.wrap-text, .bl-slide').css({
                    left:-260
                }, that.options.speed)
            }
            that.eventos();
        },
        eventos : function(){
            var that = this;
            $btn.on('click', function(){
                var $el = $(this),
                    $open = $el.hasClass('active');

                if(!$open){
                    $body.addClass('aside-open');
                    $body.removeClass('aside-closed aside-closed-complete');
                    $el.addClass('active');

                    $('.wrap-text, .bl-slide').stop().animate({
                        left:0
                    }, that.options.speed, function(){
                        $body.addClass('aside-open-complete');
                        if($body.hasClass('aside-open-complete')){                            
                            
                            $('[data-menu]').each(function(key,val){
                                if($(this).hasClass('active')){
                                    $(this).find('.sub-menu').slideDown();
                                }
                            });
                        }
                    });


                    


                }else{
                    $body.addClass('aside-closed');
                    $body.removeClass('aside-open aside-open-complete');
                                    

                            


                    $('.sub-menu').slideUp(function(){
                        $("[data-navajax='true']").each(function(key,val){
                            var $el = $(this);

                            if($el.hasClass('active')){
                                $('.menu-dropdown').removeClass('active');
                                $el.closest('.menu-dropdown').addClass('active');                               
                            }
                        })
                    });

                    
                    
                    setTimeout(function(){
                        $('.wrap-text, .bl-slide').stop().animate({
                            left:-260
                        }, that.options.speed, function(){
                            $el.removeClass('active');   
                            $body.addClass('aside-closed-complete');
                        });     
                    }, 500)
                }               
            });
        }       
    };


    $.fn.asideSlide = function ( options ) {        
            if (!$.data(this, 'plugin_' + 'asideSlide')) {
                $.data(this, 'plugin_' + 'asideSlide', 
                new asideSlide( this, options ));
            }        
    }

})( jQuery, window, document );


/*--------------------------------------------------------------------------------------------------------- 
*@function: selectTheme
*@description : Funcion para seleccionar el tema en vivo.
**//*---------------------------------------------------------------------------------------------------- */
var selectTheme = function(){
    var $body = $('body'),
        $wrapTheme = $('.select-ui'),
        $btn = $wrapTheme.find('li');

        $btn.on('click', function(){    
            var $el = $(this);

                if($el.hasClass('skin')){
                    $el.closest('ul').find('li').removeClass('active');
                    $el.addClass('active');
                    $body.removeClass (function (index, css) {
                        return (css.match (/\bskin-\S+/g) || []).join(' ');
                    }).addClass($el.attr('class'))
                }
                if($el.hasClass('color')){
                    $el.closest('ul').find('li').removeClass('active');
                    $el.addClass('active');
                    $body.removeClass (function (index, css) {
                        return (css.match (/\bbar-\S+/g) || []).join(' ');
                    }).addClass($el.attr('class'))
                }
        });

        $('.close-ui').on('click', function(){
             $body.removeClass('show-ui');
            $('.select-ui').hide();
        })
};

selectTheme();

/*--------------------------------------------------------------------------------------------------------- 
*@function: showBlock
*@description : Muestra bloques
**//*---------------------------------------------------------------------------------------------------- */
var showBlock = function(el, flag){    
    var current = this,
        $elbtn = el,
        $elContent = $('[data-show-content="' + el.data('show-btn') + '"]');


    
    current.init = function(){
        current.event();
    }   

    current.event = function(){
        var that = this;
        $elbtn.on('click', function(){
            var $el = $(this);
            if(flag == true){
                current.removeClass('hidden');
            }
            if(flag == false){
                current.addClass('hidden');
            }
        })
    }

    current.show = function(){     
    
        $elContent.removeClass('hidden');        
    }

    current.hidden = function(){     
        $elContent.addClass('hidden');     
    }


    current.init();
}


/*--------------------------------------------------------------------------------------------------------- 
*@function: ajaxInner
*@description : carga ajax
**//*---------------------------------------------------------------------------------------------------- */
var ajaxInner = function(el, block){
    var current = this,
        $elbtn = el,
        $elContent = block;

    current.init = function(){        
        current.event();
    }   

    current.event = function(){
        $elbtn.off('click').on('click', function(e){
            e.preventDefault();

            var $el = $(this),
            url = $el.attr('href');            

            $elbtn.removeClass('active');
            $el.addClass('active');

            if(url == '#' || url == ''){
                alert("Ingresar url valida")
            }else{
                current.ajax(url)
            }         
        })
    }

    current.ajax = function(url){
        $.ajax({
            url : url,
            success : function(data){
                $elContent.empty()
                $elContent.append(data);
            }
        })
    }

}

/*--------------------------------------------------------------------------------------------------------- 
*@function: showEditSelectLabel
*@description : Muesta oculta select y label
**//*---------------------------------------------------------------------------------------------------- */
    var showEditSelectLabel = function(el){
        var current = this,
            $elbtn = el;

        current.init = function(){
            current.event();
           
        }

        current.event = function(){
            //CLICK
            $elbtn.on('click', function(){
                var $el = $(this),
                    $elIcon = $el.find('.fa'),
                    $elRow = $el.closest('tr'),
                    $elSelectLabel = $elRow.find('[data-label="content"]'),
                    $elInputRead = $elRow.find('[data-input-read="content"]'),
                    $elSelect = $elSelectLabel.find('select'),
                    $elInput = $elInputRead.find('input');
                    
                   
                if($el.data("edit")){                    
                    $el.data("edit", false);
                    $el.addClass('active');
                    $elSelectLabel.addClass('active');
                    $elInput.prop("disabled", false);
                    $elIcon.attr('class','');                    
                    $elIcon.addClass('fa fa-floppy-o');
                    $elIcon.attr('data-original-title', 'Grabar');


                    current.selectChange($elSelect);
                }else{
                    $el.data("edit", true);            
                    $el.removeClass('active');
                    $elSelectLabel.removeClass('active');
                    $elInput.prop("disabled", true);
                    $elIcon.attr('class','');
                    $elIcon.addClass('fa fa-pencil');
                    $elIcon.attr('data-original-title', 'Editar');
                }
            });
        },

        current.selectChange = function(el){
            var elLabel = el.prev('.label');
            $(el).on('change', function (e) {
                //console.log(e.target.options[e.target.selectedIndex].text);
                switch(this.value){
                    case'003':{
                        elLabel
                        .attr('class','')
                        .addClass('label label-warning')
                        .html(e.target.options[e.target.selectedIndex].text);
                        break;
                    }
                    case'001':{
                        elLabel
                        .attr('class','')
                        .addClass('label label-warning')
                        .html(e.target.options[e.target.selectedIndex].text);
                        break;
                    }
                    case'002':{
                        elLabel
                        .attr('class','')
                        .addClass('label label-success')
                        .html(e.target.options[e.target.selectedIndex].text);
                        break;
                    }
                }
            })
        }

        

    }


/*--------------------------------------------------------------------------------------------------------- 
INIT
**//*---------------------------------------------------------------------------------------------------- */
$(function(){

    $('[data-navAjax]').naxAjax();

    $('[data-menu]').menuMultinivel({
        type : "dropdown"
    });

    $.fn.asideSlide();
});



//$.extend($.fn.dataTable.defaults, {

//    language: {
//        url: "Scripts/datatable/Spanish.json"
//    }
//});