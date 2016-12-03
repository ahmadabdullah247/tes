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
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label ID="lblFname" runat="server" Text="Full Name"></asp:Label>
                            <asp:TextBox ID="txtFname" runat="server"
                                class="form-control" placeholder="Full Name ... "
                                data-maxlength="50" data-minlength="3"
                                data-error="Name must contain 3 to 50 characters." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server"
                                                        CssClass="form-control" placeholder="Example@xyz.com ... "
                            data-error="That email address is invalid." required="required"></asp:TextBox>
                        <span class="help-block with-errors"></span>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblContact" runat="server" Text="Contact No:"></asp:Label>
                            <asp:TextBox ID="txtContact" runat="server"
                            CssClass="form-control" placeholder="000-00000 ... "
                            pattern="^[0-9]{4}-[0-9]{7}$"
                            data-error="Invalid phone number." required="required"></asp:TextBox>
                        <span class="help-block with-errors"></span>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                            <asp:RadioButtonList ID="rblGender" runat="server">
                                <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCnic" runat="server" Text="Cnic No:"></asp:Label>
                            <asp:TextBox ID="txtCnic" runat="server"
                                                            CssClass="form-control" placeholder="CNIC ... "
                            pattern="^[0-9]{5}-[0-9]{7}-[0-9]{1}$"
                            data-error="Invalid CNIC." required="required"></asp:TextBox>
                        <span class="help-block with-errors"></span>
                        </div>
                        <asp:Button ID="btnUpdte" runat="server" Text="Update" OnClick="btnUpdte_Click" CssClass="btn btn-warning"/>
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
