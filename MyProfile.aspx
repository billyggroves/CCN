<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center" style="height: 2px">
        <asp:TextBox ID="txtUser" runat="server" Visible="False"></asp:TextBox>
    </h1>
    <h1 class="text-center">
        <strong>My Profile Page</strong></h1>
    <table class="nav-justified">
        <tr>
            <td class="auto-style2">
                </td>
            <td class="text-center" style="border: thin #000000 solid; width: 316px; padding-left: 35px; padding-right: 35px;">
                <div class="text-left">
                    <asp:FormView ID="fvName" runat="server" DataKeyNames="UserID" DataSourceID="SqlDataSource1" Height="179px" Width="310px">
                        <EditItemTemplate>
                            FirstName:
                            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                            <br />
                            LastName:
                            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                            <br />
                            Position:
                            <asp:TextBox ID="PositionTextBox" runat="server" Text='<%# Bind("Position") %>' />
                            <br />
                            Location:
                            <asp:TextBox ID="LocationTextBox" runat="server" Text='<%# Bind("Location") %>' />
                            <br />
                            <asp:LinkButton ID="lbUpdate" runat="server" OnClick="lbUpdate_Click">Update</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            &nbsp;<asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
&nbsp;<asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
                            <br />
                            <span style="font-size: small">Position: </span>
                            <asp:Label ID="PositionLabel" runat="server" style="font-size: small" Text='<%# Bind("Position") %>' />
                            <br style="font-size: small" />
                            <span style="font-size: small">Location: </span>
                            <asp:Label ID="LocationLabel" runat="server" style="font-size: small" Text='<%# Bind("Location") %>' />
                            <br style="font-size: small" />
                            <span style="font-size: small">ValueScore: </span>
                            <asp:Label ID="ValueScoreLabel" runat="server" style="font-size: small" Text='<%# Bind("ValueScore") %>' />
                            <br />
                            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
&nbsp;
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UserID], [Username], [FirstName], [LastName], [Position], [Location], [ValueScore] FROM [User] WHERE ([Username] = @Username)" DeleteCommand="DELETE FROM [User] WHERE [UserID] = @UserID" InsertCommand="INSERT INTO [User] ([Username], [FirstName], [LastName], [Position], [Location], [ValueScore]) VALUES (@Username, @FirstName, @LastName, @Position, @Location, @ValueScore)" UpdateCommand="UPDATE [User] SET [Username] = @Username, [FirstName] = @FirstName, [LastName] = @LastName, [Position] = @Position, [Location] = @Location, [ValueScore] = @ValueScore WHERE [UserID] = @UserID">
                        <DeleteParameters>
                            <asp:Parameter Name="UserID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Username" Type="String" />
                            <asp:Parameter Name="FirstName" Type="String" />
                            <asp:Parameter Name="LastName" Type="String" />
                            <asp:Parameter Name="Position" Type="String" />
                            <asp:Parameter Name="Location" Type="String" />
                            <asp:Parameter Name="ValueScore" Type="Int32" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtUser" Name="Username" PropertyName="Text" Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Username" Type="String" />
                            <asp:Parameter Name="FirstName" Type="String" />
                            <asp:Parameter Name="LastName" Type="String" />
                            <asp:Parameter Name="Position" Type="String" />
                            <asp:Parameter Name="Location" Type="String" />
                            <asp:Parameter Name="ValueScore" Type="Int32" />
                            <asp:Parameter Name="UserID" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </div>
            </td>
            <td style="width: 643px; border: thin #000000 solid; padding-left: 35px; padding-right: 35px">
                <h3 class="text-left">&nbsp;</h3>
                <h3 class="text-left"><strong>About Me</strong></h3>
                <p class="text-left" style="height: 3px">&nbsp;</p>
                    <div class="text-left">
                        <asp:FormView ID="fvAboutMe" runat="server" DataKeyNames="UID" DataSourceID="sdsAboutUser" Width="605px">
                            <EditItemTemplate>
                                &nbsp;<asp:TextBox ID="UserContentTextBox" runat="server" BorderStyle="Solid" Text='<%# Bind("UserContent") %>' Height="100px" TextMode="MultiLine" Width="100%" />
                                <br />
                                <asp:LinkButton ID="lbUpdate2" runat="server" OnClick="lbUpdate2_Click">Update</asp:LinkButton>
&nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                <asp:LinkButton ID="lbAddAbout" runat="server" CommandName="New">Add New Content</asp:LinkButton>
                            </EmptyDataTemplate>
                            <InsertItemTemplate>
                                &nbsp;<asp:TextBox ID="UserContentTextBox" runat="server" BorderStyle="Solid" Text='<%# Bind("UserContent") %>' Height="100px" TextMode="MultiLine" Width="600px" />
                                <br />
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Insert</asp:LinkButton>
&nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                            </InsertItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="UserContentLabel" runat="server" Text='<%# Bind("UserContent") %>' Width="90%" />
                                <br />
                                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
&nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
&nbsp;
                            </ItemTemplate>
                        </asp:FormView>
                    </div>
                    <asp:SqlDataSource ID="sdsAboutUser" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [UserProfile] WHERE [UID] = @UID" InsertCommand="INSERT INTO [UserProfile] ([Username], [UserPage], [UserSection], [UserContent]) VALUES (@Username, @UserPage, @UserSection, @UserContent)" SelectCommand="SELECT [UID], [Username], [UserPage], [UserSection], [UserContent] FROM [UserProfile] WHERE (([Username] = @Username) AND ([UserPage] = @UserPage) AND ([UserSection] = @UserSection))" UpdateCommand="UPDATE [UserProfile] SET [UserContent] = @UserContent WHERE (([UID] = @UID AND ([UserSection] = @UserSection))">
                        <DeleteParameters>
                            <asp:Parameter Name="UID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:ControlParameter ControlID="txtUser" DefaultValue="txtUser.Text" Name="Username" PropertyName="Text" Type="String" />
                            <asp:Parameter DefaultValue="UserProfile" Name="UserPage" Type="String" />
                            <asp:Parameter DefaultValue="" Name="UserContent" Type="String" />
                            <asp:Parameter DefaultValue="AboutUser" Name="UserSection" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter DefaultValue="UserProfile" Name="UserPage" Type="String" />
                            <asp:ControlParameter ControlID="txtUser" DefaultValue="txtUser.Text" Name="Username" PropertyName="Text" />
                            <asp:Parameter DefaultValue="AboutUser" Name="UserSection" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="UserContent" Type="String" />
                            <asp:Parameter Name="UID" Type="Int32" />
                            <asp:Parameter DefaultValue="AboutUser" Name="UserSection" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </p>
                <br />
                <br />
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td class="auto-style2" rowspan="4">
                &nbsp;</td>
            <td class="text-center" style="width: 316px; padding-left: 35px; padding-right: 35px; border-top-style: solid; border-right-style: solid; border-left-style: solid; border-top-width: thin; border-right-width: thin; border-left-width: thin; border-top-color: #000000; border-right-color: #000000; border-left-color: #000000;">
                <strong>Badges</strong></td>
            <td style="width: 643px; border: thin #000000 solid; padding-left: 35px; padding-right: 35px" class="text-center" rowspan="4">
                <span style="font-weight: bold; font-size: large">Recognition<br />
                </span>
                                <asp:GridView ID="gvRecognition" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="SqlDataSource2" GridLines="Horizontal" Width="641px">
                    <Columns>
                        <asp:BoundField DataField="Advocated" HeaderText="Advocated" SortExpression="Advocated" Visible="False" />
                        <asp:BoundField DataField="Advocator" HeaderText="Advocator" SortExpression="Advocator" />
                        <asp:BoundField DataField="DateTime" HeaderText="Date Time" SortExpression="DateTime" />
                        <asp:BoundField DataField="SpecificValue" HeaderText="Core Value" SortExpression="SpecificValue" />
                        <asp:BoundField DataField="RecognitionNote" HeaderText="Note" SortExpression="RecognitionNote" />
                    </Columns>
                    <EmptyDataTemplate>
                        No Recognition
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
                <br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote] FROM [Recognition] WHERE ([Advocated] = @Advocated) ORDER BY [DateTime] DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtUser" Name="Advocated" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="auto-style2" rowspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="width: 316px; padding-left: 35px; padding-right: 35px; border-right-style: solid; border-left-style: solid; border-right-width: thin; border-left-width: thin; border-right-color: #000000; border-left-color: #000000;">
                <asp:Image ID="Image2" runat="server" Height="155px" ImageUrl="~/Images/Badge1.JPG" Visible="False" Width="200px" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 316px; padding-left: 35px; padding-right: 35px; border-right-style: solid; border-left-style: solid; border-right-width: thin; border-left-width: thin; border-right-color: #000000; border-left-color: #000000;">
                <asp:Image ID="Image3" runat="server" Height="146px" ImageUrl="~/Images/Badge2.JPG" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="width: 316px; padding-left: 35px; padding-right: 35px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: thin; border-bottom-width: thin; border-left-width: thin; border-right-color: #000000; border-bottom-color: #000000; border-left-color: #000000;">
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

