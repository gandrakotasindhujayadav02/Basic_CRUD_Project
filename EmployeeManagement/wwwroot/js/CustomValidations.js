function validateSalaryInput(inputElement) {
    inputElement.addEventListener("input", function (e) {
        let value = inputElement.value;

        // Remove invalid characters (allow only digits and 1 dot)
        let cleanValue = value.replace(/[^0-9.]/g, '');

        // Prevent multiple dots
        let dotCount = (cleanValue.match(/\./g) || []).length;
        if (dotCount > 1) {
            cleanValue = cleanValue.substring(0, cleanValue.lastIndexOf('.'));
        }

        // Prevent leading dot
        if (cleanValue.startsWith(".")) {
            cleanValue = cleanValue.replace(".", "");
        }

        // Prevent leading zero unless it's "0." format
        if (cleanValue.length > 1 && cleanValue.startsWith("0") && cleanValue[1] !== ".") {
            cleanValue = cleanValue.replace(/^0+/, '');
        }

        inputElement.value = cleanValue;
    });
}

function validateAgeInput(inputElement) {
    inputElement.addEventListener("input", function () {
        let value = inputElement.value;

        // Remove non-digit characters
        value = value.replace(/\D/g, '');

        // Remove leading zeros
        value = value.replace(/^0+/, '');

        // Restrict age to a reasonable max (optional)
        if (value !== "" && parseInt(value) > 120) {
            value = "120"; // cap at 120
        }

        inputElement.value = value;
    });
}

