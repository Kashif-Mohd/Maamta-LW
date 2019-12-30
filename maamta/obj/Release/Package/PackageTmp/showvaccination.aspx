<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="showvaccination.aspx.cs" Inherits="maamta.showvaccination" %>

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
            Vaccination:
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





        <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="woman_nm" HeaderText="mother_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="father_nm" />
                    <asp:BoundField DataField="arm" HeaderText="ARM" />
                    <asp:BoundField DataField="dob" HeaderText="DOB" />
                    <asp:BoundField DataField="current_age" HeaderText="Current Age" />
                    <asp:BoundField DataField="dod" HeaderText="DOD" />
                    <asp:BoundField DataField="" HeaderText="DOD_age" />
                    <asp:BoundField DataField="site" HeaderText="Site" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Anthro" HeaderText="Anthro Followups" />
                    <asp:BoundField DataField="bcg0_card_history" HeaderText="bcg0 card / history" />
                    <asp:BoundField DataField="bcg0_date" HeaderText="BCG0_date" />
                    <asp:BoundField DataField="bcg0_aku_vpt" HeaderText="bcg0 aku/vpt" />
                    <asp:BoundField DataField="opv0_card_history" HeaderText="opv0 card / history" />
                    <asp:BoundField DataField="opv0_date" HeaderText="OPV0_date" />
                    <asp:BoundField DataField="opv0_aku_vpt" HeaderText="opv0 aku/vpt" />
                    <asp:BoundField DataField="opv1_card_history" HeaderText="opv1 card / history" />
                    <asp:BoundField DataField="opv1_date" HeaderText="OPV1_date" />
                    <asp:BoundField DataField="opv1_aku_vpt" HeaderText="opv1 aku/vpt" />
                    <asp:BoundField DataField="penta1_card_history" HeaderText="penta1 card / history" />
                    <asp:BoundField DataField="penta1_date" HeaderText="Penta1_date" />
                    <asp:BoundField DataField="penta1_aku_vpt" HeaderText="penta1 aku/vpt" />
                    <asp:BoundField DataField="pcv1_card_history" HeaderText="pcv1 card / history" />
                    <asp:BoundField DataField="pcv1_date" HeaderText="PCV1_date" />
                    <asp:BoundField DataField="pcv1_aku_vpt" HeaderText="pcv1 aku/vpt" />
                    <asp:BoundField DataField="rota1_card_history" HeaderText="rota1 card / history" />
                    <asp:BoundField DataField="rota1_date" HeaderText="Rota1_date" />
                    <asp:BoundField DataField="rota1_aku_vpt" HeaderText="rota1 aku/vpt" />
                    <asp:BoundField DataField="opv2_card_history" HeaderText="opv2 card / history" />
                    <asp:BoundField DataField="opv2_date" HeaderText="OPV2_date" />
                    <asp:BoundField DataField="opv2_aku_vpt" HeaderText="opv2 aku/vpt" />
                    <asp:BoundField DataField="penta2_card_history" HeaderText="penta2 card / history" />
                    <asp:BoundField DataField="penta2_date" HeaderText="Penta2_date" />
                    <asp:BoundField DataField="penta2_aku_vpt" HeaderText="penta2 aku/vpt" />
                    <asp:BoundField DataField="pcv2_card_history" HeaderText="pcv2 card / history" />
                    <asp:BoundField DataField="pcv2_date" HeaderText="PCV2_date" />
                    <asp:BoundField DataField="pcv2_aku_vpt" HeaderText="pcv2 aku/vpt" />
                    <asp:BoundField DataField="rota2_card_history" HeaderText="rota2 card / history" />
                    <asp:BoundField DataField="rota2_date" HeaderText="Rota2_date" />
                    <asp:BoundField DataField="rota2_aku_vpt" HeaderText="rota2 aku/vpt" />
                    <asp:BoundField DataField="opv3_card_history" HeaderText="opv3 card / history" />
                    <asp:BoundField DataField="opv3_date" HeaderText="OPV3_date" />
                    <asp:BoundField DataField="opv3_aku_vpt" HeaderText="opv3 aku/vpt" />
                    <asp:BoundField DataField="penta3_card_history" HeaderText="penta3 card / history" />
                    <asp:BoundField DataField="penta3_date" HeaderText="Penta3_date" />
                    <asp:BoundField DataField="penta3_aku_vpt" HeaderText="penta3 aku/vpt" />
                    <asp:BoundField DataField="pcv3_card_history" HeaderText="pcv3 card / history" />
                    <asp:BoundField DataField="pcv3_date" HeaderText="PCV3_date" />
                    <asp:BoundField DataField="pcv3_aku_vpt" HeaderText="pcv3 aku/vpt" />
                    <asp:BoundField DataField="ipv_card_history" HeaderText="ipv card / history" />
                    <asp:BoundField DataField="ipv_date" HeaderText="IPV_date" />
                    <asp:BoundField DataField="ipv_aku_vpt" HeaderText="ipv aku/vpt" />
                    <asp:BoundField DataField="" HeaderText="" />
                    <asp:BoundField DataField="" HeaderText="Pending_After_Birth" />
                    <asp:BoundField DataField="" HeaderText="Pending_Greater_6_Weeks" />
                    <asp:BoundField DataField="" HeaderText="Pending_Greater_10_Weeks" />
                    <asp:BoundField DataField="" HeaderText="Pending_Greater_14_Weeks" />
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




            <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="woman_nm" HeaderText="mother_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="father_nm" />
                    <asp:BoundField DataField="arm" HeaderText="ARM" />
                    <asp:BoundField DataField="dob" HeaderText="DOB" />
                    <asp:BoundField DataField="current_age" HeaderText="Current Age" />
                    <asp:BoundField DataField="dod" HeaderText="DOD" />
                    <asp:BoundField DataField="" HeaderText="DOD_age" />
                    <asp:BoundField DataField="site" HeaderText="Site" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="Anthro" HeaderText="Anthro Followups" />
                    <asp:BoundField DataField="bcg0_card_history" HeaderText="bcg0 card / history" />
                    <asp:BoundField DataField="bcg0_date" HeaderText="BCG0_date" />
                    <asp:BoundField DataField="bcg0_aku_vpt" HeaderText="bcg0 aku/vpt" />
                    <asp:BoundField DataField="opv0_card_history" HeaderText="opv0 card / history" />
                    <asp:BoundField DataField="opv0_date" HeaderText="OPV0_date" />
                    <asp:BoundField DataField="opv0_aku_vpt" HeaderText="opv0 aku/vpt" />
                    <asp:BoundField DataField="opv1_card_history" HeaderText="opv1 card / history" />
                    <asp:BoundField DataField="opv1_date" HeaderText="OPV1_date" />
                    <asp:BoundField DataField="opv1_aku_vpt" HeaderText="opv1 aku/vpt" />
                    <asp:BoundField DataField="penta1_card_history" HeaderText="penta1 card / history" />
                    <asp:BoundField DataField="penta1_date" HeaderText="Penta1_date" />
                    <asp:BoundField DataField="penta1_aku_vpt" HeaderText="penta1 aku/vpt" />
                    <asp:BoundField DataField="pcv1_card_history" HeaderText="pcv1 card / history" />
                    <asp:BoundField DataField="pcv1_date" HeaderText="PCV1_date" />
                    <asp:BoundField DataField="pcv1_aku_vpt" HeaderText="pcv1 aku/vpt" />
                    <asp:BoundField DataField="rota1_card_history" HeaderText="rota1 card / history" />
                    <asp:BoundField DataField="rota1_date" HeaderText="Rota1_date" />
                    <asp:BoundField DataField="rota1_aku_vpt" HeaderText="rota1 aku/vpt" />
                    <asp:BoundField DataField="opv2_card_history" HeaderText="opv2 card / history" />
                    <asp:BoundField DataField="opv2_date" HeaderText="OPV2_date" />
                    <asp:BoundField DataField="opv2_aku_vpt" HeaderText="opv2 aku/vpt" />
                    <asp:BoundField DataField="penta2_card_history" HeaderText="penta2 card / history" />
                    <asp:BoundField DataField="penta2_date" HeaderText="Penta2_date" />
                    <asp:BoundField DataField="penta2_aku_vpt" HeaderText="penta2 aku/vpt" />
                    <asp:BoundField DataField="pcv2_card_history" HeaderText="pcv2 card / history" />
                    <asp:BoundField DataField="pcv2_date" HeaderText="PCV2_date" />
                    <asp:BoundField DataField="pcv2_aku_vpt" HeaderText="pcv2 aku/vpt" />
                    <asp:BoundField DataField="rota2_card_history" HeaderText="rota2 card / history" />
                    <asp:BoundField DataField="rota2_date" HeaderText="Rota2_date" />
                    <asp:BoundField DataField="rota2_aku_vpt" HeaderText="rota2 aku/vpt" />
                    <asp:BoundField DataField="opv3_card_history" HeaderText="opv3 card / history" />
                    <asp:BoundField DataField="opv3_date" HeaderText="OPV3_date" />
                    <asp:BoundField DataField="opv3_aku_vpt" HeaderText="opv3 aku/vpt" />
                    <asp:BoundField DataField="penta3_card_history" HeaderText="penta3 card / history" />
                    <asp:BoundField DataField="penta3_date" HeaderText="Penta3_date" />
                    <asp:BoundField DataField="penta3_aku_vpt" HeaderText="penta3 aku/vpt" />
                    <asp:BoundField DataField="pcv3_card_history" HeaderText="pcv3 card / history" />
                    <asp:BoundField DataField="pcv3_date" HeaderText="PCV3_date" />
                    <asp:BoundField DataField="pcv3_aku_vpt" HeaderText="pcv3 aku/vpt" />
                    <asp:BoundField DataField="ipv_card_history" HeaderText="ipv card / history" />
                    <asp:BoundField DataField="ipv_date" HeaderText="IPV_date" />
                    <asp:BoundField DataField="ipv_aku_vpt" HeaderText="ipv aku/vpt" />
                    <asp:BoundField DataField="" HeaderText="" />
                    <asp:BoundField DataField="" HeaderText="Pending_After_Birth" />
                    <asp:BoundField DataField="" HeaderText="Pending_Greater_6_Weeks" />
                    <asp:BoundField DataField="" HeaderText="Pending_Greater_10_Weeks" />
                    <asp:BoundField DataField="" HeaderText="Pending_Greater_14_Weeks" />
                </Columns>
            </asp:GridView>
        </div>


    </div>
</asp:Content>
