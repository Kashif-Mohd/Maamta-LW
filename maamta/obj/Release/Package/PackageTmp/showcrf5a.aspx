<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf5a.aspx.cs" Inherits="maamta.showcrf5a" %>
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
            MAAMTA Compliance:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
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
                    <asp:BoundField DataField="age" HeaderText="Age" />
                    <asp:TemplateField HeaderText="Study ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudy" OnClick="Link_Study" Text='<%#Eval("study_code") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_5a_id")+","+ Eval("study_code")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="lw_crf5a_02" HeaderText="lw_crf5a_02" />
                    <asp:BoundField DataField="lw_crf5a_03" HeaderText="lw_crf5a_03" />
                    <asp:BoundField DataField="q10" HeaderText="q10" />
                    <asp:BoundField DataField="q11" HeaderText="q11" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="arm" HeaderText="ARM" />

                    <asp:BoundField DataField="lw_crf5a_26" HeaderText="lw_crf5a_26" />
                    <asp:BoundField DataField="lw_crf5a_27" HeaderText="lw_crf5a_27" />
                    <asp:BoundField DataField="lw_crf5a_28" HeaderText="lw_crf5a_28" />
                    <asp:BoundField DataField="lw_crf5a_29" HeaderText="lw_crf5a_29" />
                    <asp:BoundField DataField="lw_crf5a_30" HeaderText="lw_crf5a_30" />
                    <asp:BoundField DataField="lw_crf5a_31" HeaderText="lw_crf5a_31" />
                    <asp:BoundField DataField="lw_crf5a_32" HeaderText="lw_crf5a_32" />
                    <asp:BoundField DataField="lw_crf5a_33" HeaderText="lw_crf5a_33" />
                    <asp:BoundField DataField="lw_crf5a_34" HeaderText="lw_crf5a_34" />
                    <asp:BoundField DataField="lw_crf5a_35a" HeaderText="lw_crf5a_35a" />
                    <asp:BoundField DataField="lw_crf5a_35b" HeaderText="lw_crf5a_35b" />
                    <asp:BoundField DataField="lw_crf5a_35c" HeaderText="lw_crf5a_35c" />
                    <asp:BoundField DataField="lw_crf5a_35d" HeaderText="lw_crf5a_35d" />
                    <asp:BoundField DataField="lw_crf5a_35e" HeaderText="lw_crf5a_35e" />
                    <asp:BoundField DataField="lw_crf5a_35f" HeaderText="lw_crf5a_35f" />
                    <asp:BoundField DataField="lw_crf5a_35g" HeaderText="lw_crf5a_35g" />
                    <asp:BoundField DataField="lw_crf5a_35h" HeaderText="lw_crf5a_35h" />
                    <asp:BoundField DataField="lw_crf5a_35h_oth_1" HeaderText="lw_crf5a_35h_oth_1" />
                    <asp:BoundField DataField="lw_crf5a_36" HeaderText="lw_crf5a_36" />
                    <asp:BoundField DataField="lw_crf5a_37a" HeaderText="lw_crf5a_37a" />
                    <asp:BoundField DataField="lw_crf5a_37b" HeaderText="lw_crf5a_37b" />
                    <asp:BoundField DataField="lw_crf5a_37c" HeaderText="lw_crf5a_37c" />
                    <asp:BoundField DataField="lw_crf5a_37d" HeaderText="lw_crf5a_37d" />
                    <asp:BoundField DataField="lw_crf5a_37e" HeaderText="lw_crf5a_37e" />
                    <asp:BoundField DataField="lw_crf5a_37e_oth_1" HeaderText="lw_crf5a_37e_oth_1" />
                    <asp:BoundField DataField="lw_crf5a_38a" HeaderText="lw_crf5a_38a" />
                    <asp:BoundField DataField="lw_crf5a_38b" HeaderText="lw_crf5a_38b" />
                    <asp:BoundField DataField="lw_crf5a_38c" HeaderText="lw_crf5a_38c" />
                    <asp:BoundField DataField="lw_crf5a_38d" HeaderText="lw_crf5a_38d" />
                    <asp:BoundField DataField="lw_crf5a_38e" HeaderText="lw_crf5a_38e" />
                    <asp:BoundField DataField="lw_crf5a_38f" HeaderText="lw_crf5a_38f" />
                    <asp:BoundField DataField="lw_crf5a_38g" HeaderText="lw_crf5a_38g" />
                    <asp:BoundField DataField="lw_crf5a_38h" HeaderText="lw_crf5a_38h" />
                    <asp:BoundField DataField="lw_crf5a_38i" HeaderText="lw_crf5a_38i" />
                    <asp:BoundField DataField="lw_crf5a_38j" HeaderText="lw_crf5a_38j" />
                    <asp:BoundField DataField="lw_crf5a_38k" HeaderText="lw_crf5a_38k" />
                    <asp:BoundField DataField="lw_crf5a_38k_oth_1" HeaderText="lw_crf5a_38k_oth_1" />
                    <asp:BoundField DataField="lw_crf5a_39" HeaderText="lw_crf5a_39" />
                    <asp:BoundField DataField="lw_crf5a_40" HeaderText="lw_crf5a_40" />
                    <asp:BoundField DataField="lw_crf5a_41" HeaderText="lw_crf5a_41" />
                    <asp:BoundField DataField="lw_crf5a_42" HeaderText="lw_crf5a_42" />
                    <asp:BoundField DataField="lw_crf5a_43" HeaderText="lw_crf5a_43" />
                    <asp:BoundField DataField="lw_crf5a_44" HeaderText="lw_crf5a_44" />
                    <asp:BoundField DataField="lw_crf5a_45a" HeaderText="lw_crf5a_45a" />
                    <asp:BoundField DataField="lw_crf5a_45b" HeaderText="lw_crf5a_45b" />
                    <asp:BoundField DataField="lw_crf5a_45v" HeaderText="lw_crf5a_45c" />
                    <asp:BoundField DataField="lw_crf5a_45d" HeaderText="lw_crf5a_45d" />
                    <asp:BoundField DataField="lw_crf5a_45e" HeaderText="lw_crf5a_45e" />
                    <asp:BoundField DataField="lw_crf5a_45f" HeaderText="lw_crf5a_45f" />
                    <asp:BoundField DataField="lw_crf5a_46" HeaderText="lw_crf5a_46" />
                    <asp:BoundField DataField="lw_crf5a_47a" HeaderText="lw_crf5a_47a" />
                    <asp:BoundField DataField="lw_crf5a_47b" HeaderText="lw_crf5a_47b" />
                    <asp:BoundField DataField="lw_crf5a_47c" HeaderText="lw_crf5a_47c" />
                    <asp:BoundField DataField="lw_crf5a_47d" HeaderText="lw_crf5a_47d" />
                    <asp:BoundField DataField="lw_crf5a_47e" HeaderText="lw_crf5a_47e" />
                    <asp:BoundField DataField="lw_crf5a_47f" HeaderText="lw_crf5a_47f" />
                    <asp:BoundField DataField="lw_crf5a_48" HeaderText="lw_crf5a_48" />
                    <asp:BoundField DataField="lw_crf5a_49" HeaderText="lw_crf5a_49" />
                    <asp:BoundField DataField="lw_crf5a_50" HeaderText="lw_crf5a_50" />
                    <asp:BoundField DataField="lw_crf5a_51" HeaderText="lw_crf5a_51" />
                    <asp:BoundField DataField="lw_crf5a_52" HeaderText="lw_crf5a_52" />
                    <asp:BoundField DataField="lw_crf5a_53" HeaderText="lw_crf5a_53" />
                    <asp:BoundField DataField="lw_crf5a_54a" HeaderText="lw_crf5a_54a" />
                    <asp:BoundField DataField="lw_crf5a_54b" HeaderText="lw_crf5a_54b" />
                    <asp:BoundField DataField="lw_crf5a_55" HeaderText="lw_crf5a_55" />
                    <asp:BoundField DataField="lw_crf5a_56" HeaderText="lw_crf5a_56" />
                    <asp:BoundField DataField="lw_crf5a_57" HeaderText="lw_crf5a_57" />
                    <asp:BoundField DataField="lw_crf5a_58" HeaderText="lw_crf5a_58" />
                    <asp:BoundField DataField="lw_crf5a_60" HeaderText="lw_crf5a_60" />
                    <asp:BoundField DataField="counsil_start_time" HeaderText="start_counsil" />
                    <asp:BoundField DataField="counsil_end_time" HeaderText="end_counsil" />

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
                    <asp:BoundField DataField="form_crf_5a_id" HeaderText="form_crf_5a_id" />
                    <asp:BoundField DataField="followup_num" HeaderText="followup_num" />
                    <asp:BoundField DataField="age" HeaderText="Age" />
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="lw_crf5a_02" HeaderText="lw_crf5a_02" />
                    <asp:BoundField DataField="lw_crf5a_03" HeaderText="lw_crf5a_03" />
                    <asp:BoundField DataField="q10" HeaderText="q10" />
                    <asp:BoundField DataField="q11" HeaderText="q11" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="arm" HeaderText="ARM" />

                    <asp:BoundField DataField="lw_crf5a_26" HeaderText="lw_crf5a_26" />
                    <asp:BoundField DataField="lw_crf5a_27" HeaderText="lw_crf5a_27" />
                    <asp:BoundField DataField="lw_crf5a_28" HeaderText="lw_crf5a_28" />
                    <asp:BoundField DataField="lw_crf5a_29" HeaderText="lw_crf5a_29" />
                    <asp:BoundField DataField="lw_crf5a_30" HeaderText="lw_crf5a_30" />
                    <asp:BoundField DataField="lw_crf5a_31" HeaderText="lw_crf5a_31" />
                    <asp:BoundField DataField="lw_crf5a_32" HeaderText="lw_crf5a_32" />
                    <asp:BoundField DataField="lw_crf5a_33" HeaderText="lw_crf5a_33" />
                    <asp:BoundField DataField="lw_crf5a_34" HeaderText="lw_crf5a_34" />
                    <asp:BoundField DataField="lw_crf5a_35a" HeaderText="lw_crf5a_35a" />
                    <asp:BoundField DataField="lw_crf5a_35b" HeaderText="lw_crf5a_35b" />
                    <asp:BoundField DataField="lw_crf5a_35c" HeaderText="lw_crf5a_35c" />
                    <asp:BoundField DataField="lw_crf5a_35d" HeaderText="lw_crf5a_35d" />
                    <asp:BoundField DataField="lw_crf5a_35e" HeaderText="lw_crf5a_35e" />
                    <asp:BoundField DataField="lw_crf5a_35f" HeaderText="lw_crf5a_35f" />
                    <asp:BoundField DataField="lw_crf5a_35g" HeaderText="lw_crf5a_35g" />
                    <asp:BoundField DataField="lw_crf5a_35h" HeaderText="lw_crf5a_35h" />
                    <asp:BoundField DataField="lw_crf5a_35h_oth_1" HeaderText="lw_crf5a_35h_oth_1" />
                    <asp:BoundField DataField="lw_crf5a_36" HeaderText="lw_crf5a_36" />
                    <asp:BoundField DataField="lw_crf5a_37a" HeaderText="lw_crf5a_37a" />
                    <asp:BoundField DataField="lw_crf5a_37b" HeaderText="lw_crf5a_37b" />
                    <asp:BoundField DataField="lw_crf5a_37c" HeaderText="lw_crf5a_37c" />
                    <asp:BoundField DataField="lw_crf5a_37d" HeaderText="lw_crf5a_37d" />
                    <asp:BoundField DataField="lw_crf5a_37e" HeaderText="lw_crf5a_37e" />
                    <asp:BoundField DataField="lw_crf5a_37e_oth_1" HeaderText="lw_crf5a_37e_oth_1" />
                    <asp:BoundField DataField="lw_crf5a_38a" HeaderText="lw_crf5a_38a" />
                    <asp:BoundField DataField="lw_crf5a_38b" HeaderText="lw_crf5a_38b" />
                    <asp:BoundField DataField="lw_crf5a_38c" HeaderText="lw_crf5a_38c" />
                    <asp:BoundField DataField="lw_crf5a_38d" HeaderText="lw_crf5a_38d" />
                    <asp:BoundField DataField="lw_crf5a_38e" HeaderText="lw_crf5a_38e" />
                    <asp:BoundField DataField="lw_crf5a_38f" HeaderText="lw_crf5a_38f" />
                    <asp:BoundField DataField="lw_crf5a_38g" HeaderText="lw_crf5a_38g" />
                    <asp:BoundField DataField="lw_crf5a_38h" HeaderText="lw_crf5a_38h" />
                    <asp:BoundField DataField="lw_crf5a_38i" HeaderText="lw_crf5a_38i" />
                    <asp:BoundField DataField="lw_crf5a_38j" HeaderText="lw_crf5a_38j" />
                    <asp:BoundField DataField="lw_crf5a_38k" HeaderText="lw_crf5a_38k" />
                    <asp:BoundField DataField="lw_crf5a_38k_oth_1" HeaderText="lw_crf5a_38k_oth_1" />
                    <asp:BoundField DataField="lw_crf5a_39" HeaderText="lw_crf5a_39" />
                    <asp:BoundField DataField="lw_crf5a_40" HeaderText="lw_crf5a_40" />
                    <asp:BoundField DataField="lw_crf5a_41" HeaderText="lw_crf5a_41" />
                    <asp:BoundField DataField="lw_crf5a_42" HeaderText="lw_crf5a_42" />
                    <asp:BoundField DataField="lw_crf5a_43" HeaderText="lw_crf5a_43" />
                    <asp:BoundField DataField="lw_crf5a_44" HeaderText="lw_crf5a_44" />
                    <asp:BoundField DataField="lw_crf5a_45a" HeaderText="lw_crf5a_45a" />
                    <asp:BoundField DataField="lw_crf5a_45b" HeaderText="lw_crf5a_45b" />
                    <asp:BoundField DataField="lw_crf5a_45v" HeaderText="lw_crf5a_45c" />
                    <asp:BoundField DataField="lw_crf5a_45d" HeaderText="lw_crf5a_45d" />
                    <asp:BoundField DataField="lw_crf5a_45e" HeaderText="lw_crf5a_45e" />
                    <asp:BoundField DataField="lw_crf5a_45f" HeaderText="lw_crf5a_45f" />
                    <asp:BoundField DataField="lw_crf5a_46" HeaderText="lw_crf5a_46" />
                    <asp:BoundField DataField="lw_crf5a_47a" HeaderText="lw_crf5a_47a" />
                    <asp:BoundField DataField="lw_crf5a_47b" HeaderText="lw_crf5a_47b" />
                    <asp:BoundField DataField="lw_crf5a_47c" HeaderText="lw_crf5a_47c" />
                    <asp:BoundField DataField="lw_crf5a_47d" HeaderText="lw_crf5a_47d" />
                    <asp:BoundField DataField="lw_crf5a_47e" HeaderText="lw_crf5a_47e" />
                    <asp:BoundField DataField="lw_crf5a_47f" HeaderText="lw_crf5a_47f" />
                    <asp:BoundField DataField="lw_crf5a_48" HeaderText="lw_crf5a_48" />
                    <asp:BoundField DataField="lw_crf5a_49" HeaderText="lw_crf5a_49" />
                    <asp:BoundField DataField="lw_crf5a_50" HeaderText="lw_crf5a_50" />
                    <asp:BoundField DataField="lw_crf5a_51" HeaderText="lw_crf5a_51" />
                    <asp:BoundField DataField="lw_crf5a_52" HeaderText="lw_crf5a_52" />
                    <asp:BoundField DataField="lw_crf5a_53" HeaderText="lw_crf5a_53" />
                    <asp:BoundField DataField="lw_crf5a_54a" HeaderText="lw_crf5a_54a" />
                    <asp:BoundField DataField="lw_crf5a_54b" HeaderText="lw_crf5a_54b" />
                    <asp:BoundField DataField="lw_crf5a_55" HeaderText="lw_crf5a_55" />
                    <asp:BoundField DataField="lw_crf5a_56" HeaderText="lw_crf5a_56" />
                    <asp:BoundField DataField="lw_crf5a_57" HeaderText="lw_crf5a_57" />
                    <asp:BoundField DataField="lw_crf5a_58" HeaderText="lw_crf5a_58" />
                    <asp:BoundField DataField="lw_crf5a_60" HeaderText="lw_crf5a_60" />
                    <asp:BoundField DataField="counsil_start_time" HeaderText="start_counsil" />
                    <asp:BoundField DataField="counsil_end_time" HeaderText="end_counsil" />
                    <asp:BoundField DataField="name" HeaderText="name" />
                </Columns>

              
            </asp:GridView>
        </div>
    </div>
</asp:Content>
