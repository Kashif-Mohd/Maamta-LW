<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="moniLWAnthro.aspx.cs" Inherits="maamta.moniLWAnthro" %>

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
            Lactating Woman (LW) Anthro for Monitoring:
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
                    <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="Complete DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; height: 450px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." OnRowDataBound="OnRowDataBound" AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="arm" HeaderText="ARM" />
                    <asp:BoundField DataField="crf2_dov" HeaderText="CRF2 dov" />
                    <asp:BoundField DataField="date_of_outcome" HeaderText="Date of Outcome" />
                    <asp:BoundField DataField="LW Height" HeaderText="" />
                    <asp:BoundField DataField="crf3c_LW_Height" HeaderText="CRF3c Height" />
                    <asp:BoundField DataField="LW MUAC" HeaderText="" />
                    <asp:BoundField DataField="crf1_LW_MUAC" HeaderText="CRF1 MUAC" />
                    <asp:BoundField DataField="crf2_LW_MUAC" HeaderText="CRF2 MUAC" />
                    <asp:BoundField DataField="crf3c_LW_MUAC" HeaderText="CRF3c MUAC" />
                    <asp:BoundField DataField="F1_LW_MUAC" HeaderText="F1 MUAC" />
                    <asp:BoundField DataField="F2_LW_MUAC" HeaderText="F2 MUAC" />
                    <asp:BoundField DataField="F3_LW_MUAC" HeaderText="F3 MUAC" />
                    <asp:BoundField DataField="F4_LW_MUAC" HeaderText="F4 MUAC" />
                    <asp:BoundField DataField="F5_LW_MUAC" HeaderText="F5 MUAC" />
                    <asp:BoundField DataField="F6_LW_MUAC" HeaderText="F6 MUAC" />
                    <asp:BoundField DataField="F7_LW_MUAC" HeaderText="F7 MUAC" />
                    <asp:BoundField DataField="F8_LW_MUAC" HeaderText="F8 MUAC" />
                    <asp:BoundField DataField="LW Weight" HeaderText="" />
                    <asp:BoundField DataField="crf3c_LW_weight" HeaderText="CRF3c Weight" />
                    <asp:BoundField DataField="F1_LW_weight" HeaderText="F1 Weight" />
                    <asp:BoundField DataField="F2_LW_weight" HeaderText="F2 Weight" />
                    <asp:BoundField DataField="F3_LW_weight" HeaderText="F3 Weight" />
                    <asp:BoundField DataField="F4_LW_weight" HeaderText="F4 Weight" />
                    <asp:BoundField DataField="F5_LW_weight" HeaderText="F5 Weight" />
                    <asp:BoundField DataField="F6_LW_weight" HeaderText="F6 Weight" />
                    <asp:BoundField DataField="F7_LW_weight" HeaderText="F7 Weight" />
                    <asp:BoundField DataField="F8_LW_weight" HeaderText="F8 Weight" />
                    <asp:BoundField DataField="" HeaderText="" />
                    <asp:BoundField DataField="Screening_Date" HeaderText="Screening Date" />
                    <asp:BoundField DataField="Enrollment_Date" HeaderText="Enrollment Date" />
                    <asp:BoundField DataField="F1_DATE" HeaderText="F1_DATE" />
                    <asp:BoundField DataField="F2_DATE" HeaderText="F2_DATE" />
                    <asp:BoundField DataField="F3_DATE" HeaderText="F3_DATE" />
                    <asp:BoundField DataField="F4_DATE" HeaderText="F4_DATE" />
                    <asp:BoundField DataField="F5_DATE" HeaderText="F5_DATE" />
                    <asp:BoundField DataField="F6_DATE" HeaderText="F6_DATE" />
                    <asp:BoundField DataField="" HeaderText="" />
                    <asp:BoundField DataField="" HeaderText="BMI" />
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
                    <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                    <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                    <asp:BoundField DataField="arm" HeaderText="ARM" />
                    <asp:BoundField DataField="crf2_dov" HeaderText="CRF2 dov" />
                    <asp:BoundField DataField="date_of_outcome" HeaderText="Date of Outcome" />
                    <asp:BoundField DataField="LW Height" HeaderText="" />
                    <asp:BoundField DataField="crf3c_LW_Height" HeaderText="CRF3c Height" />
                    <asp:BoundField DataField="LW MUAC" HeaderText="" />
                    <asp:BoundField DataField="crf1_LW_MUAC" HeaderText="CRF1 MUAC" />
                    <asp:BoundField DataField="crf2_LW_MUAC" HeaderText="CRF2 MUAC" />
                    <asp:BoundField DataField="crf3c_LW_MUAC" HeaderText="CRF3c MUAC" />
                    <asp:BoundField DataField="F1_LW_MUAC" HeaderText="F1 MUAC" />
                    <asp:BoundField DataField="F2_LW_MUAC" HeaderText="F2 MUAC" />
                    <asp:BoundField DataField="F3_LW_MUAC" HeaderText="F3 MUAC" />
                    <asp:BoundField DataField="F4_LW_MUAC" HeaderText="F4 MUAC" />
                    <asp:BoundField DataField="F5_LW_MUAC" HeaderText="F5 MUAC" />
                    <asp:BoundField DataField="F6_LW_MUAC" HeaderText="F6 MUAC" />
                    <asp:BoundField DataField="F7_LW_MUAC" HeaderText="F7 MUAC" />
                    <asp:BoundField DataField="F8_LW_MUAC" HeaderText="F8 MUAC" />
                    <asp:BoundField DataField="LW Weight" HeaderText="" />
                    <asp:BoundField DataField="crf3c_LW_weight" HeaderText="CRF3c Weight" />
                    <asp:BoundField DataField="F1_LW_weight" HeaderText="F1 Weight" />
                    <asp:BoundField DataField="F2_LW_weight" HeaderText="F2 Weight" />
                    <asp:BoundField DataField="F3_LW_weight" HeaderText="F3 Weight" />
                    <asp:BoundField DataField="F4_LW_weight" HeaderText="F4 Weight" />
                    <asp:BoundField DataField="F5_LW_weight" HeaderText="F5 Weight" />
                    <asp:BoundField DataField="F6_LW_weight" HeaderText="F6 Weight" />
                    <asp:BoundField DataField="F7_LW_weight" HeaderText="F7 Weight" />
                    <asp:BoundField DataField="F8_LW_weight" HeaderText="F8 Weight" />
                    <asp:BoundField DataField="" HeaderText="" />
                    <asp:BoundField DataField="Screening_Date" HeaderText="Screening Date" />
                    <asp:BoundField DataField="Enrollment_Date" HeaderText="Enrollment Date" />
                    <asp:BoundField DataField="F1_DATE" HeaderText="F1_DATE" />
                    <asp:BoundField DataField="F2_DATE" HeaderText="F2_DATE" />
                    <asp:BoundField DataField="F3_DATE" HeaderText="F3_DATE" />
                    <asp:BoundField DataField="F4_DATE" HeaderText="F4_DATE" />
                    <asp:BoundField DataField="F5_DATE" HeaderText="F5_DATE" />
                    <asp:BoundField DataField="F6_DATE" HeaderText="F6_DATE" />
                    <asp:BoundField DataField="" HeaderText="" />
                    <asp:BoundField DataField="" HeaderText="BMI" />

                </Columns>


            </asp:GridView>
        </div>
    </div>
</asp:Content>
