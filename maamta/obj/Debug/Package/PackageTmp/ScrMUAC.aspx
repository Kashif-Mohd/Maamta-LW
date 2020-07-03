<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ScrMUAC.aspx.cs" Inherits="maamta.ScrMUAC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 5px; font-size: 18px">
        <a href="scrUserdetail.aspx" class="logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back 
        </a>
    </div>
    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 18px;">
            Assessment-ID:
            <asp:Label ID="lbeAssis" ForeColor="#10ac84" Font-Bold="true" runat="server" Text="Label"></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div style="color: gray; font-size: 24px; text-align: center; font-family: Arial;">
            MUAC Detail
        </div>

        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="code_of_reader_1" HeaderText="Code Reader-1" />
                    <asp:BoundField DataField="code_of_reader_2" HeaderText="Code Reader-2" />
                    <asp:BoundField DataField="reading_1" HeaderText="Reading-1" />
                    <asp:BoundField DataField="reading_2" HeaderText="Reading-2" />
                    <asp:BoundField DataField="difference" HeaderText="Difference" />
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" />
                <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
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
