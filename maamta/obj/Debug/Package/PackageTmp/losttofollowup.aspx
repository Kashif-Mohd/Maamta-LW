<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="losttofollowup.aspx.cs" Inherits="maamta.losttofollowup" %>

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
            Consent Refused (or) Lost to Follow-ups:
            <asp:Label ID="lbeDateFromTo" ForeColor="#10ac84" Font-Size="17px" Font-Bold="true" runat="server" Text=""></asp:Label>
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">



        <div id="divShowData" runat="server" visible="true">


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
            <div style="width: 100%; height: 460px; overflow: scroll; margin-top: 20px">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Record Found." AllowPaging="True" PageSize="200" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="Link_id" OnClick="Link_EditForm" Text='Edit' runat="server" ToolTip="Edit Anthro Record" CommandArgument='<%#Eval("study_id")+","+ Eval("dssid")+","+ Eval("woman_nm")+","+ Eval("husband_nm")+","+ Eval("wm_status")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial no.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="study_id" HeaderText="study_code" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="wm_status" HeaderText="Participant Status" />
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
                        <asp:BoundField DataField="study_code" HeaderText="study_code" />
                        <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                        <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                        <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                        <asp:BoundField DataField="wm_status" HeaderText="Participant Status" />
                        <asp:BoundField DataField="entry_nm" HeaderText="Entry Name" />
                        <asp:BoundField DataField="entry_dt" HeaderText="Entry Date" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>



        <div id="divEntry" runat="server" visible="false" style="text-align: center; margin-top: 10px">
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">




                        <tr class="trCSS">
                            <td class="TableColumn tdCSS spaceMob">Study ID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ReadOnly="true"  ClientIDMode="Static" ID="txtStudyID" Height="2.3em" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">DSSID</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ReadOnly="true"  ClientIDMode="Static" ID="txtdssidEntry" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.3em" placeholder="mother name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Woman Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ReadOnly="true"  ClientIDMode="Static" ID="txtWomanNm" Style="text-transform: uppercase;" type="text" Font-Size="Medium" Height="2.3em" placeholder="mother name" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Husband Name</td>
                            <td class="Space tdCSS">
                                <asp:TextBox CssClass="form-control input-lg textBoxCSS" ReadOnly="true"  ClientIDMode="Static" ID="txtHusbandNm" Style="text-transform: uppercase;" type="text" placeholder="father name" Height="2.3em" MaxLength="25" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="trCSS">
                            <td class="TableColumn tdCSS">Status</td>
                            <td class="Space tdCSScenter">
                                <!--Radio group-->
                                <asp:RadioButtonList ID="txtStatus" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Text="&nbsp None" Value="None" Selected="True" />
                                    <asp:ListItem Text="&nbsp Lost to Followups" Value="Lost to Followups" />
                                    <asp:ListItem Text="&nbsp Consent Refused" Value="Consent Refused" />
                                </asp:RadioButtonList>
                                <!--Radio group-->
                            </td>
                        </tr>
                    </table>


                    <br>
                    <br>
                    <br>
                    <br>
                    <div class="buttonWeb">
                        <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" class="btn btn-theme btn-lg btn-block" OnClick="submit_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>


    </div>
</asp:Content>
