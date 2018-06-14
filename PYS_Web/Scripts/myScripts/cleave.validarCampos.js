// Deshabilitar submit al presionar enter
$('.form-control').keydown(function (e) {
    if (e.keyCode == 13) {
        return false;
    }
});

$('.validaNumeros_11').toArray().forEach(function (campo) {
    new Cleave(campo, {
        blocks: [11],
        numericOnly: true,
        numeralThousandsGroupStyle: 'none',
        numeralDecimalScale: 0
    });
});
$('.validaNumeros_3').toArray().forEach(function (campo) {
    new Cleave(campo, {
        blocks: [3],
        numericOnly: true,
        numeralThousandsGroupStyle: 'none',
        numeralDecimalScale: 0
    });
});
$('.validaNumeros_4').toArray().forEach(function (campo) {
    new Cleave(campo, {
        blocks: [4],
        numericOnly: true,
        numeralThousandsGroupStyle: 'none',
        numeralDecimalScale: 0
    });
});
$('.validaNumeros_6').toArray().forEach(function (campo) {
    new Cleave(campo, {
        blocks: [6],
        numericOnly: true,
        numeralThousandsGroupStyle: 'none',
        numeralDecimalScale: 0
    });
});

$('.validaCodigo_3').toArray().forEach(function(campo){
    new Cleave(campo, {
        uppercase: true,
        blocks: [3]
    });
});
$('.validaCodigo_4').toArray().forEach(function (campo) {
    new Cleave(campo, {
        uppercase: true,
        blocks: [4]
    });
});
$('.validaCodigo_10').toArray().forEach(function (campo) {
    new Cleave(campo, {
        uppercase: true,
        blocks: [10]
    });
});
$('.validaNumeros_2').toArray().forEach(function (campo) {
    new Cleave(campo, {
        blocks: [2],
        numericOnly: true,
        numeralThousandsGroupStyle: 'none',
        numeralDecimalScale: 0
    });
});

