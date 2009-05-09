<%@ Register TagPrefix="uc" TagName="MainMenu" Src="~/UserControls/MainMenu.ascx" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="DataTestPage.aspx.cs" Inherits="DataTestPage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="_head" Runat="Server" >
    <title>Data Test Page</title>
</asp:Content>
<asp:Content ID="menuContent" ContentPlaceHolderID="_menuPlaceHolder" runat="server">
    <uc:MainMenu ID="_mainMenu" runat="server" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="_contentPlaceHolder" Runat="Server">
    <asp:SqlDataSource ID="_sqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SUFORS %>" 
        SelectCommand="SELECT * FROM [Citizens] ORDER BY [LastName], [FirstName]">
    </asp:SqlDataSource>
    <asp:GridView ID="_gridView" runat="server" AllowPaging="True" 
        AllowSorting="True" DataSourceID="_sqlDataSource">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>

