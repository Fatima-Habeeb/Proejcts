
function submitPageSize() {
    document.getElementById("pageSizeForm").submit();
}

//////////////////////////////////////////////////////
document.getElementById('interest').addEventListener('change', function () {
    var selectedOption = this.value;
    var newInterestField = document.getElementById('newInterest');

    if (selectedOption === 'Other') {
        newInterestField.style.display = 'block';
    } else {
        newInterestField.style.display = 'none';
    }
});

