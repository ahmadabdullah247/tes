<%@ Page Language="C#" Title="Sign In" MasterPageFile="~/Main_Site/Main.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="TES.Main_Site.SignIn" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <div class="container">
        <!-- Response
            ============================================================================================ -->
        <div class="row">
            <div class="col-lg-12">
                <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                    <i class="fa fa-exclamation-triangle"></i>&nbsp Sign up was successful.
                        <button class="close" data-dismiss="alert">&times;</button>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading" style="background-color: rgb(42, 122, 167);color:white;">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group has-feedback">
                            <asp:TextBox ID="txtUsername" runat="server"
                                placeholder="Username ..." CssClass="form-control"
                                data-error="Please enter a valid username" required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                           

                        </div>
                        <div class="form-group has-feedback">
                            <asp:TextBox ID="txtPassword" runat="server"
                                placeholder="Password ..." CssClass="form-control"
                                TextMode="Password"
                                data-error="Please enter password" required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True">-- Select One --</asp:ListItem>
                                <asp:ListItem Value="Student" Text="Student"></asp:ListItem>
                                <asp:ListItem Value="Supervisor" Text="Supervisor"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">User name or password is incorrect</asp:Panel>
                        <!-- Change this to a button or input when using this as a form -->
                        <asp:Button ID="btnSignIn" runat="server" Text="Sign in" OnClick="btnSignIn_Click" CssClass="btn btn-lg btn-success btn-block" />
                        <hr />
                        <div class="row">
                            <div class="col-lg-6">
                                <a href="/SignUp">Sign Up</a>
                            </div>
                            <div class="col-lg-6">
                                <a href="/ForgetPassword" class="pull-right">Forget Password</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
