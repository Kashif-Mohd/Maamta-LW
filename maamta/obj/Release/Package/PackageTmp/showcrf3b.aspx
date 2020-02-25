<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf3b.aspx.cs" Inherits="maamta.showcrf3b" %>

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
            BASELINE INFORMATION AND OUTCOME ASSESSMENT FORM:
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
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="form_crf_3b_id" HeaderText="crf3b_id" />
                    <asp:BoundField DataField="assis_id" HeaderText="Assisment ID" />
                    <asp:TemplateField HeaderText="Study-ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudyID" OnClick="Link_StudyID" Text='<%#Eval("study_code") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_3b_id")+","+ Eval("study_code")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lw_crf3b_2" HeaderText="lw_crf3b_2" />
                    <asp:BoundField DataField="lw_crf3b_3" HeaderText="lw_crf3b_3" />
                    <asp:BoundField DataField="lw_crf3b_4" HeaderText="lw_crf3b_4" />
                    <asp:BoundField DataField="q5" HeaderText="q5" />
                    <asp:BoundField DataField="q6" HeaderText="q6" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="lw_crf3b_13" HeaderText="lw_crf3b_13" />
                    <asp:BoundField DataField="lw_crf3b_13_oth_1" HeaderText="lw_crf3b_13_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_14" HeaderText="lw_crf3b_14" />
                    <asp:BoundField DataField="lw_crf3b_15" HeaderText="lw_crf3b_15" />
                    <asp:BoundField DataField="lw_crf3b_16" HeaderText="lw_crf3b_16" />
                    <asp:BoundField DataField="lw_crf3b_17" HeaderText="lw_crf3b_17" />
                    <asp:BoundField DataField="lw_crf3b_18" HeaderText="lw_crf3b_18" />
                    <asp:BoundField DataField="lw_crf3b_18_oth_1" HeaderText="lw_crf3b_18_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_19" HeaderText="lw_crf3b_19" />
                    <asp:BoundField DataField="lw_crf3b_20" HeaderText="lw_crf3b_20" />
                    <asp:BoundField DataField="lw_crf3b_20_oth_1" HeaderText="lw_crf3b_20_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_21" HeaderText="lw_crf3b_21" />
                    <asp:BoundField DataField="lw_crf3b_22" HeaderText="lw_crf3b_22" />
                    <asp:BoundField DataField="lw_crf3b_23" HeaderText="lw_crf3b_23" />
                    <asp:BoundField DataField="lw_crf3b_24" HeaderText="lw_crf3b_24" />
                    <asp:BoundField DataField="lw_crf3b_25" HeaderText="lw_crf3b_25" />
                    <asp:BoundField DataField="lw_crf3b_26" HeaderText="lw_crf3b_26" />
                    <asp:BoundField DataField="lw_crf3b_27" HeaderText="lw_crf3b_27" />
                    <asp:BoundField DataField="lw_crf3b_28" HeaderText="lw_crf3b_28" />
                    <asp:BoundField DataField="lw_crf3b_29a" HeaderText="lw_crf3b_29a" />
                    <asp:BoundField DataField="lw_crf3b_29b" HeaderText="lw_crf3b_29b" />
                    <asp:BoundField DataField="lw_crf3b_29c" HeaderText="lw_crf3b_29c" />
                    <asp:BoundField DataField="lw_crf3b_29d" HeaderText="lw_crf3b_29d" />
                    <asp:BoundField DataField="lw_crf3b_29e" HeaderText="lw_crf3b_29e" />
                    <asp:BoundField DataField="lw_crf3b_29e_oth_1" HeaderText="lw_crf3b_29e_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_30" HeaderText="lw_crf3b_30" />
                    <asp:BoundField DataField="lw_crf3b_31" HeaderText="lw_crf3b_31" />
                    <asp:BoundField DataField="lw_crf3b_31_oth_1" HeaderText="lw_crf3b_31_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_32" HeaderText="lw_crf3b_32" />
                    <asp:BoundField DataField="lw_crf3b_33" HeaderText="lw_crf3b_33" />
                    <asp:BoundField DataField="lw_crf3b_34" HeaderText="lw_crf3b_34" />
                    <asp:BoundField DataField="lw_crf3b_35" HeaderText="lw_crf3b_35" />
                    <asp:BoundField DataField="lw_crf3b_36a" HeaderText="lw_crf3b_36a" />
                    <asp:BoundField DataField="lw_crf3b_36b" HeaderText="lw_crf3b_36b" />
                    <asp:BoundField DataField="lw_crf3b_36c" HeaderText="lw_crf3b_36c" />
                    <asp:BoundField DataField="lw_crf3b_36d" HeaderText="lw_crf3b_36d" />
                    <asp:BoundField DataField="lw_crf3b_36e" HeaderText="lw_crf3b_36e" />
                    <asp:BoundField DataField="lw_crf3b_36f" HeaderText="lw_crf3b_36f" />
                    <asp:BoundField DataField="lw_crf3b_36g" HeaderText="lw_crf3b_36g" />
                    <asp:BoundField DataField="lw_crf3b_36h" HeaderText="lw_crf3b_36h" />
                    <asp:BoundField DataField="lw_crf3b_36i" HeaderText="lw_crf3b_36i" />
                    <asp:BoundField DataField="lw_crf3b_36j" HeaderText="lw_crf3b_36j" />
                    <asp:BoundField DataField="lw_crf3b_36k" HeaderText="lw_crf3b_36k" />
                    <asp:BoundField DataField="lw_crf3b_36l" HeaderText="lw_crf3b_36l" />
                    <asp:BoundField DataField="lw_crf3b_36m" HeaderText="lw_crf3b_36m" />
                    <asp:BoundField DataField="lw_crf3b_36n" HeaderText="lw_crf3b_36n" />
                    <asp:BoundField DataField="lw_crf3b_36o" HeaderText="lw_crf3b_36o" />
                    <asp:BoundField DataField="lw_crf3b_36p" HeaderText="lw_crf3b_36p" />
                    <asp:BoundField DataField="lw_crf3b_36q" HeaderText="lw_crf3b_36q" />
                    <asp:BoundField DataField="lw_crf3b_36r" HeaderText="lw_crf3b_36r" />
                    <asp:BoundField DataField="lw_crf3b_36s" HeaderText="lw_crf3b_36s" />
                    <asp:BoundField DataField="lw_crf3b_36t" HeaderText="lw_crf3b_36t" />
                    <asp:BoundField DataField="lw_crf3b_36u" HeaderText="lw_crf3b_36u" />
                    <asp:BoundField DataField="lw_crf3b_36v" HeaderText="lw_crf3b_36v" />
                    <asp:BoundField DataField="lw_crf3b_36w" HeaderText="lw_crf3b_36w" />
                    <asp:BoundField DataField="lw_crf3b_36x" HeaderText="lw_crf3b_36x" />
                    <asp:BoundField DataField="lw_crf3b_36y" HeaderText="lw_crf3b_36y" />
                    <asp:BoundField DataField="lw_crf3b_36y_oth_1" HeaderText="lw_crf3b_36y_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_37" HeaderText="lw_crf3b_37" />
                    <asp:BoundField DataField="lw_crf3b_38" HeaderText="lw_crf3b_38" />
                    <asp:BoundField DataField="lw_crf3b_38_oth_1" HeaderText="lw_crf3b_38_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_39a" HeaderText="lw_crf3b_39a" />
                    <asp:BoundField DataField="lw_crf3b_39b" HeaderText="lw_crf3b_39b" />
                    <asp:BoundField DataField="lw_crf3b_39c" HeaderText="lw_crf3b_39c" />
                    <asp:BoundField DataField="lw_crf3b_39d" HeaderText="lw_crf3b_39d" />
                    <asp:BoundField DataField="lw_crf3b_39e" HeaderText="lw_crf3b_39e" />
                    <asp:BoundField DataField="lw_crf3b_39f" HeaderText="lw_crf3b_39f" />
                    <asp:BoundField DataField="lw_crf3b_39g" HeaderText="lw_crf3b_39g" />
                    <asp:BoundField DataField="lw_crf3b_39h" HeaderText="lw_crf3b_39h" />
                    <asp:BoundField DataField="lw_crf3b_39i" HeaderText="lw_crf3b_39i" />
                    <asp:BoundField DataField="lw_crf3b_39j" HeaderText="lw_crf3b_39j" />
                    <asp:BoundField DataField="lw_crf3b_39j_oth_1" HeaderText="lw_crf3b_39j_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_40a" HeaderText="lw_crf3b_40a" />
                    <asp:BoundField DataField="lw_crf3b_40b" HeaderText="lw_crf3b_40b" />
                    <asp:BoundField DataField="lw_crf3b_40c" HeaderText="lw_crf3b_40c" />
                    <asp:BoundField DataField="lw_crf3b_40d" HeaderText="lw_crf3b_40d" />
                    <asp:BoundField DataField="lw_crf3b_40e" HeaderText="lw_crf3b_40e" />
                    <asp:BoundField DataField="lw_crf3b_40f" HeaderText="lw_crf3b_40f" />
                    <asp:BoundField DataField="lw_crf3b_40g" HeaderText="lw_crf3b_40g" />
                    <asp:BoundField DataField="lw_crf3b_40h" HeaderText="lw_crf3b_40h" />
                    <asp:BoundField DataField="lw_crf3b_40i" HeaderText="lw_crf3b_40i" />
                    <asp:BoundField DataField="lw_crf3b_40j" HeaderText="lw_crf3b_40j" />
                    <asp:BoundField DataField="lw_crf3b_40k" HeaderText="lw_crf3b_40k" />
                    <asp:BoundField DataField="lw_crf3b_40l" HeaderText="lw_crf3b_40l" />
                    <asp:BoundField DataField="lw_crf3b_40m" HeaderText="lw_crf3b_40m" />
                    <asp:BoundField DataField="lw_crf3b_40n" HeaderText="lw_crf3b_40n" />
                    <asp:BoundField DataField="lw_crf3b_40o" HeaderText="lw_crf3b_40o" />
                    <asp:BoundField DataField="lw_crf3b_40p" HeaderText="lw_crf3b_40p" />
                    <asp:BoundField DataField="lw_crf3b_40q" HeaderText="lw_crf3b_40q" />
                    <asp:BoundField DataField="lw_crf3b_40r" HeaderText="lw_crf3b_40r" />
                    <asp:BoundField DataField="lw_crf3b_40r_oth_1" HeaderText="lw_crf3b_40r_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_41" HeaderText="lw_crf3b_41" />
                    <asp:BoundField DataField="lw_crf3b_42" HeaderText="lw_crf3b_42" />
                    <asp:BoundField DataField="lw_crf3b_42_oth_1" HeaderText="lw_crf3b_42_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_43a" HeaderText="lw_crf3b_43a" />
                    <asp:BoundField DataField="lw_crf3b_43b" HeaderText="lw_crf3b_43b" />
                    <asp:BoundField DataField="lw_crf3b_43c" HeaderText="lw_crf3b_43c" />
                    <asp:BoundField DataField="lw_crf3b_43d" HeaderText="lw_crf3b_43d" />
                    <asp:BoundField DataField="lw_crf3b_43e" HeaderText="lw_crf3b_43e" />
                    <asp:BoundField DataField="lw_crf3b_43f" HeaderText="lw_crf3b_43f" />
                    <asp:BoundField DataField="lw_crf3b_43g" HeaderText="lw_crf3b_43g" />
                    <asp:BoundField DataField="lw_crf3b_43h" HeaderText="lw_crf3b_43h" />
                    <asp:BoundField DataField="lw_crf3b_43i" HeaderText="lw_crf3b_43i" />
                    <asp:BoundField DataField="lw_crf3b_43j" HeaderText="lw_crf3b_43j" />
                    <asp:BoundField DataField="lw_crf3b_43k" HeaderText="lw_crf3b_43k" />
                    <asp:BoundField DataField="lw_crf3b_43k_oth_1" HeaderText="lw_crf3b_43k_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_44" HeaderText="lw_crf3b_44" />
                    <asp:BoundField DataField="lw_crf3b_45" HeaderText="lw_crf3b_45" />
                    <asp:BoundField DataField="lw_crf3b_45_oth_1" HeaderText="lw_crf3b_45_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_46" HeaderText="lw_crf3b_46" />
                    <asp:BoundField DataField="lw_crf3b_47" HeaderText="lw_crf3b_47" />
                    <asp:BoundField DataField="lw_crf3b_48" HeaderText="lw_crf3b_48" />
                    <asp:BoundField DataField="lw_crf3b_49" HeaderText="lw_crf3b_49" />
                    <asp:BoundField DataField="lw_crf3b_50" HeaderText="lw_crf3b_50" />
                    <asp:BoundField DataField="lw_crf3b_51" HeaderText="lw_crf3b_51" />
                    <asp:BoundField DataField="lw_crf3b_52" HeaderText="lw_crf3b_52" />
                    <asp:BoundField DataField="lw_crf3b_53" HeaderText="lw_crf3b_53" />
                    <asp:BoundField DataField="lw_crf3b_54" HeaderText="lw_crf3b_54" />
                    <asp:BoundField DataField="lw_crf3b_55" HeaderText="lw_crf3b_55" />
                    <asp:BoundField DataField="lw_crf3b_56" HeaderText="lw_crf3b_56" />
                    <asp:BoundField DataField="lw_crf3b_57" HeaderText="lw_crf3b_57" />
                    <asp:BoundField DataField="lw_crf3b_58" HeaderText="lw_crf3b_58" />
                    <asp:BoundField DataField="lw_crf3b_59" HeaderText="lw_crf3b_59" />
                    <asp:BoundField DataField="lw_crf3b_60" HeaderText="lw_crf3b_60" />
                    <asp:BoundField DataField="lw_crf3b_61" HeaderText="lw_crf3b_61" />
                    <asp:BoundField DataField="lw_crf3b_62" HeaderText="lw_crf3b_62" />
                    <asp:BoundField DataField="lw_crf3b_63" HeaderText="lw_crf3b_63" />
                    <asp:BoundField DataField="lw_crf3b_64" HeaderText="lw_crf3b_64" />
                    <asp:BoundField DataField="lw_crf3b_65a" HeaderText="lw_crf3b_65a" />
                    <asp:BoundField DataField="lw_crf3b_65b" HeaderText="lw_crf3b_65b" />
                    <asp:BoundField DataField="lw_crf3b_65c" HeaderText="lw_crf3b_65c" />
                    <asp:BoundField DataField="lw_crf3b_65d" HeaderText="lw_crf3b_65d" />
                    <asp:BoundField DataField="lw_crf3b_65e" HeaderText="lw_crf3b_65e" />
                    <asp:BoundField DataField="lw_crf3b_65f" HeaderText="lw_crf3b_65f" />
                    <asp:BoundField DataField="lw_crf3b_65g" HeaderText="lw_crf3b_65g" />
                    <asp:BoundField DataField="lw_crf3b_65h" HeaderText="lw_crf3b_65h" />
                    <asp:BoundField DataField="lw_crf3b_65i" HeaderText="lw_crf3b_65i" />
                    <asp:BoundField DataField="lw_crf3b_65j" HeaderText="lw_crf3b_65j" />
                    <asp:BoundField DataField="lw_crf3b_65k" HeaderText="lw_crf3b_65k" />
                    <asp:BoundField DataField="lw_crf3b_65l" HeaderText="lw_crf3b_65l" />
                    <asp:BoundField DataField="lw_crf3b_65m" HeaderText="lw_crf3b_65m" />
                    <asp:BoundField DataField="lw_crf3b_65m_oth_1" HeaderText="lw_crf3b_65m_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_66a" HeaderText="lw_crf3b_66a" />
                    <asp:BoundField DataField="lw_crf3b_66b" HeaderText="lw_crf3b_66b" />
                    <asp:BoundField DataField="lw_crf3b_66c" HeaderText="lw_crf3b_66c" />
                    <asp:BoundField DataField="lw_crf3b_67" HeaderText="lw_crf3b_67" />
                    <asp:BoundField DataField="lw_crf3b_68a" HeaderText="lw_crf3b_68a" />
                    <asp:BoundField DataField="lw_crf3b_68b" HeaderText="lw_crf3b_68b" />
                    <asp:BoundField DataField="lw_crf3b_68c" HeaderText="lw_crf3b_68c" />
                    <asp:BoundField DataField="lw_crf3b_69" HeaderText="lw_crf3b_69" />
                    <asp:BoundField DataField="lw_crf3b_70a" HeaderText="lw_crf3b_70a" />
                    <asp:BoundField DataField="lw_crf3b_70b" HeaderText="lw_crf3b_70b" />
                    <asp:BoundField DataField="lw_crf3b_70c" HeaderText="lw_crf3b_70c" />
                    <asp:BoundField DataField="lw_crf3b_70d" HeaderText="lw_crf3b_70d" />
                    <asp:BoundField DataField="lw_crf3b_70e" HeaderText="lw_crf3b_70e" />
                    <asp:BoundField DataField="lw_crf3b_70f" HeaderText="lw_crf3b_70f" />
                    <asp:BoundField DataField="lw_crf3b_70g" HeaderText="lw_crf3b_70g" />
                    <asp:BoundField DataField="lw_crf3b_70h" HeaderText="lw_crf3b_70h" />
                    <asp:BoundField DataField="lw_crf3b_70i" HeaderText="lw_crf3b_70i" />
                    <asp:BoundField DataField="lw_crf3b_70j" HeaderText="lw_crf3b_70j" />
                    <asp:BoundField DataField="lw_crf3b_70k" HeaderText="lw_crf3b_70k" />
                    <asp:BoundField DataField="lw_crf3b_70l" HeaderText="lw_crf3b_70l" />
                    <asp:BoundField DataField="lw_crf3b_70m" HeaderText="lw_crf3b_70m" />
                    <asp:BoundField DataField="lw_crf3b_70n" HeaderText="lw_crf3b_70n" />
                    <asp:BoundField DataField="lw_crf3b_70o" HeaderText="lw_crf3b_70o" />
                    <asp:BoundField DataField="lw_crf3b_70o_oth_1" HeaderText="lw_crf3b_70o_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_71a" HeaderText="lw_crf3b_71a" />
                    <asp:BoundField DataField="lw_crf3b_71b" HeaderText="lw_crf3b_71b" />
                    <asp:BoundField DataField="lw_crf3b_71c" HeaderText="lw_crf3b_71c" />
                    <asp:BoundField DataField="lw_crf3b_71d" HeaderText="lw_crf3b_71d" />
                    <asp:BoundField DataField="lw_crf3b_71e" HeaderText="lw_crf3b_71e" />
                    <asp:BoundField DataField="lw_crf3b_71f" HeaderText="lw_crf3b_71f" />
                    <asp:BoundField DataField="lw_crf3b_71g" HeaderText="lw_crf3b_71g" />
                    <asp:BoundField DataField="lw_crf3b_71h" HeaderText="lw_crf3b_71h" />
                    <asp:BoundField DataField="lw_crf3b_71i" HeaderText="lw_crf3b_71i" />
                    <asp:BoundField DataField="lw_crf3b_71j" HeaderText="lw_crf3b_71j" />
                    <asp:BoundField DataField="lw_crf3b_71k" HeaderText="lw_crf3b_71k" />
                    <asp:BoundField DataField="lw_crf3b_71l" HeaderText="lw_crf3b_71l" />
                    <asp:BoundField DataField="lw_crf3b_71l_oth_1" HeaderText="lw_crf3b_71l_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_72" HeaderText="lw_crf3b_72" />
                    <asp:BoundField DataField="lw_crf3b_73a" HeaderText="lw_crf3b_73a" />
                    <asp:BoundField DataField="lw_crf3b_73b" HeaderText="lw_crf3b_73b" />
                    <asp:BoundField DataField="lw_crf3b_73c" HeaderText="lw_crf3b_73c" />
                    <asp:BoundField DataField="lw_crf3b_73d" HeaderText="lw_crf3b_73d" />
                    <asp:BoundField DataField="lw_crf3b_73e" HeaderText="lw_crf3b_73e" />
                    <asp:BoundField DataField="lw_crf3b_73f" HeaderText="lw_crf3b_73f" />
                    <asp:BoundField DataField="lw_crf3b_73g" HeaderText="lw_crf3b_73g" />
                    <asp:BoundField DataField="lw_crf3b_73h" HeaderText="lw_crf3b_73h" />
                    <asp:BoundField DataField="lw_crf3b_73i" HeaderText="lw_crf3b_73i" />
                    <asp:BoundField DataField="lw_crf3b_73j" HeaderText="lw_crf3b_73j" />
                    <asp:BoundField DataField="lw_crf3b_73k" HeaderText="lw_crf3b_73k" />
                    <asp:BoundField DataField="lw_crf3b_73l" HeaderText="lw_crf3b_73l" />
                    <asp:BoundField DataField="lw_crf3b_73m" HeaderText="lw_crf3b_73m" />
                    <asp:BoundField DataField="lw_crf3b_73n" HeaderText="lw_crf3b_73n" />
                    <asp:BoundField DataField="lw_crf3b_73o" HeaderText="lw_crf3b_73o" />
                    <asp:BoundField DataField="lw_crf3b_73p" HeaderText="lw_crf3b_73p" />
                    <asp:BoundField DataField="lw_crf3b_73q" HeaderText="lw_crf3b_73q" />
                    <asp:BoundField DataField="lw_crf3b_73r" HeaderText="lw_crf3b_73r" />
                    <asp:BoundField DataField="lw_crf3b_73s" HeaderText="lw_crf3b_73s" />
                    <asp:BoundField DataField="lw_crf3b_73t" HeaderText="lw_crf3b_73t" />
                    <asp:BoundField DataField="lw_crf3b_73u" HeaderText="lw_crf3b_73u" />
                    <asp:BoundField DataField="lw_crf3b_73v" HeaderText="lw_crf3b_73v" />
                    <asp:BoundField DataField="lw_crf3b_73w" HeaderText="lw_crf3b_73w" />
                    <asp:BoundField DataField="lw_crf3b_73x" HeaderText="lw_crf3b_73x" />
                    <asp:BoundField DataField="lw_crf3b_73y" HeaderText="lw_crf3b_73y" />
                    <asp:BoundField DataField="lw_crf3b_73z" HeaderText="lw_crf3b_73z" />
                    <asp:BoundField DataField="lw_crf3b_73z_oth_1" HeaderText="lw_crf3b_73z_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_74" HeaderText="lw_crf3b_74" />
                    <asp:BoundField DataField="lw_crf3b_75a" HeaderText="lw_crf3b_75a" />
                    <asp:BoundField DataField="lw_crf3b_75b" HeaderText="lw_crf3b_75b" />
                    <asp:BoundField DataField="lw_crf3b_75c" HeaderText="lw_crf3b_75c" />
                    <asp:BoundField DataField="lw_crf3b_75d" HeaderText="lw_crf3b_75d" />
                    <asp:BoundField DataField="lw_crf3b_75e" HeaderText="lw_crf3b_75e" />
                    <asp:BoundField DataField="lw_crf3b_75f" HeaderText="lw_crf3b_75f" />
                    <asp:BoundField DataField="lw_crf3b_75g" HeaderText="lw_crf3b_75g" />
                    <asp:BoundField DataField="lw_crf3b_75h" HeaderText="lw_crf3b_75h" />
                    <asp:BoundField DataField="lw_crf3b_75i" HeaderText="lw_crf3b_75i" />
                    <asp:BoundField DataField="lw_crf3b_75j" HeaderText="lw_crf3b_75j" />
                    <asp:BoundField DataField="lw_crf3b_75k" HeaderText="lw_crf3b_75k" />
                    <asp:BoundField DataField="lw_crf3b_75l" HeaderText="lw_crf3b_75l" />
                    <asp:BoundField DataField="lw_crf3b_75m" HeaderText="lw_crf3b_75m" />
                    <asp:BoundField DataField="lw_crf3b_76" HeaderText="lw_crf3b_76" />
                    <asp:BoundField DataField="lw_crf3b_77a" HeaderText="lw_crf3b_77a" />
                    <asp:BoundField DataField="lw_crf3b_77b" HeaderText="lw_crf3b_77b" />
                    <asp:BoundField DataField="lw_crf3b_77c" HeaderText="lw_crf3b_77c" />
                    <asp:BoundField DataField="lw_crf3b_77d" HeaderText="lw_crf3b_77d" />
                    <asp:BoundField DataField="lw_crf3b_77e" HeaderText="lw_crf3b_77e" />
                    <asp:BoundField DataField="lw_crf3b_77f" HeaderText="lw_crf3b_77f" />
                    <asp:BoundField DataField="lw_crf3b_77g" HeaderText="lw_crf3b_77g" />
                    <asp:BoundField DataField="lw_crf3b_77h" HeaderText="lw_crf3b_77h" />
                    <asp:BoundField DataField="lw_crf3b_77i" HeaderText="lw_crf3b_77i" />
                    <asp:BoundField DataField="lw_crf3b_77i_oth_1" HeaderText="lw_crf3b_77i_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_78a" HeaderText="lw_crf3b_78a" />
                    <asp:BoundField DataField="lw_crf3b_78b" HeaderText="lw_crf3b_78b" />
                    <asp:BoundField DataField="lw_crf3b_79" HeaderText="lw_crf3b_79" />
                    <asp:BoundField DataField="lw_crf3b_80a" HeaderText="lw_crf3b_80a" />
                    <asp:BoundField DataField="lw_crf3b_80b" HeaderText="lw_crf3b_80b" />
                    <asp:BoundField DataField="lw_crf3b_81" HeaderText="lw_crf3b_81" />
                    <asp:BoundField DataField="lw_crf3b_82" HeaderText="lw_crf3b_82" />
                    <asp:BoundField DataField="lw_crf3b_83a" HeaderText="lw_crf3b_83a" />
                    <asp:BoundField DataField="lw_crf3b_83b" HeaderText="lw_crf3b_83b" />
                    <asp:BoundField DataField="lw_crf3b_84" HeaderText="lw_crf3b_84" />
                    <asp:BoundField DataField="lw_crf3b_85" HeaderText="lw_crf3b_85" />
                    <asp:BoundField DataField="lw_crf3b_86" HeaderText="lw_crf3b_86" />
                    <asp:BoundField DataField="lw_crf3b_87" HeaderText="lw_crf3b_87" />
                    <asp:BoundField DataField="lw_crf3b_88a" HeaderText="lw_crf3b_88a" />
                    <asp:BoundField DataField="lw_crf3b_88ba" HeaderText="lw_crf3b_88ba" />
                    <asp:BoundField DataField="lw_crf3b_88bb" HeaderText="lw_crf3b_88bb" />
                    <asp:BoundField DataField="lw_crf3b_88bc" HeaderText="lw_crf3b_88bc" />
                    <asp:BoundField DataField="lw_crf3b_88bd" HeaderText="lw_crf3b_88bd" />
                    <asp:BoundField DataField="lw_crf3b_89" HeaderText="lw_crf3b_89" />
                    <asp:BoundField DataField="lw_crf3b_90" HeaderText="lw_crf3b_90" />
                    <asp:BoundField DataField="lw_crf3b_91" HeaderText="lw_crf3b_91" />
                    <asp:BoundField DataField="lw_crf3b_92" HeaderText="lw_crf3b_92" />
                    <asp:BoundField DataField="lw_crf3b_93" HeaderText="lw_crf3b_93" />
                    <asp:BoundField DataField="lw_crf3b_94" HeaderText="lw_crf3b_94" />
                    <asp:BoundField DataField="lw_crf3b_95" HeaderText="lw_crf3b_95" />
                    <asp:BoundField DataField="lw_crf3b_96a" HeaderText="lw_crf3b_96a" />
                    <asp:BoundField DataField="lw_crf3b_96b" HeaderText="lw_crf3b_96b" />
                    <asp:BoundField DataField="lw_crf3b_96c" HeaderText="lw_crf3b_96c" />
                    <asp:BoundField DataField="lw_crf3b_96d" HeaderText="lw_crf3b_96d" />
                    <asp:BoundField DataField="lw_crf3b_96e" HeaderText="lw_crf3b_96e" />
                    <asp:BoundField DataField="lw_crf3b_96f" HeaderText="lw_crf3b_96f" />
                    <asp:BoundField DataField="lw_crf3b_96g" HeaderText="lw_crf3b_96g" />
                    <asp:BoundField DataField="lw_crf3b_96h" HeaderText="lw_crf3b_96h" />
                    <asp:BoundField DataField="lw_crf3b_96i" HeaderText="lw_crf3b_96i" />
                    <asp:BoundField DataField="lw_crf3b_96j" HeaderText="lw_crf3b_96j" />
                    <asp:BoundField DataField="lw_crf3b_96k" HeaderText="lw_crf3b_96k" />
                    <asp:BoundField DataField="lw_crf3b_96l" HeaderText="lw_crf3b_96l" />
                    <asp:BoundField DataField="lw_crf3b_96m" HeaderText="lw_crf3b_96m" />
                    <asp:BoundField DataField="lw_crf3b_96n" HeaderText="lw_crf3b_96n" />
                    <asp:BoundField DataField="lw_crf3b_96o" HeaderText="lw_crf3b_96o" />
                    <asp:BoundField DataField="lw_crf3b_96p" HeaderText="lw_crf3b_96p" />
                    <asp:BoundField DataField="lw_crf3b_96p_oth_1" HeaderText="lw_crf3b_96p_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_97" HeaderText="lw_crf3b_97" />
                    <asp:BoundField DataField="lw_crf3b_98" HeaderText="lw_crf3b_98" />
                    <asp:BoundField DataField="lw_crf3b_99" HeaderText="lw_crf3b_99" />
                    <asp:BoundField DataField="lw_crf3b_100" HeaderText="lw_crf3b_100" />
                    <asp:BoundField DataField="lw_crf3b_101a" HeaderText="lw_crf3b_101a" />
                    <asp:BoundField DataField="lw_crf3b_101b" HeaderText="lw_crf3b_101b" />
                    <asp:BoundField DataField="lw_crf3b_101c" HeaderText="lw_crf3b_101c" />
                    <asp:BoundField DataField="lw_crf3b_101d" HeaderText="lw_crf3b_101d" />
                    <asp:BoundField DataField="lw_crf3b_101e" HeaderText="lw_crf3b_101e" />
                    <asp:BoundField DataField="lw_crf3b_101f" HeaderText="lw_crf3b_101f" />
                    <asp:BoundField DataField="lw_crf3b_101g" HeaderText="lw_crf3b_101g" />
                    <asp:BoundField DataField="lw_crf3b_101h" HeaderText="lw_crf3b_101h" />
                    <asp:BoundField DataField="lw_crf3b_101i" HeaderText="lw_crf3b_101i" />
                    <asp:BoundField DataField="lw_crf3b_101j" HeaderText="lw_crf3b_101j" />
                    <asp:BoundField DataField="lw_crf3b_101k" HeaderText="lw_crf3b_101k" />
                    <asp:BoundField DataField="lw_crf3b_101l" HeaderText="lw_crf3b_101l" />
                    <asp:BoundField DataField="lw_crf3b_101l_oth_1" HeaderText="lw_crf3b_101l_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_102" HeaderText="lw_crf3b_102" />
                    <asp:BoundField DataField="lw_crf3b_103" HeaderText="lw_crf3b_103" />
                    <asp:BoundField DataField="lw_crf3b_104a" HeaderText="lw_crf3b_104a" />
                    <asp:BoundField DataField="lw_crf3b_104b" HeaderText="lw_crf3b_104b" />
                    <asp:BoundField DataField="lw_crf3b_104c" HeaderText="lw_crf3b_104c" />
                    <asp:BoundField DataField="lw_crf3b_105a" HeaderText="lw_crf3b_105a" />
                    <asp:BoundField DataField="lw_crf3b_105b" HeaderText="lw_crf3b_105b" />
                    <asp:BoundField DataField="lw_crf3b_105c" HeaderText="lw_crf3b_105c" />
                    <asp:BoundField DataField="lw_crf3b_105d" HeaderText="lw_crf3b_105d" />
                    <asp:BoundField DataField="lw_crf3b_106" HeaderText="lw_crf3b_106" />
                    <asp:BoundField DataField="Tab_user" HeaderText="Tab_user" />
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



            <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="form_crf_3b_id" HeaderText="form_crf_3b_id" />
                    <asp:BoundField DataField="assis_id" HeaderText="Assisment_ID" />
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="lw_crf3b_2" HeaderText="lw_crf3b_2" />
                    <asp:BoundField DataField="lw_crf3b_3" HeaderText="lw_crf3b_3" />
                    <asp:BoundField DataField="lw_crf3b_4" HeaderText="lw_crf3b_4" />
                    <asp:BoundField DataField="q5" HeaderText="q5" />
                    <asp:BoundField DataField="q6" HeaderText="q6" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="lw_crf3b_13" HeaderText="lw_crf3b_13" />
                    <asp:BoundField DataField="lw_crf3b_13_oth_1" HeaderText="lw_crf3b_13_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_14" HeaderText="lw_crf3b_14" />
                    <asp:BoundField DataField="lw_crf3b_15" HeaderText="lw_crf3b_15" />
                    <asp:BoundField DataField="lw_crf3b_16" HeaderText="lw_crf3b_16" />
                    <asp:BoundField DataField="lw_crf3b_17" HeaderText="lw_crf3b_17" />
                    <asp:BoundField DataField="lw_crf3b_18" HeaderText="lw_crf3b_18" />
                    <asp:BoundField DataField="lw_crf3b_18_oth_1" HeaderText="lw_crf3b_18_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_19" HeaderText="lw_crf3b_19" />
                    <asp:BoundField DataField="lw_crf3b_20" HeaderText="lw_crf3b_20" />
                    <asp:BoundField DataField="lw_crf3b_20_oth_1" HeaderText="lw_crf3b_20_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_21" HeaderText="lw_crf3b_21" />
                    <asp:BoundField DataField="lw_crf3b_22" HeaderText="lw_crf3b_22" />
                    <asp:BoundField DataField="lw_crf3b_23" HeaderText="lw_crf3b_23" />
                    <asp:BoundField DataField="lw_crf3b_24" HeaderText="lw_crf3b_24" />
                    <asp:BoundField DataField="lw_crf3b_25" HeaderText="lw_crf3b_25" />
                    <asp:BoundField DataField="lw_crf3b_26" HeaderText="lw_crf3b_26" />
                    <asp:BoundField DataField="lw_crf3b_27" HeaderText="lw_crf3b_27" />
                    <asp:BoundField DataField="lw_crf3b_28" HeaderText="lw_crf3b_28" />
                    <asp:BoundField DataField="lw_crf3b_29a" HeaderText="lw_crf3b_29a" />
                    <asp:BoundField DataField="lw_crf3b_29b" HeaderText="lw_crf3b_29b" />
                    <asp:BoundField DataField="lw_crf3b_29c" HeaderText="lw_crf3b_29c" />
                    <asp:BoundField DataField="lw_crf3b_29d" HeaderText="lw_crf3b_29d" />
                    <asp:BoundField DataField="lw_crf3b_29e" HeaderText="lw_crf3b_29e" />
                    <asp:BoundField DataField="lw_crf3b_29e_oth_1" HeaderText="lw_crf3b_29e_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_30" HeaderText="lw_crf3b_30" />
                    <asp:BoundField DataField="lw_crf3b_31" HeaderText="lw_crf3b_31" />
                    <asp:BoundField DataField="lw_crf3b_31_oth_1" HeaderText="lw_crf3b_31_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_32" HeaderText="lw_crf3b_32" />
                    <asp:BoundField DataField="lw_crf3b_33" HeaderText="lw_crf3b_33" />
                    <asp:BoundField DataField="lw_crf3b_34" HeaderText="lw_crf3b_34" />
                    <asp:BoundField DataField="lw_crf3b_35" HeaderText="lw_crf3b_35" />
                    <asp:BoundField DataField="lw_crf3b_36a" HeaderText="lw_crf3b_36a" />
                    <asp:BoundField DataField="lw_crf3b_36b" HeaderText="lw_crf3b_36b" />
                    <asp:BoundField DataField="lw_crf3b_36c" HeaderText="lw_crf3b_36c" />
                    <asp:BoundField DataField="lw_crf3b_36d" HeaderText="lw_crf3b_36d" />
                    <asp:BoundField DataField="lw_crf3b_36e" HeaderText="lw_crf3b_36e" />
                    <asp:BoundField DataField="lw_crf3b_36f" HeaderText="lw_crf3b_36f" />
                    <asp:BoundField DataField="lw_crf3b_36g" HeaderText="lw_crf3b_36g" />
                    <asp:BoundField DataField="lw_crf3b_36h" HeaderText="lw_crf3b_36h" />
                    <asp:BoundField DataField="lw_crf3b_36i" HeaderText="lw_crf3b_36i" />
                    <asp:BoundField DataField="lw_crf3b_36j" HeaderText="lw_crf3b_36j" />
                    <asp:BoundField DataField="lw_crf3b_36k" HeaderText="lw_crf3b_36k" />
                    <asp:BoundField DataField="lw_crf3b_36l" HeaderText="lw_crf3b_36l" />
                    <asp:BoundField DataField="lw_crf3b_36m" HeaderText="lw_crf3b_36m" />
                    <asp:BoundField DataField="lw_crf3b_36n" HeaderText="lw_crf3b_36n" />
                    <asp:BoundField DataField="lw_crf3b_36o" HeaderText="lw_crf3b_36o" />
                    <asp:BoundField DataField="lw_crf3b_36p" HeaderText="lw_crf3b_36p" />
                    <asp:BoundField DataField="lw_crf3b_36q" HeaderText="lw_crf3b_36q" />
                    <asp:BoundField DataField="lw_crf3b_36r" HeaderText="lw_crf3b_36r" />
                    <asp:BoundField DataField="lw_crf3b_36s" HeaderText="lw_crf3b_36s" />
                    <asp:BoundField DataField="lw_crf3b_36t" HeaderText="lw_crf3b_36t" />
                    <asp:BoundField DataField="lw_crf3b_36u" HeaderText="lw_crf3b_36u" />
                    <asp:BoundField DataField="lw_crf3b_36v" HeaderText="lw_crf3b_36v" />
                    <asp:BoundField DataField="lw_crf3b_36w" HeaderText="lw_crf3b_36w" />
                    <asp:BoundField DataField="lw_crf3b_36x" HeaderText="lw_crf3b_36x" />
                    <asp:BoundField DataField="lw_crf3b_36y" HeaderText="lw_crf3b_36y" />
                    <asp:BoundField DataField="lw_crf3b_36y_oth_1" HeaderText="lw_crf3b_36y_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_37" HeaderText="lw_crf3b_37" />
                    <asp:BoundField DataField="lw_crf3b_38" HeaderText="lw_crf3b_38" />
                    <asp:BoundField DataField="lw_crf3b_38_oth_1" HeaderText="lw_crf3b_38_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_39a" HeaderText="lw_crf3b_39a" />
                    <asp:BoundField DataField="lw_crf3b_39b" HeaderText="lw_crf3b_39b" />
                    <asp:BoundField DataField="lw_crf3b_39c" HeaderText="lw_crf3b_39c" />
                    <asp:BoundField DataField="lw_crf3b_39d" HeaderText="lw_crf3b_39d" />
                    <asp:BoundField DataField="lw_crf3b_39e" HeaderText="lw_crf3b_39e" />
                    <asp:BoundField DataField="lw_crf3b_39f" HeaderText="lw_crf3b_39f" />
                    <asp:BoundField DataField="lw_crf3b_39g" HeaderText="lw_crf3b_39g" />
                    <asp:BoundField DataField="lw_crf3b_39h" HeaderText="lw_crf3b_39h" />
                    <asp:BoundField DataField="lw_crf3b_39i" HeaderText="lw_crf3b_39i" />
                    <asp:BoundField DataField="lw_crf3b_39j" HeaderText="lw_crf3b_39j" />
                    <asp:BoundField DataField="lw_crf3b_39j_oth_1" HeaderText="lw_crf3b_39j_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_40a" HeaderText="lw_crf3b_40a" />
                    <asp:BoundField DataField="lw_crf3b_40b" HeaderText="lw_crf3b_40b" />
                    <asp:BoundField DataField="lw_crf3b_40c" HeaderText="lw_crf3b_40c" />
                    <asp:BoundField DataField="lw_crf3b_40d" HeaderText="lw_crf3b_40d" />
                    <asp:BoundField DataField="lw_crf3b_40e" HeaderText="lw_crf3b_40e" />
                    <asp:BoundField DataField="lw_crf3b_40f" HeaderText="lw_crf3b_40f" />
                    <asp:BoundField DataField="lw_crf3b_40g" HeaderText="lw_crf3b_40g" />
                    <asp:BoundField DataField="lw_crf3b_40h" HeaderText="lw_crf3b_40h" />
                    <asp:BoundField DataField="lw_crf3b_40i" HeaderText="lw_crf3b_40i" />
                    <asp:BoundField DataField="lw_crf3b_40j" HeaderText="lw_crf3b_40j" />
                    <asp:BoundField DataField="lw_crf3b_40k" HeaderText="lw_crf3b_40k" />
                    <asp:BoundField DataField="lw_crf3b_40l" HeaderText="lw_crf3b_40l" />
                    <asp:BoundField DataField="lw_crf3b_40m" HeaderText="lw_crf3b_40m" />
                    <asp:BoundField DataField="lw_crf3b_40n" HeaderText="lw_crf3b_40n" />
                    <asp:BoundField DataField="lw_crf3b_40o" HeaderText="lw_crf3b_40o" />
                    <asp:BoundField DataField="lw_crf3b_40p" HeaderText="lw_crf3b_40p" />
                    <asp:BoundField DataField="lw_crf3b_40q" HeaderText="lw_crf3b_40q" />
                    <asp:BoundField DataField="lw_crf3b_40r" HeaderText="lw_crf3b_40r" />
                    <asp:BoundField DataField="lw_crf3b_40r_oth_1" HeaderText="lw_crf3b_40r_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_41" HeaderText="lw_crf3b_41" />
                    <asp:BoundField DataField="lw_crf3b_42" HeaderText="lw_crf3b_42" />
                    <asp:BoundField DataField="lw_crf3b_42_oth_1" HeaderText="lw_crf3b_42_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_43a" HeaderText="lw_crf3b_43a" />
                    <asp:BoundField DataField="lw_crf3b_43b" HeaderText="lw_crf3b_43b" />
                    <asp:BoundField DataField="lw_crf3b_43c" HeaderText="lw_crf3b_43c" />
                    <asp:BoundField DataField="lw_crf3b_43d" HeaderText="lw_crf3b_43d" />
                    <asp:BoundField DataField="lw_crf3b_43e" HeaderText="lw_crf3b_43e" />
                    <asp:BoundField DataField="lw_crf3b_43f" HeaderText="lw_crf3b_43f" />
                    <asp:BoundField DataField="lw_crf3b_43g" HeaderText="lw_crf3b_43g" />
                    <asp:BoundField DataField="lw_crf3b_43h" HeaderText="lw_crf3b_43h" />
                    <asp:BoundField DataField="lw_crf3b_43i" HeaderText="lw_crf3b_43i" />
                    <asp:BoundField DataField="lw_crf3b_43j" HeaderText="lw_crf3b_43j" />
                    <asp:BoundField DataField="lw_crf3b_43k" HeaderText="lw_crf3b_43k" />
                    <asp:BoundField DataField="lw_crf3b_43k_oth_1" HeaderText="lw_crf3b_43k_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_44" HeaderText="lw_crf3b_44" />
                    <asp:BoundField DataField="lw_crf3b_45" HeaderText="lw_crf3b_45" />
                    <asp:BoundField DataField="lw_crf3b_45_oth_1" HeaderText="lw_crf3b_45_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_46" HeaderText="lw_crf3b_46" />
                    <asp:BoundField DataField="lw_crf3b_47" HeaderText="lw_crf3b_47" />
                    <asp:BoundField DataField="lw_crf3b_48" HeaderText="lw_crf3b_48" />
                    <asp:BoundField DataField="lw_crf3b_49" HeaderText="lw_crf3b_49" />
                    <asp:BoundField DataField="lw_crf3b_50" HeaderText="lw_crf3b_50" />
                    <asp:BoundField DataField="lw_crf3b_51" HeaderText="lw_crf3b_51" />
                    <asp:BoundField DataField="lw_crf3b_52" HeaderText="lw_crf3b_52" />
                    <asp:BoundField DataField="lw_crf3b_53" HeaderText="lw_crf3b_53" />
                    <asp:BoundField DataField="lw_crf3b_54" HeaderText="lw_crf3b_54" />
                    <asp:BoundField DataField="lw_crf3b_55" HeaderText="lw_crf3b_55" />
                    <asp:BoundField DataField="lw_crf3b_56" HeaderText="lw_crf3b_56" />
                    <asp:BoundField DataField="lw_crf3b_57" HeaderText="lw_crf3b_57" />
                    <asp:BoundField DataField="lw_crf3b_58" HeaderText="lw_crf3b_58" />
                    <asp:BoundField DataField="lw_crf3b_59" HeaderText="lw_crf3b_59" />
                    <asp:BoundField DataField="lw_crf3b_60" HeaderText="lw_crf3b_60" />
                    <asp:BoundField DataField="lw_crf3b_61" HeaderText="lw_crf3b_61" />
                    <asp:BoundField DataField="lw_crf3b_62" HeaderText="lw_crf3b_62" />
                    <asp:BoundField DataField="lw_crf3b_63" HeaderText="lw_crf3b_63" />
                    <asp:BoundField DataField="lw_crf3b_64" HeaderText="lw_crf3b_64" />
                    <asp:BoundField DataField="lw_crf3b_65a" HeaderText="lw_crf3b_65a" />
                    <asp:BoundField DataField="lw_crf3b_65b" HeaderText="lw_crf3b_65b" />
                    <asp:BoundField DataField="lw_crf3b_65c" HeaderText="lw_crf3b_65c" />
                    <asp:BoundField DataField="lw_crf3b_65d" HeaderText="lw_crf3b_65d" />
                    <asp:BoundField DataField="lw_crf3b_65e" HeaderText="lw_crf3b_65e" />
                    <asp:BoundField DataField="lw_crf3b_65f" HeaderText="lw_crf3b_65f" />
                    <asp:BoundField DataField="lw_crf3b_65g" HeaderText="lw_crf3b_65g" />
                    <asp:BoundField DataField="lw_crf3b_65h" HeaderText="lw_crf3b_65h" />
                    <asp:BoundField DataField="lw_crf3b_65i" HeaderText="lw_crf3b_65i" />
                    <asp:BoundField DataField="lw_crf3b_65j" HeaderText="lw_crf3b_65j" />
                    <asp:BoundField DataField="lw_crf3b_65k" HeaderText="lw_crf3b_65k" />
                    <asp:BoundField DataField="lw_crf3b_65l" HeaderText="lw_crf3b_65l" />
                    <asp:BoundField DataField="lw_crf3b_65m" HeaderText="lw_crf3b_65m" />
                    <asp:BoundField DataField="lw_crf3b_65m_oth_1" HeaderText="lw_crf3b_65m_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_66a" HeaderText="lw_crf3b_66a" />
                    <asp:BoundField DataField="lw_crf3b_66b" HeaderText="lw_crf3b_66b" />
                    <asp:BoundField DataField="lw_crf3b_66c" HeaderText="lw_crf3b_66c" />
                    <asp:BoundField DataField="lw_crf3b_67" HeaderText="lw_crf3b_67" />
                    <asp:BoundField DataField="lw_crf3b_68a" HeaderText="lw_crf3b_68a" />
                    <asp:BoundField DataField="lw_crf3b_68b" HeaderText="lw_crf3b_68b" />
                    <asp:BoundField DataField="lw_crf3b_68c" HeaderText="lw_crf3b_68c" />
                    <asp:BoundField DataField="lw_crf3b_69" HeaderText="lw_crf3b_69" />
                    <asp:BoundField DataField="lw_crf3b_70a" HeaderText="lw_crf3b_70a" />
                    <asp:BoundField DataField="lw_crf3b_70b" HeaderText="lw_crf3b_70b" />
                    <asp:BoundField DataField="lw_crf3b_70c" HeaderText="lw_crf3b_70c" />
                    <asp:BoundField DataField="lw_crf3b_70d" HeaderText="lw_crf3b_70d" />
                    <asp:BoundField DataField="lw_crf3b_70e" HeaderText="lw_crf3b_70e" />
                    <asp:BoundField DataField="lw_crf3b_70f" HeaderText="lw_crf3b_70f" />
                    <asp:BoundField DataField="lw_crf3b_70g" HeaderText="lw_crf3b_70g" />
                    <asp:BoundField DataField="lw_crf3b_70h" HeaderText="lw_crf3b_70h" />
                    <asp:BoundField DataField="lw_crf3b_70i" HeaderText="lw_crf3b_70i" />
                    <asp:BoundField DataField="lw_crf3b_70j" HeaderText="lw_crf3b_70j" />
                    <asp:BoundField DataField="lw_crf3b_70k" HeaderText="lw_crf3b_70k" />
                    <asp:BoundField DataField="lw_crf3b_70l" HeaderText="lw_crf3b_70l" />
                    <asp:BoundField DataField="lw_crf3b_70m" HeaderText="lw_crf3b_70m" />
                    <asp:BoundField DataField="lw_crf3b_70n" HeaderText="lw_crf3b_70n" />
                    <asp:BoundField DataField="lw_crf3b_70o" HeaderText="lw_crf3b_70o" />
                    <asp:BoundField DataField="lw_crf3b_70o_oth_1" HeaderText="lw_crf3b_70o_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_71a" HeaderText="lw_crf3b_71a" />
                    <asp:BoundField DataField="lw_crf3b_71b" HeaderText="lw_crf3b_71b" />
                    <asp:BoundField DataField="lw_crf3b_71c" HeaderText="lw_crf3b_71c" />
                    <asp:BoundField DataField="lw_crf3b_71d" HeaderText="lw_crf3b_71d" />
                    <asp:BoundField DataField="lw_crf3b_71e" HeaderText="lw_crf3b_71e" />
                    <asp:BoundField DataField="lw_crf3b_71f" HeaderText="lw_crf3b_71f" />
                    <asp:BoundField DataField="lw_crf3b_71g" HeaderText="lw_crf3b_71g" />
                    <asp:BoundField DataField="lw_crf3b_71h" HeaderText="lw_crf3b_71h" />
                    <asp:BoundField DataField="lw_crf3b_71i" HeaderText="lw_crf3b_71i" />
                    <asp:BoundField DataField="lw_crf3b_71j" HeaderText="lw_crf3b_71j" />
                    <asp:BoundField DataField="lw_crf3b_71k" HeaderText="lw_crf3b_71k" />
                    <asp:BoundField DataField="lw_crf3b_71l" HeaderText="lw_crf3b_71l" />
                    <asp:BoundField DataField="lw_crf3b_71l_oth_1" HeaderText="lw_crf3b_71l_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_72" HeaderText="lw_crf3b_72" />
                    <asp:BoundField DataField="lw_crf3b_73a" HeaderText="lw_crf3b_73a" />
                    <asp:BoundField DataField="lw_crf3b_73b" HeaderText="lw_crf3b_73b" />
                    <asp:BoundField DataField="lw_crf3b_73c" HeaderText="lw_crf3b_73c" />
                    <asp:BoundField DataField="lw_crf3b_73d" HeaderText="lw_crf3b_73d" />
                    <asp:BoundField DataField="lw_crf3b_73e" HeaderText="lw_crf3b_73e" />
                    <asp:BoundField DataField="lw_crf3b_73f" HeaderText="lw_crf3b_73f" />
                    <asp:BoundField DataField="lw_crf3b_73g" HeaderText="lw_crf3b_73g" />
                    <asp:BoundField DataField="lw_crf3b_73h" HeaderText="lw_crf3b_73h" />
                    <asp:BoundField DataField="lw_crf3b_73i" HeaderText="lw_crf3b_73i" />
                    <asp:BoundField DataField="lw_crf3b_73j" HeaderText="lw_crf3b_73j" />
                    <asp:BoundField DataField="lw_crf3b_73k" HeaderText="lw_crf3b_73k" />
                    <asp:BoundField DataField="lw_crf3b_73l" HeaderText="lw_crf3b_73l" />
                    <asp:BoundField DataField="lw_crf3b_73m" HeaderText="lw_crf3b_73m" />
                    <asp:BoundField DataField="lw_crf3b_73n" HeaderText="lw_crf3b_73n" />
                    <asp:BoundField DataField="lw_crf3b_73o" HeaderText="lw_crf3b_73o" />
                    <asp:BoundField DataField="lw_crf3b_73p" HeaderText="lw_crf3b_73p" />
                    <asp:BoundField DataField="lw_crf3b_73q" HeaderText="lw_crf3b_73q" />
                    <asp:BoundField DataField="lw_crf3b_73r" HeaderText="lw_crf3b_73r" />
                    <asp:BoundField DataField="lw_crf3b_73s" HeaderText="lw_crf3b_73s" />
                    <asp:BoundField DataField="lw_crf3b_73t" HeaderText="lw_crf3b_73t" />
                    <asp:BoundField DataField="lw_crf3b_73u" HeaderText="lw_crf3b_73u" />
                    <asp:BoundField DataField="lw_crf3b_73v" HeaderText="lw_crf3b_73v" />
                    <asp:BoundField DataField="lw_crf3b_73w" HeaderText="lw_crf3b_73w" />
                    <asp:BoundField DataField="lw_crf3b_73x" HeaderText="lw_crf3b_73x" />
                    <asp:BoundField DataField="lw_crf3b_73y" HeaderText="lw_crf3b_73y" />
                    <asp:BoundField DataField="lw_crf3b_73z" HeaderText="lw_crf3b_73z" />
                    <asp:BoundField DataField="lw_crf3b_73z_oth_1" HeaderText="lw_crf3b_73z_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_74" HeaderText="lw_crf3b_74" />
                    <asp:BoundField DataField="lw_crf3b_75a" HeaderText="lw_crf3b_75a" />
                    <asp:BoundField DataField="lw_crf3b_75b" HeaderText="lw_crf3b_75b" />
                    <asp:BoundField DataField="lw_crf3b_75c" HeaderText="lw_crf3b_75c" />
                    <asp:BoundField DataField="lw_crf3b_75d" HeaderText="lw_crf3b_75d" />
                    <asp:BoundField DataField="lw_crf3b_75e" HeaderText="lw_crf3b_75e" />
                    <asp:BoundField DataField="lw_crf3b_75f" HeaderText="lw_crf3b_75f" />
                    <asp:BoundField DataField="lw_crf3b_75g" HeaderText="lw_crf3b_75g" />
                    <asp:BoundField DataField="lw_crf3b_75h" HeaderText="lw_crf3b_75h" />
                    <asp:BoundField DataField="lw_crf3b_75i" HeaderText="lw_crf3b_75i" />
                    <asp:BoundField DataField="lw_crf3b_75j" HeaderText="lw_crf3b_75j" />
                    <asp:BoundField DataField="lw_crf3b_75k" HeaderText="lw_crf3b_75k" />
                    <asp:BoundField DataField="lw_crf3b_75l" HeaderText="lw_crf3b_75l" />
                    <asp:BoundField DataField="lw_crf3b_75m" HeaderText="lw_crf3b_75m" />
                    <asp:BoundField DataField="lw_crf3b_76" HeaderText="lw_crf3b_76" />
                    <asp:BoundField DataField="lw_crf3b_77a" HeaderText="lw_crf3b_77a" />
                    <asp:BoundField DataField="lw_crf3b_77b" HeaderText="lw_crf3b_77b" />
                    <asp:BoundField DataField="lw_crf3b_77c" HeaderText="lw_crf3b_77c" />
                    <asp:BoundField DataField="lw_crf3b_77d" HeaderText="lw_crf3b_77d" />
                    <asp:BoundField DataField="lw_crf3b_77e" HeaderText="lw_crf3b_77e" />
                    <asp:BoundField DataField="lw_crf3b_77f" HeaderText="lw_crf3b_77f" />
                    <asp:BoundField DataField="lw_crf3b_77g" HeaderText="lw_crf3b_77g" />
                    <asp:BoundField DataField="lw_crf3b_77h" HeaderText="lw_crf3b_77h" />
                    <asp:BoundField DataField="lw_crf3b_77i" HeaderText="lw_crf3b_77i" />
                    <asp:BoundField DataField="lw_crf3b_77i_oth_1" HeaderText="lw_crf3b_77i_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_78a" HeaderText="lw_crf3b_78a" />
                    <asp:BoundField DataField="lw_crf3b_78b" HeaderText="lw_crf3b_78b" />
                    <asp:BoundField DataField="lw_crf3b_79" HeaderText="lw_crf3b_79" />
                    <asp:BoundField DataField="lw_crf3b_80a" HeaderText="lw_crf3b_80a" />
                    <asp:BoundField DataField="lw_crf3b_80b" HeaderText="lw_crf3b_80b" />
                    <asp:BoundField DataField="lw_crf3b_81" HeaderText="lw_crf3b_81" />
                    <asp:BoundField DataField="lw_crf3b_82" HeaderText="lw_crf3b_82" />
                    <asp:BoundField DataField="lw_crf3b_83a" HeaderText="lw_crf3b_83a" />
                    <asp:BoundField DataField="lw_crf3b_83b" HeaderText="lw_crf3b_83b" />
                    <asp:BoundField DataField="lw_crf3b_84" HeaderText="lw_crf3b_84" />
                    <asp:BoundField DataField="lw_crf3b_85" HeaderText="lw_crf3b_85" />
                    <asp:BoundField DataField="lw_crf3b_86" HeaderText="lw_crf3b_86" />
                    <asp:BoundField DataField="lw_crf3b_87" HeaderText="lw_crf3b_87" />
                    <asp:BoundField DataField="lw_crf3b_88a" HeaderText="lw_crf3b_88a" />
                    <asp:BoundField DataField="lw_crf3b_88ba" HeaderText="lw_crf3b_88ba" />
                    <asp:BoundField DataField="lw_crf3b_88bb" HeaderText="lw_crf3b_88bb" />
                    <asp:BoundField DataField="lw_crf3b_88bc" HeaderText="lw_crf3b_88bc" />
                    <asp:BoundField DataField="lw_crf3b_88bd" HeaderText="lw_crf3b_88bd" />
                    <asp:BoundField DataField="lw_crf3b_89" HeaderText="lw_crf3b_89" />
                    <asp:BoundField DataField="lw_crf3b_90" HeaderText="lw_crf3b_90" />
                    <asp:BoundField DataField="lw_crf3b_91" HeaderText="lw_crf3b_91" />
                    <asp:BoundField DataField="lw_crf3b_92" HeaderText="lw_crf3b_92" />
                    <asp:BoundField DataField="lw_crf3b_93" HeaderText="lw_crf3b_93" />
                    <asp:BoundField DataField="lw_crf3b_94" HeaderText="lw_crf3b_94" />
                    <asp:BoundField DataField="lw_crf3b_95" HeaderText="lw_crf3b_95" />
                    <asp:BoundField DataField="lw_crf3b_96a" HeaderText="lw_crf3b_96a" />
                    <asp:BoundField DataField="lw_crf3b_96b" HeaderText="lw_crf3b_96b" />
                    <asp:BoundField DataField="lw_crf3b_96c" HeaderText="lw_crf3b_96c" />
                    <asp:BoundField DataField="lw_crf3b_96d" HeaderText="lw_crf3b_96d" />
                    <asp:BoundField DataField="lw_crf3b_96e" HeaderText="lw_crf3b_96e" />
                    <asp:BoundField DataField="lw_crf3b_96f" HeaderText="lw_crf3b_96f" />
                    <asp:BoundField DataField="lw_crf3b_96g" HeaderText="lw_crf3b_96g" />
                    <asp:BoundField DataField="lw_crf3b_96h" HeaderText="lw_crf3b_96h" />
                    <asp:BoundField DataField="lw_crf3b_96i" HeaderText="lw_crf3b_96i" />
                    <asp:BoundField DataField="lw_crf3b_96j" HeaderText="lw_crf3b_96j" />
                    <asp:BoundField DataField="lw_crf3b_96k" HeaderText="lw_crf3b_96k" />
                    <asp:BoundField DataField="lw_crf3b_96l" HeaderText="lw_crf3b_96l" />
                    <asp:BoundField DataField="lw_crf3b_96m" HeaderText="lw_crf3b_96m" />
                    <asp:BoundField DataField="lw_crf3b_96n" HeaderText="lw_crf3b_96n" />
                    <asp:BoundField DataField="lw_crf3b_96o" HeaderText="lw_crf3b_96o" />
                    <asp:BoundField DataField="lw_crf3b_96p" HeaderText="lw_crf3b_96p" />
                    <asp:BoundField DataField="lw_crf3b_96p_oth_1" HeaderText="lw_crf3b_96p_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_97" HeaderText="lw_crf3b_97" />
                    <asp:BoundField DataField="lw_crf3b_98" HeaderText="lw_crf3b_98" />
                    <asp:BoundField DataField="lw_crf3b_99" HeaderText="lw_crf3b_99" />
                    <asp:BoundField DataField="lw_crf3b_100" HeaderText="lw_crf3b_100" />
                    <asp:BoundField DataField="lw_crf3b_101a" HeaderText="lw_crf3b_101a" />
                    <asp:BoundField DataField="lw_crf3b_101b" HeaderText="lw_crf3b_101b" />
                    <asp:BoundField DataField="lw_crf3b_101c" HeaderText="lw_crf3b_101c" />
                    <asp:BoundField DataField="lw_crf3b_101d" HeaderText="lw_crf3b_101d" />
                    <asp:BoundField DataField="lw_crf3b_101e" HeaderText="lw_crf3b_101e" />
                    <asp:BoundField DataField="lw_crf3b_101f" HeaderText="lw_crf3b_101f" />
                    <asp:BoundField DataField="lw_crf3b_101g" HeaderText="lw_crf3b_101g" />
                    <asp:BoundField DataField="lw_crf3b_101h" HeaderText="lw_crf3b_101h" />
                    <asp:BoundField DataField="lw_crf3b_101i" HeaderText="lw_crf3b_101i" />
                    <asp:BoundField DataField="lw_crf3b_101j" HeaderText="lw_crf3b_101j" />
                    <asp:BoundField DataField="lw_crf3b_101k" HeaderText="lw_crf3b_101k" />
                    <asp:BoundField DataField="lw_crf3b_101l" HeaderText="lw_crf3b_101l" />
                    <asp:BoundField DataField="lw_crf3b_101l_oth_1" HeaderText="lw_crf3b_101l_oth_1" />
                    <asp:BoundField DataField="lw_crf3b_102" HeaderText="lw_crf3b_102" />
                    <asp:BoundField DataField="lw_crf3b_103" HeaderText="lw_crf3b_103" />
                    <asp:BoundField DataField="lw_crf3b_104a" HeaderText="lw_crf3b_104a" />
                    <asp:BoundField DataField="lw_crf3b_104b" HeaderText="lw_crf3b_104b" />
                    <asp:BoundField DataField="lw_crf3b_104c" HeaderText="lw_crf3b_104c" />
                    <asp:BoundField DataField="lw_crf3b_105a" HeaderText="lw_crf3b_105a" />
                    <asp:BoundField DataField="lw_crf3b_105b" HeaderText="lw_crf3b_105b" />
                    <asp:BoundField DataField="lw_crf3b_105c" HeaderText="lw_crf3b_105c" />
                    <asp:BoundField DataField="lw_crf3b_105d" HeaderText="lw_crf3b_105d" />
                    <asp:BoundField DataField="lw_crf3b_106" HeaderText="lw_crf3b_106" />
                    <asp:BoundField DataField="Tab_user" HeaderText="Tab_user" />
                </Columns>
            </asp:GridView>


            
            <%--For BMGF Export --%>
            <asp:GridView ID="GridViewBMFG" runat="server" CssClass="footable"  ForeColor="#333333" AutoGenerateColumns="true">
               
            </asp:GridView>



        </div>
    </div>
</asp:Content>
