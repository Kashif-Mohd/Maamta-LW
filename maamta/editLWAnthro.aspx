<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="editLWAnthro.aspx.cs" Inherits="maamta.editLWAnthro" %>

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



            /* own design*/
            table {
                border-collapse: collapse;
                width: 100%;
            }

            .trCSS {
                border-bottom: 1px solid #ddd;
            }

            .tdCSS {
                margin-top: 1em;
                margin-bottom: 1em;
                display: block;
                font-family: Trebuchet MS;
                text-align: center;
            }

            .tdCSScenter {
                margin-left: 37%;
                margin-top: 1em;
                margin-bottom: 1em;
                display: block;
                font-family: Trebuchet MS;
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
            For Update LW Anthro:
        </div>
        <hr style="border-top: 1px solid #ccc; background: transparent; margin-top: -3px">




        <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: -17px">
            <tr>
                <td>
                    <asp:Button ID="btnCRF1" OnClick="btnCRF1_Click" CssClass="btnChng" runat="server" Text="CRF1 (LW Anthro)" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnCRF3c" OnClick="btnCRF3c_Click" CssClass="btnChng" runat="server" Text="CRF3c (LW Anthro)" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnCRF6" OnClick="btnCRF6_Click" CssClass="btnChng" runat="server" Text="CRF6 (LW Anthro)" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
            </tr>
        </table>








        





        <div id="divCRF1" runat="server" visible="true">

            <div id="divShowCRF1" runat="server" visible="true">


                <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 10px;">
                    <div id="Div1" style="margin-top: 10px">
                        <div class="input-group stylish-input-group">
                            <asp:TextBox ID="txtdssidCRF1" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                            <span class="input-group-addon">
                                <button type="submit" id="btnSearchCRF1" runat="server" style="height: 20px" onserverclick="btnSearchCRF1_Click">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>


                <div style="width: 100%; height: 425px; overflow: scroll; margin-top: 20px">
                    <asp:GridView ID="GridViewCRF1" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link_id_CRF1" OnClick="Link_EditFormCRF1" Text='Edit' runat="server" ToolTip="Edit Anthro Record" CommandArgument='<%#Eval("form_crf_1_id")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="assis_id" HeaderText="Assessment ID" />
                            <asp:BoundField DataField="lw_crf1_02" HeaderText="DOV" />
                            <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                            <asp:BoundField DataField="woman_nm" HeaderText="Woman Name" />
                            <asp:BoundField DataField="husband_nm" HeaderText="Husband Name" />
                            <asp:BoundField DataField="lw_crf1_21" HeaderText="LW-MUAC" />
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
                </div>
            </div>

            <div id="divEntryCRF1" runat="server" visible="false" style="text-align: center; margin-top: 10px">

                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">

                        <tr class="trCSS">
                            <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Mid Upper Arm Circumference (MUAC) of LW (in cm)
                                <br>
                                <td class="tdCSS">
                                    <%--MUAC start--%>

                                    <table>
                                        <thead>
                                            <tr class="trCSS">
                                                <th>Reading 1</th>
                                                <th>Reading 2</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <tr class="trCSS">
                                                <td class="tdCSS" data-th="Reading 1">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF1MUACR1" type="tel" placeholder="reading 1" ClientIDMode="Static" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtCRF1MUACR1" Mask="99.9" MaskType="Number" />
                                                </td>
                                                <td class="tdCSS" data-th="Reading 2">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF1MUACR2" type="tel" placeholder="reading 2" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtCRF1MUACR2" Mask="99.9" MaskType="Number" />
                                                </td>
                                            </tr>


                                            <tr>
                                                <td colspan="3" style="text-align: center" class="tdCSS">
                                                    <asp:Button ID="btnCRF1MUAC" runat="server" Text="Update MUAC" class="btn btn-danger btn-lg" OnClick="btnCRF1MUAC_Click" />
                                                </td>
                                            </tr>


                                        </tbody>
                                    </table>

                                    <%--MUAC End--%>
                                </td>
                        </tr>


                    </table>
                </div>

            </div>


        </div>







        <div id="divCRF3c" runat="server" visible="true">

            <div id="divShowCRF3c" runat="server" visible="true">


                <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 10px;">
                    <div id="imaginary_container" style="margin-top: 10px">
                        <div class="input-group stylish-input-group">
                            <asp:TextBox ID="txtdssidCRF3c" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                            <span class="input-group-addon">
                                <button type="submit" id="btnSearchCRF3c" runat="server" style="height: 20px" onserverclick="btnSearchCRF3c_Click">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>


                <div style="width: 100%; height: 425px; overflow: scroll; margin-top: 20px">
                    <asp:GridView ID="GridViewCRF3c" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link_id_CRF3c" OnClick="Link_EditFormCRF3c" Text='Edit' runat="server" ToolTip="Edit Anthro Record" CommandArgument='<%#Eval("form_crf_3c_id")+","+ Eval("assis_id")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Serial no.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                            <asp:BoundField DataField="lw_crf3c_2" HeaderText="DOV" />
                            <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                            <asp:BoundField DataField="q6" HeaderText="Woman Name" />
                            <asp:BoundField DataField="q7" HeaderText="Husband Name" />
                            <asp:BoundField DataField="lw_crf3c_23" HeaderText="LW-Weight" />
                            <asp:BoundField DataField="lw_crf3c_25" HeaderText="LW-Height" />
                            <asp:BoundField DataField="lw_crf3c_27" HeaderText="LW-MUAC" />
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
                </div>
            </div>

                <div id="divEntryCRF3c" runat="server" visible="false" style="text-align: center; margin-top: 10px">


                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">


                        <tr class="trCSS">
                            <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Height Woman (in cm)
                                <br>
                                <td class="tdCSS">
                                    <%--Height start--%>

                                    <table>
                                        <thead>
                                            <tr class="trCSS">
                                                <th>Reading 1</th>
                                                <th>Reading 2</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <tr class="trCSS">
                                                <td class="tdCSS" data-th="Reading 1">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF3cHeightR1" type="tel" placeholder="reading 1" ClientIDMode="Static"  runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtCRF3cHeightR1" Mask="999.9" MaskType="Number" />
                                                </td>
                                                <td class="tdCSS" data-th="Reading 2">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF3cHeightR2" type="tel" placeholder="reading 2" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)"  runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtCRF3cHeightR2" Mask="999.9" MaskType="Number" />
                                                </td>
                                            </tr>


                                            <tr>
                                                <td colspan="3" style="text-align: center" class="tdCSS">
                                                    <asp:Button ID="btnCRF3cHeight" runat="server" Text="Update Height" class="btn btn-danger btn-lg" OnClick="btnCRF3cHeight_Click" />
                                                </td>
                                            </tr>


                                        </tbody>
                                    </table>

                                    <%--Height End--%>
                                </td>
                        </tr>

                        <tr class="trCSS">
                            <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Mid Upper Arm Circumference (MUAC) of LW (in cm)
                                <br>
                                <td class="tdCSS">
                                    <%--MUAC start--%>

                                    <table>
                                        <thead>
                                            <tr class="trCSS">
                                                <th>Reading 1</th>
                                                <th>Reading 2</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <tr class="trCSS">
                                                <td class="tdCSS" data-th="Reading 1">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF3cMUACR1" type="tel" placeholder="reading 1" ClientIDMode="Static" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCRF3cMUACR1" Mask="99.9" MaskType="Number" />
                                                </td>
                                                <td class="tdCSS" data-th="Reading 2">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF3cMUACR2" type="tel" placeholder="reading 2" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtCRF3cMUACR2" Mask="99.9" MaskType="Number" />
                                                </td>
                                            </tr>


                                            <tr>
                                                <td colspan="3" style="text-align: center" class="tdCSS">
                                                    <asp:Button ID="btnCRF3cMUAC" runat="server" Text="Update MUAC" class="btn btn-danger btn-lg" OnClick="btnCRF3cMUAC_Click" />
                                                </td>
                                            </tr>


                                        </tbody>
                                    </table>

                                    <%--MUAC End--%>
                                </td>
                        </tr>

                        <tr class="trCSS">
                            <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Weight Woman (in cm)
                                <br>
                                <td class="tdCSS">
                                    <%--Weight LW start--%>

                                    <table>
                                        <thead>
                                            <tr class="trCSS">
                                                <th>Reading 1</th>
                                                <th>Reading 2</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <tr class="trCSS">
                                                <td class="tdCSS" data-th="Reading 1">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF3cWeightR1" type="tel" placeholder="reading 1" ClientIDMode="Static" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtCRF3cWeightR1" Mask="99.9" MaskType="Number" />
                                                </td>
                                                <td class="tdCSS" data-th="Reading 2">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF3cWeightR2" type="tel" placeholder="reading 2" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtCRF3cWeightR2" Mask="99.9" MaskType="Number" />
                                                </td>
                                            </tr>


                                            <tr>
                                                <td colspan="3" style="text-align: center" class="tdCSS">
                                                    <asp:Button ID="btnCRF3cWeight" runat="server" Text="Update Weight" class="btn btn-danger btn-lg" OnClick="btnCRF3cWeight_Click" />
                                                </td>
                                            </tr>


                                        </tbody>
                                    </table>

                                    <%--Weight LW End--%>
                                </td>
                        </tr>

                    </table>
                </div>


            </div>


        </div>






        <div id="divCRF6" runat="server" visible="false">

            <div id="divShowCRF6" runat="server" visible="true">


                <div class="col-lg-4 col-lg-offset-4" style="margin-bottom: 10px; margin-top: 10px;">
                    <div style="margin-top: 10px">
                        <div class="input-group stylish-input-group">
                            <asp:TextBox ID="txtdssidCRF6" CssClass="form-control txtboxx" ClientIDMode="Static" runat="server" placeholder="DSSID" MaxLength="11" ForeColor="Black"></asp:TextBox>
                            <span class="input-group-addon">
                                <button type="submit" id="btnSearchCRF6" runat="server" style="height: 20px" onserverclick="btnSearchCRF6_Click">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                            </span>
                        </div>
                    </div>
                </div>


                <div style="width: 100%; height: 425px; overflow: scroll; margin-top: 20px">
                    <asp:GridView ID="GridViewCRF6" runat="server" EmptyDataText="No Record Found." CssClass="footable" AllowSorting="false" ForeColor="#333333" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Link_id_CRF6" OnClick="Link_EditFormCRF6" Text='Edit' runat="server" ToolTip="Edit Anthro Record" CommandArgument='<%#Eval("form_crf_6_id")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="study_code" HeaderText="Study ID" />
                            <asp:BoundField DataField="followup_no" HeaderText="Followup No." />
                            <asp:BoundField DataField="lw_crf6_2" HeaderText="DOV" />
                            <asp:BoundField DataField="dssid" HeaderText="DSSID" />
                            <asp:BoundField DataField="q9" HeaderText="Woman Name" />
                            <asp:BoundField DataField="q10" HeaderText="Husband Name" />
                            <asp:BoundField DataField="lw_crf6_30" HeaderText="LW-Weight" />
                            <asp:BoundField DataField="lw_crf6_34" HeaderText="LW-MUAC" />
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
                </div>
            </div>

            <div id="divEntryCRF6" runat="server" visible="false" style="text-align: center; margin-top: 10px">

                <div class="Mobile">
                    <table style="width: 100%; font-size: 1em; color: #4f5963; text-align: left;">

                        <tr class="trCSS">
                            <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Weight of LW  (in cm)
                                <br>
                                <td class="tdCSS">
                                    <%--Weight start--%>

                                    <table>
                                        <thead>
                                            <tr class="trCSS">
                                                <th>Reading 1</th>
                                                <th>Reading 2</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <tr class="trCSS">
                                                <td class="tdCSS" data-th="Reading 1">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF6WeightR1" type="tel" placeholder="reading 1" ClientIDMode="Static" MaxWeight="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtCRF6WeightR1" Mask="99.9" MaskType="Number" />
                                                </td>
                                                <td class="tdCSS" data-th="Reading 2">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF6WeightR2" type="tel" placeholder="reading 2" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" MaxWeight="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtCRF6WeightR2" Mask="99.9" MaskType="Number" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="3" style="text-align: center" class="tdCSS">
                                                    <asp:Button ID="btnCRF6Weight" runat="server" Text="Update Weight" class="btn btn-danger btn-lg" OnClick="btnCRF6Weight_Click" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <%--Weight End--%>
                                </td>
                        </tr>




                        <tr class="trCSS">
                            <td class="tdCSS TableColumn ColumTOP ColumBOTTOM">Mid Upper Arm Circumference (MUAC) of LW (in cm)
                                <br>
                                <td class="tdCSS">
                                    <%--MUAC start--%>

                                    <table>
                                        <thead>
                                            <tr class="trCSS">
                                                <th>Reading 1</th>
                                                <th>Reading 2</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <tr class="trCSS">
                                                <td class="tdCSS" data-th="Reading 1">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF6MUACR1" type="tel" placeholder="reading 1" ClientIDMode="Static" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtCRF6MUACR1" Mask="99.9" MaskType="Number" />
                                                </td>
                                                <td class="tdCSS" data-th="Reading 2">
                                                    <asp:TextBox CssClass="form-control input-lg textBoxCSS" ID="txtCRF6MUACR2" type="tel" placeholder="reading 2" ClientIDMode="Static" onkeypress="return OnlyNumeric(event)" MaxLength="3" runat="server"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtCRF6MUACR2" Mask="99.9" MaskType="Number" />
                                                </td>
                                            </tr>


                                            <tr>
                                                <td colspan="3" style="text-align: center" class="tdCSS">
                                                    <asp:Button ID="btnCRF6MUAC" runat="server" Text="Update MUAC" class="btn btn-danger btn-lg" OnClick="btnCRF6MUAC_Click" />
                                                </td>
                                            </tr>


                                        </tbody>
                                    </table>

                                    <%--MUAC End--%>
                                </td>
                        </tr>
                    </table>
                </div>


            </div>
        </div>




    </div>
</asp:Content>
