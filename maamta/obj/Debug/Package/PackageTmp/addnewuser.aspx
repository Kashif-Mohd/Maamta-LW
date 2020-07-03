<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="addnewuser.aspx.cs" Inherits="maamta.addnewuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function lettersOnly() {
            var charCode = event.keyCode;

            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 8)

                return true;
            else
                return false;
        }
    </script>

     <style>
        .btnSrch {
            background-color: #4e94ba;
            border: 1px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-family: arial;
            font-size: 13px;
            padding: 4px 28px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #2f6627;
            border-radius: 3px;
            font-weight: bold;
        }

            .btnSrch:hover {
                background-color: #2574A9;
            }

            .btnSrch:active {
                position: relative;
                top: 1px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

    <br><br>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>

                <div id="content">
                    <!--  start footer-left -->
                    
                    <div id="footer-left" style=" padding-right: 1%; background-color: #F2F1EF; margin: 0 0 20px 20px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
                        <h1 style="text-align: center; font-size: 25px; word-spacing: 5px;background-color:#e6e6e6; padding-top:8px; padding-bottom:5px; color: #34495E;"><b>
                         <%--   <asp:Label ID="lbeUname" runat="server" ForeColor="#1E8BC3" Text=""></asp:Label>--%>
                            Create New User</b></h1>
                    </div>

                    <br>
                    <br>

                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSignup">
                        <div style="margin-left: 33%; margin-bottom: -50px">
                            <table border="0" style="width: 50%; font-size: 16px; text-align: center; color: #4f5963">
                                <tr style="height: 50px;">
                                    <td style="text-align: right; padding-right: 35px; font-weight: 700">User Name:</td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtUserName" placeholder="username" Width="170" Height="24" runat="server" Font-Size="15px" MaxLength="12" onkeypress="return lettersOnly(event)"></asp:TextBox></td>
                                </tr>

                                <tr style="height: 50px;">
                                    <td style="text-align: right; padding-right: 35px; font-weight: 700">Password:</td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtPassword" type="password" placeholder="password" Width="170" Height="24" runat="server" Font-Size="15px" MaxLength="12"></asp:TextBox></td>
                                </tr>
                                <tr style="height: 50px;">
                                    <td style="text-align: right; padding-right: 35px; font-weight: 700">Re-Type:</td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtConfirmPassword" type="password" placeholder="password" Width="170" Height="24" runat="server" Font-Size="15px" MaxLength="12"></asp:TextBox></td>
                                </tr>

                                <tr style="height: 50px;">
                                    <td style="text-align: right; padding-right: 35px; font-weight: 700">User Role:</td>
                                    <td style="text-align: left;">
                                        <select id="dropdownRole" style="width: 175px; font-size: 13.5px; height: 24px; color:black" runat="server">
                                            <option value="0">Select Role</option>
                                            <option value="admin">Admin</option>
                                            <option value="local">Local</option>
                                        </select>
                                    </td>
                                </tr>
                            </table>

                            <table border="0" style="width: 50%; font-size: 16px; text-align: center; color: #4f5963; margin-left: 9%;">
                                <tr style="height: 110px;">
                                    <td>
                                        <asp:Button ID="btnSignup" runat="server" Text="Sign Up" OnClick="btnSignup_Click" CssClass="btnSrch" />
                                    </td>
                                    <td style="padding-right: 30%">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btnSrch" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
                  <br><br>
                  <hr>
  
            </ContentTemplate>
        </asp:UpdatePanel>
    <br><br><br>
</asp:Content>
