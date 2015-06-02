// using highcharts
colors = Highcharts.getOptions().colors;

Highcharts.setOptions({
    lang: {
        drillUpText: '<< 返回 {series.name}'
    }
});

var highChartsOptions = {
    chart: {
        type: 'column',
        events: {
            drilldown: function (e) {
                if (!e.seriesOptions) {
                    // e.point.name is info which bar was clicked
                    chart.showLoading('Simulating Ajax ...');
                    $.get("path/to/place.html?name=" + e.point.name, function (data) {
                        /***
                        where data is this format:
                        data = {
                            name: 'Cars',
                            data: [
                                ['Toyota', 1],
                                ['Volkswagen', 2],
                                ['Opel', 5]
                            ]
                        }

                        ***/
                        chart.hideLoading();
                        chart.addSeriesAsDrilldown(e.point, data);
                    });
                }
            }
        }
    },
    pane: {
        center: ["50%", "50%"]
    },
    title: {
        text: '分时用量情况'
    },
    subtitle: {
        //text: '分时用量'
    },
    xAxis: {
        type: 'category'
    },
    yAxis: {
        min: 0,
        title: {
            text: '消耗量'
        }
    },
    tooltip: {
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y:.1f} {point.unit}</b></td></tr>',
        footerFormat: '</table>',
        shared: true,
        useHTML: true
    },
    legend: {
        enable: true
    },
    plotOptions: {
        column: {
            pointPadding: 0.2,
            borderWidth: 0
        },
        pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
                enabled: false
            },
            showInLegend: true
        },
        series: {
            borderWidth: 0,
            dataLabels: {
                enable: true
            }
        }
    },
    series: [],
    credits: {
        enabled: false,
    }

};


var chart;
function refreshChart(container, chartType, series, title) {
    if (chart != undefined && chart != null) {
        chart.destroy();
    }

    highChartsOptions.chart.renderTo = container;//'chartContainer';
    highChartsOptions.chart.type = chartType;//'pie';
    highChartsOptions.series = series;
    highChartsOptions.title.text = title;
    chart = new Highcharts.Chart(highChartsOptions);
}