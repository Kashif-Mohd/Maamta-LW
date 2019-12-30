<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="editdssid.aspx.cs" Inherits="maamta.editdssid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*change Color of Radio Button*/

        .textDropDownCSS {
            font-size: 1.0em;
            font-family: Calibri;
            Height: 2.3em;
            color: #16a085;
        }

        .RomanEnglish {
            color: #BE90D4;
            margin-top: 0.5em;
        }



        /* For Label CSS */
        .labelCSS {
            font-family: Calibri;
            font-size: 1.1em;
            color: #446CB3;
            /*#3A539B*/
        }

        /* For Textbox CSS */
        .textBoxCSS {
            font-size: 1em;
            font-family: Calibri;
            Height: 2.4em;
            color: #446CB3;
        }


        /* For First Column of Table (Questions)*/
        .TableColumn {
            color: black;
            font-family: Trebuchet MS;
            font-size: 1.2em;
            height: auto;
        }

        /* For Last Column of Table Row Distance*/
        .Space {
            margin-bottom: 1.5%;
        }

        /* Radio Button Space */
        .RadioSpace label {
            font-family: Calibri;
            margin-left: 10px;
            color: #486591;
            font-size: 1em;
        }



        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {

            thead th {
                display: none;
            }

            td[data-th]:before {
                content: attr(data-th);
            }



            /* own design*/
            table {
                border-collapse: collapse;
                width: 100%;
            }

            .trCSS {
                border-bottom: 1px solid #ddd;
            }

            .tdCSS, th {
                margin-top: 1em;
                display: block;
                font-family: Trebuchet MS;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }

            .ColumTOP {
                padding-top: 2.2em;
            }

            .ColumBOTTOM {
                padding-bottom: 1em;
            }
        }







        /* For Web Browser*/

        @media only screen and (min-width: 40em) {
            .buttonWeb {
                width: 22%;
                margin-left: 38%;
            }

            table {
                border-collapse: collapse;
                width: 100%;
            }

            th, .tdCSS {
                width: 50%;
                padding: 7px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .Mobile {
                padding-left: 5%;
                text-align: center;
                width: 95%;
            }

            .trCSS {
                height: 50px;
            }
        }
    </style>


    <script>
        function click() {

            if (document.getElementById("txtWomanNm").value == '') {
                alert("Enter Woman Name!")
                document.getElementById("txtWomanNm").focus();
                return false;
            }
            else if (document.getElementById("txtHusbandNm").value == '') {
                alert("Enter Husband Name!")
                document.getElementById("txtHusbandNm").focus();
                return false;
            }
            else if (document.getElementById("dd_Site").value == '0') {
                alert("Select Site!")
                document.getElementById("dd_Site").focus();
                return false;
            }
            else if (document.getElementById("dd_ParaList").value == '0') {
                alert("Select Para!")
                document.getElementById("dd_ParaList").focus();
                return false;
            }

            else if (document.getElementById("txtBlock").value == '' || document.getElementById("txtBlock").value.length < 2) {
                alert("Enter Block 2 digit long!")
                document.getElementById("txtBlock").focus();
                return false;
            }

            else if (document.getElementById("txtStruct").value == '' || document.getElementById("txtStruct").value.length < 3) {
                alert("Enter Structure!")
                document.getElementById("txtStruct").focus();
                return false;
            }
            else if (document.getElementById("txtHH").value == '') {
                alert("Enter House Hold!")
                document.getElementById("txtHH").focus();
                return false;
            }
            else if (document.getElementById("txtWomanNumber").value == '' || (document.getElementById("txtWomanNumber").value < 1 || document.getElementById("txtWomanNumber").value > 9)) {
                alert("Enter Woman Number between 1 to 9")
                document.getElementById("txtWomanNumber").focus();
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 5px; font-size: 18px">
        <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back
        </button>
    </div>

    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>

    <div style="text-align: center">



        <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
            <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial">
                <b>EDIT INFORMATION</b></h1>
        </div>

        <br>
        <br>
        <div style="text-align: center">



            <asp:Panel ID="Panel1" runat="server">
                <div class="Mobile">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:UpdateProgress ID="updateProgress" runat="server">
                                <ProgressTemplate>
                                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                        <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>

                            <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">

                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">ASSESSMENT ID</td>
                                    <td class="Space tdCSS">
                                        <asp:Label ID="lbeAssess" runat="server" Text="" CssClass="labelCSS" ForeColor="#16a085" Font-Bold="true"></asp:Label>
                                </tr>


                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Woman Name</td>
                                    <td class="Space tdCSS">
                                        <asp:TextBox CssClass="form-control input-lg" ID="txtWomanNm" ClientIDMode="Static"  type="text" Font-Size="Medium" Height="2.1em" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" placeholder="woman name" MaxLength="25" runat="server"></asp:TextBox></td>
                                </tr>

                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Husband Name</td>
                                    <td class="Space tdCSS">
                                        <asp:TextBox CssClass="form-control input-lg" ID="txtHusbandNm" ClientIDMode="Static"  type="text" Font-Size="Medium" Height="2.1em" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" placeholder="husband name" MaxLength="25" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Site</td>
                                    <td class="Space tdCSS">
                                        <asp:DropDownList ID="dd_Site" CssClass="form-control textDropDownCSS"  data-style="btn-primary" runat="server" ClientIDMode="Static" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="OnSelectedIndexChangedMethod">
                                            <asp:ListItem Value="0">Select SITE</asp:ListItem>
                                            <asp:ListItem Value="AG">AG</asp:ListItem>
                                            <asp:ListItem Value="BH">BH</asp:ListItem>
                                            <asp:ListItem Value="RG">RG</asp:ListItem>
                                        </asp:DropDownList>
                                </tr>
                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Para</td>
                                    <td class="Space tdCSS">
                                        <asp:DropDownList ID="dd_ParaList" CssClass="form-control textBoxCSS"  runat="server" ClientIDMode="Static" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                </tr>
                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Block</td>
                                    <td class="Space tdCSS">
                                        <asp:TextBox CssClass="form-control input-lg" ID="txtBlock" type="tel" ClientIDMode="Static"  Font-Size="Medium" onkeypress="return OnlyNumeric(event)" MaxLength="2" Height="2.1em" placeholder="block" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Structure</td>
                                    <td class="Space tdCSS">
                                        <asp:TextBox CssClass="form-control input-lg" ID="txtStruct" type="tel" ClientIDMode="Static"  Font-Size="Medium" onkeypress="return OnlyNumeric(event)" MaxLength="3" Height="2.1em" placeholder="structure" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Family / House Hold</td>
                                    <td class="Space tdCSS">

                                        <asp:TextBox CssClass="form-control input-lg" ID="txtHH" type="text"  ClientIDMode="Static" Font-Size="Medium" Height="2.1em" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" MaxLength="1" placeholder="house hold" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr class="trCSS">
                                    <td class="TableColumn tdCSS">Woman Number</td>
                                    <td class="Space tdCSS">
                                        <asp:TextBox CssClass="form-control input-lg" ID="txtWomanNumber" type="tel" ClientIDMode="Static"  Font-Size="Medium" onkeypress="return OnlyNumeric(event)" Height="2.1em" MaxLength="1" placeholder="woman no." runat="server"></asp:TextBox></td>
                                </tr>

                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <br>
                    <br>
                    <div class="buttonWeb">
                        <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" class="btn btn-theme btn-lg btn-block" OnClientClick="return click();" />
                    </div>
                </div>
            </asp:Panel>

            <br>
        </div>
    </div>

</asp:Content>
