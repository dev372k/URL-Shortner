const generate = () => {
    const url = $("#url").val()
    if (url) {
        loader("show")
        var myHeaders = new Headers();
        myHeaders.append("X-API-Key", "w5ngvayiqXiCS6UwK0liw4i74G474UcT");
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify(url);

        var requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-API-Key': 'w5ngvayiqXiCS6UwK0liw4i74G474UcT'
            },
            body: raw,
            redirect: 'follow'
        };

        fetch("https://localhost:7224/api/v1/Url", requestOptions)
            .then(response => response.json())
            .then(result => {
                const { status, data } = result
                loader("hide")
                $("#url").val("")
                if (status)
                    $("#generatedURL").text(data)
            })
            .catch(error => console.log('error', error));
    }
}

const copy = (e) => {
    navigator.clipboard.writeText(e.innerText)
    alertify
        .alert("URL is copied to clipboard.", function () {
        }).setHeader('');
}

const loader = (action) => {
    $.LoadingOverlay(action, {
        imageColor: "rgb(105, 105, 250)",
        size: "10%"
    })
}