<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="changepass.aspx.cs" Inherits="maamta.changepass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media only screen and (max-width: 40em) {
            thead th:not(:first-child) {
                display: none;
            }

            td, th {
                margin-top:0.8em;
                display: block;
                text-align: center;
            }
        }

        .btnSrch {
            background-color: #2574A9;
            border: 1px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-size: 1em;
            padding: 7px 22px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #2f6627;
            border-radius: 3px;
            font-weight: bold;
        }

            .btnSrch:hover {
                background-color: #5C97BF;
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
    <br>



    <div style="text-align: center">
        <br>
        <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
                <h1 style="text-align: center; margin-top: 30px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial">
                    <b> Resetting Your Login Password</b></h1>
            </div>



    



        <br>
        <div style="text-align: center">


            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnInsert">
                <div style="margin-bottom: -50px; padding-left:8%">
                    <table border="0" style="width: 85%; font-size: 16px; color: #4f5963; text-align:left;">
                        <tr style="height: 50px;">
                            <td style=" font-size: 1.1em; font-family: Trebuchet MS">Account Type</td>
                            <td >
                                <asp:Label ID="lbeAccType" runat="server" Text="" Font-Names="Calibri" Font-Size="23px" Font-Bold="true" ForeColor="#1E8BC3" Style="text-transform: capitalize; "></asp:Label>
                        </tr>



                        <tr style="height: 50px;">
                            <td style=" font-size: 1.1em; font-family: Trebuchet MS">Enter Old Password</td>
                            <td>
                                <asp:TextBox CssClass="form-control input-lg" ID="txtOldPassword" type="password" Font-Size="Medium" Height="2.1em" placeholder="old password" MaxLength="18" runat="server"></asp:TextBox></td>
                        </tr>




                        <tr style="height: 70px;">
                            <td style=" font-size: 1.1em; font-family: Trebuchet MS">Enter New Password</td>
                            <td ">
                                <asp:TextBox CssClass="form-control input-lg" ID="txtNewPassword" type="password" placeholder="new password" Height="2.1em" MaxLength="18" runat="server" ></asp:TextBox></td>
                        </tr>
                        <tr style="height: 50px;">
                            <td style="font-size: 1.1em; font-family: Trebuchet MS">Re-type Password</td>
                            <td>
                                <asp:TextBox CssClass="form-control input-lg" ID="txtConfirmPassword" type="password" placeholder="confirm password" Height="2.1em" MaxLength="18" runat="server" ></asp:TextBox></td>
                        </tr>


                    </table>
                    <br />
                    <table border="0" style="width: 90%; font-size: 16px; text-align: center; color: #4f5963;height:120px">
                        <tr>
                            <td>
                                <asp:Button ID="btnInsert" runat="server" Text="Confirm" OnClick="btnInsert_Click" class="btn btn-theme btn-lg" Style="margin-right: 3%" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-theme btn-lg" Style="margin-left: 2%" />
                            </td>
                        </tr>

                    </table>
                </div>


            </asp:Panel>

        </div>
    </div>
    <br>
    <br>
    <hr>
    <br>
    <br>
    <br>
    <br>
</asp:Content>
