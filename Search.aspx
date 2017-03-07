<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <asp:TextBox ID="txtTemp" runat="server" Visible="False"></asp:TextBox>
        <br />
    </p>
    <table class="nav-justified">
        <tr>
            <td style="height: 118px"></td>
            <td style="height: 118px"></td>
            <td class="text-center" style="height: 118px; width: 605px">Enter name:<br />
                <asp:TextBox ID="txtSearch" runat="server" BorderStyle="Solid" Width="50%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSearch" runat="server" ControlToValidate="txtSearch" ErrorMessage="Please enter search parameter" ForeColor="Red" Visible="False">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSearch" ErrorMessage="Please enter letter characters only." ForeColor="Red" Operator="DataTypeCheck" Visible="False">*</asp:CompareValidator>
                <br />
                <asp:ValidationSummary ID="vsSearch" runat="server" ForeColor="Red" />
            </td>
            <td style="height: 118px"></td>
            <td style="height: 118px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="text-center" style="width: 605px">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn active" Font-Bold="True" Font-Size="Small" OnClick="btnSearch_Click" Text="Search" Width="130px" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 14px"></td>
            <td style="height: 14px"></td>
            <td class="text-center" style="height: 14px; width: 605px">
                <asp:Label ID="lblFound" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="height: 14px"></td>
            <td style="height: 14px"></td>
        </tr>
        <tr>
            <td style="height: 32px"></td>
            <td style="height: 32px"></td>
            <td class="text-center" style="height: 32px; width: 605px">
                <p class="text-center"><asp:GridView ID="gvSearch" runat="server" CellPadding="3" GridLines="Horizontal" OnSelectedIndexChanged="gvSearch_SelectedIndexChanged" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:ButtonField CommandName="SELECT" Text="Select">
                        <ControlStyle Font-Underline="True" ForeColor="#3333FF" />
                        </asp:ButtonField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
                </p>
            </td>
            <td style="height: 32px"></td>
            <td style="height: 32px"></td>
        </tr>
    </table>
    <p>
    </p>
</asp:Content>

