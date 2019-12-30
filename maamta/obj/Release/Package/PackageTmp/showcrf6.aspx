<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showcrf6.aspx.cs" Inherits="maamta.showcrf6" %>

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
            Outcome Assessment (Anthro):
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
                    <asp:BoundField DataField="followup_no" HeaderText="Followups Number" />
                    <asp:TemplateField HeaderText="Study ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudy" OnClick="Link_Study" Text='<%#Eval("study_code") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_6_id")+","+ Eval("study_code")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="lw_crf6_2" HeaderText="lw_crf6_2" />
                    <asp:BoundField DataField="lw_crf6_3" HeaderText="lw_crf6_3" />
                    <asp:BoundField DataField="q9" HeaderText="q9" />
                    <asp:BoundField DataField="q10" HeaderText="q10" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="arm" HeaderText="arm" />
                    <asp:BoundField DataField="lw_crf6_15" HeaderText="lw_crf6_15" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="lw_crf6_17" HeaderText="lw_crf6_17" />
                    <asp:BoundField DataField="lw_crf6_18" HeaderText="lw_crf6_18" />
                    <asp:BoundField DataField="lw_crf6_20" HeaderText="lw_crf6_20" />
                    <asp:BoundField DataField="lw_crf6_22" HeaderText="lw_crf6_22" />
                    <asp:BoundField DataField="lw_crf6_24" HeaderText="lw_crf6_24" />
                    <asp:BoundField DataField="lw_crf6_27" HeaderText="lw_crf6_27" />
                    <asp:BoundField DataField="lw_crf6_28" HeaderText="lw_crf6_28" />
                    <asp:BoundField DataField="lw_crf6_30" HeaderText="lw_crf6_30" />
                    <asp:BoundField DataField="lw_crf6_34" HeaderText="lw_crf6_34" />
                    <asp:BoundField DataField="lw_crf6_35" HeaderText="lw_crf6_35" />
                    <asp:BoundField DataField="name" HeaderText="name" />
                    <asp:BoundField DataField="code1" HeaderText="code1" />
                    <asp:BoundField DataField="code2" HeaderText="code2" />
                    <asp:BoundField DataField="BabyLength_R1" HeaderText="BabyLength_R1" />
                    <asp:BoundField DataField="BabyLength_R2" HeaderText="BabyLength_R2" />
                    <asp:BoundField DataField="BabyMUAC_R1" HeaderText="BabyMUAC_R1" />
                    <asp:BoundField DataField="BabyMUAC_R2" HeaderText="BabyMUAC_R2" />
                    <asp:BoundField DataField="BabyOFHC_R1" HeaderText="BabyOFHC_R1" />
                    <asp:BoundField DataField="BabyOFHC_R2" HeaderText="BabyOFHC_R2" />
                    <asp:BoundField DataField="LW_Weight_R1" HeaderText="LW_Weight_R1" />
                    <asp:BoundField DataField="LW_Weight_R2" HeaderText="LW_Weight_R2" />
                    <asp:BoundField DataField="LW_MUAC_R1" HeaderText="LW_MUAC_R1" />
                    <asp:BoundField DataField="LW_MUAC_R2" HeaderText="LW_MUAC_R2" />
                    <asp:BoundField DataField="BabyWeight_R1" HeaderText="BabyWeight_R1" />
                    <asp:BoundField DataField="BabyWeight_R2" HeaderText="BabyWeight_R2" />
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
                    <asp:BoundField DataField="form_crf_6_id" HeaderText="form_crf_6_id" />
                    <asp:BoundField DataField="followup_no" HeaderText="followup_no" />
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="lw_crf6_2" HeaderText="lw_crf6_2" />
                    <asp:BoundField DataField="lw_crf6_3" HeaderText="lw_crf6_3" />
                    <asp:BoundField DataField="q9" HeaderText="q9" />
                    <asp:BoundField DataField="q10" HeaderText="q10" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="site" HeaderText="site" />
                    <asp:BoundField DataField="para" HeaderText="para" />
                    <asp:BoundField DataField="block" HeaderText="block" />
                    <asp:BoundField DataField="struct" HeaderText="struct" />
                    <asp:BoundField DataField="HH" HeaderText="HH" />
                    <asp:BoundField DataField="wm_no" HeaderText="wm_no" />
                    <asp:BoundField DataField="arm" HeaderText="arm" />
                    <asp:BoundField DataField="lw_crf6_15" HeaderText="lw_crf6_15" />
                    <asp:BoundField DataField="refused_reason" HeaderText="refused_reason" />
                    <asp:BoundField DataField="lw_crf6_17" HeaderText="lw_crf6_17" />
                    <asp:BoundField DataField="lw_crf6_18" HeaderText="lw_crf6_18" />
                    <asp:BoundField DataField="lw_crf6_20" HeaderText="lw_crf6_20" />
                    <asp:BoundField DataField="lw_crf6_22" HeaderText="lw_crf6_22" />
                    <asp:BoundField DataField="lw_crf6_24" HeaderText="lw_crf6_24" />
                    <asp:BoundField DataField="lw_crf6_27" HeaderText="lw_crf6_27" />
                    <asp:BoundField DataField="lw_crf6_28" HeaderText="lw_crf6_28" />
                    <asp:BoundField DataField="lw_crf6_30" HeaderText="lw_crf6_30" />
                    <asp:BoundField DataField="lw_crf6_34" HeaderText="lw_crf6_34" />
                    <asp:BoundField DataField="lw_crf6_35" HeaderText="lw_crf6_35" />
                    <asp:BoundField DataField="name" HeaderText="name" />
                    <asp:BoundField DataField="code1" HeaderText="code1" />
                    <asp:BoundField DataField="code2" HeaderText="code2" />
                    <asp:BoundField DataField="BabyLength_R1" HeaderText="BabyLength_R1" />
                    <asp:BoundField DataField="BabyLength_R2" HeaderText="BabyLength_R2" />
                    <asp:BoundField DataField="BabyMUAC_R1" HeaderText="BabyMUAC_R1" />
                    <asp:BoundField DataField="BabyMUAC_R2" HeaderText="BabyMUAC_R2" />
                    <asp:BoundField DataField="BabyOFHC_R1" HeaderText="BabyOFHC_R1" />
                    <asp:BoundField DataField="BabyOFHC_R2" HeaderText="BabyOFHC_R2" />
                    <asp:BoundField DataField="LW_Weight_R1" HeaderText="LW_Weight_R1" />
                    <asp:BoundField DataField="LW_Weight_R2" HeaderText="LW_Weight_R2" />
                    <asp:BoundField DataField="LW_MUAC_R1" HeaderText="LW_MUAC_R1" />
                    <asp:BoundField DataField="LW_MUAC_R2" HeaderText="LW_MUAC_R2" />
                    <asp:BoundField DataField="BabyWeight_R1" HeaderText="BabyWeight_R1" />
                    <asp:BoundField DataField="BabyWeight_R2" HeaderText="BabyWeight_R2" />
                </Columns>
            </asp:GridView>

            <%--For BMGF Export --%>
            <asp:GridView ID="GridViewBMFG" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true">
            </asp:GridView>

        </div>
    </div>
</asp:Content>
