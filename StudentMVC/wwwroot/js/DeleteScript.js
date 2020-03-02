//https://csharp-video-tutorials.blogspot.com/2019/08/delete-identity-role-in-aspnet-core.html
function confirmDelete(uniqueId, isTrue) {

    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isTrue) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}