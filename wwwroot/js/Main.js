var boton = document.getElementById("boton");

function traer() {
    var dni = document.getElementById("dni").value;
    fetch(
        "https://apiperu.dev/api/dni/" + dni + "?api_token=0867aa05471fc6dd6aed596bcc14bf4d535d076b270b4d1a4e36646fbe3221ee"
    )
        .then((res) => res.json())
        .then((data) => {
            
            document.getElementById("nombre").value = data.data.nombres;
            document.getElementById("apellido").value = data.data.apellido_paterno + " " + data.data.apellido_materno;
        });
}
boton.addEventListener("click", traer);