<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="labinvestigationEdit.aspx.cs" Inherits="maamta.labinvestigationEdit" %>

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

            .tdCSS {
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

            .tdCSS {
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


    <script type="text/javascript">

      








      












     



    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
    <div id="divBackButton" runat="server" style="margin-top: 5px; font-size: 18px; margin-bottom: 15px">
        <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back
        </button>
    </div>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">

        <div class="Mobile">
            <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Description</td>
                    <td class="Space tdCSS">
                        <asp:TextBox CssClass="form-control input-lg" ID="txtDescription" ClientIDMode="Static" type="text" Font-Size="Medium" Height="2.1em" placeholder="none" runat="server"></asp:TextBox></td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">Randomization ID</td>
                    <td class="Space tdCSS">
                        <asp:TextBox CssClass="form-control input-lg" ReadOnly="true" ID="txtRandomid" ClientIDMode="Static" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.1em" placeholder="random id" MaxLength="6" runat="server"></asp:TextBox></td>
                </tr>





                <tr class="trCSS" style="font-size: 17px; background-color: whitesmoke">
                    <td class="TableColumn tdCSS" colspan="2" style="text-align: center;">Sample Status DAY 42</td>
                </tr>


                <%--for Day 42--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(42 days) Infant Blood</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress2" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div2" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt42InfantBlood" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img42InfantBlood" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt42InfantBlood" PopupButtonID="img42InfantBlood" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk42InfantBlood" runat="server" OnCheckedChanged="InfantBlood42_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(42 days) Infant Stool</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div1" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt42InfantStool" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img42InfantStool" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt42InfantStool" PopupButtonID="img42InfantStool" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk42InfantStool" runat="server" OnCheckedChanged="InfantStool42_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(42 days) Breast Milk</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress3" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div3" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt42BreastMilk" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img42BreastMilk" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt42BreastMilk" PopupButtonID="img42BreastMilk" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk42BreastMilk" runat="server" OnCheckedChanged="BreastMilk42_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(42 days) LW Blood</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress4" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div4" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt42lwBlood" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img42lwBlood" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt42lwBlood" PopupButtonID="img42lwBlood" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk42lwBlood" runat="server" OnCheckedChanged="lwBlood42_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(42 days) LW Stool</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress5" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div5" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt42lwStool" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img42lwStool" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt42lwStool" PopupButtonID="img42lwStool" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk42lwStool" runat="server" OnCheckedChanged="lwStool42_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>








                <tr class="trCSS" style="font-size: 17px; background-color: whitesmoke">
                    <td class="TableColumn tdCSS" colspan="2" style="text-align: center;">Sample Status DAY 56</td>
                </tr>







                <%--for Day 56--%>
                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(56 days) Infant Blood</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress6" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div6" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt56InfantBlood" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img56InfantBlood" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt56InfantBlood" PopupButtonID="img56InfantBlood" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk56InfantBlood" runat="server" OnCheckedChanged="InfantBlood56_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(56 days) Infant Stool</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress7" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div7" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt56InfantStool" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img56InfantStool" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt56InfantStool" PopupButtonID="img56InfantStool" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk56InfantStool" runat="server" OnCheckedChanged="InfantStool56_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(56 days) Breast Milk</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress8" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div8" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt56BreastMilk" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img56BreastMilk" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt56BreastMilk" PopupButtonID="img56BreastMilk" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk56BreastMilk" runat="server" OnCheckedChanged="BreastMilk56_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(56 days) LW Blood</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress9" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div9" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt56lwBlood" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img56lwBlood" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt56lwBlood" PopupButtonID="img56lwBlood" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk56lwBlood" runat="server" OnCheckedChanged="lwBlood56_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>

                <tr class="trCSS">
                    <td class="TableColumn tdCSS">(56 days) LW Stool</td>

                    <td class="Space tdCSS">
                        <%--Start    Date checks--%>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:UpdateProgress ID="updateProgress10" runat="server">
                                    <ProgressTemplate>
                                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <div class="Mobile" id="Div10" runat="server">
                                    <table style="width: 100%; margin-bottom: 15px">
                                        <tr>
                                            <td class="tddd">
                                                <asp:TextBox ID="txt56lwStool" Enabled="false" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" placeholder="dd-MM-yyyy" Height="32px" runat="server" Width="8.3em"></asp:TextBox>
                                                <asp:ImageButton ID="img56lwStool" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt56lwStool" PopupButtonID="img56lwStool" Format="dd-MM-yyyy" />
                                                <asp:CheckBox ID="chk56lwStool" runat="server" OnCheckedChanged="lwStool56_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--End   Date checks--%>
                    </td>
                </tr>


            </table>
            <br />
            <div class="buttonWeb">

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" OnClientClick="return clicknext();" />
            </div>

            <br />
            <br />
        </div>
    </asp:Panel>



</asp:Content>
