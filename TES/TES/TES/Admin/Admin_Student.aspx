<%@ Page Language="C#" Title="Student" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Student.aspx.cs" Inherits="TES.Admin.Admin_Student" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Manage Students</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Student Profile Updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Student Profile did not updated.
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
                    <div>
                    <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentId" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="User.FullName" HeaderText="Full Name" SortExpression="User.FullName" />
                            <asp:BoundField DataField="User.Email" HeaderText="Email" SortExpression="User.Email" />
                            <asp:BoundField DataField="User.Contact" HeaderText="Contact" SortExpression="User.Contact" />
                            <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No" SortExpression="RegistrationNo" />
                            <asp:BoundField DataField="Semester" HeaderText="Semester" SortExpression="Semester" />

                            <asp:HyperLinkField DataNavigateUrlFields="StudentId" NavigateUrl="~/Admin/Admin_Edit_Student" DataNavigateUrlFormatString="/Admin/Student/Edit/{0}" HeaderText="Edit" Text="Edit" />
                            <asp:HyperLinkField DataNavigateUrlFields="StudentId" NavigateUrl="~/Admin/Admin_Student.aspx.cs" DataNavigateUrlFormatString="/Admin/Student/{0}" HeaderText="Delete" Text="Delete" />
                        </Columns>
                    </asp:GridView>
                    </div>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>
