﻿<%@ Page Language="C#" Title="View Submissions" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Thesis_Submission.aspx.cs" Inherits="TES.Supervisor.Supervisor_Thesis_Submission" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">View Submissions</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Submission Review was added.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-danger alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Submission review was not added.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>

                    <asp:Panel ID="pnlApprovedmsg" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Thesis status changed to approved.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>

                    <asp:Panel ID="pnlDisApprovedmsg" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Thesis status changed to unapproved.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div role="form">
                        <div class="from-group">
                            <asp:GridView ID="gvThesis" runat="server"  PageSize="7" DataKeyNames="ThesisID" AllowPaging="True" AutoGenerateColumns="false" CssClass="table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="FileName" HeaderText="Files" SortExpression="FileName" />

                                    <asp:HyperLinkField DataNavigateUrlFields="FileID" DataNavigateUrlFormatString="/Supervisor/Submission/Downlaod/{0}" HeaderText="Downlaod" Text="Download" />
                                    <asp:HyperLinkField DataNavigateUrlFields="FileID" DataNavigateUrlFormatString="/Supervisor/Submission/Review/{0}" HeaderText="Review" Text="Review" />
                                </Columns>
                            </asp:GridView>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="pull-right">
                        <asp:Panel ID="pnlApproved" runat="server">
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" CssClass="btn btn-default" />
                        </asp:Panel>
                        <asp:Panel ID="pnlDisApproved" runat="server">
                            <asp:Button ID="btnDisApprove" runat="server" Text="Disapprove" OnClick="btnDisApprove_Click" CssClass="btn btn-default" />
                        </asp:Panel>
                        <br />
                    </div>
                </div>
                <!-- /.col-lg-12 -->
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>