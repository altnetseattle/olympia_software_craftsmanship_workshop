<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CitizenEdit.aspx.cs" Inherits="CitizenEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_menuPlaceHolder" Runat="Server">
<asp:LinkButton ID="_updateButton" runat="server" CausesValidation="True" 
    CommandName="Update" Text="Update" />
<asp:LinkButton ID="_insertButton" runat="server" CausesValidation="True" 
    CommandName="Insert" Text="Insert" />
<asp:LinkButton ID="_cancelButton" runat="server" 
    CausesValidation="False" CommandName="Cancel" Text="Cancel" OnCommand="PageCommand" />    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="_contentPlaceHolder" Runat="Server">
    <asp:FormView ID="_citizenFormView" runat="server" 
        DataSourceID="_citizenSqlDataSource">
        <EditItemTemplate>
            Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            FirstName:
            <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%# Bind("FirstName") %>' />
            <br />
            LastName:
            <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%# Bind("LastName") %>' />
            <br />
            Phone:
            <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
            <br />
            EmailAddress:
            <asp:TextBox ID="EmailAddressTextBox" runat="server" 
                Text='<%# Bind("EmailAddress") %>' />
            <br />
        </EditItemTemplate>
        <InsertItemTemplate>
            FirstName:
            <asp:TextBox ID="FirstNameTextBox" runat="server" 
                Text='<%# Bind("FirstName") %>' />
            <br />
            LastName:
            <asp:TextBox ID="LastNameTextBox" runat="server" 
                Text='<%# Bind("LastName") %>' />
            <br />
            Phone:
            <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
            <br />
            EmailAddress:
            <asp:TextBox ID="EmailAddressTextBox" runat="server" 
                Text='<%# Bind("EmailAddress") %>' />
            <br />
        </InsertItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="_citizenSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SUFORS %>" 
        InsertCommand="usp_NewCitizen" InsertCommandType="StoredProcedure" 
        SelectCommand="usp_GetCitizenDetail" SelectCommandType="StoredProcedure" 
        UpdateCommand="usp_EditCitizen" UpdateCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="lastName" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
            <asp:Parameter Name="emailAddress" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="lastName" Type="String" />
            <asp:Parameter Name="phone" Type="String" />
            <asp:Parameter Name="emailAddress" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

