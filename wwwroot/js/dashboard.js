/*
    // Fetch data for top 5 interests from ASP.NET backend
fetch('/Students/GetTop5Interests')
        .then(response => {
    response.json()
})

        .then(topInterestsData => {
    // Populate top interests table
    populateTable('topInterestsTable', topInterestsData);
        })
        .catch(error => {
    console.error('Error fetching top 5 interests data:', error);
        });

// Fetch data for bottom 5 interests from ASP.NET backend
fetch('/Students/GetBottom5Interests')
        .then(response => response.json())
        .then(bottomInterestsData => {
    // Populate bottom interests table
    populateTable('bottomInterestsTable', bottomInterestsData);
        })
        .catch(error => {
    console.error('Error fetching bottom 5 interests data:', error);
        });

// Function to populate a table with a list of interests
function populateTable(tableId, interestsList) {
        const tableBody = document.getElementById(tableId).getElementsByTagName('tbody')[0];

// Clear existing table rows
tableBody.innerHTML = '';

        // Loop through the list of interests and populate table rows
        interestsList.forEach((interest, index) => {
            const newRow = tableBody.insertRow();
const cell1 = newRow.insertCell(0);
cell1.textContent = interest; // Interest value from the list
        });
    }

//distinct interests
fetch('/Students/GetDistinctInterests')
        .then(response => response.json())
        .then(data => {
            const distinctInterestsCount = data; // Assuming the returned data is a number
document.getElementById('distinctInterests').textContent = distinctInterestsCount;
        })
        .catch(error => {
    console.error('Error fetching distinct interests count:', error);
        });

//city distribution data
fetch('/Students/GetCityDistributionData')
        
        .then(response => response.json())
        
        .then(data => {
            // Process 'data' received, assuming it's in the form of {city: count }
            const labels = Object.keys(data);
const counts = Object.values(data);

// Chart.js configuration
const ctx = document.getElementById('cityDistributionChart').getContext('2d');
const cityDistributionChart = new Chart(ctx, {
    type: 'pie',
data: {
    labels: labels,
datasets: [{
    label: 'City Distribution',
data: counts,
    backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#7CB342', '#F5F5F5', '#AA4499', '#008C8C', '#FF8C00', '#4CAF50','#333333' ], // Adjust as needed
borderWidth: 1
                    }]
                },
options: {
    // Chart options and configurations
}
            });
        })
        .catch(error => {
    console.error('Error fetching city distribution data:', error);
        });


//submission chart
// Fetch data from your ASP.NET backend endpoint
fetch('/Students/GetSubmissionChartData')
    .then(response => response.json())
    .then(data => {
        // Process 'data' received, assuming it's an array of daily student creation counts
        const labels = []; // Array to hold dates as labels
        const counts = data; // Array of student creation counts

        // Generate labels for the last 30 days
        for (let i = 0; i < 30; i++) {
            const date = new Date();
            date.setDate(date.getDate() - (30 - i));
            labels.push(date.toLocaleDateString()); // Customize date formatting as needed
        }

        // Chart.js configuration
        const ctx = document.getElementById('submissionsChart').getContext('2d');
        const submissionChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Daily Student Creations',
                    data: counts,
                    fill: false,
                    borderColor: '#36A2EB',
                    tension: 0.1
                }]
            },
            options: {
                scales: {
                    x: {
                        title: {
                            display: true,
                            text: 'Date'
                        }
                    },
                    y: {
                        title: {
                            display: true,
                            text: 'Student Creations'
                        }
                    }
                }
            }
        });
    })
    .catch(error => {
        console.error('Error fetching submission data:', error);
    });


//age distribution bar graph
fetch('/Students/GetAgeDistributionData')
    .then(response =>  response.json())
    .then(ageDistributionData => {
        console.log(ageDistributionData)
        const labels = Object.keys(ageDistributionData); // Extracting keys as labels
        const data = Object.values(ageDistributionData); // Extracting values as data

        const ctx = document.getElementById('ageDistributionChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels.map(age => age.toString()), // Convert keys to strings for X-axis labels
                datasets: [{
                    label: 'Age Distribution',
                    data: data,
                    backgroundColor: 'rgba(54, 162, 235, 0.6)', // Custom bar colors
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    title: {
                        display: true,
                        text: 'Age Distribution'
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Number of Students'
                        },
                        ticks: {
                            stepSize: 5 // Customize the step size for y-axis
                        }
                    },
                    x: {
                        title: {
                            display: true,
                            text: 'Age'
                        }
                    }
                }
            }
        });
    })
    .catch(error => {
        console.error('Error fetching age distribution data:', error);
    });

//department distribution data
fetch('/Students/GetDepartmentDistributionData')

        .then(response => response.json())

        .then(data => {
            const labels = Object.keys(data);
const counts = Object.values(data);

// Chart.js configuration
const ctx = document.getElementById('departmentDistributionChart').getContext('2d');
const cityDistributionChart = new Chart(ctx, {
    type: 'pie',
data: {
    labels: labels,
datasets: [{
    label: 'Department Distribution',
data: counts,
backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#7CB342', '#F5F5F5'], // Adjust as needed
borderWidth: 1
                    }]
                },
options: {
    // Chart options and configurations
}
            });
        })
        .catch(error => {
    console.error('Error fetching department distribution data:', error);
        });


//degree distribution data
fetch('/Students/GetDegreeDistributionData')

    .then(response => response.json())

    .then(data => {
        const labels = Object.keys(data);
        const counts = Object.values(data);

        // Chart.js configuration
        const ctx = document.getElementById('degreeDistributionChart').getContext('2d');
        const cityDistributionChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Degree Distribution',
                    data: counts,
                    backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#7CB342', '#F5F5F5'], // Adjust as needed
                    borderWidth: 1
                }]
            },
            options: {
                // Chart options and configurations
            }
        });
    })
    .catch(error => {
        console.error('Error fetching degree distribution data:', error);
    });

//student status distribution data
fetch('/Students/GetStudentStatusData')

    .then(response => response.json())
    .then(dictionaryData => {
        const tableBody = document.getElementById('studentDataTable').getElementsByTagName('tbody')[0];

        // Clear existing table rows
        tableBody.innerHTML = '';

        // Loop through the dictionary data and populate table rows
        for (const [key, value] of Object.entries(dictionaryData)) {
            const newRow = tableBody.insertRow();
            const cell1 = newRow.insertCell(0);
            const cell2 = newRow.insertCell(1);

            cell1.textContent = key; // Key
            cell2.textContent = value; // Value
        }
    })
    .catch(error => {
        console.error('Error fetching dictionary data:', error);
    });


//gender distribution data
fetch('/Students/GetGenderDistributionData')

    .then(response => response.json())

    .then(data => {
        // Process 'data' received, assuming it's in the form of {city: count }
        const labels = Object.keys(data);
        const counts = Object.values(data);

        // Chart.js configuration
        const ctx = document.getElementById('genderDistributionChart').getContext('2d');
        const cityDistributionChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Gender Distribution',
                    data: counts,
                    backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#7CB342', '#F5F5F5'], // Adjust as needed
                    borderWidth: 1
                }]
            },
            options: {
                // Chart options and configurations
            }
        });
    })
    .catch(error => {
        console.error('Error fetching Gender distribution data:', error);
    });


// last 30 days activity chart
fetch('/Students/GetLast30DaysActivityData')
        .then(response => response.json())
        .then(activityData => {
    // Call function to render line chart with the fetched data
    renderLineChart(activityData);
        })
        .catch(error => {
    console.error('Error fetching last 30 days activity data:', error);
        });

// Function to render a line chart using Chart.js
function renderLineChart(activityData) {
    const ctx = document.getElementById('last30DaysActivityChart').getContext('2d');
    Chart.getChart(ctx)?.destroy();
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: generateLabelsForLast30Days(), // Generate labels for the last 30 days
            datasets: [{
                label: 'Last 30 Days Activity',
                data: activityData, // Use fetched activity data here
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Last 30 Days Activity'
                },
                legend: {
                    display: false
                }
            }
        }
    });
    }

// Function to generate labels for the last 30 days
function generateLabelsForLast30Days() {
    const labels = [];
    const currentDate = new Date();
    for (let i = 29; i >= 0; i--) {
        const date = new Date(currentDate);
        date.setDate(currentDate.getDate() - i);
        labels.push(date.toLocaleDateString()); // Adjust date formatting as needed
    }
    return labels;
}


*//*
//last 24 hours activity chart
// Fetch data for last 24 hours activity from ASP.NET backend
fetch('/Students/GetLast24HoursActivityData')
    .then(response => response.json())
    .then(activityData => {
        // Call function to render line chart with the fetched data
        renderLineChartForLast24Hours(activityData);
    })
    .catch(error => {
        console.error('Error fetching last 24 hours activity data:', error);
    });

// Function to render a line chart for the last 24 hours using Chart.js
function renderLineChartForLast24Hours(activityData) {
    const ctx = document.getElementById('last24HoursActivityChart').getContext('2d');
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: generateLabelsForLast24Hours(),
            datasets: [{
                label: 'Last 24 Hours Activity',
                data: activityData,
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgba(255, 99, 132, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Last 24 Hours Activity'
                },
                legend: {
                    display: false
                }
            }
        }
    });
}*//*

// Function to generate labels for the last 24 hours (15-minute intervals)

fetch('/Students/GetLast24HoursActivityData')
    .then(
        response => response.json(),
        console.log(response)
)
    .then(activityData => {
        // Convert the object to an array of objects with 'label' and 'data' properties
        const formattedData = Object.keys(activityData).map(key => ({
            label: key,
            data: activityData[key]
        }));

        // Call function to render line chart with the formatted data
        renderLineChartForLast24Hours(formattedData);
    })
    .catch(error => {
        console.error('Error fetching last 24 hours activity data:', error);
    });

// Function to render a line chart for the last 24 hours using Chart.js
function renderLineChartForLast24Hours(formattedData) {
    const ctx = document.getElementById('last24HoursActivityChart').getContext('2d');
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: generateLabelsForLast24Hours(),
            datasets: [{
                label: 'Last 24 Hours Activity',
                data: formattedData.map(item => item.data),
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderColor: 'rgba(255, 99, 132, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Last 24 Hours Activity'
                },
                legend: {
                    display: false
                }
            }
        }
    });
}

function generateLabelsForLast24Hours() {
    const labels = [];
    const currentTime = new Date();
    for (let i = 23; i >= 0; i--) {
        const date = new Date(currentTime);
        date.setHours(currentTime.getHours() - i);
        labels.push(date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }));
    }
    return labels;
}

// least active hours
fetch('/Students/GetLeastActiveHoursLast30DaysData')
    .then(response => response.json())
    .then(leastActiveHoursData => {
        console.log("successful1");
        // Call function to populate the unordered list with the fetched data
        populateLeastActiveHoursList(leastActiveHoursData);
    })
    .catch(error => {
        console.error('Error fetching least active hours data:', error);
    });

*/

