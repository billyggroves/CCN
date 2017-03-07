<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="MyProfile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center" style="height: 2px">
        <asp:TextBox ID="txtUser" runat="server" Visible="False"></asp:TextBox>
    </h1>
    <h1 class="text-center">
        <strong>Profile Page</strong></h1>
    <table class="nav-justified" style="height: 867px">
        <tr>
            <td class="modal-sm" rowspan="8" style="width: 10%; ">
                </td>
            <td class="text-center" style="padding: 5px; border: thin solid #000000;" rowspan="5">
                <div class="text-left">
                    <asp:FormView ID="fvName" runat="server" DataSourceID="SqlDataSource1" Height="179px" Width="100%" OnPageIndexChanging="fvName_PageIndexChanging">
                        <ItemTemplate>
                            <span style="font-size: x-large">&nbsp;</span><strong><asp:Label ID="FirstNameLabel" runat="server" Font-Size="Large" Text='<%# Bind("FirstName") %>' style="font-size: x-large" />
                            </strong>&nbsp;<strong><asp:Label ID="LastNameLabel" runat="server" Font-Size="Large" Text='<%# Bind("LastName") %>' style="font-size: x-large" />
                            </strong>
                            <br />
                            <span style="font-size: small">Position:</span>
                            <asp:Label ID="PositionLabel" runat="server" Font-Size="Small" Text='<%# Bind("Position") %>' />
                            <br />
                            <span style="font-size: small">Location:</span>
                            <asp:Label ID="LocationLabel" runat="server" Text='<%# Bind("Location") %>' Font-Size="Small" />
                            <br />
                            <span style="font-size: small">Value Score</span>:
                            <asp:Label ID="ValueScoreLabel" runat="server" Font-Size="Small" Text='<%# Bind("ValueScore") %>' />
                            <br />
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [FirstName], [LastName], [Position], [Location], [ValueScore] FROM [User] WHERE ([Username] = @Username)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtUser" Name="Username" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </td>
            <td style="width: 27%; padding-left: 35px; padding-right: 35px; height: 59px; border-top-style: solid; border-right-style: solid; border-left-style: solid; border-top-width: thin; border-right-width: thin; border-left-width: thin; border-top-color: #000000; border-right-color: #000000; border-left-color: #000000;" class="text-center">
                <h3 class="text-left"><strong>About Me</strong></h3>
            </td>
            <td style="border-left: thin solid #000000; border-right: thin solid #000000; border-top: thin solid #000000; padding: 5px; width: 20%; font-size: medium; " class="text-center" colspan="2" rowspan="2">
                <strong>Please advocate me for following Centric Core Values<br />
                </strong>
                <asp:Label ID="lblAdvocated" runat="server" Visible="False"></asp:Label>
            </td>
            <td class="auto-style2" rowspan="8" style="width: 10%; ">
                </td>
        </tr>
        <tr>
            <td style="width: 27%; padding-left: 35px; padding-right: 35px; height: 180px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: thin; border-bottom-width: thin; border-left-width: thin; border-right-color: #000000; border-bottom-color: #000000; border-left-color: #000000;" class="text-center">
                <h3 class="text-left">&nbsp;</h3>
                <p class="text-left" style="height: 3px">&nbsp;</p>
                    <div class="text-left">
                        <asp:FormView ID="fvAboutMe" runat="server" DataKeyNames="UID" DataSourceID="sdsAboutUser">
                            <EditItemTemplate>
                                &nbsp;
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                &nbsp;
                            </InsertItemTemplate>
                            <ItemTemplate>
                                &nbsp;<asp:Label ID="UserContentLabel" runat="server" Text='<%# Bind("UserContent") %>' />
                                <br />
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
                <p class="text-left">
                </p>
            </td>
        </tr>
        <tr>
            <td style="border-left: thin solid #000000; border-right: thin solid #000000; border-top: thin solid #000000; width: 27%; padding-left: 35px; padding-right: 35px; " class="text-center">
                <strong>Quick Note of Regconition</strong></td>
            <td style="font-size: small; " class="text-left" rowspan="2">
                Work/Life Balance:</td>
            <td style="padding: 5px; margin: 5px; border-right-style: solid; border-right-width: thin; border-right-color: #000000;" class="text-left" rowspan="2">
                <asp:Button ID="btnBalance" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" Font-Size="Small" OnClick="btnBalance_Click" Text="Advocate" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td style="border-left: thin solid #000000; border-right: thin solid #000000; width: 27%; padding-left: 35px; padding-right: 35px; " class="text-center">
                <asp:TextBox ID="txtRecognition" runat="server" BorderColor="#999999" BorderStyle="Solid" Height="50px" MaxLength="50" TextMode="MultiLine" Width="100%"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 27%; padding-left: 35px; padding-right: 35px; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-right-width: thin; border-bottom-width: thin; border-left-width: thin; border-right-color: #000000; border-bottom-color: #000000; border-left-color: #000000;" class="text-center">
                <asp:Button ID="btnVisible" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" OnClick="btnVisible_Click" style="font-size: x-small" Text="Enable Value Buttons" />
            </td>
            <td style="font-size: small; " class="text-left">
                Greater Good:</td>
            <td style="padding: 5px; margin: 5px; border-right-style: solid; border-right-width: thin; border-right-color: #000000;" class="text-left">
                <asp:Button ID="btnGood" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" Font-Size="Small" Text="Advocate" Enabled="False" OnClick="btnGood_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="padding: 5px; border-left-style: solid; border-left-width: thin; border-left-color: #000000;">
                Badges</td>
            <td rowspan="6" style="width: 27%; border: thin #000000 solid; padding-left: 35px; padding-right: 35px; " class="text-center">
                <asp:GridView ID="gvRecognition" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataSourceID="sdsRecognition" GridLines="Horizontal">
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
                <asp:SqlDataSource ID="sdsRecognition" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" OnSelecting="sdsRecognition_Selecting" SelectCommand="SELECT [Advocated], [Advocator], [DateTime], [SpecificValue], [RecognitionNote] FROM [Recognition] WHERE ([Advocated] = @Advocated) ORDER BY [DateTime] DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtUser" DefaultValue="" Name="Advocated" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br />
                <br />
                <br />
            </td>
            <td style="font-size: small; " class="text-left">
                Innovation:</td>
            <td style="padding: 5px; margin: 5px; border-right-style: solid; border-right-width: thin; border-right-color: #000000;" class="text-left">
                <asp:Button ID="btnInnovation" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" Font-Size="Small" Text="Advocate" Enabled="False" OnClick="btnInnovation_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="padding: 5px; border-left: thin solid #000000;">
                <asp:Image ID="Image2" runat="server" Height="155px" ImageUrl="~/Images/Badge1.JPG" Visible="False" Width="200px" />
            </td>
            <td style="font-size: small; height: 84px;" class="text-left">
                Stewardship:</td>
            <td style="border-right: thin solid #000000; padding: 5px; margin: 5px; height: 84px;" class="text-left">
                <asp:Button ID="btnStewardship" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" Font-Size="Small" Text="Advocate" Enabled="False" OnClick="btnStewardship_Click" />
            </td>
        </tr>
        <tr>
            <td class="text-center" style="padding: 5px; border-left-style: solid; border-left-width: thin; border-left-color: #000000;" rowspan="2">
                <asp:Image ID="Image3" runat="server" Height="146px" ImageUrl="~/Images/Badge2.JPG" Visible="False" />
            </td>
            <td style="font-size: small; " class="text-left">
                Delivery Excellence:</td>
            <td style="padding: 5px; margin: 5px; border-right-style: solid; border-right-width: thin; border-right-color: #000000;" class="text-left">
                <asp:Button ID="btnDelivery" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" Font-Size="Small" Text="Advocate" Enabled="False" OnClick="btnDelivery_Click" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" rowspan="3" style="width: 10%; ">
                &nbsp;</td>
            <td style="font-size: small; " class="text-left">
                Culture:</td>
            <td style="padding: 5px; margin: 5px; border-right-style: solid; border-right-width: thin; border-right-color: #000000;" class="text-left">
                <asp:Button ID="btnCulture" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" Font-Size="Small" Text="Advocate" Enabled="False" OnClick="btnCulture_Click" />
            </td>
            <td class="auto-style2" rowspan="3" style="width: 10%; ">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="padding: 5px; border-left-style: solid; border-left-width: thin; border-left-color: #000000; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000;" rowspan="2">
                &nbsp;</td>
            <td style="border-bottom: thin solid #000000; font-size: small; " class="text-left">
                Integrity and Openness:</td>
            <td style="padding: 5px; margin: 5px; border-right-style: solid; border-right-width: thin; border-right-color: #000000; border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #000000;" class="text-left">
                <asp:Button ID="btnIntegrity" runat="server" BorderColor="#CCCCCC" BorderStyle="Ridge" Font-Size="Small" Text="Advocate" Enabled="False" OnClick="btnIntegrity_Click" />
            </td>
        </tr>
        <tr>
            <td style="border-bottom: thin solid #000000; font-size: small; " class="text-left" colspan="2">
                </td>
        </tr>
        </table>

</asp:Content>

