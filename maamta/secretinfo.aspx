<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="secretinfo.aspx.cs" Inherits="maamta.infoNineMonths" %>

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



        .btnChng {
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            font-family: arial;
            font-size: 16px;
            padding: 4px 28px;
            text-decoration: none;
            font-weight: bold;
        }

            .btnChng:active {
                position: relative;
                top: 1px;
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
        /* For Web Browser*/

        @media only screen and (min-width: 40em) {

            .Mobile {
                padding-left: 20%;
                text-align: center;
                width: 75%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>




    <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: 0px">
        <tr>
            <td>
                <asp:Button ID="btnAcceptReferral" OnClick="btnAcceptReferral_Click" CssClass="btnChng" runat="server" Text="Referral Accepted (CRF11 Required)" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
            </td>
            <td>
                <asp:Button ID="btnMissedFups" OnClick="btnMissedFups_Click" CssClass="btnChng" runat="server" Text="Followups Missed (CRF-4a,5b,6)" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
            </td>
            <td>
                <asp:Button ID="btnChildAge" OnClick="btnChildAge_Click" CssClass="btnChng" runat="server" Text="Child Age Greater than 9 Month" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
            </td>
        </tr>
    </table>





    <div style="padding-left: 2%; margin-top: 15px;" id="divChildAge" runat="server">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Child Age Greater than (9 or 12) Month:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>



        <%--Search Button--%>

        <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">
            <asp:DropDownList ID="ddChildAge" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select Followups Status</asp:ListItem>
                <asp:ListItem Value="Age_9M">Child Age is 9 Months</asp:ListItem>
                <asp:ListItem Value="Age_12M">Child Age is 12 Months</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div style="margin-bottom: 10px; margin-top: 3px; text-align: center" class="Mobile">
            <asp:Button ID="btnSearchChildAge" runat="server" class="btn btn-theme" OnClick="btnSearchChildAge_Click" Text="Search" />
        </div>


        <div style="width: 100%; height: 455px; overflow: scroll; margin-top: 10px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_id" HeaderText="Study-ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
                    <asp:BoundField DataField="date_enrollment" HeaderText="Date of Enrollment" />
                    <asp:BoundField DataField="9_Months" HeaderText="9 Months" />
                    <asp:BoundField DataField="12_Months" HeaderText="12 Months" />
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
        </div>


        <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="study_id" HeaderText="Study-ID" />
                <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                <asp:BoundField DataField="dob" HeaderText="Date of Birth" />
                <asp:BoundField DataField="date_enrollment" HeaderText="Date of Enrollment" />
                <asp:BoundField DataField="9_Months" HeaderText="9 Months" />
                <asp:BoundField DataField="12_Months" HeaderText="12 Months" />
            </Columns>
        </asp:GridView>
    </div>












    <div style="padding-left: 2%; margin-top: 15px;" id="divMissedFups" runat="server">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Followups Missed (Newborn, FFQ, Anthro)
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="div2" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="btnExportMissedFups" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExportMissedFups_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>

        <%--Search Button--%>
        <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">
            <asp:DropDownList ID="ddMissedFups" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select Followups Status</asp:ListItem>
                <asp:ListItem Value="NB_Missed_Ex_Sunday">NB - F/Ups Missed (Sunday Excluded 0-Day)</asp:ListItem>
                <asp:ListItem Value="NB_Missed_Inc_Sunday">NB - F/Ups Missed (Sunday Included 0-Day)</asp:ListItem>
                <asp:ListItem Value="FFQ_Missed">FFQ - F/Ups Missed</asp:ListItem>
                <asp:ListItem Value="Anthro_Missed">Anthro - F/Ups Missed</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div style="margin-bottom: 10px; margin-top: 3px; text-align: center" class="Mobile">
            <asp:Button ID="btnSearchMissedFups" runat="server" class="btn btn-theme" OnClick="btnSearchMissedFups_Click" Text="Search" />
        </div>



        <div style="width: 100%; height: 455px; overflow: scroll; margin-top: 10px">
            <asp:GridView ID="GridView1MissedFups" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1MissedFups_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study-ID" />
                    <asp:BoundField DataField="followups" HeaderText="Followups" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="date" HeaderText="Start Date" />
                    <asp:BoundField DataField="end_date" HeaderText="End Date" />
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="day_diff" HeaderText="Day Diff" />
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
        </div>


        <asp:GridView ID="GridView2MissedFups" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="study_code" HeaderText="Study-ID" />
                <asp:BoundField DataField="followups" HeaderText="Followups" />
                <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                <asp:BoundField DataField="date" HeaderText="Start Date" />
                <asp:BoundField DataField="end_date" HeaderText="End Date" />
                <asp:BoundField DataField="day_diff" HeaderText="Day Diff" />
            </Columns>
        </asp:GridView>
    </div>













    <div style="padding-left: 2%; margin-top: 15px;" id="divAcceptReferral" runat="server" visible="false">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Referral Accepted (CRF-11 is Required):
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">



        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: -10px;">


            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssidAcceptReferral" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="Complete DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearchAcceptReferral" runat="server" style="height: 20px" onserverclick="btnSearchAcceptReferral_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

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
                                <asp:TextBox ID="txtAcceptReferralDate" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnAcceptReferralDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAcceptReferralDate" PopupButtonID="btnAcceptReferralDate" Format="dd-MM-yyyy" />
                                &nbsp To &nbsp
                                <asp:TextBox ID="txtAcceptReferralDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnAcceptReferralDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAcceptReferralDate1" PopupButtonID="btnAcceptReferralDate1" Format="dd-MM-yyyy" />
                                &nbsp &nbsp 
                          <asp:CheckBox ID="chkAcceptReferral" runat="server" Text="Disable" OnCheckedChanged="chkAcceptReferral_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--End   Date checks--%>


        <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridAcceptReferral" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridAcceptReferral_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Num" />
                    <asp:BoundField DataField="DOV" HeaderText="Date of Visit" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
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
        </div>


    </div>


</asp:Content>
