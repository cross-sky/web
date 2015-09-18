function updata() {
    $.ajax({
        type: "get",
        url: "client.aspx/jlvalue",
        contentType: "application/json; charset=utf-8",
      //  data: "{'jlvalue':'aaq'}",
        dataType: "json",
        success: function (data) {
            $("div#content #Lau1").text("lala:" + data.d);
        },
        error: function (err) {
            $("div#content #Lau1").text("err:" + err);
        }
    });

    // return false;
}

function updata1() {
    $.ajax({
        type: "get",
        url: "client.aspx/jlvalue1",
        contentType: "application/json; charset=utf-8",
        //  data: "{'jlvalue':'aaq'}",
        dataType: "json",
        success: function (data) {

            var testarray = eval(data.d);//数组数据提取
            $("div#content #La").text("lala:" + testarray[0]);
            $("div#content #Lat2").text(testarray[1]+"℃");
            $("div#content #Lat3").text(testarray[2] + "℃");
            $("div#content #Lat4").text(testarray[3] + "℃");  
        },
        error: function (err) {
            $("div#content #La").text("err:" + err);
        }
    });

    // return false;
}