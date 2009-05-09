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
    <asp:FormView ID="_reportFormView" runat="server" 
        DataSourceID="_reportSqlDataSource">
        <EditItemTemplate>
            Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Location:
            <asp:TextBox ID="LocationTextBox" runat="server" 
                Text='<%# Bind("Location") %>' />
            <br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" 
                Text='<%# Bind("Description") %>' />
            <br />
        </EditItemTemplate>
        <InsertItemTemplate>
            Location:
            <asp:TextBox ID="LocationTextBox" runat="server" 
                Text='<%# Bind("Location") %>' />
            <br />
            Description:
            <asp:TextBox ID="DescriptionTextBox" runat="server" 
                Text='<%# Bind("Description") %>' />
            <br />
        </InsertItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="_reportSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SUFORS %>" 
        InsertCommand="usp_EditReport" InsertCommandType="StoredProcedure" 
        SelectCommand="usp_GetReportDetail" SelectCommandType="StoredProcedure" 
        UpdateCommand="usp_NewReport" UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="location" Type="String" />
            <asp:Parameter Name="description" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="location" Type="String" />
            <asp:Parameter Name="description" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

