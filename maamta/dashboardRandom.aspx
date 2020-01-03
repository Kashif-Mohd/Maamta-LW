<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashboardRandom.aspx.cs" Inherits="maamta.dashboardRandom" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style>
        .highlighted {
            color: Red !important;
            background-color: blue !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>




    <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Randomization Team Performance</b></h1>
    </div>
    <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">
        <asp:Chart ID="Chart1" runat="server" Width="1000" Height="400px">
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Interval="1" TextOrientation="Rotated90">
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1" Title="Sites" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                </asp:Title>
                <asp:Title Docking="Bottom" Name="Bottom Title" Text="Year" Font="Arial Rounded MT Bold, 12pt, ">
                </asp:Title>
                <asp:Title Name="Top" Text="Enrollment (Sitewise)" Font="Arial Rounded MT Bold, 18pt, ">
                </asp:Title>
            </Titles>
        </asp:Chart>


        <hr style="border-top: 1px solid #ccc; background: transparent;">


        <asp:Label ID="lbeTotalEnrollment" runat="server" Text="" Font-Bold="true" Font-Size="Large" ForeColor="#00b894" Font-Underline="true"></asp:Label><br />

        <asp:Chart ID="Chart2" runat="server" Width="1000" Height="400px">
            <Series>
                <asp:Series Name="Series2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea2">
                    <AxisX Interval="1" TextOrientation="Rotated90">
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                </asp:Title>
                <asp:Title Docking="Bottom" Name="Bottom Title" Text="Year" Font="Arial Rounded MT Bold, 12pt, ">
                </asp:Title>
                <asp:Title Name="Top" Text="Enrollment (Cumulative)" Font="Arial Rounded MT Bold, 18pt, ">
                </asp:Title>
            </Titles>
        </asp:Chart>

    </div>

    <hr style="border-top: 1px solid #ccc; background: transparent;">






    <div style="text-align: right; margin-top: 8px">
        <button type="button" id="btnExport" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
            CRF-2 Report &nbsp<span class="glyphicon glyphicon-export"></span>
        </button>

        <button type="button" id="btnExport1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport1_Click">
            ARM Report &nbsp<span class="glyphicon glyphicon-export"></span>
        </button>
    </div>



    <div style="text-align: center; margin-top: 10px;">
        <%-- <asp:CheckBox ID="CheckBox1" runat="server" Text="Disable Date" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                <br>--%>

        <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
        <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
        &nbsp To &nbsp
                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
        <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
        <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
    </div>




    <div style="padding-left: 1%; margin-top: -10px; width: 100%; overflow: auto">

        <div style="color: #ff6b6b; font-size: 20px; font-family: Arial"><b><u>Team Status</u>:</b></div>

        <br>
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">

            <Columns>
                <asp:BoundField DataField="Site" HeaderText="Site" />
                <asp:BoundField DataField="Tab_User" HeaderText="TAB User" />
                <%--     <asp:TemplateField HeaderText="Total Approach">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" OnClick="Link_Button1" Text='<%#Eval("Total") %>' runat="server" ToolTip="Check Records" CommandArgument='<%# Eval("Tab_User") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                <asp:BoundField DataField="Total" HeaderText="Total Approach" />
                <asp:BoundField DataField="Incomplete" HeaderText="Incomplete" />
                <asp:BoundField DataField="Complete" HeaderText="Complete" />
                <asp:BoundField DataField="NBdied_Stillbrth_Miscrge_TypePrg" HeaderText="Newborn Died / Stillbirth / Miscarriage / Outcome more than one" />
                <asp:BoundField DataField="MUAC_GreaterEqual_23" HeaderText="MUAC Greater and Equal than 23.0" />
                <asp:BoundField DataField="MUAC_Less_23" HeaderText="MUAC Less than 23.0" />
                <asp:BoundField DataField="MUAC_Less23_and_Q26_Greater168" HeaderText="MUAC Less than 23 but Child was not captured within 0-6 days of age" />
                <asp:BoundField DataField="MUAC_Less23_Age_btw_0to6_and_AnyExclusion" HeaderText="Any exclusion criteria" />
                <asp:BoundField DataField="MUAC_Less23_Age_btw_0to6_noExclusion" HeaderText="No exclusion criteria" />
                <asp:BoundField DataField="consent_refusedQ47" HeaderText="Consent Refused" />
                <asp:BoundField DataField="consented_enrolledQ47" HeaderText="Consent Enrolled" />
            </Columns>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>



        <br>

        <br>
        <asp:GridView ID="GridView7" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound1">

            <Columns>
                <asp:BoundField DataField="Tab_User" HeaderText="TAB User" />
                <asp:BoundField DataField="TotalFilled_CRF3a" HeaderText="CRF-3a (Total Approach)" />
                <asp:BoundField DataField="Incomplete_CRF3a" HeaderText="CRF-3a (Incomplete)" />
                <asp:BoundField DataField="Complete_CRF3a" HeaderText="CRF-3a (Complete)" />
                <asp:BoundField DataField="CRF3b_Filled" HeaderText="CRF-3b (Complete)" />
                <asp:BoundField DataField="CRF3c_Filled" HeaderText="CRF-3c (Complete)" />
            </Columns>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" Height="50px" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>



    </div>







    <%--ARM: A--%>
    <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <%--ARM: B--%>
    <asp:GridView ID="GridView3" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <%--ARM: C--%>
    <asp:GridView ID="GridView4" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>



    <%--Report: Date Wise--%>
    <asp:GridView ID="GridView5" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="AG" HeaderText="Site " />
            <asp:BoundField DataField="TotalFilled_CRF2" HeaderText="Total Approached" />
            <asp:BoundField DataField="LW_died" HeaderText="Lactating women died before screening" />
            <asp:BoundField DataField="NewBorn_died" HeaderText="Newborn died before lactating women screening" />
            <asp:BoundField DataField="Stillbirth" HeaderText="Lactating women was not screened as outcome was stillbirth" />
            <asp:BoundField DataField="Miscarriage" HeaderText="Lactating women was not screened as outcome was miscarriage" />
            <asp:BoundField DataField="Type_Pregnancy" HeaderText="Lactating women was not screened as outcome was more than one" />
            <asp:BoundField DataField="Refused" HeaderText="Lactating women was not screened as refused for screening" />
            <asp:BoundField DataField="Not_at_home" HeaderText="Lactating women was not screened as not at home" />
            <asp:BoundField DataField="Out_of_DSS" HeaderText="Lactating women was not screened as shifted out" />
            <asp:BoundField DataField="Adopted" HeaderText="Lactating women was not screened as child was adopted" />
            <asp:BoundField DataField="False_Preg" HeaderText="Lactating women was not screened as False Pregnancy" />
            <asp:BoundField DataField="Complete" HeaderText="Total lactating women screened for eligibility" />
            <asp:BoundField DataField="MUAC_GreaterEqual_23" HeaderText="Not eligible lactating women as MUAC equal or greater than  23.0 cm" />
            <asp:BoundField DataField="MUAC_Less_23" HeaderText="Eligible lactating as MUAC less than 23.0cm" />

            <asp:BoundField DataField="MUAC_Less23_Age_Greater_7days_and_AnyExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured greater than 7 days of age, but has any exclusion criteria" />
            <asp:BoundField DataField="MUAC_Less23_Age_Greater_7days_noExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured greater than 7 days of age with no exclusion criteria" />
            <asp:BoundField DataField="MUAC_Less23_Age_btw_0to6_and_AnyExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age, but has any exclusion criteria" />
            <asp:BoundField DataField="MUAC_Less23_Age_btw_0to6_noExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age with no exclusion criteria" />

            <asp:BoundField DataField="consent_refusedQ47" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age with no exclusion criteria, but consent refused" />
            <asp:BoundField DataField="consented_enrolledQ47" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age with no exclusion criteria,  consented and enrolled" />
            <asp:BoundField DataField="Total_RandomFilled_3a" HeaderText="Total Randomization Filled" />
        </Columns>
    </asp:GridView>
    <%--Report: Date without Date--%>
    <asp:GridView ID="GridView6" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="AG" HeaderText="Site " />
            <asp:BoundField DataField="TotalFilled_CRF2" HeaderText="Total Approached" />
            <asp:BoundField DataField="LW_died" HeaderText="Lactating women died before screening" />
            <asp:BoundField DataField="NewBorn_died" HeaderText="Newborn died before lactating women screening" />
            <asp:BoundField DataField="Stillbirth" HeaderText="Lactating women was not screened as outcome was stillbirth" />
            <asp:BoundField DataField="Miscarriage" HeaderText="Lactating women was not screened as outcome was miscarriage" />
            <asp:BoundField DataField="Type_Pregnancy" HeaderText="Lactating women was not screened as outcome was more than one" />
            <asp:BoundField DataField="Refused" HeaderText="Lactating women was not screened as refused for screening" />
            <asp:BoundField DataField="Not_at_home" HeaderText="Lactating women was not screened as not at home" />
            <asp:BoundField DataField="Out_of_DSS" HeaderText="Lactating women was not screened as shifted out" />
            <asp:BoundField DataField="Adopted" HeaderText="Lactating women was not screened as child was adopted" />
            <asp:BoundField DataField="False_Preg" HeaderText="Lactating women was not screened as False Pregnancy" />
            <asp:BoundField DataField="Complete" HeaderText="Total lactating women screened for eligibility" />
            <asp:BoundField DataField="MUAC_GreaterEqual_23" HeaderText="Not eligible lactating women as MUAC equal or greater than  23.0 cm" />
            <asp:BoundField DataField="MUAC_Less_23" HeaderText="Eligible lactating as MUAC less than 23.0cm" />

            <asp:BoundField DataField="MUAC_Less23_Age_Greater_7days_and_AnyExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured greater than 7 days of age, but has any exclusion criteria" />
            <asp:BoundField DataField="MUAC_Less23_Age_Greater_7days_noExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured greater than 7 days of age with no exclusion criteria" />
            <asp:BoundField DataField="MUAC_Less23_Age_btw_0to6_and_AnyExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age, but has any exclusion criteria" />
            <asp:BoundField DataField="MUAC_Less23_Age_btw_0to6_noExclusion" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age with no exclusion criteria" />

            <asp:BoundField DataField="consent_refusedQ47" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age with no exclusion criteria, but consent refused" />
            <asp:BoundField DataField="consented_enrolledQ47" HeaderText="Eligible lactating as MUAC less than 23.0cm and child was captured within 0-6 days of age with no exclusion criteria,  consented and enrolled" />
            <asp:BoundField DataField="Total_RandomFilled_3a" HeaderText="Total Randomization Filled" />
        </Columns>
    </asp:GridView>

    <%--ARM: Date Wise--%>
    <asp:GridView ID="GridView8" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <%--ARM: without Date--%>
    <asp:GridView ID="GridView9" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

</asp:Content>
