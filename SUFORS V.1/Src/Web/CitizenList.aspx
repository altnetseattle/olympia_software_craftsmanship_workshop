<%@ Register TagPrefix="uc" TagName="MainMenu" Src="~/UserControls/MainMenu.ascx" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="CitizenList.aspx.cs" Inherits="CitizenList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="_head" Runat="Server" >
    <title>Data Test Page</title>
</asp:Content>
<asp:Content ID="menuContent" ContentPlaceHolderID="_menuPlaceHolder" runat="server">
    <a href="Default.aspx">Home</a>
    <asp:LinkButton ID="_newLink" CommandName="New" Text="Add New Citizen" runat="server" />
    <asp:LinkButton ID="_cancelButton" runat="server" 
        CausesValidation="False" CommandName="Cancel" Text="Cancel" OnCommand="PageCommand" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="_contentPlaceHolder" Runat="Server">
    <asp:SqlDataSource ID="_sqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SUFORS %>" 
        SelectCommand="usp_GetCitizenList" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:GridView ID="_gridView" runat="server" AllowPaging="True" 
        AllowSorting="True" DataSourceID="_sqlDataSource" 
        AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="GridCommand">
        <Columns>
            <asp:ButtonField DataTextField="Id" ButtonType="Link" 
            CommandName="Select" HeaderText="Select" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" 
                SortExpression="FirstName, LastName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" 
                SortExpression="LastName, FirstName" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" 
                SortExpression="EmailAddress" />
        </Columns>
    </asp:GridView>
</asp:Content>

