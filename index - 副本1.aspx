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
</script>
    <style type="text/css">
        .style1
        {
            width: 686px;
            height: 82px;
            margin-left: 0px;                      
        }
    </style>
    <style type="text/css" media="all">@import"css/master.css";</style>
</head>
<body style="width: 765px; height: 679px; margin-left: 318px; margin-top: 46px; 
        background-image:url(images/body_bg.jpg);background-repeat:no-repeat;" >
    <form id="form1" runat="server">
    <div style="height: 562px; margin-left: 0px; margin-top: 0px;">
        <img class="style1" src="images/bd_top.jpg" /><br />
        <br />
        welcome 
        <br />
        <script type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
        <br />
        &nbsp;从
         <input id="d12" type="text" runat="Server"/>
        <img onclick="WdatePicker({el:'d12'})" src="My97DatePicker\skin/datePicker.gif" width="16" height="22" align="absmiddle">&nbsp;&nbsp;到
        <input id="d13" type="text" runat="Server"/>
        <img onclick="WdatePicker({el:'d13'})" src="My97DatePicker\skin/datePicker.gif" width="16" height="22" align="absmiddle">        
        <asp:Button ID="B_que1" runat="server" onclick="B_que1_Click" Text="查询" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="B_save" runat="server" onclick="B_save_Click" Text="导出" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" PageSize="20" 
            OnPageIndexChanging="GridView1_PageIndexChanging" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="userid" />
                <asp:BoundField DataField="writetime" HeaderText="time" />
                <asp:BoundField DataField="ma1" HeaderText="ma1" />
                <asp:BoundField DataField="ma2" HeaderText="ma2" />
                <asp:BoundField DataField="mv1" HeaderText="mv1" />
                <asp:BoundField DataField="mv2" HeaderText="mv2" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
