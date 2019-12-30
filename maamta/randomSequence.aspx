﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="randomSequence.aspx.cs" Inherits="maamta.randomSequence" %>

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


    <div style="padding-left: 2%; margin-top: 15px;">
        <div style="color: #ff6b6b; font-size: 22px; width: 100%">
            Check (Randomization-ID) Sequence
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
                <asp:ListItem Value="0">Select SITE</asp:ListItem>
                <asp:ListItem Value="AG">AG  (Ali Akbar Shah)</asp:ListItem>
                <asp:ListItem Value="BH">BH  (Behance Colony)</asp:ListItem>
                <asp:ListItem Value="RG">RG  (Rehri Goth)</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="margin-bottom: 10px; margin-top: 3px; text-align: center" class="Mobile">
            <asp:Button ID="btnSearch" runat="server" class="btn btn-theme" OnClick="btnSearch_Click" Text="Search" />
        </div>




        <div style="width: 100%; height: 455px; overflow: scroll; margin-top: 10px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DSSID">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkStudyID" OnClick="Link_StudyID" Text='<%#Eval("dssid") %>' runat="server" ToolTip="Form Detail" CommandArgument='<%#Eval("form_crf_3a_id")+","+ Eval("study_id")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="lw_crf_3a_2" HeaderText="Date of Visit" />
                    <asp:BoundField DataField="lw_crf_3a_3" HeaderText="Time of Visit" />
                    <asp:BoundField DataField="lw_crf_3a_18" HeaderText="Form Random ID" />
                    <asp:BoundField DataField="randomization_id" HeaderText="Correct Random ID" />
                    <asp:BoundField DataField="lw_crf_3a_19" HeaderText="Form ARM" />
                    <asp:BoundField DataField="treatment" HeaderText="Correct ARM" />
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
        </div>


        <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="site" HeaderText="SITE" />
                <asp:BoundField DataField="study_id" HeaderText="Study-ID" />
                <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                <asp:BoundField DataField="lw_crf_3a_2" HeaderText="Date of Visit" />
                <asp:BoundField DataField="lw_crf_3a_3" HeaderText="Time of Visit" />
                <asp:BoundField DataField="lw_crf_3a_18" HeaderText="Randomization-ID" />
                <asp:BoundField DataField="randomization_id" HeaderText="Correct Randomization-ID" />
                <asp:BoundField DataField="lw_crf_3a_19" HeaderText="Form ARM" />
                <asp:BoundField DataField="treatment" HeaderText="Correct ARM" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
