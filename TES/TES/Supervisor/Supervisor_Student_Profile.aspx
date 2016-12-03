<%@ Page Language="C#" Title="Student Profile" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Student_Profile.aspx.cs" Inherits="TES.Supervisor.Supervisor_Student_Profile" %>


<asp:Content ContentPlaceHolderID="cphBody" runat="server">
        <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Student Profile</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="lblFname" runat="server" Text="Full Name:"></asp:Label>
                    <asp:Literal ID="ltrfname" runat="server"></asp:Literal>
                    <br />
                    <asp:Label ID="lblUname" runat="server" Text="User Name:"></asp:Label>
                    <asp:Literal ID="ltruname" runat="server"></asp:Literal>
                    <br />
                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:Literal ID="ltremail" runat="server"></asp:Literal>
                    <br />
                    <asp:Label ID="lblContact" runat="server" Text="Contact No:"></asp:Label>
                    <asp:Literal ID="ltrcontact" runat="server"></asp:Literal>
                    <br />
                    <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                    <asp:Literal ID="ltrgender" runat="server"></asp:Literal>
                    <br />
                    <asp:Label ID="lblCNIC" runat="server" Text="CNIC:"></asp:Label>
                    <asp:Literal ID="ltrcnic" runat="server"></asp:Literal>
                    <br />
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="lblRegNo" runat="server" Text="Registration No:"></asp:Label>
                    <asp:Literal ID="ltrRegNo" runat="server"></asp:Literal>
                    <br />
                    <asp:Label ID="lblSemester" runat="server" Text="Semester:"></asp:Label>
                    <asp:Literal ID="ltrSemester" runat="server"></asp:Literal>
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="pull-right">
                        <asp:Button ID="btnSupervise" runat="server" Text="Supervise" OnClick="btnSupervise_Click" CssClass="btn btn-default" />
                        <asp:Button ID="btnDontSupervise" runat="server" Text="Don't Supervise" OnClick="btnDontSupervise_Click" CssClass="btn btn-warning" />
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>