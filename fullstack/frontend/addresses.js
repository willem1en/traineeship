function createAddress() {
    // Formulier uitlezen
    let newStreetNameInput = document.getElementById('newStreetName').value;
    let newHouseNumberInput = document.getElementById('newHouseNumber').value;
    let newPostCodeInput = document.getElementById('newPostCode').value;
    let newCityInput = document.getElementById('newCity').value;

    let newAddress = {
        streetName: newStreetNameInput,
        houseNumber: newHouseNumberInput,
        postCode: newPostCodeInput,
        city: newCityInput
    }

    fetch("http://localhost:8080/api/address", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAddress)
    })
        .then(response => {
            getapi();
            emptyForm()
            alert('Is goedgegaan');
        })
        .catch(error => {
            alert('Er is iets fouts gegaan');
        });

}

function updateAddress() {
    // Formulier uitlezen
    let updateID = document.getElementById('updateID').value;

    let newStreetNameInput = document.getElementById('newStreetName').value;
    let newHouseNumberInput = document.getElementById('newHouseNumber').value;
    let newPostCodeInput = document.getElementById('newPostCode').value;
    let newCityInput = document.getElementById('newCity').value;

    let newAddress = {
        streetName: newStreetNameInput,
        houseNumber: newHouseNumberInput,
        postCode: newPostCodeInput,
        city: newCityInput
    }

    fetch("http://localhost:8080/api/address/" + updateID, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAddress)
    })
        .then(response => {
            getapi();
            emptyForm()
            alert('Is goedgegaan');
        })
        .catch(error => {
            alert('Er is iets fouts gegaan');
        });

}

function deleteAddress() {
    // Formulier uitlezen
    let updateID = document.getElementById('updateID').value;

    fetch("http://localhost:8080/api/address/" + updateID, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
    })
        .then(response => {
            getapi();
            emptyForm()
            alert('Is goedgegaan');
        })
        .catch(error => {
            alert('Er is iets fouts gegaan');
        });

}

function emptyForm() {
    document.getElementById('newStreetName').value = "";
    document.getElementById('newHouseNumber').value = "";
    document.getElementById('newPostCode').value = "";
    document.getElementById('newCity').value = "";
    document.getElementById('updateID').value = "";
}

function show(data) {
    let addressTableHtml =
        `<tr>
                <th>ID</th>
                <th>Streetname</th>
                <th>Housenumber</th>
                <th>Postcode</th>
                <th>Plaatsnam</th>
             </tr>`;

    // Loop to access all rows 
    for (let r of data) {
        addressTableHtml += `<tr onclick="leesPersoonData(${r.id})"> 
                <td>${r.id} </td>
                <td>${r.streetName}</td>
                <td>${r.houseNumber}</td>
                <td>${r.postCode}</td>
                <td>${r.city}</td>
            </tr>`;
    }

    // Setting innerHTML as tab variable
    document.getElementById("addresses").innerHTML = addressTableHtml;
}

function leesPersoonData(id) {
    fetch("http://localhost:8080/eenadres/" + id)
        .then(response => response.json())
        .then(selectedAddress => {
            //alert('Is goedgegaan');
            document.getElementById('newStreetName').value = selectedAddress.streetName;
            document.getElementById('newHouseNumber').value = selectedAddress.houseNumber;
            document.getElementById('newPostCode').value = selectedAddress.postCode;
            document.getElementById('newCity').value = selectedAddress.city;
            document.getElementById('updateID').value = selectedAddress.id;
        })
        .catch(error => {
            alert('Er is iets fouts gegaan');
        });
}

function getapi() {
    fetch("http://localhost:8080/alleadressen")
        .then(response => response.json())
        .then(addressList => {
            console.log('response', addressList);
            show(addressList);
        })
        .catch(error => {
            console.log('error', error);
            // handle the error
        });
}

function searchAdres() {
    var value = document.getElementById('searchValue').value;
    var searchString = "http://localhost:8080/adressen?a=" + value;
    fetch (searchString)
        .then(response => response.json())
        .then(addressList => {
            console.log('response', addressList);
            show(addressList);
        })
        .catch(error => {
            console.log('error', error);
            // handle the error
        });
}

function adresContains() {
    var value = document.getElementById('searchValue').value;
    var searchString = "http://localhost:8080/zoeken?n=" + value;
    fetch (searchString)
        .then(response => response.json())
        .then(addressList => {
            console.log('response', addressList);
            show(addressList);
        })
        .catch(error => {
            console.log('error', error);
            // handle the error
        });
}

getapi();
