<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="maamta.registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
         /* For Textbox CSS */
         .textBoxCSS {
             font-size: 1em;
             font-family: Calibri;
         }


         /* For First Column of Table (Questions)*/
         .TableColumn {
             color: black;
             font-family: Trebuchet MS;
             font-size: 1.2em;
             height: .6em;
         }

         /* For Last Column of Table Row Distance*/
         .Space {
             height: 3em;
         }



         /* For Mobile Browser*/
         @media only screen and (max-width: 40em) {
             td, th {
                 margin-top: 0.8em;
                 display: block;
                 text-align: center;
             }

             .Mobile {
                 width: 90%;
                 padding-left: 7%;
             }
         }
         /* For Web Browser*/

         @media only screen and (min-width: 40em) {

             .Mobile {
                 padding-left: 20%;
                 text-align: center;
                 width: 75%;
             }
         }
     </style>


    <script type="text/javascript">
        function clicknext() {
            if (document.getElementById("txtwomanNm").value == '' ) {
                alert("Enter Woman Name!")
                document.getElementById("txtwomanNm").focus();
                return false;
            }
            else if (document.getElementById("txthusbnNm").value == '') {
                alert("Enter Husband Name!")
                document.getElementById("txthusbnNm").focus();
                return false;
            }
            else if (document.getElementById("txtSite").value == '') {
                alert("Enter Site!")
                document.getElementById("txtSite").focus();
                return false;
            }
            else if (document.getElementById("txtPara").value == '') {
                alert("Enter Para!")
                document.getElementById("txtPara").focus();
                return false;
            }
            else if (document.getElementById("txtBlock").value == '') {
                alert("Enter Block!")
                document.getElementById("txtBlock").focus();
                return false;
            }
            else if (document.getElementById("txtStruct").value == '') {
                alert("Enter Structure!")
                document.getElementById("txtPara").focus();
                return false;
            }
            else if (document.getElementById("txtHH").value == '') {
                alert("Enter House Hold!")
                document.getElementById("txtHH").focus();
                return false;
            }
            else if (document.getElementById("txtwmNo").value == '') {
                alert("Enter Woman Number!")
                document.getElementById("txtwmNo").focus();
                return false;
            }            
        }
    </script>

 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="text-align: center">
        <br>
        <div id="footer-left" style="font-family: Garamond; background-color: #F2F1EF; margin: 0 0 20px 20px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
            <h1 style="text-align: center; font-size: 30px; background-color: #e6e6e6; padding-top: 8px; padding-bottom: 5px; color: #34495E;"><b>
                <%--   <asp:Label ID="lbeUname" runat="server" ForeColor="#1E8BC3" Text=""></asp:Label>--%>
                           WOMAN REGISTRATION</b></h1>
        </div>
        <br>
        <div style="text-align: center">


            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegis">
                <div class="Mobile" >
                    <table  style="width: 100%; text-align:left;">
                        
                        <tr>
                            <td class="TableColumn">Woman Name</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txtwomanNm" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" Font-Size="Medium" Height="2.3em" placeholder="woman name" MaxLength="18" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td class="TableColumn">Husband Name</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txthusbnNm" Style="text-transform: uppercase;" onkeypress="return onlyAlphabets()" type="text" placeholder="husband name" Height="2.3em" MaxLength="18" runat="server" ></asp:TextBox></td>
                        </tr>
                        <tr >
                            <td class="TableColumn">Site</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txtSite" Style="text-transform: uppercase;" onkeypress="return lettersOnly()" type="text" placeholder="eg. RG" Height="2.3em" MaxLength="2" runat="server" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="TableColumn">Para</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txtPara" Style="text-transform: uppercase;" onkeypress="return lettersOnly()" type="text" placeholder="eg. AJ" Height="2.3em" MaxLength="2" runat="server" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="TableColumn">Block</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txtBlock" type="tel" placeholder="eg. 12" onkeypress="return OnlyNumeric(event)" Height="2.3em" MaxLength="2" runat="server" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="TableColumn">Structure</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txtStruct" type="tel" placeholder="eg. 123" onkeypress="return OnlyNumeric(event)" Height="2.3em" MaxLength="3" runat="server" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="TableColumn">Family / House Hold</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txtHH" Style="text-transform: uppercase;" onkeypress="return lettersOnly()" type="text" placeholder="eg. A" Height="2.3em" MaxLength="1" runat="server" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="TableColumn">Woman Number</td>
                            <td class="Space">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ClientIDMode="Static"  ID="txtwmNo" type="tel" placeholder="eg. 1" onkeypress="return OnlyNumeric(event)" Height="2.3em" MaxLength="1" runat="server" ></asp:TextBox></td>
                        </tr>


                    </table>
                    <br /><br />
                                <asp:Button ID="btnRegis" runat="server" Text="REGISTER"  OnClick="btnRegis_Click" class="btn btn-theme btn-block" OnClientClick="return clicknext();"/>
                </div>
                
            </asp:Panel>
            <br><br><br>
        </div>
    </div>
</asp:Content>