/*// Function to populate the list of least active hours
function populateLeastActiveHoursList(leastActiveHoursData) {
    const leastActiveHoursList = document.getElementById('leastActiveHoursList');

    // Clear existing list items
    leastActiveHoursList.innerHTML = '';

    // Convert the object into an array of hours
    const hoursArray = Object.entries(leastActiveHoursData);

    // Populate the list with least active hours data
    hoursArray.forEach(([hour, count]) => {
        const listItem = document.createElement('li');
        listItem.textContent = `${hour}: ${count}`;
        leastActiveHoursList.appendChild(listItem);
    });
}


//most active hours
fetch('/Students/GetMostActiveHoursLast30DaysData')
        .then(response => response.json())
        .then(mostActiveHoursData => {
    console.log("successful2");
// Call function to populate the unordered list with the fetched data
populateLeastActiveHoursList(mostActiveHoursData);
        })
        .catch(error => {
    console.error('Error fetching most active hours data:', error);
        });

// Function to populate the list of least active hours
function populateLeastActiveHoursList(mostActiveHoursData) {
        const mostActiveHoursList = document.getElementById('mostActiveHoursList');

// Clear existing list items
mostActiveHoursList.innerHTML = '';

        // Populate the list with least active hours data
        mostActiveHoursData.forEach(hour => {
            const listItem = document.createElement('li');
listItem.textContent = hour;
mostActiveHoursList.appendChild(listItem);
        });
    }

//zero active hours
fetch('/Students/GetDeadHoursLast30DaysData')
        .then(response => response.json())
        .then(zeroActiveHoursData => {
    console.log("successful3");
// Call function to populate the unordered list with the fetched data
populateLeastActiveHoursList(zeroActiveHoursData);
        })
        .catch(error => {
    console.error('Error fetching most active hours data:', error);
        });

// Function to populate the list of least active hours
function populateLeastActiveHoursList(zeroActiveHoursData) {
        const zeroActiveHoursList = document.getElementById('zeroActiveHoursList');

// Clear existing list items
zeroActiveHoursList.innerHTML = '';

        // Populate the list with least active hours data
        zeroActiveHoursList.forEach(hour => {
            const listItem = document.createElement('li');
listItem.textContent = hour;
zeroActiveHoursList.appendChild(listItem);
        });
    }
*/


