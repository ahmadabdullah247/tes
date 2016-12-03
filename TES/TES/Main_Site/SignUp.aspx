<%@ Page Language="C#" Title="Sign Up" MasterPageFile="~/Main_Site/Main.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="TES.Main_Site.SignUp" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <div class="container">
        <!-- Response
            ============================================================================================ -->
        <div class="row">
            <div class="col-lg-12">
                <asp:Panel ID="pnlResponseError" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                    <i class="fa fa-exclamation-triangle"></i>&nbsp Username Already Exists. Please try agin with another username.
                        <button class="close" data-dismiss="alert">&times;</button>
                </asp:Panel>
                <asp:Panel ID="pnlRegError" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                    <i class="fa fa-exclamation-triangle"></i>&nbsp Registration No Already Exists. Please try agin with another registration no.
                        <button class="close" data-dismiss="alert">&times;</button>
                </asp:Panel>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="login-panel panel panel-default" style="margin-top: 5%;">
                        <div class="panel-heading" style="background-color: rgb(42, 122, 167); color: white;">
                            <h3 class="panel-title">Sign Up</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-2">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlUser" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" CssClass="form-control">
                                                <asp:ListItem Text="Student" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Teacher"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtFname" runat="server"
                                                class="form-control" placeholder="Full Name ... "
                                                data-maxlength="50" data-minlength="3"
                                                data-error="Name must contain 3 to 50 characters." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtUsername" runat="server"
                                                CssClass="form-control" placeholder="Username ... "
                                                data-error="Please enter a username." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>

                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"
                                                CssClass="form-control" placeholder="Example@xyz.com ... "
                                                data-error="That email address is invalid." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"
                                                CssClass="form-control" placeholder="Password ... "
                                                data-minlength="6"
                                                data-error="Password must contain atleast 6 characters." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>

                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtNumber" runat="server"
                                                CssClass="form-control" placeholder="000-00000 ... "
                                                pattern="^[0-9]{4}-[0-9]{7}$"
                                                data-error="Invalid phone number." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>

                                        </div>
                                        <div class="form-group">
                                            <asp:RadioButtonList ID="rblGender" runat="server">
                                                <asp:ListItem Value="Male" Text="Male" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCNIC" runat="server"
                                                CssClass="form-control" placeholder="CNIC ... "
                                                pattern="^[0-9]{5}-[0-9]{7}-[0-9]{1}$"
                                                data-error="Invalid CNIC." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <!---------------------------------------------------------->
                                    <asp:Panel ID="pnlStudent" Visible="true" runat="server">
                                        <div class="form-group" style="margin: -10px 0px 0px 0px;">
                                            <div class="col-md-4" style="padding: 0px;">
                                                <asp:DropDownList ID="ddlReg" runat="server" CssClass=" form-control">
                                                    <asp:ListItem Value="SP16" Text="SP16"></asp:ListItem>
                                                    <asp:ListItem Value="FA16" Text="FA16"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-4" style="padding: 0px;">
                                                <asp:DropDownList ID="ddlProgram" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="BCS" Text="BCS"></asp:ListItem>
                                                    <asp:ListItem Value="BCE" Text="BCE"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-4" style="padding: 0px;">
                                                <asp:TextBox ID="txtRegNo" runat="server"
                                                    CssClass="form-control" placeholder="XXX ... "
                                                    pattern="^[0-9]{3}$"
                                                    data-error="Invalid Registration Number." required="required"></asp:TextBox>
                                            </div>
                                            <span class="help-block with-errors"></span>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSemester" runat="server"
                                                CssClass="form-control" placeholder="Semester ... "
                                                data-maxlength="12" data-minlength="1"
                                                data-error="Please enter a valid semeter." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlTeacher" Visible="false" runat="server">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtTitle" runat="server"
                                                CssClass="form-control" placeholder="Job Title ... "
                                                data-error="Enter a valid Job title." required="required"></asp:TextBox>
                                            <span class="help-block with-errors"></span>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <hr />
                            <!-- Navigation -->
                            <div class="row">
                                <div class="col-lg-6">
                                    <a href="/Home">Go Back To Home</a>
                                </div>
                                <div class="col-lg-6">
                                    <div class="pull-right">
                                        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" CssClass="btn btn-default pull-right" />&nbsp&nbsp&nbsp
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-warning pull-right" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
