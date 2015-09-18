<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="client.aspx.cs" Inherits="WebApplication1.client" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/client.css" rel="stylesheet" type="text/css" />
    <script src="script/jquery.min.js" type="text/javascript"></script>
    <script src="script/readcl.js" type="text/javascript"></script>
    <script type="text/javascript">
        setInterval(updata1, 5000);
       // setInterval(updata, 2000);
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="header">Header</div>
    <ul id="nav">
    <li><a href="index.aspx">alpha</a></li>
    <li><a href="#">beta</a></li>
    <li><a href="#">gamma</a></li>
    <li><a href="#">delta</a></li>
    <li><a href="#">epsilon</a></li>
    <li><a href="#">zeta</a></li>  
    </ul> 
    
    <div id="siderbar-a">
    <iframe name="weather_inc" src="http://tianqi.xixik.com/cframe/4" width="130" height="220" frameborder="0" marginwidth="0" marginheight="0" scrolling="no" ></iframe>
    </div> 
      
    <div id="content">
        <br />
        <p id="locate1" class="cpstyle">珠海住建局项目&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>        
        <br />
        <a href="index.aspx" class="castyle" >数据历史记录</a>
        <br />
        <asp:Label ID="Label1" runat="server" Text="集热器出水口温度:"  CssClass="label_bt1"></asp:Label>
        <asp:Label ID="Lat2" runat="server" Text="Label" CssClass="label_rt2"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="回水管温度:"  CssClass="label_bt2"></asp:Label>
        <asp:Label ID="Lat3" runat="server" Text="Label" CssClass="label_rt2" ></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="水箱温度:"  CssClass="label_bt3"></asp:Label>
        <asp:Label ID="Lat4" runat="server" Text="Label" CssClass="label_rt2" ></asp:Label>
        <br />
        <br />
        <asp:Label ID="La" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Lau1" runat="server" Text="今日流量:"></asp:Label>
        <asp:Label ID="Lat5" runat="server" Text="Label" CssClass="label_rt2"></asp:Label>
        <br />
        <asp:Label ID="Lau2" runat="server" Text="总流量:"></asp:Label>
        <asp:Label ID="Lat6" runat="server" Text="Label" CssClass="label_rt2"></asp:Label>
        <br />
        <br />
    </div>
    <div id="total">total </div>
    <div id="footer">Footer</div>
    </div>
    </form>
</body>
</html>
