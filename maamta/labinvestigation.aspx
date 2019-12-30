<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="labinvestigation.aspx.cs" Inherits="maamta.labinvestigation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }

        .StylePager {
            border-radius: 5px;
            text-align: left;
        }

            .StylePager a:hover {
                background-color: #33d9b2;
                margin-right: 3px;
                padding: 3px;
                border-radius: 3px;
            }

            .StylePager a {
                padding: 3px;
                margin-right: 3px;
            }

            .StylePager span {
                background: #FF4081;
                padding: 4px;
                border-radius: 3px;
                margin-right: 3px;
            }


        /* For Mobile Browser*/
        @media only screen and (max-width: 40em) {
            tddd, thhh {
                margin-top: 0.8em;
                display: block;
                text-align: center;
            }

            .Mobile {
                width: 90%;
                padding-left: 7%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>





    <div style="padding-left: 2%; margin-top: 15px;">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            LAB Investigation:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
             <button type="button" id="Button3" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnReportPending_Click">
                Specimen Pending &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
            <button type="button" id="Button2" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnReport_Click">
                Report &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>

        <%--Search Button--%>
        <div id="div1" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: 0px;">
            <asp:DropDownList ID="DropDownListDSSID" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select SITE</asp:ListItem>
                <asp:ListItem Value="AG">AG  (Ali Akbar Shah)</asp:ListItem>
                <asp:ListItem Value="BH">BH  (Behance Colony)</asp:ListItem>
                <asp:ListItem Value="RG">RG  (Rehri Goth)</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 7px;">
            <asp:DropDownList ID="DropDownListBabyAge" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select CHILD AGE</asp:ListItem>
                <asp:ListItem Value="40">AGE (40 days or Less)</asp:ListItem>
                <asp:ListItem Value="56">AGE (56 days or Less)</asp:ListItem>
            </asp:DropDownList>
        </div>





        <%--Start    Date checks--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="updateProgress" runat="server">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                            <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #33D9B2; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="Mobile">
                    <table style="width: 100%; text-align: center; margin-left: 1%; margin-bottom: 15px">
                        <tr>
                            <td class="tddd">
                                <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
                                &nbsp To &nbsp
                                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />

                            </td>
                        </tr>
                    </table>
                </div>


                <%--End   Date checks--%>


                <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link_id" OnClick="Link_EditForm" Text='Edit' runat="server" ToolTip="enter Lab Information" CommandArgument='<%#Eval("lw_crf_3a_18")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                            <asp:BoundField DataField="study_id" HeaderText="Study ID" />
                            <asp:BoundField DataField="lw_crf_3a_18" HeaderText="Random ID" />
                            <asp:BoundField DataField="current_age_baby" HeaderText="Current Age" />
                            <asp:BoundField DataField="DOB" HeaderText="Date_of_Birth" />
                            <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                            <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                            <asp:BoundField DataField="Age_Day_40" HeaderText="40_Days_Age" />
                            <asp:BoundField DataField="Age_Day_56" HeaderText="56_Days_Age" />
                            <asp:BoundField DataField="treatment" HeaderText="ARM" />
                            <asp:BoundField DataField="Yes" HeaderText="Blood of Infant" />
                            <asp:BoundField DataField="description" HeaderText="Description" />
                            <asp:BoundField DataField="" HeaderText="" />
                            <asp:BoundField DataField="42_infant_blood" HeaderText="42_infant_blood" />
                            <asp:BoundField DataField="42_infant_blood_Age" HeaderText="42_infant_blood_Age" />
                            <asp:BoundField DataField="42_infant_stool" HeaderText="42_infant_stool" />
                            <asp:BoundField DataField="42_infant_stool_Age" HeaderText="42_infant_stool_Age" />
                            <asp:BoundField DataField="42_breast_milk" HeaderText="42_breast_milk" />
                            <asp:BoundField DataField="42_breast_milk_Age" HeaderText="42_breast_milk_Age" />
                            <asp:BoundField DataField="42_lw_blood" HeaderText="42_lw_blood" />
                            <asp:BoundField DataField="42_lw_blood_Age" HeaderText="42_lw_blood_Age" />
                            <asp:BoundField DataField="42_lw_stool" HeaderText="42_lw_stool" />
                            <asp:BoundField DataField="42_lw_stool_Age" HeaderText="42_lw_stool_Age" />
                            <asp:BoundField DataField="56_infant_blood" HeaderText="56_infant_blood" />
                            <asp:BoundField DataField="56_infant_blood_Age" HeaderText="56_infant_blood_Age" />
                            <asp:BoundField DataField="56_infant_stool" HeaderText="56_infant_stool" />
                            <asp:BoundField DataField="56_infant_stool_Age" HeaderText="56_infant_stool_Age" />
                            <asp:BoundField DataField="56_breast_milk" HeaderText="56_breast_milk" />
                            <asp:BoundField DataField="56_breast_milk_Age" HeaderText="56_breast_milk_Age" />
                            <asp:BoundField DataField="56_lw_blood" HeaderText="56_lw_blood" />
                            <asp:BoundField DataField="56_lw_blood_Age" HeaderText="56_lw_blood_Age" />
                            <asp:BoundField DataField="56_lw_stool" HeaderText="56_lw_stool" />
                            <asp:BoundField DataField="56_lw_stool_Age" HeaderText="56_lw_stool_Age" />
                        </Columns>

                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
                        <PagerStyle BackColor="#576574" ForeColor="White" CssClass="StylePager" />
                        <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />

                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>



                    <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                            <asp:BoundField DataField="study_id" HeaderText="Study ID" />
                            <asp:BoundField DataField="lw_crf_3a_18" HeaderText="Random ID" />
                            <asp:BoundField DataField="current_age_baby" HeaderText="Current Age" />
                            <asp:BoundField DataField="DOB" HeaderText="Date_of_Birth" />
                            <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                            <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                            <asp:BoundField DataField="Age_Day_40" HeaderText="40_Days_Age" />
                            <asp:BoundField DataField="Age_Day_56" HeaderText="56_Days_Age" />
                            <asp:BoundField DataField="treatment" HeaderText="ARM" />
                            <asp:BoundField DataField="Yes" HeaderText="Blood of Infant" />
                            <asp:BoundField DataField="description" HeaderText="Description" />
                            <asp:BoundField DataField="42_infant_blood" HeaderText="42_infant_blood" />
                            <asp:BoundField DataField="42_infant_blood_Age" HeaderText="42_infant_blood_Age" />
                            <asp:BoundField DataField="42_infant_stool" HeaderText="42_infant_stool" />
                            <asp:BoundField DataField="42_infant_stool_Age" HeaderText="42_infant_stool_Age" />
                            <asp:BoundField DataField="42_breast_milk" HeaderText="42_breast_milk" />
                            <asp:BoundField DataField="42_breast_milk_Age" HeaderText="42_breast_milk_Age" />
                            <asp:BoundField DataField="42_lw_blood" HeaderText="42_lw_blood" />
                            <asp:BoundField DataField="42_lw_blood_Age" HeaderText="42_lw_blood_Age" />
                            <asp:BoundField DataField="42_lw_stool" HeaderText="42_lw_stool" />
                            <asp:BoundField DataField="42_lw_stool_Age" HeaderText="42_lw_stool_Age" />
                            <asp:BoundField DataField="56_infant_blood" HeaderText="56_infant_blood" />
                            <asp:BoundField DataField="56_infant_blood_Age" HeaderText="56_infant_blood_Age" />
                            <asp:BoundField DataField="56_infant_stool" HeaderText="56_infant_stool" />
                            <asp:BoundField DataField="56_infant_stool_Age" HeaderText="56_infant_stool_Age" />
                            <asp:BoundField DataField="56_breast_milk" HeaderText="56_breast_milk" />
                            <asp:BoundField DataField="56_breast_milk_Age" HeaderText="56_breast_milk_Age" />
                            <asp:BoundField DataField="56_lw_blood" HeaderText="56_lw_blood" />
                            <asp:BoundField DataField="56_lw_blood_Age" HeaderText="56_lw_blood_Age" />
                            <asp:BoundField DataField="56_lw_stool" HeaderText="56_lw_stool" />
                            <asp:BoundField DataField="56_lw_stool_Age" HeaderText="56_lw_stool_Age" />
                        </Columns>
                    </asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>



        <asp:GridView ID="GridView3" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
        </asp:GridView>


        <asp:GridView ID="GridView4" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
        </asp:GridView>



        <asp:GridView ID="GridView5" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
        </asp:GridView>
    </div>
</asp:Content>
