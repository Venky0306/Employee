<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employee._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Chart ID="PieChartMonthToDate" BorderlineColor="Black" BorderlineDashStyle="Solid"
            Visible="true" ImageType="Png" runat="server" Height="400px" Width="400px" PaletteCustomColors="128, 255, 128; 255, 128, 0">
            <Titles>
                <asp:Title TextStyle="Frame">
                </asp:Title>
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                    LegendStyle="Column">
                </asp:Legend>
            </Legends>
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" YValuesPerPoint="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea IsSameFontSizeForAllAxes="true" BorderWidth="0" Name="ChartArea1">
                    <Area3DStyle Enable3D="true" />
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:Chart ID="Chart2" runat="server" Height="400px" Width="400px"  BorderlineColor="Black" BorderlineDashStyle="Solid" ImageType ="Png" BackGradientStyle="None" BackImageAlignment ="Center">
    <Series>
        <asp:Series Name="Series1" XValueMember="0" YValueMembers="0"></asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
    </ChartAreas>
</asp:Chart>
    </asp:Panel>
</asp:Content>
