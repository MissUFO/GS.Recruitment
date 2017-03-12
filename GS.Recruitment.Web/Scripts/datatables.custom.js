
function dataTableCheckAll(id, name) {
    $("INPUT[name=" + name + "][type='checkbox']").attr('checked', $('#' + id).is(':checked'));
};

function dataTableDeleteItems(form) {
    if (confirm('Are you sure you want to delete this items?'))
        $('#' + form).submit();
};