<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportEdit.aspx.cs" Inherits="ReportEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_menuPlaceHolder" Runat="Server">
    <a href="Default.aspx">Home</a>
    <asp:LinkButton ID="_updateButton" runat="server" CausesValidation="True" 
        CommandName="Update" Text="Update" OnCommand="PageCommand" />
    <asp:LinkButton ID="_insertButton" runat="server" CausesValidation="True" 
        CommandName="Insert" Text="Insert" OnCommand="PageCommand" />
    <asp:LinkButton ID="_cancelButton" runat="server" 
        CausesValidation="False" CommandName="Cancel" Text="Cancel" OnCommand="PageCommand" />    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="_contentPlaceHolder" Runat="Server">
    <asp:FormView ID="_reportFormView" runat="server">
    </asp:FormView>
    <asp:SqlDataSource ID="_reportSqlDataSource" runat="server"></asp:SqlDataSource>
</asp:Content>

