
function dataTableCheckAll(id, name) {
   $("INPUT[name=" + name + "][type='checkbox']").attr('checked', $('#' + id).is(':checked'));
}
