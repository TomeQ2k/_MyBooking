const statsData = statsWrapper;

const statsChartContext = document.getElementById('statsChart').getContext('2d');

const chart = new Chart(statsChartContext, {
    type: 'bar',
    data: {
        labels: ['Bookings', 'Orders', 'Offers', 'Created accounts'],
        datasets: [{
            label: 'Count',
            backgroundColor: ['rgb(255,99,132)',
                'rgb(153, 102, 255)',
                'rgb(54, 162, 235)',
                'rgb(255, 206, 86)'
            ],
            borderColor: ['rgb(255,99,132)',
                'rgb(153, 102, 255)',
                'rgb(54, 162, 235)',
                'rgb(255, 206, 86)'
            ],
            data: statsData
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});