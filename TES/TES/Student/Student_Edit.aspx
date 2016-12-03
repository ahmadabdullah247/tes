<%@ Page Language="C#" Title="Edit Student" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_Edit.aspx.cs" Inherits="TES.Student.Student_Edit" %>

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
            <div class="form-group" role="form">
                <div class="row">
                    <div class="col-lg-6">
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
                        <div class="form-group">
                            <label>Gender</label>
                            <asp:RadioButtonList ID="rblGender" runat="server">
                                <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                             <label>CNIC</label>
                            <asp:TextBox ID="txtCnic" runat="server"
                                CssClass="form-control" placeholder="CNIC ... "
                                pattern="^[0-9]{5}-[0-9]{7}-[0-9]{1}$"
                                data-error="Invalid CNIC." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <label>Registration No</label>
                        <div class="form-group">
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
                        <br /><br />
                        <div class="form-group">
                            <label>Semester</label>
                            <asp:TextBox ID="txtSemester" runat="server"
                                CssClass="form-control" placeholder="Semester ... "
                                data-maxlength="12" data-minlength="1"
                                data-error="Please enter a valid semeter." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="pull-right">
                        <asp:Button ID="btnUpdte" runat="server" Text="Update" OnClick="btnUpdte_Click" CssClass="btn btn-default"/>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </div>
    </div>
    <!-- /#page-wrapper -->
</asp:Content>
