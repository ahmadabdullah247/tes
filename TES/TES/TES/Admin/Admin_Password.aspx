<%@ Page Language="C#" Title="Change Password" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Password.aspx.cs" Inherits="TES.Admin.Admin_Password" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Change Password</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Admin Password Updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-danger alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Admin Password did not updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <div class="form-group  has-feedback">
                            <asp:Label ID="lblCurrentPassword" runat="server" Text="Current Password "  CssClass="control-label"></asp:Label>
                            <asp:TextBox ID="txtCurrentPassword" runat="server" placeholder="Current Password..." CssClass="form-control" TextMode="Password" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group  has-feedback">
                            <asp:Label ID="Label1" runat="server" Text="New Password"  CssClass="control-label"></asp:Label>
                            <input type="password" data-minlength="6" class="form-control" id="inputPassword" placeholder="Password ..." required="required" />
                            <span class="help-block">Minimum of 6 characters</span>
                        </div>
                        <div class="form-group  has-feedback">
                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Confirm Password ..."
                                TextMode="Password" class="form-control"
                                data-match-error="Whoops, these don't match" data-match="#inputPassword"
                                required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <asp:Button ID="btnUpdatePassword" runat="server" Text="Update Password" OnClick="btnUpdatePassword_Click"  CssClass="btn btn-default"/>
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
