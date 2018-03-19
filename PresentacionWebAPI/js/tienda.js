'use strict';

var carritoUsuario;

$(function () {
    carritoUsuario = cargarCarrito();

    if (!carritoUsuario.productos) {
        carritoUsuario = {
            usuario: {
                Id: 1,
                Nick: 'Javier',
                Password: ''
            },
            productos: [{
                producto: {
                    Id: 1,
                    Nombre: 'Producto1',
                    Precio: 10
                },
                cantidad: 5
            },
            {
                producto: {
                    Id: 2,
                    Nombre: 'Producto2',
                    Precio: 20
                },
                cantidad: 3
            }
            ]
        };

        guardarCarrito(carritoUsuario);
    }

    $('#ficha, #carrito, #factura, #login').hide();

    //Cambios de pantalla
    $('#btnAddCarrito').click(function () {
        //alert($(this).data('id'));
        $('#index').hide(); //fadeOut(2000); //slideUp(); //hide();
        $('#ficha').show(); //fadeIn(2000); //slideDown(); //show();
    });

    $('#frmCarrito').submit(function (e) {
        e.preventDefault();

        var id = $('#frmCarrito input[name=id]').val();
        var cantidad = $('#frmCarrito input[name=cantidad]').val();

        $.getJSON('api/Productos/' + id, function (producto) {

            var linea = {
                producto: producto,
                cantidad: cantidad
            };

            carritoUsuario = cargarCarrito();
            carritoUsuario.productos.push(linea);

            guardarCarrito(carritoUsuario);

            $('#ficha').hide();
            $('#carrito').show();
        });
    });

    $('#btnFactura').click(function (e) {
        e.preventDefault();

        $('#carrito').hide();
        $('#factura').show();
    });

    //Eventos botones
    $('#btnAumentarCantidad').click(function (e) {
        e.preventDefault();
        $('#cantidad').get(0).value++;
        //$('#cantidad').val($('#cantidad').val() + 1);
    });

    $('#btnReducirCantidad').click(function (e) {
        e.preventDefault();
        $('#cantidad').get(0).value--;
        //$('#cantidad').val($('#cantidad').val() + 1);
    });
});

function guardarCarrito(carrito) {
    sessionStorage.setItem('carrito', JSON.stringify(carrito));
}

function cargarCarrito() {
    return JSON.parse(sessionStorage.getItem('carrito'));
}