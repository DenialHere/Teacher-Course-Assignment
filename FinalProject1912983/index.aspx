<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FinalProject1912983.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: antiquewhite;
        }

        .center {
            text-align: center;
        }

        .btn {
            color: white;
            background-color: black;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            justify-content: right;
            width: 80px;
        }
    </style>
</head>

<body>
    <form id="formLogin2" runat="server">
        <div runat="server" id="formLogin" class="center">
            <h1>Welcome to SMTI Online Teacher-Course Assignment</h1>
            <h3>Teachers may login to see their assigned groups.</h3>
            <h3>Program Coordinators may edit course assignments.</h3>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" OnTextChanged="TextBoxPassword_TextChanged" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" CssClass="btn" />
            <br />
            <br />
            <br />
            <asp:Label ID="LabelErrorMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
        </div>



        <div runat="server" id="TeacherView" class="center" visible="false">
            <br />
            <asp:Label ID="Label4" runat="server" Text="All courses assigned to you:" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridViewAll" runat="server" HorizontalAlign="Center" CellPadding="10" CellSpacing="10">
            </asp:GridView>
            <br />
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click" CssClass="btn" />
        </div>


        <div runat="server" id="CoordView" class="center" visible="false">

            <asp:Label ID="LabelEmpty" runat="server" Text="Nothing found " Visible="false"></asp:Label>

            <asp:GridView ID="GridViewCoord" runat="server" HorizontalAlign="Center" CellPadding="10" CellSpacing="10">
            </asp:GridView>

            <br />

            <asp:Table runat="server" HorizontalAlign="Center">

                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="right">
                        <asp:Label ID="Label3" runat="server" Text="Employee Id: "></asp:Label>
                        <asp:DropDownList runat="server" ID="dropEmployeeId"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="right">
                        <asp:Label ID="Label5" runat="server" Text="Course Code: "></asp:Label>
                        <asp:DropDownList runat="server" ID="dropCourse"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="right">
                        <asp:Label ID="Label6" runat="server" Text="Group Number: "></asp:Label>
                        <asp:DropDownList runat="server" ID="dropGroup"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="right">
                        <asp:Label ID="Label7" runat="server" Text="Date: "></asp:Label>
                        <asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <br />
                        <asp:Button ID="ButtonView" runat="server" Text="View" OnClick="ButtonView_Click" CssClass="btn" />
                        <asp:Button ID="ButtonAssign" runat="server" Text="Assign" OnClick="ButtonAssign_Click" CssClass="btn" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>


            <asp:Button ID="ButtonLogoutCoord" runat="server" Text="Logout" OnClick="ButtonLogout_Click" CssClass="btn" />

        </div>


    </form>

</body>
</html>
