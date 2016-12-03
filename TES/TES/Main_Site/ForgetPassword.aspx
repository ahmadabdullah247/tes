<%@ Page Language="C#" Title="Forget Password" MasterPageFile="~/Main_Site/Main.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="TES.Main_Site.ForgetPassword" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <div class="container">
        <!-- Response
            ============================================================================================ -->
        <div class="row">
            <div class="col-lg-12">
                <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                    <i class="fa fa-exclamation-triangle"></i>&nbsp Please check you email.
                        <button class="close" data-dismiss="alert">&times;</button>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading"  style="background-color: rgb(42, 122, 167);color:white;">
                        <h3 class="panel-title">Please enter your email address here.</h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"
                                CssClass="form-control" placeholder="Example@xyz.com ... "
                                data-error="That email address is invalid." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">Email dose not exists.</asp:Panel>
                        <!-- Change this to a button or input when using this as a form -->
                        <asp:Button ID="btnRecover" runat="server" Text="Submit" OnClick="btnRecover_Click" CssClass="btn btn-lg btn-success btn-block" />
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