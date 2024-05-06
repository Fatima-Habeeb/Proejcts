/*"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = message;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});*/

"use strict";
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub") // Replace with the correct URL where the SignalR hub is hosted
    .build();

connection.start().catch(err => console.error(err));

const testData = {
    temperature: 25.5,
    humidity: 60,
    status: "Normal"
};

/*const testData = {
    temperature: getRandomNumber(20, 30).toFixed(2),
    humidity: getRandomNumber(40, 70),
    status: getRandomStatus()
};*/
connection.on('ReceiveData', (data) => {
    document.getElementById('data').innerText = `Real-Time Data: Temperature ${data.temperature}°C, Humidity ${data.humidity}%, Status ${data.status}`;
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    connection.invoke("SendMessage", testData)
        .catch(err => console.error(err));
    event.preventDefault();

});

/*function generateRandomData() {
    const temperature = getRandomNumber(20, 30).toFixed(2);
    const humidity = getRandomNumber(40, 70);
    const status = getRandomStatus();

    return {
        temperature,
        humidity,
        status
    };
}

function getRandomNumber(min, max) {
    return Math.random() * (max - min) + min;
}

function getRandomStatus() {
    const statuses = ["Normal", "Warning", "Critical"];
    const randomIndex = Math.floor(Math.random() * statuses.length);
    return statuses[randomIndex];
}*/