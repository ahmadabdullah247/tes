<%@ Page Language="C#" Title="Edit Faculty" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Eidt_Faculty.aspx.cs" Inherits="TES.Admin.Admin_Eidt_Faculty" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Edit Faculty</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Can not add more than 3 GTC members.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <!-- /.row -->
            <div role="form">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="col-lg-6">
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
                        </div>
                    </div>
                    <div class="col-lg-6">
                    <div class="form-group">
                        <asp:CheckBox ID="cbGTC" runat="server" Text="GTC " Checked="false"/>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtJobTitle" runat="server"
                            CssClass="form-control" placeholder="Job Title ... "
                            data-error="Enter a valid Job title." required="required"></asp:TextBox>
                        <span class="help-block with-errors"></span>

                    </div>
                    </div>
                </div>

                <asp:Button ID="btnUpdte" runat="server" Text="Update" OnClick="btnUpdte_Click" CssClass="btn btn-warning"/>
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>
