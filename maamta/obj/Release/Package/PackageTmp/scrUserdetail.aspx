<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="scrUserdetail.aspx.cs" Inherits="maamta.scrUserdetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <asp:UpdateProgress ID="updateProgress" runat="server">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                        <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #ff7675; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>


            <div style="margin-top: 5px; font-size: 18px">
                <a href="dashboard.aspx" class="logout">
                    <span class="glyphicon glyphicon-chevron-left"></span>Back 
                </a>
            </div>

            <div style="padding-left: 2%; margin-top: 15px;">
                <div style="color: #ff6b6b; font-size: 18px;">
                    Status of
            <asp:Label ID="lbeStatus" ForeColor="#10ac84" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                </div>
                <div style="color: #ff6b6b; font-size: 18px;">
                    Date from
            <asp:Label ID="lbeFdate" ForeColor="#10ac84" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                    to
            <asp:Label ID="lbeSdate" Font-Bold="true" ForeColor="#10ac84" runat="server" Text="Label"></asp:Label>
                </div>
                <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">



                <div>
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: center;">
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
                            <td class="TableColumn tdCSS">
                            MUAC Greater than and Equal to 24:
                    <th class=" tdCSS">
                        <asp:Label ID="lbeNotElg" runat="server" Text="0"></asp:Label>
                    </th>
                        </tr>
                    </table>
                </div>

                <%--Search Button--%>
                <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 13px; margin-top: 27px;">
                    <div id="imaginary_container">
                        <div class="input-group stylish-input-group">
                            <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                            <span class="input-group-addon">
                                <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>

                <%--                <table style="text-align: center; width: 100%; margin-top: 30px; margin-bottom: 15px;">
                    <tr>
                        <td>
                            <asp:TextBox CssClass="input-lg txtboxx" ClientIDMode="Static" ID="txtdssid" type="text" Width="200px" Height="1.9em" placeholder="DSSID" MaxLength="11" runat="server"></asp:TextBox>

                            <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
                        </td>
                    </tr>
                </table>--%>
                <div style="width: 100%; overflow: auto">

                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound1">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>

                            <%--<asp:BoundField DataField="title" HeaderText="Form" />--%>

                            <asp:TemplateField HeaderText="Assisment ID">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkAssis" OnClick="Link_Assis" Text='<%#Eval("assis_id") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_id") + ";" +Eval("assis_id")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="dssid"  HeaderText="DSSID"    runat="server" />
                            <asp:BoundField DataField="wmnm" HeaderText="Woman Name" runat="server"/>
                            <asp:BoundField DataField="hbnm" HeaderText="Husband Name" />
                            <asp:BoundField DataField="visit_date" HeaderText="Date of Visit" />
                            <asp:BoundField DataField="s_time" HeaderText="Start Time" />
                            <asp:BoundField DataField="e_time" HeaderText="End Time" />
                            <asp:BoundField DataField="V_Status" HeaderText="Visit Status" />

                            <asp:TemplateField HeaderText="MUAC Attempt">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkMUAC" OnClick="Link_MUAC" Text='<%#Eval("muac_attempt") %>' runat="server" ToolTip="MUAC Detail" CommandArgument='<%#Eval("form_id") + ";" +Eval("assis_id")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="lw_crf1_21" HeaderText="MUAC Average" />

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
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
