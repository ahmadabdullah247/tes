<%@ Page Language="C#" Title="Meeting History" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Meeting_History.aspx.cs" Inherits="TES.Supervisor.Supervisor_Meeting_History" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Meeting History</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Meeting Minutes Successfully Added.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Meeting Minutes Were Not Added..
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div role="form">
                        <div class="from-group">
                            <asp:GridView ID="gvMeeting" runat="server" AutoGenerateColumns="False" DataKeyNames="MeetingId" PageSize="7" CssClass="table table-bordered" OnPageIndexChanging="OnPaging">
                                <Columns>
                                    <asp:BoundField DataField="MeetingTime" HeaderText="Meeting Time" SortExpression="MeetingTime" />
                                    <asp:BoundField DataField="Supervisor.User.FullName" HeaderText="Supervisor" SortExpression="Supervisor.User.FullName" />
                                    <asp:BoundField DataField="Student.User.FullName" HeaderText="Student" SortExpression="Student.User.FullName" />

                                    <asp:HyperLinkField DataNavigateUrlFields="MeetingId" DataNavigateUrlFormatString="/Supervisor/History/Meeting/{0}" HeaderText="Meeting Minutes" Text="Meeting Minutes" />
                                </Columns>
                            </asp:GridView>
                            <br />
                        </div>
                    </div>
                </div>
                <!-- /.col-lg-12 -->
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>




