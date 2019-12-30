<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="pendingvaccination.aspx.cs" Inherits="maamta.pendingvaccination" %>

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
            Pending Vaccination
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -17px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExport_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>




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




        <div style="width: 100%; height: 455px; overflow: scroll; margin-top: 10px">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="OnRowDataBound" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="study_code" />
                    <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                    <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                    <asp:BoundField DataField="arm" HeaderText="arm" />
                    <asp:BoundField DataField="dob" HeaderText="dob" />
                    <asp:BoundField DataField="current_age" HeaderText="current_age" />
                    <asp:BoundField DataField="dssid" HeaderText="dssid" />
                    <asp:BoundField DataField="Done_After_Birth" HeaderText="Done_After_Birth" />
                    <asp:BoundField DataField="Pending_After_Birth" HeaderText="Pending_After_Birth" />
                    <asp:BoundField DataField="Done_Greater_6_Weeks" HeaderText="Done_Greater_6_Weeks" />
                    <asp:BoundField DataField="Pending_Greater_6_Weeks" HeaderText="Pending_Greater_6_Weeks" />
                    <asp:BoundField DataField="Done_Greater_10_Weeks" HeaderText="Done_Greater_10_Weeks" />
                    <asp:BoundField DataField="Pending_Greater_10_Weeks" HeaderText="Pending_Greater_10_Weeks" />
                    <asp:BoundField DataField="Done_Greater_14_Weeks" HeaderText="Done_Greater_14_Weeks" />
                    <asp:BoundField DataField="Pending_Greater_14_Weeks" HeaderText="Pending_Greater_14_Weeks" />
                    <asp:BoundField DataField="dod" HeaderText="dod" />
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


        <asp:GridView ID="GridView2" runat="server" CssClass="footable" ForeColor="#333333" AutoGenerateColumns="false"  OnRowDataBound="OnRowDataBound" >
            <Columns>
                <asp:TemplateField HeaderText="Serial no.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:BoundField DataField="study_code" HeaderText="study_code" />
                <asp:BoundField DataField="woman_nm" HeaderText="woman_nm" />
                <asp:BoundField DataField="husband_nm" HeaderText="husband_nm" />
                <asp:BoundField DataField="arm" HeaderText="arm" />
                <asp:BoundField DataField="dob" HeaderText="dob" />
                <asp:BoundField DataField="current_age" HeaderText="current_age" />
                <asp:BoundField DataField="dssid" HeaderText="dssid" />
                <asp:BoundField DataField="Done_After_Birth" HeaderText="Done_After_Birth" />
                <asp:BoundField DataField="Pending_After_Birth" HeaderText="Pending_After_Birth" />
                <asp:BoundField DataField="Done_Greater_6_Weeks" HeaderText="Done_Greater_6_Weeks" />
                <asp:BoundField DataField="Pending_Greater_6_Weeks" HeaderText="Pending_Greater_6_Weeks" />
                <asp:BoundField DataField="Done_Greater_10_Weeks" HeaderText="Done_Greater_10_Weeks" />
                <asp:BoundField DataField="Pending_Greater_10_Weeks" HeaderText="Pending_Greater_10_Weeks" />
                <asp:BoundField DataField="Done_Greater_14_Weeks" HeaderText="Done_Greater_14_Weeks" />
                <asp:BoundField DataField="Pending_Greater_14_Weeks" HeaderText="Pending_Greater_14_Weeks" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