// Function to render a pie chart using Chart.js
function renderPieChart(chartId, labels, counts, label) {
    const ctx = document.getElementById(chartId).getContext('2d');
    Chart.getChart(ctx)?.destroy(); // Destroy existing chart instance, if any
    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: label,
                data: counts,
                backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56', '#7CB342', '#F5F5F5'], // Adjust as needed
                borderWidth: 1
            }]
        },
        options: {
            // Chart options and configurations
        }
    });
}

// Function to render a bar chart using Chart.js
function renderBarChart(chartId, labels, data, label) {
    const ctx = document.getElementById(chartId).getContext('2d');
    Chart.getChart(ctx)?.destroy(); // Destroy existing chart instance, if any
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels.map(age => age.toString()),
            datasets: [{
                label: label,
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.6)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: label
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Number of Students'
                    },
                    ticks: {
                        stepSize: 5
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Age'
                    }
                }
            }
        }
    });
}

// Fetch data for top 5 interests from ASP.NET backend
fetch('/Students/GetTop5Interests')
    .then(response => response.json())
    .then(topInterestsData => {
        // Populate top interests table
        populateTable('topInterestsTable', topInterestsData);
    })
    .catch(error => {
        console.error('Error fetching top 5 interests data:', error);
    });

// Fetch data for bottom 5 interests from ASP.NET backend
fetch('/Students/GetBottom5Interests')
    .then(response => response.json())
    .then(bottomInterestsData => {
        // Populate bottom interests table
        populateTable('bottomInterestsTable', bottomInterestsData);
    })
    .catch(error => {
        console.error('Error fetching bottom 5 interests data:', error);
    });

