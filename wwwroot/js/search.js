document.getElementById('searchInput').addEventListener('keyup', function() {
    const query = this.value.trim();
    if (query.length > 0) {
        // Filter contacts based on the search term
        fetch(`/Contacts/Search?searchTerm=${query}`)
            .then(response => response.json())
            .then(data => updateTable(data));
    } else {
        resetTable();
    }
});

function updateTable(data) {
    const tableBody = document.getElementById('contactsTableBody');
    tableBody.innerHTML = '';

    const tagMap = {
        0: 'None',
        1: 'Family',
        2: 'Work',
        3: 'Friends'
    };

    data.forEach(contact => {
        const row = document.createElement('tr');
        const tagName = tagMap[contact.tag] || 'None';
        row.innerHTML = `
            <td>${contact.name}</td>
            <td>${contact.phoneNumber}</td>
            <td>${contact.email}</td>
            <td>${tagName}</td>
            <td>
                <a href="/Contacts/Edit/${contact.id}" class="btn btn-warning">Edit</a>
                <a href="/Contacts/Delete/${contact.id}" class="btn btn-danger">Delete</a>
            </td>
        `;
        tableBody.appendChild(row);
    });
}

function resetTable() {
    const tableBody = document.getElementById('contactsTableBody');
    tableBody.innerHTML = '';
    
    initialContacts.forEach(contact => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${contact.name}</td>
            <td>${contact.phoneNumber}</td>
            <td>${contact.email}</td>
            <td>${contact.tag}</td>
            <td>
                <a href="/Contacts/Edit?id=${contact.id}" class="btn btn-warning">Edit</a>
                <a href="/Contacts/Delete?id=${contact.id}" class="btn btn-danger">Delete</a>
            </td>
        `;
        tableBody.appendChild(row);
    });
}
