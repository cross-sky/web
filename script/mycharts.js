function OutputDatat(tbody, item) {
    tbody.append("<tr>" +
                    "<td>" +
                        item.name +
                    "</td>" +
                    "<td>" +
                        item.t0 +
                    "</td>" +
                    "</tr>");
}

function GetSeriesValue() {
    $.ajax({
        async: true,
        type: "GET",
        url: 'ajax/chartjson.ashx',
        dataType: "jsonp",
        crossDomain: true,
        //    cache: false,
        jsonp: "callback",
        success: function (data) {

            data = $.parseJSON(data);

            var tbody = $('#tbody1');

            $.each(data, function (index, item) {
                OutputDatat(tbody, item);
            });

            dataTmp = "";
            $.each(data, function (i, field) {
                dataTmp += "{name: '" + field.name + "',data: ["
                            + field.t0 + "," + field.t1 + ","+ field.t2 + ","+ field.t3 + ","
                            + field.t4 + ","+ field.t5 + ","+ field.t6 + ","+ field.t7 + ","
                            + field.t8 + ","+ field.t9 + ","+ field.t10 + ","+ field.t11 + ","
                            + field.t12 + ","+ field.t12 + ","+ field.t14 + ","+ field.t15 + ","
                            + field.t16 + ","+ field.t17 + ","+ field.t18 + ","+ field.t19 + ","
                            + field.t20 + ","+ field.t21 + ","+ field.t22 + ","+ field.t23 + "]}" + ",";
            });
            dataTmp = dataTmp.substring(0, dataTmp.length - 1);
            $("#test1").text(dataTmp);
            charts(dataTmp);
        },

        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR + "\r\n Error Message: " + textStatus + "\r\n Http Error: " + errorThrown);
        }
    });
}

function charts(dataTmp) {
    $("#container").highcharts({
        chart: {
            type: 'spline'
        },
        title: {
            text: "Today's Temprature"
        },
        subtitle: {
            text: 'Source: lacs'
        },
        xAxis: {
            title: {
                text: 'hours'
            },
            categories: ['0:00', '1:00', '2:00', '3:00', '4:00',
                         '5:00', '6:00', '7:00', '8:00', '9:00',
                         '10:00', '11:00', '12:00', '13:00', '14:00',
                         '15:00', '16:00', '17:00', '18:00', '19:00',
                         '20:00', '21:00', '22:00', '23:00']
        },
        yAxis: {
            title: {
                text: 'Temperature'
            },
            labels: {
                formatter: function () {
                    return this.value + '°';
                }
            },
            tickPositions: [0, 15, 30, 45, 60, 75]
            
        },
        tooltip: {
            valueSuffix: '℃',
            crosshairs: true,
            shared:true
        },
        plotOptions: {
            series: {
                    connectNulls: true //连接数据为null的前后点
            },
            spline: {
                marker: {
                    radius: 4,
                    lineColor: '#666666',
                    lineWidth: 1
                }
            }
        },
        series: eval("[" + dataTmp + "]")

    });
}

      