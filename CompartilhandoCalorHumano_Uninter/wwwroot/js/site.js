//verificação de força de senha

function forcaDaSenha() {
    var senha = document.getElementById('senha').value;
    var forca = 0;

    if ((senha.length >= 4) && (senha.length <= 7)) {
        forca += 10;
    } else if ((senha.length > 7) ) {
        forca += 15;
    }
    if ((senha.length >= 5) && (senha.match(/[a-z]+/))) {
        forca += 10;
    }
    if ((senha.length >= 6) && (senha.match(/[A-Z]+/))) {
        forca += 20;
    }
    if (senha.length >= 7 && senha.match(/[^A-Za-z0-9]+/)) {
        forca += 25;
    }


    mostrarForca(forca); 
}
function mostrarForca(forca) {
    if (forca < 30) {
        document.getElementById("ErroSenhaForca").innerHTML = "<span style='color:#ff0000'> Senha Fraca </span>";
    } else if ((forca >= 30) && (forca < 50)) {
        document.getElementById("ErroSenhaForca").innerHTML = "<span style='color:#ffD700'> Senha Média </span>";
    } else if ((forca >= 50) && (forca < 70)) {
        document.getElementById("ErroSenhaForca").innerHTML = "<span style='color:#7fff00'> Senha Forte </span>";
    } else if ((forca >= 70 ) && (forca < 100)) {
        document.getElementById("ErroSenhaForca").innerHTML = "<span style='color:#008000'> Senha Excelente </span>";
    }
}