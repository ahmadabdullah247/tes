<%@ Page Language="C#" Title="Update Password" MasterPageFile="~/Main_Site/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TES.Main_Site.ChangePassword" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <div class="container">
        <!-- Response
            ============================================================================================ -->
        <div class="row">
            <div class="col-lg-12">
                <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                    <i class="fa fa-exclamation-triangle"></i>&nbsp Password successfully updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please enter your email address here.</h3>
                    </div>
                    <div class="panel-body">
                        <label for="inputPassword" class="control-label">New Password</label>
                        <div class="form-group">
                            <input type="password" data-minlength="6" class="form-control" id="inputPassword" placeholder="Password ..." required="required" />
                            <span class="help-block">Minimum of 6 characters</span>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPassword" runat="server" placeholder="Confirm Password ..."
                                TextMode="Password" class="form-control"
                                data-match-error="Whoops, these don't match" data-match="#inputPassword"
                                required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <!-- Change this to a button or input when using this as a form -->
                        <asp:Button ID="btnUpdatePassword" runat="server" Text="Submit" OnClick="btnUpdatePassword_Click" CssClass="btn btn-lg btn-success btn-block" />
                        <hr />
                        <div class="row">
                            <div class="col-lg-6">
                                <a href="/Home">Go Back To Home</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
