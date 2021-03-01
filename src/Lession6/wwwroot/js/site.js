const uri = 'api/contactItems';
let todos = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    // customize area

    // "Customer" : 1,
    // "Country" : "ABC",
    // "BusinessType" : "Others",
    // "BusinessOthers" : "Digital Marketing",
    // "MainProducts" : "Consumer Electronics,Computer/Computer Peripherals Equipment,LED/Display",
    // "Company" : "Blockcode",
    // "FirstName" : "Justin",
    // "LastName" : "Liao",
    // "BusinessTitle" : "CTO",
    // "Email" : "justin@blockcode.com.tw",
    // "Telephone1" : "+886",
    // "Telephone2" : "83784725",
    // "Telephone3" : "99",
    // "Comments" : "please contact us"

    const Textbox_Customer = document.getElementById('add-Customer');
    const Textbox_Country = document.getElementById('add-Country');
    const Textbox_BusinessTyper = document.getElementById('add-BusinessType');
    const Textbox_BusinessOthers = document.getElementById('add-BusinessOthers');
    const Textbox_MainProducts = document.getElementById('add-MainProducts');
    const Textbox_Company = document.getElementById('add-Company');
    const Textbox_FirstName = document.getElementById('add-FirstName');
    const Textbox_LastName = document.getElementById('add-LastName');
    const Textbox_BusinessTitle = document.getElementById('add-BusinessTitle');
    const Textbox_Email = document.getElementById('add-Email');
    const Textbox_Telephone1 = document.getElementById('add-Telephone1');
    const Textbox_Telephone2 = document.getElementById('add-Telephone2');
    const Textbox_Telephone3 = document.getElementById('add-Telephone3');
    const Textbox_Comments = document.getElementById('add-Comments');

    const item = {
        Customer: parseInt(Textbox_Customer.value.trim()),
        Country: Textbox_Country.value.trim(),
        BusinessTyper: Textbox_BusinessTyper.value.trim(),
        BusinessOthers: Textbox_BusinessOthers.value.trim(),
        MainProducts: Textbox_MainProducts.value.trim(),
        Company: Textbox_Company.value.trim(),
        FirstName: Textbox_FirstName.value.trim(),
        LastNametomer: Textbox_LastName.value.trim(),
        BusinessTitle: Textbox_BusinessTitle.value.trim(),
        Email: Textbox_Email.value.trim(),
        Telephone1 : Textbox_Telephone1.value.trim(),
        Telephone2 : Textbox_Telephone2.value.trim(),
        Telephone3 : Textbox_Telephone3.value.trim(),
        Comments : Textbox_Comments.value.trim()
    };

    console.log(JSON.stringify(item))

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            // 如果要清空目前的資料，可以寫在這裡。
            // addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = todos.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isComplete;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10),
        isComplete: document.getElementById('edit-isComplete').checked,
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'to-do' : 'to-dos';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = '';

    _displayCount(data.length);
    
    const button = document.createElement('button');

    data.forEach(item => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td2 = tr.insertCell(0);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(1);
        td3.appendChild(deleteButton);

        // customize area
        let td4 = tr.insertCell(2);
        td4.appendChild(document.createTextNode(item.id));

        let td5 = tr.insertCell(3);
        let isCustomerCheckbox = document.createElement('input');
        isCustomerCheckbox.type = 'checkbox';
        isCustomerCheckbox.disabled = true;
        isCustomerCheckbox.checked = item.customer;
        td5.appendChild(isCustomerCheckbox);

        let td6 = tr.insertCell(4);
        td6.appendChild(document.createTextNode(item.company));

        let td7 = tr.insertCell(5);
        td7.appendChild(textNode = document.createTextNode(item.firstName));

        let td8 = tr.insertCell(6);
        td8.appendChild(textNode = document.createTextNode(item.lastName));

    });

    todos = data;
}