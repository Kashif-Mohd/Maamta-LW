<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf2.aspx.cs" Inherits="maamta.showcrf2" %>

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
    <div id="divBackButton" runat="server" style="margin-top: 5px; font-size: 18px">
        <button type="submit" id="btnBack" runat="server" onserverclick="btnBack_Click" class="transparentButton logout">
            <span class="glyphicon glyphicon-chevron-left"></span>Back
        </button>
    </div>


    <div style="padding-left: 2%; margin-top: 15px;">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            TRIAL ELIGIBILITY FORM:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
            <button type="button" id="btnBMGF" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnBMGF_Click">
                BMGF &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>

        </div>






        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: -10px;">


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
                    <table style="width: 100%; text-align: center; margin-left: 1%; margin-bottom: 15px">
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


        <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="form_crf_2" HeaderText="form_crf_2" />
                    <asp:TemplateField HeaderText="Assisment ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkAssis" OnClick="Link_Assis" Text='<%#Eval("assis_id") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_2")+","+ Eval("assis_id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="date_of_attempt" HeaderText="date_of_attempt" />
                    <asp:BoundField DataField="time_of_attempt" HeaderText="time_of_attempt" />
                    <asp:BoundField DataField="lw_crf1_09" HeaderText="lw_crf1_09" />
                    <asp:BoundField DataField="lw_crf1_10" HeaderText="lw_crf1_10" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="Q17_Vstatus" HeaderText="Q17_Vstatus" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="lw_crf2_18" HeaderText="lw_crf2_18" />
                    <asp:BoundField DataField="Q19" HeaderText="Q19" />
                    <asp:BoundField DataField="Q20" HeaderText="Q20" />
                    <asp:BoundField DataField="lw_crf2_21" HeaderText="lw_crf2_21" />
                    <asp:BoundField DataField="lw_crf2_22" HeaderText="lw_crf2_22" />
                    <asp:BoundField DataField="lw_crf2_23" HeaderText="lw_crf2_23" />
                    <asp:BoundField DataField="lw_crf2_24" HeaderText="lw_crf2_24" />
                    <asp:BoundField DataField="lw_crf2_25" HeaderText="lw_crf2_25" />
                    <asp:BoundField DataField="lw_crf2_26" HeaderText="lw_crf2_26" />
                    <asp:BoundField DataField="lw_crf2_30" HeaderText="lw_crf2_30" />
                    <asp:BoundField DataField="lw_crf2_31" HeaderText="lw_crf2_31" />
                    <asp:BoundField DataField="lw_crf2_32" HeaderText="lw_crf2_32" />
                    <asp:BoundField DataField="lw_crf2_34" HeaderText="lw_crf2_34" />
                    <asp:BoundField DataField="lw_crf2_35" HeaderText="lw_crf2_35" />
                    <asp:BoundField DataField="lw_crf2_36" HeaderText="lw_crf2_36" />
                    <asp:BoundField DataField="lw_crf2_37" HeaderText="lw_crf2_37" />
                    <asp:BoundField DataField="lw_crf2_38_a" HeaderText="lw_crf2_38_a" />
                    <asp:BoundField DataField="lw_crf2_38_b" HeaderText="lw_crf2_38_b" />
                    <asp:BoundField DataField="lw_crf2_39" HeaderText="lw_crf2_39" />
                    <asp:BoundField DataField="lw_crf2_40" HeaderText="lw_crf2_40" />
                    <asp:BoundField DataField="lw_crf2_41_a" HeaderText="lw_crf2_41_a" />
                    <asp:BoundField DataField="lw_crf2_41_b" HeaderText="lw_crf2_41_b" />
                    <asp:BoundField DataField="lw_crf2_41_c" HeaderText="lw_crf2_41_c" />
                    <asp:BoundField DataField="lw_crf2_41_d" HeaderText="lw_crf2_41_d" />
                    <asp:BoundField DataField="lw_crf2_41_e" HeaderText="lw_crf2_41_e" />
                    <asp:BoundField DataField="lw_crf2_41_f" HeaderText="lw_crf2_41_f" />
                    <asp:BoundField DataField="lw_crf2_42" HeaderText="lw_crf2_42" />
                    <asp:BoundField DataField="lw_crf2_43" HeaderText="lw_crf2_43" />
                    <asp:BoundField DataField="" HeaderText="Q44_sum" />
                    <asp:BoundField DataField="" HeaderText="Q44_1" />
                    <asp:BoundField DataField="" HeaderText="Q44_2" />
                    <asp:BoundField DataField="" HeaderText="Q44_3" />
                    <asp:BoundField DataField="" HeaderText="Q44_4" />
                    <asp:BoundField DataField="" HeaderText="Q44_5" />
                    <asp:BoundField DataField="" HeaderText="Q44_6" />
                    <asp:BoundField DataField="" HeaderText="Q44_7" />
                    <asp:BoundField DataField="" HeaderText="Q44_8" />
                    <asp:BoundField DataField="" HeaderText="Q44_9" />
                    <asp:BoundField DataField="" HeaderText="Q44_10" />
                    <asp:BoundField DataField="" HeaderText="Q44_11" />

                    <asp:BoundField DataField="lw_crf2_45" HeaderText="lw_crf2_45" />
                    <asp:BoundField DataField="lw_crf2_46" HeaderText="lw_crf2_46" />
                    <asp:BoundField DataField="lw_crf2_47" HeaderText="lw_crf2_47" />
                    <asp:BoundField DataField="lw_crf2_48" HeaderText="lw_crf2_48" />
                    <asp:BoundField DataField="lw_crf2_49" HeaderText="lw_crf2_49" />
                    <asp:BoundField DataField="lw_crf2_50" HeaderText="lw_crf2_50" />
                    <asp:BoundField DataField="end_time_of_attempt" HeaderText="end_time_of_attempt" />
                    <asp:BoundField DataField="Tab_User" HeaderText="Tab_User" />

                    <asp:BoundField DataField="code1" HeaderText="code1" />
                    <asp:BoundField DataField="code2" HeaderText="code2" />
                    <asp:BoundField DataField="LW_MUAC_R1" HeaderText="LW_MUAC_R1" />
                    <asp:BoundField DataField="LW_MUAC_R2" HeaderText="LW_MUAC_R2" />
                    <asp:BoundField DataField="Child_Weight_R1" HeaderText="Child_Weight_R1" />
                    <asp:BoundField DataField="Child_Weight_R2" HeaderText="Child_Weight_R2" />

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



            <asp:GridView ID="GridView2" runat="server" CssClass="footable" OnRowDataBound="OnRowDataBound" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="form_crf_2" HeaderText="form_crf_2" />
                    <asp:BoundField DataField="assis_id" HeaderText="Assisment_ID" />
                    <asp:BoundField DataField="date_of_attempt" HeaderText="date_of_attempt" />
                    <asp:BoundField DataField="time_of_attempt" HeaderText="time_of_attempt" />
                    <asp:BoundField DataField="lw_crf1_09" HeaderText="lw_crf1_09" />
                    <asp:BoundField DataField="lw_crf1_10" HeaderText="lw_crf1_10" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="Q17_Vstatus" HeaderText="Q17_Vstatus" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="lw_crf2_18" HeaderText="lw_crf2_18" />
                    <asp:BoundField DataField="Q19" HeaderText="Q19" />
                    <asp:BoundField DataField="Q20" HeaderText="Q20" />
                    <asp:BoundField DataField="lw_crf2_21" HeaderText="lw_crf2_21" />
                    <asp:BoundField DataField="lw_crf2_22" HeaderText="lw_crf2_22" />
                    <asp:BoundField DataField="lw_crf2_23" HeaderText="lw_crf2_23" />
                    <asp:BoundField DataField="lw_crf2_24" HeaderText="lw_crf2_24" />
                    <asp:BoundField DataField="lw_crf2_25" HeaderText="lw_crf2_25" />
                    <asp:BoundField DataField="lw_crf2_26" HeaderText="lw_crf2_26" />
                    <asp:BoundField DataField="lw_crf2_30" HeaderText="lw_crf2_30" />
                    <asp:BoundField DataField="lw_crf2_31" HeaderText="lw_crf2_31" />
                    <asp:BoundField DataField="lw_crf2_32" HeaderText="lw_crf2_32" />
                    <asp:BoundField DataField="lw_crf2_34" HeaderText="lw_crf2_34" />
                    <asp:BoundField DataField="lw_crf2_35" HeaderText="lw_crf2_35" />
                    <asp:BoundField DataField="lw_crf2_36" HeaderText="lw_crf2_36" />
                    <asp:BoundField DataField="lw_crf2_37" HeaderText="lw_crf2_37" />
                    <asp:BoundField DataField="lw_crf2_38_a" HeaderText="lw_crf2_38_a" />
                    <asp:BoundField DataField="lw_crf2_38_b" HeaderText="lw_crf2_38_b" />
                    <asp:BoundField DataField="lw_crf2_39" HeaderText="lw_crf2_39" />
                    <asp:BoundField DataField="lw_crf2_40" HeaderText="lw_crf2_40" />
                    <asp:BoundField DataField="lw_crf2_41_a" HeaderText="lw_crf2_41_a" />
                    <asp:BoundField DataField="lw_crf2_41_b" HeaderText="lw_crf2_41_b" />
                    <asp:BoundField DataField="lw_crf2_41_c" HeaderText="lw_crf2_41_c" />
                    <asp:BoundField DataField="lw_crf2_41_d" HeaderText="lw_crf2_41_d" />
                    <asp:BoundField DataField="lw_crf2_41_e" HeaderText="lw_crf2_41_e" />
                    <asp:BoundField DataField="lw_crf2_41_f" HeaderText="lw_crf2_41_f" />
                    <asp:BoundField DataField="lw_crf2_42" HeaderText="lw_crf2_42" />
                    <asp:BoundField DataField="lw_crf2_43" HeaderText="lw_crf2_43" />
                    <asp:BoundField DataField="" HeaderText="Q44_sum" />
                    <asp:BoundField DataField="" HeaderText="Q44_1" />
                    <asp:BoundField DataField="" HeaderText="Q44_2" />
                    <asp:BoundField DataField="" HeaderText="Q44_3" />
                    <asp:BoundField DataField="" HeaderText="Q44_4" />
                    <asp:BoundField DataField="" HeaderText="Q44_5" />
                    <asp:BoundField DataField="" HeaderText="Q44_6" />
                    <asp:BoundField DataField="" HeaderText="Q44_7" />
                    <asp:BoundField DataField="" HeaderText="Q44_8" />
                    <asp:BoundField DataField="" HeaderText="Q44_9" />
                    <asp:BoundField DataField="" HeaderText="Q44_10" />
                    <asp:BoundField DataField="" HeaderText="Q44_11" />

                    <asp:BoundField DataField="lw_crf2_45" HeaderText="lw_crf2_45" />
                    <asp:BoundField DataField="lw_crf2_46" HeaderText="lw_crf2_46" />
                    <asp:BoundField DataField="lw_crf2_47" HeaderText="lw_crf2_47" />
                    <asp:BoundField DataField="lw_crf2_48" HeaderText="lw_crf2_48" />
                    <asp:BoundField DataField="lw_crf2_49" HeaderText="lw_crf2_49" />
                    <asp:BoundField DataField="lw_crf2_50" HeaderText="lw_crf2_50" />
                    <asp:BoundField DataField="end_time_of_attempt" HeaderText="end_time_of_attempt" />
                    <asp:BoundField DataField="Tab_User" HeaderText="Tab_User" />

                    <asp:BoundField DataField="code1" HeaderText="code1" />
                    <asp:BoundField DataField="code2" HeaderText="code2" />
                    <asp:BoundField DataField="LW_MUAC_R1" HeaderText="LW_MUAC_R1" />
                    <asp:BoundField DataField="LW_MUAC_R2" HeaderText="LW_MUAC_R2" />
                    <asp:BoundField DataField="Child_Weight_R1" HeaderText="Child_Weight_R1" />
                    <asp:BoundField DataField="Child_Weight_R2" HeaderText="Child_Weight_R2" />
                </Columns>
            </asp:GridView>


            <%--For BMGF Export --%>
            <asp:GridView ID="GridViewBMFG" runat="server" CssClass="footable"  ForeColor="#333333" AutoGenerateColumns="true">
               
            </asp:GridView>


        </div>
    </div>
</asp:Content>
