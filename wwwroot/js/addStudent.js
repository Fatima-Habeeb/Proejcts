document.getElementById('interest').addEventListener('change', function () {
    var selectedOption = this.value;
    var newInterestField = document.getElementById('newInterest');

    if (selectedOption === 'Other') {
        newInterestField.style.display = 'block';
        newInterestField.disabled = false; // Enable the input
    } else {
        newInterestField.style.display = 'none';
        newInterestField.disabled = true; // Disable the input
    }
});

function reloadForm() {
    document.getElementById('myForm').reset(); // Reset form fields
    // Optional: Redirect to the same page after resetting the form
    window.location.reload(); // Reload the page
}