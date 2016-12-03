<%@ Page Language="C#" Title="View Students" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Student.aspx.cs" Inherits="TES.Supervisor.Supervisor_Student" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Student Requests</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Student is added to your supervision.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Student request denied.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div>
                        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentId" PageSize="7" AllowPaging="True" CssClass="table table-bordered" OnPageIndexChanging="gvStudent_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="User.FullName" HeaderText="Full Name" SortExpression="User.FullName" />
                                <asp:BoundField DataField="User.Email" HeaderText="Email" SortExpression="User.Email" />
                                <asp:BoundField DataField="User.Contact" HeaderText="Contact" SortExpression="User.Contact" />
                                <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No" SortExpression="RegistrationNo" />
                                <asp:BoundField DataField="Semester" HeaderText="Semester" SortExpression="Semester" />

                                <asp:HyperLinkField DataNavigateUrlFields="StudentId" DataNavigateUrlFormatString="/Supervisor/Student/{0}" HeaderText="View" Text="View" />
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
