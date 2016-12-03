<%@ Page Language="C#" Title="Meeting Minutes Report" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Report_MeetingMinutes.aspx.cs" Inherits="TES.Admin.Admin_Report_MeetingMinutes" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Meeting Minutes Report</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Admin Profile Updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-danger alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Admin Profile did not updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                        <asp:GridView ID="gvThesisReport" runat="server" AutoGenerateColumns="False" DataKeyNames="ThesisID" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="Supervisor.User.FullName" HeaderText="Supervisor Name" SortExpression="Supervisor.User.FullName" />
                                <asp:BoundField DataField="Student.User.FullName" HeaderText="Student Name" SortExpression="Student.User.FullName" />
                                <asp:BoundField DataField="Title" HeaderText="Thesis Title" SortExpression="Title" />
                                <asp:BoundField DataField="Domain" HeaderText="Domain" SortExpression="Domain" />
                                
                                <asp:HyperLinkField DataNavigateUrlFields="ThesisID" NavigateUrl="~/Admin/Admin_Report.aspx" DataNavigateUrlFormatString="/Admin/Reports/{0}" HeaderText="Report" Text="Report" />
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