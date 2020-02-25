<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf4b.aspx.cs" Inherits="maamta.showcrf4b" %>

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
            Routine Followups of Child Danger Sign and Other History:
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
                <div class="Mobile">
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
                    <asp:BoundField DataField="followup_num" HeaderText="Followups Number" />
                    <asp:TemplateField HeaderText="Study ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudy" OnClick="Link_Study" Text='<%#Eval("study_code") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_4b_id")+","+ Eval("study_code")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="lw_crf4b_2" HeaderText="lw_crf4b_2" />
                    <asp:BoundField DataField="lw_crf4b_3" HeaderText="lw_crf4b_3" />
                    <asp:BoundField DataField="q10" HeaderText="q10" />
                    <asp:BoundField DataField="q11" HeaderText="q11" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="q19" HeaderText="q19" />
                    <asp:BoundField DataField="q19_Reason" HeaderText="q19_Reason" />
                    <asp:BoundField DataField="lw_crf4b_20" HeaderText="lw_crf4b_20" />
                    <asp:BoundField DataField="lw_crf4b_21a" HeaderText="lw_crf4b_21a" />
                    <asp:BoundField DataField="lw_crf4b_21b" HeaderText="lw_crf4b_21b" />
                    <asp:BoundField DataField="lw_crf4b_21c" HeaderText="lw_crf4b_21c" />
                    <asp:BoundField DataField="lw_crf4b_21d" HeaderText="lw_crf4b_21d" />
                    <asp:BoundField DataField="lw_crf4b_21e" HeaderText="lw_crf4b_21e" />
                    <asp:BoundField DataField="lw_crf4b_21f" HeaderText="lw_crf4b_21f" />
                    <asp:BoundField DataField="lw_crf4b_21g" HeaderText="lw_crf4b_21g" />
                    <asp:BoundField DataField="lw_crf4b_21h" HeaderText="lw_crf4b_21h" />
                    <asp:BoundField DataField="lw_crf4b_21i" HeaderText="lw_crf4b_21i" />
                    <asp:BoundField DataField="lw_crf4b_21j" HeaderText="lw_crf4b_21j" />
                    <asp:BoundField DataField="lw_crf4b_21k" HeaderText="lw_crf4b_21k" />
                    <asp:BoundField DataField="lw_crf4b_21l" HeaderText="lw_crf4b_21l" />
                    <asp:BoundField DataField="lw_crf4b_21m" HeaderText="lw_crf4b_21m" />
                    <asp:BoundField DataField="lw_crf4b_21n" HeaderText="lw_crf4b_21n" />
                    <asp:BoundField DataField="lw_crf4b_21o" HeaderText="lw_crf4b_21o" />
                    <asp:BoundField DataField="lw_crf4b_21p" HeaderText="lw_crf4b_21p" />
                    <asp:BoundField DataField="lw_crf4b_21q" HeaderText="lw_crf4b_21q" />
                    <asp:BoundField DataField="lw_crf4b_21r" HeaderText="lw_crf4b_21r" />
                    <asp:BoundField DataField="lw_crf4b_21s" HeaderText="lw_crf4b_21s" />
                    <asp:BoundField DataField="lw_crf4b_21t" HeaderText="lw_crf4b_21t" />
                    <asp:BoundField DataField="lw_crf4b_21u" HeaderText="lw_crf4b_21u" />
                    <asp:BoundField DataField="lw_crf4b_21v" HeaderText="lw_crf4b_21v" />
                    <asp:BoundField DataField="lw_crf4b_21w" HeaderText="lw_crf4b_21w" />
                    <asp:BoundField DataField="lw_crf4b_21x" HeaderText="lw_crf4b_21x" />
                    <asp:BoundField DataField="lw_crf4b_21y" HeaderText="lw_crf4b_21y" />
                    <asp:BoundField DataField="lw_crf4b_21z" HeaderText="lw_crf4b_21z" />
                    <asp:BoundField DataField="lw_crf4b_21z_oth_1" HeaderText="lw_crf4b_21z_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_22" HeaderText="lw_crf4b_22" />
                    <asp:BoundField DataField="lw_crf4b_23a" HeaderText="lw_crf4b_23a" />
                    <asp:BoundField DataField="lw_crf4b_23b" HeaderText="lw_crf4b_23b" />
                    <asp:BoundField DataField="lw_crf4b_23c" HeaderText="lw_crf4b_23c" />
                    <asp:BoundField DataField="lw_crf4b_23d" HeaderText="lw_crf4b_23d" />
                    <asp:BoundField DataField="lw_crf4b_23e" HeaderText="lw_crf4b_23e" />
                    <asp:BoundField DataField="lw_crf4b_23f" HeaderText="lw_crf4b_23f" />
                    <asp:BoundField DataField="lw_crf4b_23g" HeaderText="lw_crf4b_23g" />
                    <asp:BoundField DataField="lw_crf4b_23g_oth_1" HeaderText="lw_crf4b_23g_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_23h" HeaderText="lw_crf4b_23h" />
                    <asp:BoundField DataField="lw_crf4b_23i" HeaderText="lw_crf4b_23i" />
                    <asp:BoundField DataField="lw_crf4b_23j" HeaderText="lw_crf4b_23j" />
                    <asp:BoundField DataField="lw_crf4b_23k" HeaderText="lw_crf4b_23k" />
                    <asp:BoundField DataField="lw_crf4b_23l" HeaderText="lw_crf4b_23l" />
                    <asp:BoundField DataField="lw_crf4b_23m" HeaderText="lw_crf4b_23m" />
                    <asp:BoundField DataField="lw_crf4b_24" HeaderText="lw_crf4b_24" />
                    <asp:BoundField DataField="lw_crf4b_25a" HeaderText="lw_crf4b_25a" />
                    <asp:BoundField DataField="lw_crf4b_25b" HeaderText="lw_crf4b_25b" />
                    <asp:BoundField DataField="lw_crf4b_25c" HeaderText="lw_crf4b_25c" />
                    <asp:BoundField DataField="lw_crf4b_25d" HeaderText="lw_crf4b_25d" />
                    <asp:BoundField DataField="lw_crf4b_25e" HeaderText="lw_crf4b_25e" />
                    <asp:BoundField DataField="lw_crf4b_25f" HeaderText="lw_crf4b_25f" />
                    <asp:BoundField DataField="lw_crf4b_25g" HeaderText="lw_crf4b_25g" />
                    <asp:BoundField DataField="lw_crf4b_25h" HeaderText="lw_crf4b_25h" />
                    <asp:BoundField DataField="lw_crf4b_25i" HeaderText="lw_crf4b_25i" />
                    <asp:BoundField DataField="lw_crf4b_25i_oth_1" HeaderText="lw_crf4b_25i_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_26" HeaderText="lw_crf4b_26" />
                    <asp:BoundField DataField="lw_crf4b_27a" HeaderText="lw_crf4b_27a" />
                    <asp:BoundField DataField="lw_crf4b_27b" HeaderText="lw_crf4b_27b" />
                    <asp:BoundField DataField="lw_crf4b_27c" HeaderText="lw_crf4b_27c" />
                    <asp:BoundField DataField="lw_crf4b_27d" HeaderText="lw_crf4b_27d" />
                    <asp:BoundField DataField="lw_crf4b_27e" HeaderText="lw_crf4b_27e" />
                    <asp:BoundField DataField="lw_crf4b_27f" HeaderText="lw_crf4b_27f" />
                    <asp:BoundField DataField="lw_crf4b_28" HeaderText="lw_crf4b_28" />
                    <asp:BoundField DataField="lw_crf4b_29a" HeaderText="lw_crf4b_29a" />
                    <asp:BoundField DataField="lw_crf4b_29b" HeaderText="lw_crf4b_29b" />
                    <asp:BoundField DataField="lw_crf4b_29c" HeaderText="lw_crf4b_29c" />
                    <asp:BoundField DataField="lw_crf4b_29d" HeaderText="lw_crf4b_29d" />
                    <asp:BoundField DataField="lw_crf4b_29e" HeaderText="lw_crf4b_29e" />
                    <asp:BoundField DataField="lw_crf4b_29f" HeaderText="lw_crf4b_29f" />
                    <asp:BoundField DataField="lw_crf4b_30" HeaderText="lw_crf4b_30" />
                    <asp:BoundField DataField="lw_crf4b_31" HeaderText="lw_crf4b_31" />
                    <asp:BoundField DataField="lw_crf4b_32_hours" HeaderText="lw_crf4b_32_hours" />
                    <asp:BoundField DataField="lw_crf4b_32days" HeaderText="lw_crf4b_32days" />
                    <asp:BoundField DataField="lw_crf4b_33" HeaderText="lw_crf4b_33" />
                    <asp:BoundField DataField="lw_crf4b_34a" HeaderText="lw_crf4b_34a" />
                    <asp:BoundField DataField="lw_crf4b_34b" HeaderText="lw_crf4b_34b" />
                    <asp:BoundField DataField="lw_crf4b_35" HeaderText="lw_crf4b_35" />
                    <asp:BoundField DataField="lw_crf4b_36" HeaderText="lw_crf4b_36" />
                    <asp:BoundField DataField="lw_crf4b_37a" HeaderText="lw_crf4b_37a" />
                    <asp:BoundField DataField="lw_crf4b_37b" HeaderText="lw_crf4b_37b" />
                    <asp:BoundField DataField="lw_crf4b_38" HeaderText="lw_crf4b_38" />
                    <asp:BoundField DataField="lw_crf4b_39" HeaderText="lw_crf4b_39" />
                    <asp:BoundField DataField="lw_crf4b_40" HeaderText="lw_crf4b_40" />
                    <asp:BoundField DataField="lw_crf4b_41" HeaderText="lw_crf4b_41" />
                    <asp:BoundField DataField="lw_crf4b_42a" HeaderText="lw_crf4b_42a" />
                    <asp:BoundField DataField="lw_crf4b_42b1" HeaderText="lw_crf4b_42b1" />
                    <asp:BoundField DataField="lw_crf4b_42b2" HeaderText="lw_crf4b_42b2" />
                    <asp:BoundField DataField="lw_crf4b_42b3" HeaderText="lw_crf4b_42b3" />
                    <asp:BoundField DataField="lw_crf4b_42b4" HeaderText="lw_crf4b_42b4" />
                    <asp:BoundField DataField="lw_crf4b_43" HeaderText="lw_crf4b_43" />
                    <asp:BoundField DataField="lw_crf4b_44" HeaderText="lw_crf4b_44" />
                    <asp:BoundField DataField="lw_crf4b_45" HeaderText="lw_crf4b_45" />
                    <asp:BoundField DataField="lw_crf4b_46" HeaderText="lw_crf4b_46" />
                    <asp:BoundField DataField="lw_crf4b_47" HeaderText="lw_crf4b_47" />
                    <asp:BoundField DataField="lw_crf4b_48" HeaderText="lw_crf4b_48" />
                    <asp:BoundField DataField="lw_crf4b_49" HeaderText="lw_crf4b_49" />
                    <asp:BoundField DataField="lw_crf4b_50a" HeaderText="lw_crf4b_50a" />
                    <asp:BoundField DataField="lw_crf4b_50b" HeaderText="lw_crf4b_50b" />
                    <asp:BoundField DataField="lw_crf4b_50c" HeaderText="lw_crf4b_50c" />
                    <asp:BoundField DataField="lw_crf4b_50d" HeaderText="lw_crf4b_50d" />
                    <asp:BoundField DataField="lw_crf4b_50e" HeaderText="lw_crf4b_50e" />
                    <asp:BoundField DataField="lw_crf4b_50f" HeaderText="lw_crf4b_50f" />
                    <asp:BoundField DataField="lw_crf4b_50g" HeaderText="lw_crf4b_50g" />
                    <asp:BoundField DataField="lw_crf4b_50h" HeaderText="lw_crf4b_50h" />
                    <asp:BoundField DataField="lw_crf4b_50i" HeaderText="lw_crf4b_50i" />
                    <asp:BoundField DataField="lw_crf4b_50j" HeaderText="lw_crf4b_50j" />
                    <asp:BoundField DataField="lw_crf4b_50k" HeaderText="lw_crf4b_50k" />
                    <asp:BoundField DataField="lw_crf4b_50l" HeaderText="lw_crf4b_50l" />
                    <asp:BoundField DataField="lw_crf4b_50m" HeaderText="lw_crf4b_50m" />
                    <asp:BoundField DataField="lw_crf4b_50n" HeaderText="lw_crf4b_50n" />
                    <asp:BoundField DataField="lw_crf4b_50o" HeaderText="lw_crf4b_50o" />
                    <asp:BoundField DataField="lw_crf4b_50p" HeaderText="lw_crf4b_50p" />
                    <asp:BoundField DataField="lw_crf4b_50p_oth_1" HeaderText="lw_crf4b_50p_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_51" HeaderText="lw_crf4b_51" />
                    <asp:BoundField DataField="lw_crf4b_52" HeaderText="lw_crf4b_52" />
                    <asp:BoundField DataField="lw_crf4b_53" HeaderText="lw_crf4b_53" />
                    <asp:BoundField DataField="lw_crf4b_54" HeaderText="lw_crf4b_54" />
                    <asp:BoundField DataField="lw_crf4b_55a" HeaderText="lw_crf4b_55a" />
                    <asp:BoundField DataField="lw_crf4b_55b" HeaderText="lw_crf4b_55b" />
                    <asp:BoundField DataField="lw_crf4b_55c" HeaderText="lw_crf4b_55c" />
                    <asp:BoundField DataField="lw_crf4b_55d" HeaderText="lw_crf4b_55d" />
                    <asp:BoundField DataField="lw_crf4b_55e" HeaderText="lw_crf4b_55e" />
                    <asp:BoundField DataField="lw_crf4b_55f" HeaderText="lw_crf4b_55f" />
                    <asp:BoundField DataField="lw_crf4b_55g" HeaderText="lw_crf4b_55g" />
                    <asp:BoundField DataField="lw_crf4b_55h" HeaderText="lw_crf4b_55h" />
                    <asp:BoundField DataField="lw_crf4b_55i" HeaderText="lw_crf4b_55i" />
                    <asp:BoundField DataField="lw_crf4b_55j" HeaderText="lw_crf4b_55j" />
                    <asp:BoundField DataField="lw_crf4b_55k" HeaderText="lw_crf4b_55k" />
                    <asp:BoundField DataField="lw_crf4b_55l" HeaderText="lw_crf4b_55l" />
                    <asp:BoundField DataField="lw_crf4b_55l_oth_1" HeaderText="lw_crf4b_55l_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_56" HeaderText="lw_crf4b_56" />
                    <asp:BoundField DataField="name" HeaderText="name" />
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



            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="form_crf_4b_id" HeaderText="form_crf_4b_id" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followups Number" />
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="lw_crf4b_2" HeaderText="lw_crf4b_2" />
                    <asp:BoundField DataField="lw_crf4b_3" HeaderText="lw_crf4b_3" />
                    <asp:BoundField DataField="q10" HeaderText="q10" />
                    <asp:BoundField DataField="q11" HeaderText="q11" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="q19" HeaderText="q19" />
                    <asp:BoundField DataField="q19_Reason" HeaderText="q19_Reason" />
                    <asp:BoundField DataField="lw_crf4b_20" HeaderText="lw_crf4b_20" />
                    <asp:BoundField DataField="lw_crf4b_21a" HeaderText="lw_crf4b_21a" />
                    <asp:BoundField DataField="lw_crf4b_21b" HeaderText="lw_crf4b_21b" />
                    <asp:BoundField DataField="lw_crf4b_21c" HeaderText="lw_crf4b_21c" />
                    <asp:BoundField DataField="lw_crf4b_21d" HeaderText="lw_crf4b_21d" />
                    <asp:BoundField DataField="lw_crf4b_21e" HeaderText="lw_crf4b_21e" />
                    <asp:BoundField DataField="lw_crf4b_21f" HeaderText="lw_crf4b_21f" />
                    <asp:BoundField DataField="lw_crf4b_21g" HeaderText="lw_crf4b_21g" />
                    <asp:BoundField DataField="lw_crf4b_21h" HeaderText="lw_crf4b_21h" />
                    <asp:BoundField DataField="lw_crf4b_21i" HeaderText="lw_crf4b_21i" />
                    <asp:BoundField DataField="lw_crf4b_21j" HeaderText="lw_crf4b_21j" />
                    <asp:BoundField DataField="lw_crf4b_21k" HeaderText="lw_crf4b_21k" />
                    <asp:BoundField DataField="lw_crf4b_21l" HeaderText="lw_crf4b_21l" />
                    <asp:BoundField DataField="lw_crf4b_21m" HeaderText="lw_crf4b_21m" />
                    <asp:BoundField DataField="lw_crf4b_21n" HeaderText="lw_crf4b_21n" />
                    <asp:BoundField DataField="lw_crf4b_21o" HeaderText="lw_crf4b_21o" />
                    <asp:BoundField DataField="lw_crf4b_21p" HeaderText="lw_crf4b_21p" />
                    <asp:BoundField DataField="lw_crf4b_21q" HeaderText="lw_crf4b_21q" />
                    <asp:BoundField DataField="lw_crf4b_21r" HeaderText="lw_crf4b_21r" />
                    <asp:BoundField DataField="lw_crf4b_21s" HeaderText="lw_crf4b_21s" />
                    <asp:BoundField DataField="lw_crf4b_21t" HeaderText="lw_crf4b_21t" />
                    <asp:BoundField DataField="lw_crf4b_21u" HeaderText="lw_crf4b_21u" />
                    <asp:BoundField DataField="lw_crf4b_21v" HeaderText="lw_crf4b_21v" />
                    <asp:BoundField DataField="lw_crf4b_21w" HeaderText="lw_crf4b_21w" />
                    <asp:BoundField DataField="lw_crf4b_21x" HeaderText="lw_crf4b_21x" />
                    <asp:BoundField DataField="lw_crf4b_21y" HeaderText="lw_crf4b_21y" />
                    <asp:BoundField DataField="lw_crf4b_21z" HeaderText="lw_crf4b_21z" />
                    <asp:BoundField DataField="lw_crf4b_21z_oth_1" HeaderText="lw_crf4b_21z_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_22" HeaderText="lw_crf4b_22" />
                    <asp:BoundField DataField="lw_crf4b_23a" HeaderText="lw_crf4b_23a" />
                    <asp:BoundField DataField="lw_crf4b_23b" HeaderText="lw_crf4b_23b" />
                    <asp:BoundField DataField="lw_crf4b_23c" HeaderText="lw_crf4b_23c" />
                    <asp:BoundField DataField="lw_crf4b_23d" HeaderText="lw_crf4b_23d" />
                    <asp:BoundField DataField="lw_crf4b_23e" HeaderText="lw_crf4b_23e" />
                    <asp:BoundField DataField="lw_crf4b_23f" HeaderText="lw_crf4b_23f" />
                    <asp:BoundField DataField="lw_crf4b_23g" HeaderText="lw_crf4b_23g" />
                    <asp:BoundField DataField="lw_crf4b_23g_oth_1" HeaderText="lw_crf4b_23g_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_23h" HeaderText="lw_crf4b_23h" />
                    <asp:BoundField DataField="lw_crf4b_23i" HeaderText="lw_crf4b_23i" />
                    <asp:BoundField DataField="lw_crf4b_23j" HeaderText="lw_crf4b_23j" />
                    <asp:BoundField DataField="lw_crf4b_23k" HeaderText="lw_crf4b_23k" />
                    <asp:BoundField DataField="lw_crf4b_23l" HeaderText="lw_crf4b_23l" />
                    <asp:BoundField DataField="lw_crf4b_23m" HeaderText="lw_crf4b_23m" />
                    <asp:BoundField DataField="lw_crf4b_24" HeaderText="lw_crf4b_24" />
                    <asp:BoundField DataField="lw_crf4b_25a" HeaderText="lw_crf4b_25a" />
                    <asp:BoundField DataField="lw_crf4b_25b" HeaderText="lw_crf4b_25b" />
                    <asp:BoundField DataField="lw_crf4b_25c" HeaderText="lw_crf4b_25c" />
                    <asp:BoundField DataField="lw_crf4b_25d" HeaderText="lw_crf4b_25d" />
                    <asp:BoundField DataField="lw_crf4b_25e" HeaderText="lw_crf4b_25e" />
                    <asp:BoundField DataField="lw_crf4b_25f" HeaderText="lw_crf4b_25f" />
                    <asp:BoundField DataField="lw_crf4b_25g" HeaderText="lw_crf4b_25g" />
                    <asp:BoundField DataField="lw_crf4b_25h" HeaderText="lw_crf4b_25h" />
                    <asp:BoundField DataField="lw_crf4b_25i" HeaderText="lw_crf4b_25i" />
                    <asp:BoundField DataField="lw_crf4b_25i_oth_1" HeaderText="lw_crf4b_25i_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_26" HeaderText="lw_crf4b_26" />
                    <asp:BoundField DataField="lw_crf4b_27a" HeaderText="lw_crf4b_27a" />
                    <asp:BoundField DataField="lw_crf4b_27b" HeaderText="lw_crf4b_27b" />
                    <asp:BoundField DataField="lw_crf4b_27c" HeaderText="lw_crf4b_27c" />
                    <asp:BoundField DataField="lw_crf4b_27d" HeaderText="lw_crf4b_27d" />
                    <asp:BoundField DataField="lw_crf4b_27e" HeaderText="lw_crf4b_27e" />
                    <asp:BoundField DataField="lw_crf4b_27f" HeaderText="lw_crf4b_27f" />
                    <asp:BoundField DataField="lw_crf4b_28" HeaderText="lw_crf4b_28" />
                    <asp:BoundField DataField="lw_crf4b_29a" HeaderText="lw_crf4b_29a" />
                    <asp:BoundField DataField="lw_crf4b_29b" HeaderText="lw_crf4b_29b" />
                    <asp:BoundField DataField="lw_crf4b_29c" HeaderText="lw_crf4b_29c" />
                    <asp:BoundField DataField="lw_crf4b_29d" HeaderText="lw_crf4b_29d" />
                    <asp:BoundField DataField="lw_crf4b_29e" HeaderText="lw_crf4b_29e" />
                    <asp:BoundField DataField="lw_crf4b_29f" HeaderText="lw_crf4b_29f" />
                    <asp:BoundField DataField="lw_crf4b_30" HeaderText="lw_crf4b_30" />
                    <asp:BoundField DataField="lw_crf4b_31" HeaderText="lw_crf4b_31" />
                    <asp:BoundField DataField="lw_crf4b_32_hours" HeaderText="lw_crf4b_32_hours" />
                    <asp:BoundField DataField="lw_crf4b_32days" HeaderText="lw_crf4b_32days" />
                    <asp:BoundField DataField="lw_crf4b_33" HeaderText="lw_crf4b_33" />
                    <asp:BoundField DataField="lw_crf4b_34a" HeaderText="lw_crf4b_34a" />
                    <asp:BoundField DataField="lw_crf4b_34b" HeaderText="lw_crf4b_34b" />
                    <asp:BoundField DataField="lw_crf4b_35" HeaderText="lw_crf4b_35" />
                    <asp:BoundField DataField="lw_crf4b_36" HeaderText="lw_crf4b_36" />
                    <asp:BoundField DataField="lw_crf4b_37a" HeaderText="lw_crf4b_37a" />
                    <asp:BoundField DataField="lw_crf4b_37b" HeaderText="lw_crf4b_37b" />
                    <asp:BoundField DataField="lw_crf4b_38" HeaderText="lw_crf4b_38" />
                    <asp:BoundField DataField="lw_crf4b_39" HeaderText="lw_crf4b_39" />
                    <asp:BoundField DataField="lw_crf4b_40" HeaderText="lw_crf4b_40" />
                    <asp:BoundField DataField="lw_crf4b_41" HeaderText="lw_crf4b_41" />
                    <asp:BoundField DataField="lw_crf4b_42a" HeaderText="lw_crf4b_42a" />
                    <asp:BoundField DataField="lw_crf4b_42b1" HeaderText="lw_crf4b_42b1" />
                    <asp:BoundField DataField="lw_crf4b_42b2" HeaderText="lw_crf4b_42b2" />
                    <asp:BoundField DataField="lw_crf4b_42b3" HeaderText="lw_crf4b_42b3" />
                    <asp:BoundField DataField="lw_crf4b_42b4" HeaderText="lw_crf4b_42b4" />
                    <asp:BoundField DataField="lw_crf4b_43" HeaderText="lw_crf4b_43" />
                    <asp:BoundField DataField="lw_crf4b_44" HeaderText="lw_crf4b_44" />
                    <asp:BoundField DataField="lw_crf4b_45" HeaderText="lw_crf4b_45" />
                    <asp:BoundField DataField="lw_crf4b_46" HeaderText="lw_crf4b_46" />
                    <asp:BoundField DataField="lw_crf4b_47" HeaderText="lw_crf4b_47" />
                    <asp:BoundField DataField="lw_crf4b_48" HeaderText="lw_crf4b_48" />
                    <asp:BoundField DataField="lw_crf4b_49" HeaderText="lw_crf4b_49" />
                    <asp:BoundField DataField="lw_crf4b_50a" HeaderText="lw_crf4b_50a" />
                    <asp:BoundField DataField="lw_crf4b_50b" HeaderText="lw_crf4b_50b" />
                    <asp:BoundField DataField="lw_crf4b_50c" HeaderText="lw_crf4b_50c" />
                    <asp:BoundField DataField="lw_crf4b_50d" HeaderText="lw_crf4b_50d" />
                    <asp:BoundField DataField="lw_crf4b_50e" HeaderText="lw_crf4b_50e" />
                    <asp:BoundField DataField="lw_crf4b_50f" HeaderText="lw_crf4b_50f" />
                    <asp:BoundField DataField="lw_crf4b_50g" HeaderText="lw_crf4b_50g" />
                    <asp:BoundField DataField="lw_crf4b_50h" HeaderText="lw_crf4b_50h" />
                    <asp:BoundField DataField="lw_crf4b_50i" HeaderText="lw_crf4b_50i" />
                    <asp:BoundField DataField="lw_crf4b_50j" HeaderText="lw_crf4b_50j" />
                    <asp:BoundField DataField="lw_crf4b_50k" HeaderText="lw_crf4b_50k" />
                    <asp:BoundField DataField="lw_crf4b_50l" HeaderText="lw_crf4b_50l" />
                    <asp:BoundField DataField="lw_crf4b_50m" HeaderText="lw_crf4b_50m" />
                    <asp:BoundField DataField="lw_crf4b_50n" HeaderText="lw_crf4b_50n" />
                    <asp:BoundField DataField="lw_crf4b_50o" HeaderText="lw_crf4b_50o" />
                    <asp:BoundField DataField="lw_crf4b_50p" HeaderText="lw_crf4b_50p" />
                    <asp:BoundField DataField="lw_crf4b_50p_oth_1" HeaderText="lw_crf4b_50p_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_51" HeaderText="lw_crf4b_51" />
                    <asp:BoundField DataField="lw_crf4b_52" HeaderText="lw_crf4b_52" />
                    <asp:BoundField DataField="lw_crf4b_53" HeaderText="lw_crf4b_53" />
                    <asp:BoundField DataField="lw_crf4b_54" HeaderText="lw_crf4b_54" />
                    <asp:BoundField DataField="lw_crf4b_55a" HeaderText="lw_crf4b_55a" />
                    <asp:BoundField DataField="lw_crf4b_55b" HeaderText="lw_crf4b_55b" />
                    <asp:BoundField DataField="lw_crf4b_55c" HeaderText="lw_crf4b_55c" />
                    <asp:BoundField DataField="lw_crf4b_55d" HeaderText="lw_crf4b_55d" />
                    <asp:BoundField DataField="lw_crf4b_55e" HeaderText="lw_crf4b_55e" />
                    <asp:BoundField DataField="lw_crf4b_55f" HeaderText="lw_crf4b_55f" />
                    <asp:BoundField DataField="lw_crf4b_55g" HeaderText="lw_crf4b_55g" />
                    <asp:BoundField DataField="lw_crf4b_55h" HeaderText="lw_crf4b_55h" />
                    <asp:BoundField DataField="lw_crf4b_55i" HeaderText="lw_crf4b_55i" />
                    <asp:BoundField DataField="lw_crf4b_55j" HeaderText="lw_crf4b_55j" />
                    <asp:BoundField DataField="lw_crf4b_55k" HeaderText="lw_crf4b_55k" />
                    <asp:BoundField DataField="lw_crf4b_55l" HeaderText="lw_crf4b_55l" />
                    <asp:BoundField DataField="lw_crf4b_55l_oth_1" HeaderText="lw_crf4b_55l_oth_1" />
                    <asp:BoundField DataField="lw_crf4b_56" HeaderText="lw_crf4b_56" />
                    <asp:BoundField DataField="name" HeaderText="name" />
                </Columns>

            </asp:GridView>



            <%--For BMGF Export --%>
            <asp:GridView ID="GridViewBMFG" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
            </asp:GridView>


        </div>
    </div>
</asp:Content>
