<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="DotNet_Project3.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            /* Add, Update,Delete,Display&nbsp; Employee By Stored Procedures&nbsp; */<br />
            <br />
            Employee Details:<br />
            <br />
            Eid:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Name:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Address:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Salary:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="193px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="206px"></asp:ListBox>
            <br />
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Save" Width="81px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" style="margin-left: 27px" Text="Update" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" style="margin-left: 27px" Text="Delete" Width="88px" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" style="margin-left: 25px" Text="Display" Width="95px" OnClick="Button4_Click" />
        </p>
    </form>
</body>
</html>
