<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="scrnduplicate.aspx.cs" Inherits="maamta.scrnduplicate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 24px;">
            Duplicate Screening Forms:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div style="text-align: center; margin-top: -5px; margin-bottom:15px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export Records &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
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
                                    <asp:TemplateField HeaderText="DSSID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkDSSID" OnClick="Link_DSSID" Text='<%#Eval("dssid") %>' runat="server" ToolTip="Show Detail"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:BoundField DataField="total" HeaderText="Duplicate" />
                <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
            </Columns>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" Height="35px" />
            <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
            <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

        <br/>

        <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="assis_id" HeaderText="Assisment ID" />
                    <asp:BoundField DataField="lw_crf1_02" HeaderText="Q2_DOV" />
                    <asp:BoundField DataField="lw_crf1_03" HeaderText="Q3_StartTime" />
                    <asp:BoundField DataField="RS_code_q8" HeaderText="Q8_RS_code " />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman_Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband_Name" />
                    <asp:BoundField DataField="Duplicate" HeaderText="Duplicate" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="site" HeaderText="Site" />
                    <asp:BoundField DataField="para" HeaderText="Para" />
                    <asp:BoundField DataField="block" HeaderText="Block" />
                    <asp:BoundField DataField="struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="Wm_No" />
                    <asp:BoundField DataField="V_Status" HeaderText="Visit_Status" />
                    <asp:BoundField DataField="lw_crf1_21" HeaderText="Q21" />
                    <asp:BoundField DataField="lw_crf1_22" HeaderText="Q22" />
                    <asp:BoundField DataField="lw_crf1_23" HeaderText="Q23" />
                    <asp:BoundField DataField="lw_crf1_24" HeaderText="Q24" />
                    <asp:BoundField DataField="lw_crf1_25" HeaderText="Q25" />
                    <asp:BoundField DataField="lw_crf1_26" HeaderText="Q26_LMP" />
                    <asp:BoundField DataField="lw_crf1_27" HeaderText="Q27_EDD" />
                    <asp:BoundField DataField="lw_crf1_28" HeaderText="Q28_wk" />
                    <asp:BoundField DataField="lw_crf1_29" HeaderText="Q29" />
                    <asp:BoundField DataField="lw_crf1_30" HeaderText="Q30" />
                    <asp:BoundField DataField="lw_crf1_31" HeaderText="Q31_Ult" />
                    <asp:BoundField DataField="lw_crf1_32" HeaderText="Q32_wk" />
                    <asp:BoundField DataField="lw_crf1_34" HeaderText="Q32_EndTime" />
                    <asp:BoundField DataField="c_start_date" HeaderText="Start_Consl" />
                    <asp:BoundField DataField="c_end_date" HeaderText="End_Consl" />
                    <asp:BoundField DataField="tab_user_nm" HeaderText="Tab_User" />
                </Columns>
            </asp:GridView>
     </div>

    </div>
</asp:Content>
