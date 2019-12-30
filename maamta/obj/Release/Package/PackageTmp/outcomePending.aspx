﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="outcomePending.aspx.cs" Inherits="maamta.outcomePending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            List of Expected Outcome:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
        <div id="div1" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: 0px;">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select SITE</asp:ListItem>
                <asp:ListItem Value="AG">AG  (Ali Akbar Shah)</asp:ListItem>
                <asp:ListItem Value="BH">BH  (Behance Colony)</asp:ListItem>
                <asp:ListItem Value="RG">RG  (Rehri Goth)</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">


            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">

                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="assis_id" HeaderText="Assisment ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="block" HeaderText="Block" />
                    <asp:BoundField DataField="a/c to Ultrasound" HeaderText="a/c to Ultrasound" />
                    <asp:BoundField DataField="Expected_Date" HeaderText="Expected_Date " />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman_Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband_Name" />
                    <asp:BoundField DataField="Contact_No" HeaderText="Contact_No." />

                </Columns>


                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#33d9b2" ForeColor="white" Font-Bold="True" Height="40px" />
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
                    <asp:BoundField DataField="assis_id" HeaderText="Assisment ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="block" HeaderText="Block" />
                    <asp:BoundField DataField="a/c to Ultrasound" HeaderText="a/c to Ultrasound" />
                    <asp:BoundField DataField="Expected_Date" HeaderText="Expected_Date " />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman_Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband_Name" />
                    <asp:BoundField DataField="Contact_No" HeaderText="Contact_No." />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
