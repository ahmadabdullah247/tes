<%@ Page Language="C#" Title="Meeting Request" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Meeting_Request.aspx.cs" Inherits="TES.Supervisor.Supervisor_Meeting_Request" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Meeting Request</h1>
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
                            <asp:GridView ID="gvMeeting" runat="server" AutoGenerateColumns="False" DataKeyNames="MeetingId" PageSize="7" CssClass="table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="Supervisor.User.FullName" HeaderText="Supervisor" SortExpression="Supervisor.User.FullName" />
                                    <asp:BoundField DataField="Student.User.FullName" HeaderText="Student" SortExpression="Student.User.FullName" />

                                    <asp:HyperLinkField DataNavigateUrlFields="MeetingId" DataNavigateUrlFormatString="/Supervisor/Meeting/{0}" HeaderText="Assign Time" Text="Assign Time" />
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
                        <a href="/Supervisor/Add/Meeting" class="btn btn-default">Add Meeting</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>



