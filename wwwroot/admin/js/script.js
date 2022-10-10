function deleteModal(elementId) {
    event.preventDefault();

    if (confirm('Are you sure you want to delete?')) {
        document.getElementById(elementId).submit();
    }
}

