<%@ Page Language="C#" Title="Thesis" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Thesis.aspx.cs" Inherits="TES.Admin.Admin_Thesis" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Thesis</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div>
                        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" DataKeyNames="ThesisID" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Thesis Title" SortExpression="Title" />
                                <asp:BoundField DataField="Domain" HeaderText="Domain" SortExpression="Domain" />
                                <asp:BoundField DataField="Supervisor.User.FullName" HeaderText="Supervisor Name" SortExpression="Supervisor.User.FullName" />
                                <asp:BoundField DataField="Student.User.FullName" HeaderText="Student Name" SortExpression="Student.User.FullName" />
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />

                                <asp:HyperLinkField DataNavigateUrlFields="ThesisID" NavigateUrl="~/Admin/Admin_View_Thesis.aspx" DataNavigateUrlFormatString="/Admin/Thesis/{0}" HeaderText="View" Text="View" />
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
