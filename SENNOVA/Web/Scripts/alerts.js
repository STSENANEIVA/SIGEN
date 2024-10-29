var estado = "load";

$(document).ready(function () {
    $(".text-warning").attr("title", "Editar");
});

document.addEventListener("DOMContentLoaded", function (e) {
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_initializeRequest(progressAlert);
});


function successalert(messaje) {
    const success = Swal.mixin({
        position: 'center',
        icon: 'success',
        title: messaje,
        showConfirmButton: false,
        timer: 1500
    })
    estado = "success"
    success.fire()
}

function warningalert(messaje) {
    const warning = Swal.mixin({
        position: 'center',
        icon: 'warning',
        title: messaje,
        showConfirmButton: true,
    })
    estado = "warning"
    warning.fire()
}

function erroralert(messaje) {
    const error = Swal.mixin({
        icon: 'error',
        title: 'Oops...',
        text: messaje,
    })
    estado = "error"
    error.fire()
}

function progressAlert() {
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    const UpdateProgressAlert = Swal.mixin({
        title: '<h4>Procesando Datos, Espere por favor...</h4>',
        timerProgressBar: true,
        allowOutsideClick: false,
        allowEscapeKey: false,
        inputAttributes: {
            id: "progressAlert",
        },
        didOpen: () => {
            Swal.showLoading()
            textContent: ""
        }
    })

    UpdateProgressAlert.fire()

    prm.add_endRequest(function () {
        if (estado == "success") {
            setTimeout(function () {
                UpdateProgressAlert.close();
            }, 1000);
        } else if (estado == "load") {
            UpdateProgressAlert.close();
        }
    });
}