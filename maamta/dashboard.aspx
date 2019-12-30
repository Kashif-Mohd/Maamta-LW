<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="maamta.dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <style>
        .mycheckbox {
            margin-right: 22px;
            font-size: 17px;
            font-family: Arial;
        }

        .btnChng {
            background-color: #4e94ba;
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-family: arial;
            font-size: 16px;
            padding: 4px 28px;
            text-decoration: none;
            font-weight: bold;
        }

            /*.btnSrch:hover {
                background-color: #2574A9;
            }*/

            .btnChng:active {
                position: relative;
                top: 1px;
            }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>


    <div style="text-align: right; margin-top: 8px">
        <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
            Export Report &nbsp<span class="glyphicon glyphicon-export"></span>
        </button>
    </div>




    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="updateProgress" runat="server">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                        <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #ff7675; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>




    <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>
            <asp:Label ID="lbeUname" runat="server" ForeColor="white" Text=""></asp:Label>, Welcome to Screening Board!</b></h1>
    </div>



    <div class="Mobile">
        <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left; margin-top: 10px;">
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Total Forms:</td>
                <th class=" tdCSS">
                    <asp:Label ID="lbeTotal" runat="server" Text="0"></asp:Label>
                </th>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Complete Forms:</td>
                <th class=" tdCSS">
                    <asp:Label ID="lbeComplete" runat="server" Text="0"></asp:Label>
                </th>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Incomplete Forms:</td>
                <th class=" tdCSS">
                    <asp:Label ID="lbeIncomplete" runat="server" Text="0"></asp:Label>
                </th>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">MUAC Less than 24:</td>
                <th class=" tdCSS">
                    <asp:Label ID="lbeElg" runat="server" Text="0"></asp:Label>
                </th>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">MUAC Greater than and Equal to 24:</td>
                <th class=" tdCSS">
                    <asp:Label ID="lbeNotElg" runat="server" Text="0"></asp:Label>
                </th>
            </tr>
            <tr class="trCSS">
                <td class="TableColumn tdCSS">Duplicate DSSID:</td>
                <th class=" tdCSS">
                    <asp:LinkButton ID="linkDuplicate" OnClick="Link_Duplicate" Text="0" runat="server"></asp:LinkButton>

                    <%-- <asp:Label ID="lbeDuplicate" runat="server" Text="0"></asp:Label>--%>
                </th>
            </tr>
        </table>
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





    <div style="padding-left: 2%; margin-top: -15px;">

        <div style="color: #ff6b6b; font-size: 20px; font-family: Arial"><b><u>Team Status</u>:</b></div>

        <br>
        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound1">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="site" HeaderText="Assign Site" />
                    <asp:BoundField DataField="name" HeaderText="User Name" />
                    <asp:BoundField DataField="Complete" HeaderText="Complete" />
                    <asp:BoundField DataField="Incomplete" HeaderText="Incomplete" />
                    <asp:TemplateField HeaderText="Total Forms">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" OnClick="Link_Button1" Text='<%#Eval("total") %>' runat="server" ToolTip="Check Records" CommandArgument='<%# Eval("name") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
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

    <hr style="border-top: 1px solid #ccc; background: transparent;">
    <br />



    <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>


    <asp:GridView ID="GridView3" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
    </asp:GridView>

    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>



    <br>
    <br>
</asp:Content>
