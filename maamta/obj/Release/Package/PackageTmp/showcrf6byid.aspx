﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf6byid.aspx.cs" Inherits="maamta.showcrf6byid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media only screen and (min-width: 40em) {
            .WidthFix {
                width: 65%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 5px; font-size: 18px">
        <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back
        </button>
    </div>

    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%;">
            <div style="color: #ff6b6b; font-size: 18px;">
                Study-ID:
            <asp:Label ID="lbeStudyID" ForeColor="#10ac84" Font-Bold="true" runat="server" Text=""></asp:Label>
            </div>
            Outcome Assessment (Anthro):
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <asp:GridView ID="GridView1" runat="server" Font-Size="4.0mm" CssClass="footable WidthFix" CellPadding="20" ForeColor="#333333" OnRowDataBound="OnRowDataBound" AutoGenerateColumns="true">
            <RowStyle BackColor="#00b894" ForeColor="WhiteSmoke" />
        </asp:GridView>
        <br />


        <div style="color: #ff6b6b; font-size: 18px; margin-top: 30px; margin-bottom: 5px; font-family: Arial; font-weight: bold">
            <u>Q19: Weight of Child (grams)</u>:
        </div>
        <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." CssClass="footable WidthFix" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="reader_code1" HeaderText="Code Reader-1" />
                <asp:BoundField DataField="reader_code2" HeaderText="Code Reader-2" />
                <asp:BoundField DataField="reader1" HeaderText="Reading-1" />
                <asp:BoundField DataField="reader2" HeaderText="Reading-2" />
                <asp:BoundField DataField="difference" HeaderText="Difference" />
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



        <br />
        <div style="color: #ff6b6b; font-size: 18px; margin-top: 30px; margin-bottom: 5px; font-family: Arial; font-weight: bold">
            <u>Q21: Length of Child (cm)</u>:
        </div>

        <asp:GridView ID="GridView3" runat="server" EmptyDataText="No Record Found." CssClass="footable WidthFix" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="reader_code1" HeaderText="Code Reader-1" />
                <asp:BoundField DataField="reader_code2" HeaderText="Code Reader-2" />
                <asp:BoundField DataField="reader1" HeaderText="Reading-1" />
                <asp:BoundField DataField="reader2" HeaderText="Reading-2" />
                <asp:BoundField DataField="difference" HeaderText="Difference" />
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

        <br />
        <div style="color: #ff6b6b; font-size: 18px; margin-top: 30px; margin-bottom: 5px; font-family: Arial; font-weight: bold">
            <u>Q23: MUAC of Child (cm)</u>:
        </div>

        <asp:GridView ID="GridView4" runat="server" EmptyDataText="No Record Found." CssClass="footable WidthFix" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="reader_code1" HeaderText="Code Reader-1" />
                <asp:BoundField DataField="reader_code2" HeaderText="Code Reader-2" />
                <asp:BoundField DataField="reader1" HeaderText="Reading-1" />
                <asp:BoundField DataField="reader2" HeaderText="Reading-2" />
                <asp:BoundField DataField="difference" HeaderText="Difference" />
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



        <br />
        <div style="color: #ff6b6b; font-size: 18px; margin-top: 30px; margin-bottom: 5px; font-family: Arial; font-weight: bold">
            <u>Q25: Occipito-Frontal Head Circumference of Baby (cm)</u>:
        </div>

        <asp:GridView ID="GridView5" runat="server" EmptyDataText="No Record Found." CssClass="footable WidthFix" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="reader_code1" HeaderText="Code Reader-1" />
                <asp:BoundField DataField="reader_code2" HeaderText="Code Reader-2" />
                <asp:BoundField DataField="reader1" HeaderText="Reading-1" />
                <asp:BoundField DataField="reader2" HeaderText="Reading-2" />
                <asp:BoundField DataField="difference" HeaderText="Difference" />
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


        <br />
        <div style="color: #ff6b6b; font-size: 18px; margin-top: 30px; margin-bottom: 5px; font-family: Arial; font-weight: bold">
            <u>Q29: Weight of LW (kg)</u>:
        </div>

        <asp:GridView ID="GridView6" runat="server" EmptyDataText="No Record Found." CssClass="footable WidthFix" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="reader_code1" HeaderText="Code Reader-1" />
                <asp:BoundField DataField="reader_code2" HeaderText="Code Reader-2" />
                <asp:BoundField DataField="reader1" HeaderText="Reading-1" />
                <asp:BoundField DataField="reader2" HeaderText="Reading-2" />
                <asp:BoundField DataField="difference" HeaderText="Difference" />
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


        <br />
       

      

        <br />
        <div style="color: #ff6b6b; font-size: 18px; margin-top: 30px; margin-bottom: 5px; font-family: Arial; font-weight: bold">
            <u>Q31: MUAC of LW (cm)</u>:
        </div>

        <asp:GridView ID="GridView7" runat="server" EmptyDataText="No Record Found." CssClass="footable WidthFix" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="reader_code1" HeaderText="Code Reader-1" />
                <asp:BoundField DataField="reader_code2" HeaderText="Code Reader-2" />
                <asp:BoundField DataField="reader1" HeaderText="Reading-1" />
                <asp:BoundField DataField="reader2" HeaderText="Reading-2" />
                <asp:BoundField DataField="difference" HeaderText="Difference" />
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
    </div>
</asp:Content>
