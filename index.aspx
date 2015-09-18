<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>web-gprs</title>
<script language="javascript" type="text/javascript">
// <![CDATA[

function Time_onclick() {

}

// ]]>
/*
 *	
 $(document).ready(function () {
    $("div#siderbar-a button").click(function () {
        $("div#siderbar-a p.testp").hide();
    });

    function btest() {
        $("#siderbar-a p.testp").hide();
    }
});
 */


</script>

        <script type="text/javascript">
        </script>

    <style type="text/css" media="all">@import"css/master.css";</style>
    <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script> 

</head>
<body >
    <form id="form1" runat="server">
    <div id="header"></div>
    <ul id="nav">
    <li><a href="#">alpha</a></li>
    <li><a href="#">beta</a></li>
    <li><a href="#">gamma</a></li>
    <li><a href="#">delta</a></li>
    <li><a href="#">epsilon</a></li>
    <li><a href="#">zeta</a></li>  
    </ul>
    <br />
    <div id="siderbar-a">
        <br />
        <br />
        <asp:Label ID="Label1t1" runat="server" Text="fg"></asp:Label>
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Buttona" runat="server"  Text="Node A" CssClass="btn_side"  />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Buttonb"  OnClientClick="btest();" runat="server" Text="Node B"  CssClass="btn_side"  />
    </div>

    <div id="content">
        <a href="client.aspx"  class="history" >返回实时数据</a>        
        <br />
        从<input id="d12" type="text" runat="Server"/>
        <img onclick="WdatePicker({el:'d12'})" src="My97DatePicker\skin/datePicker.gif" width="16" height="22" align="absmiddle" alt="1"/> 
        &nbsp;到<input id="d13" type="text" runat="Server"/>
        <img onclick="WdatePicker({el:'d13'})" src="My97DatePicker\skin/datePicker.gif" width="16" height="22" align="absmiddle" alt="2"/> &nbsp;&nbsp;&nbsp;        
        <asp:Button ID="B_que1" runat="server" onclick="B_que1_Click"  CssClass="btn" Text="查询" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="B_save" runat="server" onclick="B_save_Click" Text="导出" CssClass="btn" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" PageSize="2" CssClass="datable" border="1" CellPadding="2" CellSpacing="1" 
            OnPageIndexChanging="GridView1_PageIndexChanging" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <RowStyle CssClass="lupbai" />
            <HeaderStyle CssClass="lup" />
            <AlternatingRowStyle CssClass="trnei" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="序号"  >
                <HeaderStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="writetime" HeaderText="时间" >
                <HeaderStyle Width="160px" />
                </asp:BoundField>
                <asp:BoundField DataField="ma1" HeaderText="电流1" >
                <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="ma2" HeaderText="电流2" >
                <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="mv1" HeaderText="电压1" >
                <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="mv2" HeaderText="电压2" >
                <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="t1" HeaderText="集热器出水温度" >
                <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="t2" HeaderText="回水管温度" >
                <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="t3" HeaderText="水箱温度" >
                <HeaderStyle Width="70px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
    </div>

    <div id="footer">
    <p>关于</p>
    <p>Copyright</p>
    </div>

    </form>
</body>
</html>
