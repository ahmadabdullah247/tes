<%@ Page Language="C#" Title="Edit Profile" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Edit.aspx.cs" Inherits="TES.Admin.Admin_Edit" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Edit Profile</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="form-group">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Full Name</label>
                            <asp:TextBox ID="txtFname" runat="server"
                                class="form-control" placeholder="Full Name ... "
                                data-maxlength="50" data-minlength="3"
                                data-error="Name must contain 3 to 50 characters." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox ID="txtEmail" runat="server"
                                                        CssClass="form-control" placeholder="Example@xyz.com ... "
                            data-error="That email address is invalid." required="required"></asp:TextBox>
                        <span class="help-block with-errors"></span>
                        </div>
                        <div class="form-group">
                            <label>Contact No</label>
                            <asp:TextBox ID="txtContact" runat="server"
                            CssClass="form-control" placeholder="000-00000 ... "
                            pattern="^[0-9]{4}-[0-9]{7}$"
                            data-error="Invalid phone number." required="required"></asp:TextBox>
                        <span class="help-block with-errors"></span>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>CNIC</label>
                            <asp:TextBox ID="txtCnic" runat="server"
                                                            CssClass="form-control" placeholder="CNIC ... "
                            pattern="^[0-9]{5}-[0-9]{7}-[0-9]{1}$"
                            data-error="Invalid CNIC." required="required"></asp:TextBox>
                        <span class="help-block with-errors"></span>
                        </div>
                        <div class="form-group">
                            <label>Gender</label>
                            <asp:RadioButtonList ID="rblGender" runat="server">
                                <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="pull-right">
                        <asp:Button ID="btnUpdte" runat="server" Text="Update" OnClick="btnUpdte_Click" CssClass="btn btn-default"/>
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
