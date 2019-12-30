﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf1.aspx.cs" Inherits="maamta.showcrf1" %>

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
    <div id="divBackButton" runat="server" style="margin-top: 5px; font-size: 18px">
        <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back
        </button>
    </div>


    <div style="padding-left: 2%; margin-top: 15px;">

        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            SCREENING FORM
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>

        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">
            <asp:DropDownList ID="DropDownList1" CssClass="form-control textDropDownCSS" data-style="btn-primary" runat="server">
                <asp:ListItem Value="0">Select MUAC Range</asp:ListItem>
                <asp:ListItem Value="1">MUAC Less than 24</asp:ListItem>
                <asp:ListItem Value="2">MUAC Greater than and Equal to 24</asp:ListItem>
            </asp:DropDownList>

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
                <div class="Mobile" id="calendar" runat="server">
                    <table style="width: 100%; text-align: center; margin-left: 6%; margin-bottom: 15px">
                        <tr>
                            <td class="tddd">
                                <asp:TextBox ID="txtCalndrDate" Font-Bold="true" Font-Size="16px" ClientIDMode="Static" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCalndrDate" PopupButtonID="btnCalndrDate" Format="dd-MM-yyyy" />
                                &nbsp To &nbsp
                                <asp:TextBox ID="txtCalndrDate1" Font-Bold="true" Font-Size="16px" CssClass="txtboxx" Height="32px" runat="server" Width="8.0em"></asp:TextBox>
                                <asp:ImageButton ID="btnCalndrDate1" ImageUrl="~/assets/img/calendar1.png" CssClass="calanderButton" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCalndrDate1" PopupButtonID="btnCalndrDate1" Format="dd-MM-yyyy" />
                                &nbsp &nbsp 
                          <asp:CheckBox ID="CheckBox1" runat="server" Text="Disable" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" CssClass="mycheckbox" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--End   Date checks--%>





        <div style="width: 100%; height: 490px; overflow: scroll; margin-top: 10px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assisment ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkAssis" OnClick="Link_Assis" Text='<%#Eval("assis_id") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("assis_id")+","+ Eval("form_crf_1_id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lw_crf1_02" HeaderText="Q2_DOV" />
                    <asp:BoundField DataField="lw_crf1_03" HeaderText="Q3_StartTime" />
                    <asp:BoundField DataField="code1" HeaderText="Q8_RS_code " />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman_Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband_Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="site" HeaderText="Site" />
                    <asp:BoundField DataField="para" HeaderText="Para" />
                    <asp:BoundField DataField="block" HeaderText="Block" />
                    <asp:BoundField DataField="struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="Wm_No" />
                    <asp:BoundField DataField="V_Status" HeaderText="Visit_Status" />
                    <asp:BoundField DataField="refused_reason" HeaderText="Refused Reason" />
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
                    <asp:BoundField DataField="lw_crf1_34" HeaderText="Q34_EndTime" />
                    <asp:BoundField DataField="c_start_date" HeaderText="Start_Consl" />
                    <asp:BoundField DataField="c_end_date" HeaderText="End_Consl" />
                    <asp:BoundField DataField="tab_user_nm" HeaderText="Tab_User" />
                    <asp:BoundField DataField="code1" HeaderText="code1" />
                    <asp:BoundField DataField="code2" HeaderText="code2" />
                    <asp:BoundField DataField="LW_MUAC_R1" HeaderText="LW_MUAC_R1" />
                    <asp:BoundField DataField="LW_MUAC_R2" HeaderText="LW_MUAC_R2" />
                    <asp:BoundField DataField="form_crf_1_id" HeaderText="form_crf_1_id" />
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






            <asp:GridView ID="GridView3" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound1" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="assisment_id">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkAssis" OnClick="Link_Assis" Text='<%#Eval("assis_id") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("assis_id")+","+ Eval("form_crf_1_id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="total" HeaderText="Total Filled" />
                    <asp:BoundField DataField="lw_crf1_02" HeaderText="Q2_DOV" />
                    <asp:BoundField DataField="lw_crf1_03" HeaderText="Q3_StartTime" />
                    <asp:BoundField DataField="code1" HeaderText="Q8_RS_code " />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman_Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband_Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="site" HeaderText="Site" />
                    <asp:BoundField DataField="para" HeaderText="Para" />
                    <asp:BoundField DataField="block" HeaderText="Block" />
                    <asp:BoundField DataField="struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="Wm_No" />
                    <asp:BoundField DataField="V_Status" HeaderText="Visit_Status" />
                    <asp:BoundField DataField="refused_reason" HeaderText="Refused Reason" />
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
                    <asp:BoundField DataField="lw_crf1_34" HeaderText="Q34_EndTime" />
                    <asp:BoundField DataField="c_start_date" HeaderText="Start_Consl" />
                    <asp:BoundField DataField="c_end_date" HeaderText="End_Consl" />
                    <asp:BoundField DataField="tab_user_nm" HeaderText="Tab_User" />
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




            <asp:GridView ID="GridView2" runat="server" CssClass="footable" OnRowDataBound="OnRowDataBound" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="assis_id" HeaderText="Assisment_ID" />
                    <asp:BoundField DataField="lw_crf1_02" HeaderText="Q2_DOV" />
                    <asp:BoundField DataField="lw_crf1_03" HeaderText="Q3_StartTime" />
                    <asp:BoundField DataField="code1" HeaderText="Q8_RS_code" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman_Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband_Name" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="site" HeaderText="Site" />
                    <asp:BoundField DataField="para" HeaderText="Para" />
                    <asp:BoundField DataField="block" HeaderText="Block" />
                    <asp:BoundField DataField="struct" HeaderText="Struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="Wm_No" />
                    <asp:BoundField DataField="V_Status" HeaderText="Visit_Status" />
                    <asp:BoundField DataField="refused_reason" HeaderText="Refused_Reason" />
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
                    <asp:BoundField DataField="lw_crf1_34" HeaderText="Q34_EndTime" />
                    <asp:BoundField DataField="c_start_date" HeaderText="Start_Consl" />
                    <asp:BoundField DataField="c_end_date" HeaderText="End_Consl" />
                    <asp:BoundField DataField="tab_user_nm" HeaderText="Tab_User" />
                    
                    <asp:BoundField DataField="code1" HeaderText="code1" />
                    <asp:BoundField DataField="code2" HeaderText="code2" />
                    <asp:BoundField DataField="LW_MUAC_R1" HeaderText="LW_MUAC_R1" />
                    <asp:BoundField DataField="LW_MUAC_R2" HeaderText="LW_MUAC_R2" />
					
                    <asp:BoundField DataField="form_crf_1_id" HeaderText="form_crf_1_id" />
                </Columns>
            </asp:GridView>




        </div>
    </div>
</asp:Content>
