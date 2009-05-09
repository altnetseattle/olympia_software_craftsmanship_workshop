<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CitizenDetail.aspx.cs" Inherits="CitizenDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="_menuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="_contentPlaceHolder" runat="Server">
    <asp:DetailsView ID="_citizenDetailsView" runat="server" AutoGenerateRows="False"
        DataSourceID="_citizenDetailSqlDataSource">
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"
                SortExpression="Id" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
        </Fields>
    </asp:DetailsView>
    <asp:DataList ID="_citizenConcernFlagsDataList" runat="server" 
        DataSourceID="_citizenFlagsSqlDataSource">
        <ItemTemplate>
            <asp:Label ID="DescriptionLabel" runat="server" 
                Text='<%# Eval("Description") %>' />
        </ItemTemplate>
    </asp:DataList>
    <asp:GridView ID="_citizenReportsGridView" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" 
        DataSourceID="_citizenReportsSqlDataSource">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Location" HeaderText="Location" 
                SortExpression="Location" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="_citizenDetailSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SUFORS %>"
        SelectCommand="usp_GetCitizenDetail" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="_citizenFlagsSqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SUFORS %>" 
        SelectCommand="usp_GetCitizenFlags" SelectCommandType="StoredProcedure" >
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="_citizenReportsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SUFORS %>"
        SelectCommand="usp_GetCitizenReports" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
