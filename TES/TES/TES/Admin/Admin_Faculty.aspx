<%@ Page Language="C#" Title="Faculty" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Faculty.aspx.cs" Inherits="TES.Admin.Admin_Faculty" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Manage Faculty</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Faculty Profile Updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Faculty Profile did not updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlDeleteSuccess" runat="server" Visible="false" CssClass="alert alert-danger alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Student Profile is deleted.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" DataKeyNames="SupervisorId" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="User.FullName" HeaderText="Full Name" SortExpression="User.FullName" />
                            <asp:BoundField DataField="User.Email" HeaderText="Email" SortExpression="User.Email" />
                            <asp:BoundField DataField="User.Contact" HeaderText="Contact" SortExpression="User.Contact" />
                            <asp:BoundField DataField="GTC" HeaderText="GTC" SortExpression="GTC" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />

                            <asp:HyperLinkField DataNavigateUrlFields="SupervisorId" NavigateUrl="~/Admin/Admin_Edit_Faculty" DataNavigateUrlFormatString="/Admin/Faculty/Edit/{0}" HeaderText="Edit" Text="Edit" />
                            <asp:HyperLinkField DataNavigateUrlFields="SupervisorId" NavigateUrl="~/Admin/Admin_Faculty.aspx.cs" DataNavigateUrlFormatString="/Admin/Faculty/{0}" HeaderText="Delete" Text="Delete" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>