// Function to populate a table with a list of interests
function populateTable(tableId, interestsList) {
    const tableBody = document.getElementById(tableId).getElementsByTagName('tbody')[0];

    // Clear existing table rows
    tableBody.innerHTML = '';

    // Loop through the list of interests and populate table rows
    interestsList.forEach((interest, index) => {
        const newRow = tableBody.insertRow();
        const cell1 = newRow.insertCell(0);
        cell1.textContent = interest; // Interest value from the list
    });
}

// Fetch distinct interests count
fetch('/Students/GetDistinctInterests')
    .then(response => response.json())
    .then(data => {
        const distinctInterestsCount = data; // Assuming the returned data is a number
        document.getElementById('distinctInterests').textContent = distinctInterestsCount;
    })
    .catch(error => {
        console.error('Error fetching distinct interests count:', error);
    });

// Call the renderPieChart function for city distribution chart
fetch('/Students/GetCityDistributionData')
    .then(response => response.json())
    .then(data => {
        const labels = Object.keys(data);
        const counts = Object.values(data);
        renderPieChart('cityDistributionChart', labels, counts, 'City Distribution');
    })
    .catch(error => {
        console.error('Error fetching city distribution data:', error);
    });

// Call the renderPieChart function for department distribution chart
fetch('/Students/GetDepartmentDistributionData')
    .then(response => response.json())
    .then(data => {
        const labels = Object.keys(data);
        const counts = Object.values(data);
        renderPieChart('departmentDistributionChart', labels, counts, 'Department Distribution');
    })
    .catch(error => {
        console.error('Error fetching department distribution data:', error);
    });

