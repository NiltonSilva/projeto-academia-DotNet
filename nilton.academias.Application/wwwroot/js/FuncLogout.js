$('.btnSair').click(function () {
    logout();
})

function logout() {
    if (confirm("Deseja sair realmente?")) {
        var Url = "/Account/LogOut";
        $.ajax({
            typeof: "POST",
            url: Url,
            success: function () {
            }
        });
        alert("Usuário desconectado com sucesso!");
        window.location.href = "/Home/Index";
    }
}