<%@ Page Language="C#" Title="Profile" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_Profile.aspx.cs" Inherits="TES.Student.Student_Profile" %>


<asp:Content ContentPlaceHolderID="cphBody" runat="server">
        <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Profile</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Student Profile Updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-danger alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Student Profile did not updated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <table class="table table-hover">
                        <tr>
                            <td>
                                <label style="margin: 0px;">Full Name :</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltrfname" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <label style="margin: 0px;">Username :</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltruname" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="margin: 0px;">Email :</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltremail" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <label style="margin: 0px;">Contact No :</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltrcontact" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="margin: 0px;">Gender :</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltrgender" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <label style="margin: 0px;">CNIC :</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltrcnic" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label style="margin: 0px;">Reg# : </label>
                            </td>
                            <td>
                    <asp:Literal ID="ltrRegNo" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <label style="margin: 0px;">Semester : </label>
                            </td>
                            <td>
                    <asp:Literal ID="ltrSemester" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>