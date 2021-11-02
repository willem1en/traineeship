function createPerson() {
    // Formulier uitlezen
    let nieuweNaamInvoer = document.getElementById('newName').value;

    let newPerson = {
        name: nieuweNaamInvoer
    }

    fetch("http://localhost:8080/api/person", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newPerson)
    })
        .then(response => {
            alert('Is goedgegaan');
        })
        .catch(error => {
            alert('Er is iets fouts gegaan');
        });

        show()
}

function updatePerson() {
    // Formulier uitlezen
    let nieuweNaamInvoer = document.getElementById('newName').value;
    let updateID = document.getElementById('updateID').value;

    let newPerson = {
        name: nieuweNaamInvoer
    }

    fetch("http://localhost:8080/api/person/" + updateID, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newPerson)
    })
        .then(response => {
            alert('Is goedgegaan');
        })
        .catch(error => {
            alert('Er is iets fouts gegaan');
        });

        show()
}

function show(data) {
    let personsTableHtml =
        `<tr>
                <th>ID</th>
                <th>Name</th>
             </tr>`;

    // Loop to access all rows 
    for (let r of data) {
        personsTableHtml += `<tr> 
                <td>${r.id} </td>
                <td>${r.name}</td>
            </tr>`;
    }

    // Setting innerHTML as tab variable
    document.getElementById("persons").innerHTML = personsTableHtml;
}

function getapi() {
    fetch("http://localhost:8080/personen?n=Willem")
        .then(response => response.json())
        .then(personList => {
            console.log('response', personList);
            show(personList);
        })
        .catch(error => {
            console.log('error', error);
            // handle the error
        });
}

getapi();
