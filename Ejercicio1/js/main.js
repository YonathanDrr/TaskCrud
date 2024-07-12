$(document).ready(function () {


    CargaTablaTask();


});







function CargaTablaTask() {




    $("#tablaTask").DataTable({
        processing: false,
        destroy: true,
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [],
        ajax: {
            url: "/Task/TaskList",
            type: "GET",
            datatype: "json",
        },
        columns: [
            { data: "Title" },
            { data: "Description" },
            { data: "IsCompletedName" },



            {
                render: function (data, type, d) {

                    inner = '';
                    inner += '<div class="dropdown" style="margin-left:30px !important;">';
                    inner += '    <button style="margin:-5px;width:120px" class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="false"';
                    inner += '        aria-expanded="false">';
                    inner += '     Opciones';
                    inner += '    </button>';
                    inner += '    <div class="dropdown-menu">';
                    inner += '       <button class="btn btn-primary" style="width:200px;font-size:12px;" onclick="retorna_tareas(' + d['Id'] + ')"><i class="fa fa-pencil" style="color:blue"></i> Editar</button><br />';


                    inner += '       <button class="btn btn-danger" style="width:200px;font-size:12px;" onclick="modal_eliminar_tarea(' + d['Id'] + ')"><i class="fa fa-trash" style="color:red"></i> Eliminar </button><br />';


                    inner += '    </div>';
                    inner += '</div>';

                    return inner;
                },
                "orderable": false,
                "searchable": false,
                "width": "160px"
            },

        ],
        language: {
            sProcessing: "",
            sLengthMenu: "_MENU_",
            sZeroRecords: "No se encontraron resultados en la búsqueda",
            sEmptyTable: "Ningún dato disponible en esta tabla",
            //sInfo: "",
            sInfoEmpty: "",
            sInfo: "",
            sInfoFiltered: "",
            sSearch: "",
            sLoadingRecords: "Cargando...",
            oPaginate: {
                sFirst: "<<",
                sLast: ">>",
                sNext: "Siguiente",
                sPrevious: "Anterior"
            },
            oAria: {
                sSortAscending: ": Activar para ordenar la columna de manera ascendente",
                sSortDescending: ": Activar para ordenar la columna de manera descendente"
            },
        }
    }
    );


    $("#tablaTask_filter [type='search']").addClass("form-control d-inline").attr("placeholder", "Búsqueda Rápida");
    //$('<i class="fa fa-search" aria-hidden="true"></i>').insertBefore("#tabla_personal_filter [type='search']");
    $('<i class="fa fa-search" aria-hidden="true" style="color:rgba(87, 124, 160, 1);font-size:17px;"></i>').insertBefore("#tablaTask_filter [type='search']");

    $("#tablaTask_filter [type='search']").css({ "font-size": "12px", 'width': '180px' });

    $("#tablaTask_length [name='tablaTask_length']").addClass("browser-default selectpicker grey-text");
    $("#tablaTask_length [name='tablaTask_length']").css({
        'height': '25px',
        "font-size": "12px"
    });


}





function ingresar_tarea() {

        let Obj = {
            Title: $('#input_titulo').val(),
            Description: $('#input_descripcion').val(),
            IsCompleted: $('#select_IsCompleted').val(),
        };

        $.ajax({
            url: "/Task/TaskIngresa",
            data: JSON.stringify(Obj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $('#tablaTask').DataTable().ajax.reload(null, false);
                $("#modal_ingresar_editar").modal('hide');
                Command: toastr["success"]("El registro ha sido ingresado correctamente !")

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function eliminar_tarea() {

    let Obj = {
        Id: $('#id_eliminar').val(),
    };

    $.ajax({
        url: "/Task/TaskElimina",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#tablaTask').DataTable().ajax.reload(null, false);
            $("#modal_eliminar").modal('hide');
            Command: toastr["success"]("El registro ha sido eliminado correctamente !")

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function retorna_tareas(ID) {

    modal_retorna_tareas();

    let Obj = {
        Id: ID,
    };

    $.ajax({
        url: "/Task/TaskRetornaTareas",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#id_tarea').val(result.Id);
            $('#input_titulo').val(result.Title);
            $('#input_descripcion').val(result.Description);

            if (result.IsCompleted == 0) {
                $('#select_IsCompleted').val("0");

            } else {

                $('#select_IsCompleted').val("1");
            }


        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}



function actualizar_tarea() {

    let Obj = {
        Id: $('#id_tarea').val(),
        Title: $('#input_titulo').val(),
        Description: $('#input_descripcion').val(),
        IsCompleted: $('#select_IsCompleted').val(),
    };

    $.ajax({
        url: "/Task/TaskActualiza",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#tablaTask').DataTable().ajax.reload(null, false);
            $("#modal_ingresar_editar").modal('hide');
            Command: toastr["success"]("El registro ha sido ingresado correctamente !")

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



function modal_ingresa_tarea() {

    $('#modal_ingresar_editar').modal('show');
    $('#label_ingresar_editar').text('Ingresar Tarea');
    $('#btn_ingresa').show();
    $('#btn_actualizar').hide();


}

function modal_retorna_tareas() {

    $('#modal_ingresar_editar').modal('show');
    $('#label_ingresar_editar').text('Editar Tarea');

    $('#btn_actualizar').show();
    $('#btn_ingresa').hide();



}


function modal_eliminar_tarea(Id) {
    $('#modal_eliminar').modal('show');
    $('#id_eliminar').val(Id);


}