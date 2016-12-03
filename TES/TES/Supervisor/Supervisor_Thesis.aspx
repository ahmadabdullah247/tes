<%@ Page Language="C#" Title="Thesis" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Thesis.aspx.cs" Inherits="TES.Supervisor.Supervisor_Thesis" %>

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
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Thesis successfully added.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Thesis successfully Updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div role="form">
                        <div class="from-group">
                            <asp:GridView ID="gvThesis" runat="server" AutoGenerateColumns="False" DataKeyNames="ThesisID" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                                    <asp:BoundField DataField="Domain" HeaderText="Domain" SortExpression="Domain" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="User.Contact" />
                                    <asp:BoundField DataField="Student.User.FullName" HeaderText="Student" SortExpression="Student.User.FullName" />

                                    <asp:HyperLinkField DataNavigateUrlFields="ThesisID" DataNavigateUrlFormatString="/Supervisor/Thesis/Edit/{0}" HeaderText="Edit" Text="Edit" />
                                    <asp:HyperLinkField DataNavigateUrlFields="ThesisID" DataNavigateUrlFormatString="/Supervisor/Thesis/{0}" HeaderText="Delete" Text="Delete" />
                                    <asp:HyperLinkField DataNavigateUrlFields="ThesisID" DataNavigateUrlFormatString="/Supervisor/Submission/{0}" HeaderText="Submission" Text="Submission" />
                                </Columns>
                            </asp:GridView>
                            <br />
                        </div>
                    </div>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="pull-right">
                        <a href="/Supervisor/Thesis/Add" class="btn btn-default">Add</a>
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>


