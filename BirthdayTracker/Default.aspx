<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BirthdayTracker.Default" %> 

<!DOCTYPE html>

<!--This is a html Comment - it will go along with the page to the client-->
<%-- This is a SERVER SIDE Comment - it wil be stripped out during rendering --%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"/>
    <style>
span {
    background-color:lightslategray;
    font-size: 30px;
    
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 class="display-4 bd-primary">Wonderful Birthday Tracker</h2>

            <span>ID:</span> <asp:Label ID="lblId" runat="server" Text="0" /> <br />
            <span>First Name:</span> <asp:TextBox ID="txtFirst" runat="server" /> <br />
            <span>Last Name:</span> <asp:TextBox ID="txtLast" runat="server" /> <br />
            <span>Likes</span> <asp:TextBox ID="txtLikes" runat="server" /> <br />
            <span>Dislikes</span> <asp:TextBox ID="txtDislikes" runat="server" /> <br />
            <span>Date of Birth</span> <asp:TextBox ID="txtDob" runat="server" /> <br />
            <!--Buttons-->
            <asp:Button ID="btnFirst" runat="server" Text="First" OnClick="btnFirst_Click" />
            <asp:Button ID="btnPrev"  runat="server" Text="Prev" OnClick="btnPrev_Click" />
            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
            <asp:Button ID="btnLast" runat="server" Text="Last" OnClick="btnLast_Click" />
        </div>
    </form>
</body>
</html>
