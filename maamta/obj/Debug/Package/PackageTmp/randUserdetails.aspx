<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="randUserdetails.aspx.cs" Inherits="maamta.randUserdetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <asp:UpdateProgress ID="updateProgress" runat="server">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                        <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 4%; color: white; background-color: #ff7675; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>


            <div style="margin-top: 5px; font-size: 18px">
                <a href="dashboardRandom.aspx" class="logout">
                    <span class="glyphicon glyphicon-chevron-left"></span>Back 
                </a>
            </div>

            <div style="padding-left: 2%; margin-top: 15px;">
                <div style="color: #ff6b6b; font-size: 18px;">
                    Status of
            <asp:Label ID="lbeStatus" ForeColor="#10ac84" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                </div>
                <div style="color: #ff6b6b; font-size: 18px;">
                    Date from
            <asp:Label ID="lbeFdate" ForeColor="#10ac84" Font-Bold="true" runat="server" Text="Label"></asp:Label>
                    to
            <asp:Label ID="lbeSdate" Font-Bold="true" ForeColor="#10ac84" runat="server" Text="Label"></asp:Label>
                </div>
                <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">


                

                <%--Search Button--%>
                <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 13px; margin-top: 27px;">
                    <div id="imaginary_container">
                        <div class="input-group stylish-input-group">
                            <asp:TextBox ID="txtdssid" CssClass="form-control txtboxx" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                            <span class="input-group-addon">
                                <button type="submit" id="btnSearch" runat="server" style="height: 20px" onserverclick="btnSearch_Click">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>


                <div style="width: 100%; overflow: auto">

                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." CssClass="footable" ForeColor="#333333" AutoGenerateColumns="true" >
                    
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#00b894" ForeColor="white" Font-Bold="True" />
                        <PagerSettings Position="TopAndBottom" Mode="NumericFirstLast" PreviousPageText="&amp;lt;" PageButtonCount="13" />
                        <PagerStyle BackColor="#284775" ForeColor="White" CssClass="StylePager" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>