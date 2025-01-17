﻿document.getElementById('incidentForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const formData = {
        accountName: document.getElementById('accountName').value.trim(),
        contactFirstName: document.getElementById('contactFirstName').value.trim(),
        contactLastName: document.getElementById('contactLastName').value.trim(),
        contactEmail: document.getElementById('contactEmail').value.trim(),
        incidentDescription: document.getElementById('incidentDescription').value.trim()
    };

    if (!formData.accountName || !formData.contactFirstName || !formData.contactLastName || !formData.contactEmail || !formData.incidentDescription) {
        document.getElementById('responseMessage').innerHTML = `
            <p style="color: red;">All fields are required.</p>
        `;
        return;
    }

    try {
        const response = await fetch('/Incident', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        });

        if (response.ok) {
            const data = await response.json();
            document.getElementById('responseMessage').innerHTML = `
                <p style="color: green;">Incident created successfully!</p>
            `;
        } else if (response.status === 404) {
            document.getElementById('responseMessage').innerHTML = `
                <p style="color: red;">Account not found!</p>
            `;
        } else {
            const errorData = await response.json();
            document.getElementById('responseMessage').innerHTML = `
                <p style="color: red;">Error: ${errorData.message}</p>
            `;
        }
    } catch (error) {
        document.getElementById('responseMessage').innerHTML = `
            <p style="color: red;">An error occurred: ${error.message}</p>
        `;
    }
});