// Call the renderPieChart function for degree distribution chart
fetch('/Students/GetDegreeDistributionData')
    .then(response => response.json())
    .then(data => {
        const labels = Object.keys(data);
        const counts = Object.values(data);
        renderPieChart('degreeDistributionChart', labels, counts, 'Degree Distribution');
    })
    .catch(error => {
        console.error('Error fetching degree distribution data:', error);
    });

// Call the renderPieChart function for gender distribution chart
fetch('/Students/GetGenderDistributionData')
    .then(response => response.json())
    .then(data => {
        const labels = Object.keys(data);
        const counts = Object.values(data);
        renderPieChart('genderDistributionChart', labels, counts, 'Gender Distribution');
    })
    .catch(error => {
        console.error('Error fetching gender distribution data:', error);
    });

// Call the renderBarChart function for age distribution chart
fetch('/Students/GetAgeDistributionData')
    .then(response => response.json())
    .then(ageDistributionData => {
        const labels = Object.keys(ageDistributionData);
        const data = Object.values(ageDistributionData);
        renderBarChart('ageDistributionChart', labels, data, 'Age Distribution');
    })
    .catch(error => {
        console.error('Error fetching age distribution data:', error);
    });

// Call the renderBarChart function for submission chart
fetch('/Students/GetSubmissionData')
    .then(response => response.json())
    .then(submissionData => {
        const labels = Object.keys(submissionData);
        const data = Object.values(submissionData);
        renderBarChart('submissionChart', labels, data, 'Submission Chart');
    })
    .catch(error => {
        console.error('Error fetching submission data:', error);
    });

// Call the renderLineChart function for last 30 days activity chart
fetch('/Students/GetLast30DaysActivityData')
    .then(response => response.json())
    .then(activityData => {
        // Call function to render line chart with the fetched data
        renderLineChart(activityData, 'last30DaysActivityChart', 'Last 30 Days Activity');
    })
    .catch(error => {
        console.error('Error fetching last 30 days activity data:', error);
    });

// Call the renderLineChart function for last 24 hours activity chart
fetch('/Students/GetLast24HoursActivityData')
    .then(response => response.json())
    .then(activityData => {
        // Call function to render line chart with the fetched data
        renderLineChart(activityData, 'last24HoursActivityChart', 'Last 24 Hours Activity');
    })
    .catch(error => {
        console.error('Error fetching last 24 hours activity data:', error);
    });

// Function to render a line chart using Chart.js
function renderLineChart(activityData, chartId, label) {
    const ctx = document.getElementById(chartId).getContext('2d');
    Chart.getChart(ctx)?.destroy();
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: generateLabelsForLast30Days(), // Generate labels for the last 30 days
            datasets: [{
                label: label,
                data: activityData, // Use fetched activity data here
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: label
                },
                legend: {
                    display: false
                }
            }
        }
    });
}

// Function to generate labels for the last 30 days
function generateLabelsForLast30Days() {
    const labels = [];
    const currentDate = new Date();
    for (let i = 29; i >= 0; i--) {
        const date = new Date(currentDate);
        date.setDate(currentDate.getDate() - i);
        labels.push(date.toLocaleDateString()); // Adjust date formatting as needed
    }
    return labels;
}
