function Left(cadena, len) {
    if (len <= 0)
        return "";
    else if (len > String(cadena).length)
        return cadena;
    else
        return String(cadena).substring(0, len);
}
function Right(cadena, len) {
    if (len <= 0)
        return "";
    else if (len > String(cadena).length)
        return str;
    else {
        var iLen = String(cadena).length;
        return String(cadena).substring(iLen, iLen - len);
    }
}
String.prototype.format = String.prototype.formatoArreglo = function () {
    var s = this,
        i = arguments.length;

    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    }
    return s;
};

function getHoraActualControl(txtHora) {
    var fechoy = new Date();
    var hora = fechoy.getHours();
    var minuto = fechoy.getMinutes();
    if (hora > 12)
        hora = hora - 12;
    var horactual = Right("0" + hora, 2) + ":" + Right("0" + minuto, 2);
    $(txtHora).val(horactual);
}

function getHoraActualRango(txtFecini, txtFecfin) {
    //Formato: dd/mm/yyyy
    var vrFechoy = new Date();
    var vrMesactual = vrFechoy.getMonth() + 1;
    var vrAnio = vrFechoy.getFullYear();
    var vrFechaIni = "01/" + Right("0" + vrMesactual, 2) + "/" + vrAnio;
    var vrDiaFin = dias(Right("0" + vrMesactual, 2), vrAnio);
    var vrFechaFin = vrDiaFin + "/" + Right("0" + vrMesactual, 2) + "/" + vrAnio;
    $(txtFecini).val(vrFechaIni);
    $(txtFecfin).val(vrFechaFin);
}
function dias(mes, anno) {
    anno = parseInt(anno);
    switch (mes) {
        case '01':
        case '03':
        case '05':
        case '07':
        case '08':
        case '10':
        case '12': return 31;
        case '02': return (anno % 4 == 0) ? 29 : 28;
    }
    return 30;
}

Date.prototype.ddmmyyyy = function () {
    var yyyy = this.getFullYear().toString();
    var mm = (this.getMonth() + 1).toString(); // getMonth() is zero-based
    var dd = this.getDate().toString();
    return (dd[1] ? dd : "0" + dd[0]) + "/" + (mm[1] ? mm : "0" + mm[0]) + "/" + yyyy; // padding
};

function ValidaSoloNumeros() {
    if ((event.keyCode < 48) || (event.keyCode > 57))
        event.returnValue = false;
}

function ConfiguraSoloDecimal() {
    if ((event.keyCode > 57 || event.keyCode < 48) && event.keyCode != 13 && event.keyCode != 46) {
        event.returnValue = false;
    }
}

function CallOpen(asUrl) {
    window.open(asUrl, "_blank", "resizable=yes, scrollbars=yes, titlebar=yes, width=700, height=500, top=10, left=10");
}

//Giovanni 09-07-2014. Descarga de archivos.
function createElement(tag, attribs, styles, parent, nopad) {
    doc = document;
    var el = doc.createElement(tag);
    if (attribs) {
        extend(el, attribs);
    }
    if (nopad) {
        css(el, { padding: 0, border: NONE, margin: 0 });
    }
    if (styles) {
        css(el, styles);
    }
    if (parent) {
        parent.appendChild(el);
    }
    return el;
}
function extend(a, b) {
    var n;
    if (!a) {
        a = {};
    }
    for (n in b) {
        a[n] = b[n];
    }
    return a;
}
function css(el, styles) {
    var userAgent = navigator.userAgent,
         isOpera = window.opera
    isIE = /msie/i.test(userAgent) && !isOpera;

    if (isIE) {
        if (styles && styles.opacity !== UNDEFINED) {
            styles.filter = 'alpha(opacity=' + (styles.opacity * 100) + ')';
        }
    }
    extend(el.style, styles);
}
function discardElement(element) {
    var garbageBin,
          DIV = 'div';
    if (!garbageBin) {
        garbageBin = createElement(DIV);
    }
    // move the node and empty bin
    if (element) {
        garbageBin.appendChild(element);
    }
    garbageBin.innerHTML = '';
}
function DescargaFileUrl(strUrl) {
    var form;
    // create the form
    form = createElement('form', {
        method: 'post',
        action: strUrl,
        enctype: 'multipart/form-data'
    }, {
        display: 'none'
    }, document.body);
    // submit
    form.submit();
    // clean up
    discardElement(form);
}
//fin

function TextVacio(item, mensaje) {
    if ($(item).val().trim() == "") {
        alert(mensaje);
        $(item).focus();
        return false;

    }
    return true;
}

function ConfirmarEliminar() {
    if (confirm("Desea eliminar el registro?") == true)
        return true;
    else
        return false;
}

function alertGrabar() {
    alert("Se registró correctamente.");
}
function alertActualizar() {
    alert("Se actualizó correctamente.");
}
function alertEliminar() {
    alert("El registro fue eliminado.");
}
function alertExitente() {
    alert("El registro ya existe.");
}

//Validar Máximo Carácteres
function ValidarCaracteres(txt, maxlength) {
    if (txt.value.length > maxlength) {
        txt.value = txt.value.substring(0, maxlength);
        //alert("Debe ingresar hasta un Máximo de "+maxlength+" Caracteres");        
        return;
    }
}

//Validar Solo Numeros
function ValidaSoloNumeros() {
    if ((event.keyCode < 48) || (event.keyCode > 57))
        event.returnValue = false;
}

//Validar Solo Decimal
function ConfiguraSoloDecimal() {
    if ((event.keyCode > 57 || event.keyCode < 48) && event.keyCode != 13 && event.keyCode != 46) {
        event.returnValue = false;
    }
}

//Validar Solo Texto
function ConfiguraSoloTexto(item) {
    //if ((event.keyCode != 32) && (event.keyCode != 237)||(event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
    //    event.returnValue = false;
    var reg = /^([a-z ñáéíóú]{2,60})$/i;
    if (!reg.test(item.val())) {
        alert("true");
        //return true;
        event.returnValue = true;
    }
    else {
        alert("false");
        //return false;
        event.returnValue = false;
    }
}



function AgregarComas(nStr) {
    nStr += '';
    nStr = nStr.split(',').join('');
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '.00';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

$(document).ready(function () {
    "use strict";
    setTimeout(function () {
        $('.loader-overlay').addClass('loaded');
        $('body > section').animate({
            opacity: 1,
        }, 400);
    }, 500);
});