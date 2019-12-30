<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="dangersign.aspx.cs" Inherits="maamta.dangersign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* For DropDown CSS */
        .textDropDownCSS {
            font-size: 1.2em;
            font-family: Calibri;
            Height: 2.4em;
            color: #16a085;
        }



        .btnChng {
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            font-family: arial;
            font-size: 16px;
            padding: 4px 28px;
            text-decoration: none;
            font-weight: bold;
        }

            .btnChng:active {
                position: relative;
                top: 1px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color: #ff6b6b; font-size: 22px; width: 100%; margin-top: 15px; padding-left: 2%;">
        <h3><b>Danger Sign:</b></h3>
        <h4>(Note: Please refer these Child to the Physician)</h4>
        <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
    </div>
    <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">




    <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: -17px">
        <tr>
            <td>
                <asp:Button ID="btnbyEnrollment" OnClick="btnbyEnrollment_Click" CssClass="btnChng" runat="server" Text="During Enrollment" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
            </td>
            <td>
                <asp:Button ID="btnbyFollowups" OnClick="btnbyFollowups_Click" CssClass="btnChng" runat="server" Text="During Followups" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
            </td>
        </tr>
    </table>




    <div style="padding-left: 2%; margin-top: 15px;" id="divbyEnrollment" runat="server">

        <div id="divExportButton" runat="server" style="text-align: right; margin-top: -5px">
            <button type="button" id="Button1" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExportbyEnrollment_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>
        <div id="divSearch" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">


            <div id="imaginary_container" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssidbyEnrollment" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="Complete DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnbyEnrollment_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No any Danger Sign record found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="assis_id" HeaderText="Assistment ID" />
                    <asp:BoundField DataField="study_code" HeaderText="Study Code" />
                    <asp:BoundField DataField="Date_of_Enrollment" HeaderText="Date of Enrollment" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="Woman_Name" HeaderText="Woman Name" />
                    <asp:BoundField DataField="Husband_Name" HeaderText="Husband Name" />
                    <asp:BoundField DataField="q73" HeaderText="Complication, Problem or Disease" />
                    <asp:BoundField DataField="q74" HeaderText="Has the baby been taken to any health care facility since birth?" />
                    <asp:BoundField DataField="q75" HeaderText="From where was the care was sought?" />
                    <asp:BoundField DataField="q76" HeaderText="Did the baby received any treatment?" />
                    <asp:BoundField DataField="q77" HeaderText="What was the treatment given?" />
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




            <asp:GridView ID="GridView2" runat="server" EmptyDataText="No any Danger Sign record found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="assis_id" HeaderText="Assistment ID" />
                    <asp:BoundField DataField="study_code" HeaderText="Study Code" />
                    <asp:BoundField DataField="Date_of_Enrollment" HeaderText="Date of Enrollment" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="Woman_Name" HeaderText="Woman Name" />
                    <asp:BoundField DataField="Husband_Name" HeaderText="Husband Name" />
                    <asp:BoundField DataField="q73" HeaderText="Complication, Problem or Disease" />
                    <asp:BoundField DataField="q74" HeaderText="Has the baby been taken to any health care facility since birth?" />
                    <asp:BoundField DataField="q75" HeaderText="From where was the care was sought?" />
                    <asp:BoundField DataField="q76" HeaderText="Did the baby received any treatment?" />
                    <asp:BoundField DataField="q77" HeaderText="What was the treatment given?" />
                </Columns>
            </asp:GridView>
        </div>
    </div>











    <div style="padding-left: 2%; margin-top: 15px;" id="divbyFollowups" runat="server">

        <div id="div3" runat="server" style="text-align: right; margin-top: -5px">
            <button type="button" id="Button2" class="btn btn-success" runat="server" style="height: 38px" onserverclick="btnExportbyFollowups_Click">
                Export &nbsp<span class="glyphicon glyphicon-export"></span>
            </button>
        </div>


        <%--Search Button--%>

        <div id="div5" runat="server" class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 0px;">


            <div id="Div6" style="margin-top: 10px">
                <div class="input-group stylish-input-group">
                    <asp:TextBox ID="txtdssidbyFollowups" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="Complete DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                    <span class="input-group-addon">
                        <button type="submit" id="Button3" runat="server" style="height: 20px" onserverclick="btnSearchbyFollowups_Click">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </span>
                </div>
            </div>

        </div>




        <div style="width: 100%; overflow: auto">
            <asp:GridView ID="GridView3" runat="server" EmptyDataText="No any Danger Sign record found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study Code" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Number" />
                    <asp:BoundField DataField="Date_of_Followup" HeaderText="Date of Followup" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="Woman_Name" HeaderText="Woman Name" />
                    <asp:BoundField DataField="Husband_Name" HeaderText="Husband Name" />
                    <asp:BoundField DataField="q21" HeaderText="Complication, Problem or Disease" />
                    <asp:BoundField DataField="q22" HeaderText="Was baby taken to any health care facility?" />
                    <asp:BoundField DataField="q23" HeaderText="From where was the care was sought?" />
                    <asp:BoundField DataField="q24" HeaderText="Did the baby received any treatment?" />
                    <asp:BoundField DataField="q25" HeaderText="What was the treatment given?" />
                    <asp:BoundField DataField="q26" HeaderText="Any prescription or wrapper of medicine's available?" />
                    <asp:BoundField DataField="q27" HeaderText="Name of Medicine" />
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




            <asp:GridView ID="GridView4" runat="server" EmptyDataText="No any Danger Sign record found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Serial no.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="study_code" HeaderText="Study Code" />
                    <asp:BoundField DataField="followup_num" HeaderText="Followup Number" />
                    <asp:BoundField DataField="Date_of_Followup" HeaderText="Date of Followup" />
                    <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                    <asp:BoundField DataField="Woman_Name" HeaderText="Woman Name" />
                    <asp:BoundField DataField="Husband_Name" HeaderText="Husband Name" />
                    <asp:BoundField DataField="q21" HeaderText="Complication, Problem or Disease" />
                    <asp:BoundField DataField="q22" HeaderText="Was baby taken to any health care facility?" />
                    <asp:BoundField DataField="q23" HeaderText="From where was the care was sought?" />
                    <asp:BoundField DataField="q24" HeaderText="Did the baby received any treatment?" />
                    <asp:BoundField DataField="q25" HeaderText="What was the treatment given?" />
                    <asp:BoundField DataField="q26" HeaderText="Any prescription or wrapper of medicine's available?" />
                    <asp:BoundField DataField="q27" HeaderText="Name of Medicine" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
