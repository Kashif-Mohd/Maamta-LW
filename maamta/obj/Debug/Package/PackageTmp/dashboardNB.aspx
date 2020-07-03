<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashboardNB.aspx.cs" Inherits="maamta.dashboardNB" %>

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
    <br>
    <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Newborn Team!</b></h1>
    </div>


    <div style="text-align: center; margin-top: 30px;">
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
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true" OnRowDataBound="OnRowDataBound">

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

</asp:Content>
