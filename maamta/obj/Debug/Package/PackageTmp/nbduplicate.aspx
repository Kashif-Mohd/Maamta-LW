<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="nbduplicate.aspx.cs" Inherits="maamta.nbduplicate" %>

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
            Newborn / Compliance Forms:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <div id="div1" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: 0px;">
            <asp:DropDownList ID="DropDownListForm" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select Form</asp:ListItem>
                <asp:ListItem Value="nb">Newborn Form</asp:ListItem>
                <asp:ListItem Value="comp">Compliance Form</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="div2" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 0px; margin-top: 5px;text-align:center">

            <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
        </div>


        <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Num" />
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="date_of_attempt" HeaderText="Date of Attempt" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
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

            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="true">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
