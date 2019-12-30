<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userstatus.aspx.cs" Inherits="maamta.userstatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btnChng {
            background-color: #4e94ba;
            border: 0px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
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



    <style>
        .btnSrch {
            background-color: #4b8eb3;
            border: 1px solid #2574A9;
            display: inline-block;
            cursor: pointer;
            color: white;
            font-family: arial;
            font-size: 13px;
            padding: 5px 17px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #2f6627;
            border-radius: 3px;
            font-weight: bold;
        }

            .btnSrch:hover {
                background-color: #2574A9;
            }

            .btnSrch:active {
                position: relative;
                top: 1px;
            }

        .loader {
            border: 3px solid #BFBFBF; /* Light grey */
            border-top: 3px solid #3498db; /* Blue */
            border-radius: 50%;
            width: 18px;
            height: 18px;
            animation: spin 1s linear infinite;
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="background-color: #F2F1EF; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 30px; font-size: 28px; word-spacing: 5px; color: #34495E; text-transform: capitalize; background-color: #e6e6e6; padding-top: 8px; padding-bottom: 7px"><b>
            <asp:Label ID="lbeUname" runat="server" ForeColor="#1E8BC3" Text=""></asp:Label>, Welcome to Dashboard!</b></h1>
    </div>



    <div style="padding-left: 8%;">


        <table style="text-align: center; width: 90%; font-family: Tahoma">
            <tr>
                <td>
                    <asp:Button ID="btnTotalStatus" OnClick="btnTotalStatus_Click" CssClass="btnChng" runat="server" Text="Current Status" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; color: #adadad; text-transform: capitalize; background-color: #e0e0e0; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnDIOstatus" OnClick="btnDIOstatus_Click" CssClass="btnChng" runat="server" Text="DIO's Status" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
            </tr>
        </table>



        <%--//Start User Status from Here:--%>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>


                <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSearch">

                    <asp:UpdateProgress ID="updateProgress" runat="server">
                        <ProgressTemplate>
                            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.75;">
                                <span style="border-width: 0px; border-radius: 10px; position: fixed; padding: 50px; color: white; background-color: #2574A9; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <div style="text-align: left; font-size: 16px; width: 80%; font-weight: bold; color: #34495E; margin-top: 25px; margin-left: 1%">
                       User Name:&nbsp&nbsp&nbsp
                         <asp:DropDownList ID="DropDownList1" Font-Size="16px" Height="22px" Width="170px" runat="server" Font-Bold="false" ForeColor="Black"></asp:DropDownList>
                    </div>

                    <table style="width: 80%; text-align: center; margin-top: 17px; color: black; margin-left: 1%"">
                        <tr>
                            <td style="text-align: left; font-size: 16px; font-weight: bold; color: #34495E">Date From: &nbsp
                            </td>

                            <td>
                                <table border="0">
                                    <tr>
                                        <td>

                                            <select id="d1" style="width: 50px" class="styledselect-day" runat="server">
                                                <option value="0">dd</option>
                                                <option value="01">1</option>
                                                <option value="02">2</option>
                                                <option value="03">3</option>
                                                <option value="04">4</option>
                                                <option value="05">5</option>
                                                <option value="06">6</option>
                                                <option value="07">7</option>
                                                <option value="08">8</option>
                                                <option value="09">9</option>
                                                <option value="10">10</option>
                                                <option value="11">11</option>
                                                <option value="12">12</option>
                                                <option value="13">13</option>
                                                <option value="14">14</option>
                                                <option value="15">15</option>
                                                <option value="16">16</option>
                                                <option value="17">17</option>
                                                <option value="18">18</option>
                                                <option value="19">19</option>
                                                <option value="20">20</option>
                                                <option value="21">21</option>
                                                <option value="22">22</option>
                                                <option value="23">23</option>
                                                <option value="24">24</option>
                                                <option value="25">25</option>
                                                <option value="26">26</option>
                                                <option value="27">27</option>
                                                <option value="28">28</option>
                                                <option value="29">29</option>
                                                <option value="30">30</option>
                                                <option value="31">31</option>
                                            </select>
                                        </td>
                                        <td>
                                            <select id="m1" class="styledselect-month" runat="server">
                                                <option value="0">mmm</option>
                                                <option value="01">Jan</option>
                                                <option value="02">Feb</option>
                                                <option value="03">Mar</option>
                                                <option value="04">Apr</option>
                                                <option value="05">May</option>
                                                <option value="06">Jun</option>
                                                <option value="07">Jul</option>
                                                <option value="08">Aug</option>
                                                <option value="09">Sep</option>
                                                <option value="10">Oct</option>
                                                <option value="11">Nov</option>
                                                <option value="12">Dec</option>
                                            </select>
                                        </td>
                                        <td>
                                            <select id="y1" class="styledselect-year" runat="server">
                                                <option value="0">yyyy</option>
                                                
                                              
                                                <option value="2016">2016</option>
                                                <option value="2017">2017</option>
                                                <option value="2018">2018</option>
                                                <option value="2019">2019</option>
                                                <option value="2020">2020</option>
                                                <option value="2021">2021</option>
                                                <option value="2021">2022</option>
                                                <option value="2021">2023</option>
                                                <option value="2021">2024</option>
                                                <option value="2021">2025</option>
                                            </select>
                                            </form>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                            <td style="text-align: center; font-size: 16px; font-weight: bold; color: #34495E; padding-right: 4%;">To</td>

                            <td style="text-align: center; padding-right: 12%;">
                                <table border="0">
                                    <tr>
                                        <td>
                                            <select id="d2" style="width: 50px" class="styledselect-day" runat="server">
                                                <option value="0">dd</option>
                                                <option value="01">1</option>
                                                <option value="02">2</option>
                                                <option value="03">3</option>
                                                <option value="04">4</option>
                                                <option value="05">5</option>
                                                <option value="06">6</option>
                                                <option value="07">7</option>
                                                <option value="08">8</option>
                                                <option value="09">9</option>
                                                <option value="10">10</option>
                                                <option value="11">11</option>
                                                <option value="12">12</option>
                                                <option value="13">13</option>
                                                <option value="14">14</option>
                                                <option value="15">15</option>
                                                <option value="16">16</option>
                                                <option value="17">17</option>
                                                <option value="18">18</option>
                                                <option value="19">19</option>
                                                <option value="20">20</option>
                                                <option value="21">21</option>
                                                <option value="22">22</option>
                                                <option value="23">23</option>
                                                <option value="24">24</option>
                                                <option value="25">25</option>
                                                <option value="26">26</option>
                                                <option value="27">27</option>
                                                <option value="28">28</option>
                                                <option value="29">29</option>
                                                <option value="30">30</option>
                                                <option value="31">31</option>
                                            </select>
                                        </td>
                                        <td>
                                            <select id="m2" class="styledselect-month" runat="server">
                                                <option value="0">mmm</option>
                                                <option value="01">Jan</option>
                                                <option value="02">Feb</option>
                                                <option value="03">Mar</option>
                                                <option value="04">Apr</option>
                                                <option value="05">May</option>
                                                <option value="06">Jun</option>
                                                <option value="07">Jul</option>
                                                <option value="08">Aug</option>
                                                <option value="09">Sep</option>
                                                <option value="10">Oct</option>
                                                <option value="11">Nov</option>
                                                <option value="12">Dec</option>
                                            </select>
                                        </td>
                                        <td>
                                            <select id="y2" class="styledselect-year" runat="server">
                                                <option value="0">yyyy</option>
                                               
                                               
                                                <option value="2016">2016</option>
                                                <option value="2017">2017</option>
                                                <option value="2018">2018</option>
                                                <option value="2019">2019</option>
                                                <option value="2020">2020</option>
                                                <option value="2021">2021</option>
                                                <option value="2021">2022</option>
                                                <option value="2021">2023</option>
                                                <option value="2021">2024</option>
                                                <option value="2021">2025</option>
                                            </select>
                                            </form>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="text-align: center; padding-right: 7%;">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btnSrch" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>






                <asp:Panel ID="Panel1" runat="server" Visible="true">
                    <table border="1" style="text-align: center; width: 90%; margin-top: 20px; font-size: 16px; border: 1px solid #BFBFBF; color: #2C3E50; font-family: Tahoma">

                        <tr style="background-color: #34495E; color: #94b52c;">
                            <th colspan="5" style="text-align: center; padding: 6px; font-family: Calibri; font-size: 18px; text-transform: capitalize;">
                                <asp:Label ID="lbeEntryUser" runat="server" Text=""></asp:Label></th>
                        </tr>

                        <tr style="background-color: #2574A9; color: white; text-align: center">
                            <th style="padding: 12px; text-align: center">&nbsp Name of Instrument</th>
                            <th style="text-align: center">Log Form &nbsp </th>
                            <th style="text-align: center">1<sup style="font-size: 12px">st</sup> Entry</th>
                            <th style="text-align: center">2<sup style="font-size: 12px">nd</sup> Entry</th>
                            <th style="text-align: center">Total Entry&nbsp </th>
                        </tr>

                        <tr>
                            <td style="padding: 8px; text-align: left; font-size: 15px"><b>CRF-1</b> &nbsp(Pregnant Women Registration)</td>
                            <td>
                                <asp:Label ID="lbeLogCrf1" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe1Crf1" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe2Crf1" runat="server" Text="-"></asp:Label></td>
                            <td style="color: #2574A9">
                                <asp:Label ID="lbeTotalCrf1" runat="server" Text="-"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="padding: 8px; text-align: left; font-size: 15px"><b>CRF-1A</b> &nbsp Antenatal visit (1-2)</td>
                            <td>
                                <asp:Label ID="lbeLogCrf1a" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe1Crf1a" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe2Crf1a" runat="server" Text="-"></asp:Label></td>
                            <td style="color: #2574A9">
                                <asp:Label ID="lbeTotalCrf1a" runat="server" Text="-"></asp:Label></td>
                        </tr>


                        <tr>
                            <td style="padding: 8px; text-align: left; font-size: 15px"><b>CRF-2</b> &nbsp(Pregnancy Outcome)</td>
                            <td>
                                <asp:Label ID="lbeLogCrf2" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe1Crf2" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe2Crf2" runat="server" Text="-"></asp:Label></td>
                            <td style="color: #2574A9">
                                <asp:Label ID="lbeTotalCrf2" runat="server" Text="-"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding: 8px; text-align: left; font-size: 15px"><b>CRF-3</b> &nbsp(NB First Assessment)</td>
                            <td>
                                <asp:Label ID="lbeLogCrf3" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe1Crf3" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe2Crf3" runat="server" Text="-"></asp:Label></td>
                            <td style="color: #2574A9">
                                <asp:Label ID="lbeTotalCrf3" runat="server" Text="-"></asp:Label></td>
                        </tr>


                        <tr>
                            <td style="padding: 8px; text-align: left; font-size: 15px"><b>CRF-4</b> &nbsp NB Follow Ups (0-59 days) visit (1-9)</td>
                            <td>
                                <asp:Label ID="lbeLogCrf4" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe1Crf4" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe2Crf4" runat="server" Text="-"></asp:Label></td>
                            <td style="color: #2574A9">
                                <asp:Label ID="lbeTotalCrf4" runat="server" Text="-"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding: 8px; text-align: left; font-size: 15px"><b>CRF-5</b> &nbsp NB Follow Ups (3-11months) visit (1-9)</td>
                            <td>
                                <asp:Label ID="lbeLogCrf5" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe1Crf5" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe2Crf5" runat="server" Text="-"></asp:Label></td>
                            <td style="color: #2574A9">
                                <asp:Label ID="lbeTotalCrf5" runat="server" Text="-"></asp:Label></td>
                        </tr>

                        <tr style="background-color: #2574A9; color: white">
                            <th style="padding: 9px; text-align: center; font-size: 15px">Grand Total</th>
                            <th style="color: #F5D76E; font-size: 16px; text-align: center">
                                <asp:Label ID="lbeLogTotal" runat="server" Text="-"></asp:Label></th>
                            <td>
                                <asp:Label ID="lbe1Total" runat="server" Text="-"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbe2Total" runat="server" Text="-"></asp:Label></td>
                            <th style="color: #F5D76E; font-size: 16px; text-align: center">
                                <asp:Label ID="lbeGrandTotal" runat="server" Text="-"></asp:Label></th>
                        </tr>
                    </table>
                </asp:Panel>


            </ContentTemplate>
        </asp:UpdatePanel>




        <%--//End User Status:--%>
    </div>


    <br>
    <br>
    <br>
    <br>
</asp:Content>
