<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="digitpreference.aspx.cs" Inherits="maamta.digitpreference" %>

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


    <div style="background-color: #095e66; margin: 0 0 10px 10px; -moz-box-shadow: 0 6px 6px -6px gray; box-shadow: 0 6px 6px -6px gray;">
        <h1 style="text-align: center; margin-top: 10px; font-size: 28px; word-spacing: 5px; color: white; text-transform: capitalize; background-color: #55efc4; padding-top: 8px; padding-bottom: 7px; font-family: Arial"><b>Digit Preference</b></h1>
    </div>
    <div style="width: 100%; text-align: center; overflow: auto; margin-top: 30px">



        <table style="text-align: center; width: 100%; font-family: Tahoma; margin-top: 0px">
            <tr>
                <td>
                    <asp:Button ID="btnCRF2" OnClick="btnCRF2_Click" CssClass="btnChng" runat="server" Text="CRF-2" Width="100%" Style="text-align: center; border-bottom-left-radius: 14px; border-top-left-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnCRF3c" OnClick="btnCRF3c_Click" CssClass="btnChng" runat="server" Text="CRF-3c (Baby)" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnlwCRF3c" OnClick="btnlwCRF3c_Click" CssClass="btnChng" runat="server" Text="CRF-3c (LW)" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnCRF6" OnClick="btnCRF6_Click" CssClass="btnChng" runat="server" Text="CRF-6 (Baby)" Width="100%" Style="text-align: center; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
                <td>
                    <asp:Button ID="btnlwCRF6" OnClick="btnlwCRF6_Click" CssClass="btnChng" runat="server" Text="CRF-6 (LW)" Width="100%" Style="text-align: center; border-bottom-right-radius: 14px; border-top-right-radius: 14px; margin-top: 10px; text-transform: capitalize; padding-top: 7px; padding-bottom: 6px" />
                </td>
            </tr>
        </table>



        <div style="padding-left: 2%; margin-top: 15px;" id="divCRF2" runat="server">

           

            <asp:Chart ID="ChartCRF2_R1" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF2_R1">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF2_R1" Title="SRA Name" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF2-MUAC (Reading1)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <asp:Chart ID="ChartCRF2_R2" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF2_R2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF2_R2" Title="SRA Name" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF2-MUAC (Reading2)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </div>











        <div style="padding-left: 2%; margin-top: 15px;" id="div_Ch_CRF3c" runat="server">


          
            <asp:Chart ID="ChartCRF3c_Length_R1" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_Length_R1">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_Length_R1" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-Length (Reading1)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <asp:Chart ID="ChartCRF3c_Length_R2" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_Length_R2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_Length_R2" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-Length (Reading2)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>












            <hr style="border-top: 5px solid #ccc; background: transparent;">
            <br />

        

            <asp:Chart ID="ChartCRF3c_MUAC_R1" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_MUAC_R1">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_MUAC_R1" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-MUAC (Reading1)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <asp:Chart ID="ChartCRF3c_MUAC_R2" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_MUAC_R2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_MUAC_R2" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-MUAC (Reading2)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>










            <hr style="border-top: 5px solid #ccc; background: transparent;">
            <br />

          
            <asp:Chart ID="ChartCRF3c_OFHC_R1" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_OFHC_R1">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_OFHC_R1" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-OFHC (Reading1)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <asp:Chart ID="ChartCRF3c_OFHC_R2" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_OFHC_R2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_OFHC_R2" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-OFHC (Reading2)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

        </div>








        <div style="padding-left: 2%; margin-top: 15px;" id="div_LW_CRF3c" runat="server">


        
            <asp:Chart ID="ChartCRF3c_LW_Weight_R1" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_LW_Weight_R1">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_LW_Weight_R1" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-LW_Weight (Reading1)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <asp:Chart ID="ChartCRF3c_LW_Weight_R2" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_LW_Weight_R2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_LW_Weight_R2" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-LW_Weight (Reading2)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>









            <hr style="border-top: 5px solid #ccc; background: transparent;">
            <br />

            <asp:Chart ID="ChartCRF3c_LW_Height_R1" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_LW_Height_R1">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_LW_Height_R1" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-LW_Height (Reading1)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <asp:Chart ID="ChartCRF3c_LW_Height_R2" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_LW_Height_R2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_LW_Height_R2" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-LW_Height (Reading2)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>





            <hr style="border-top: 5px solid #ccc; background: transparent;">
            <br />

           
            <asp:Chart ID="ChartCRF3c_LW_MUAC_R1" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_LW_MUAC_R1">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_LW_MUAC_R1" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-LW_MUAC (Reading1)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>

            <hr style="border-top: 1px solid #ccc; background: transparent;">

            <asp:Chart ID="ChartCRF3c_LW_MUAC_R2" runat="server" Width="1050" Height="450px" Palette="EarthTones">
                <ChartAreas>
                    <asp:ChartArea Name="ChartAreaCRF3c_LW_MUAC_R2">
                        <AxisX Interval="1" TextOrientation="Rotated90">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="LegendCRF3c_LW_MUAC_R2" Title="SRA" Font="Microsoft Sans Serif, 10.25pt" TitleFont="Arial Rounded MT Bold, 12.25pt">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Docking="Left" Name="Left Title" Text="Total" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Bottom Title" Text="Values" Font="Arial Rounded MT Bold, 12pt, ">
                    </asp:Title>
                    <asp:Title Name="Top" Text="CRF3c-LW_MUAC (Reading2)" Font="Arial Rounded MT Bold, 18pt, ">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </div>



    </div>
</asp:Content>
