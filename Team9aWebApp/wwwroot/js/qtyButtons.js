 //Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
 //for details on configuring this project to bundle and minify static web assets.

 //Write your JavaScript code.
$(document).ready(function () {

    $(".addBtn").click(function (event) {
        var str = event.target.id;
        var id = str.substring(0, 1);
        var qtyid = 'itemQty-' + id;
        var qty = parseInt(document.getElementById(qtyid).value);
        qty++;
        document.getElementById(qtyid).value = qty;

        var addid = id + '-addBtn';
        var price = parseInt(document.getElementById(addid).value);
        var totalPrice = price + parseInt(document.getElementById('totalPrice').value);
        document.getElementById('totalPrice').value = totalPrice;
    });

    $(".minusBtn").click(function (event) {
        var str = event.target.id;
        var id = str.substring(0, 1);
        var qtyid = 'itemQty-' + id;
        var qty = parseInt(document.getElementById(qtyid).value);

        if (qty > 1) {
            qty = qty - 1;

            var minusid = id + '-minusBtn';
            var price = parseInt(document.getElementById(minusid).value);
            var totalPrice = parseInt(document.getElementById('totalPrice').value) - price;
            document.getElementById(qtyid).value = qty;
            document.getElementById('totalPrice').value = totalPrice;
        }
    });

    $(".removeBtn").click(function (event) {
        var str = event.target.id;
        var id = str.substring(0, 1);
        var qtyid = 'itemQty-' + id;
        var qty = parseInt(document.getElementById(qtyid).value);

        var minusid = id + '-minusBtn';
        var price = parseInt(document.getElementById(minusid).value);
        var sumProduct = price * qty;
        var totalPrice = parseInt(document.getElementById('totalPrice').value);
        var updateTotalPrice = totalPrice - sumProduct;
        document.getElementById('totalPrice').value = updateTotalPrice;
    });
})