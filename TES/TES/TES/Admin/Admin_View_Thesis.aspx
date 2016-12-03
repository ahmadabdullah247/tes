<%@ Page Language="C#" Title="View Thesis" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_View_Thesis.aspx.cs" Inherits="TES.Admin.Admin_View_Thesis" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Thesis</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label><br />
                    <asp:Label ID="lblDomain" runat="server" Text="Domain"></asp:Label><br />
                    <asp:Label ID="lblDiscription" runat="server" Text="Discription"></asp:Label><br />
                    <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label><br />
                </div>
                <div class="col-lg-6">
                    <asp:Label ID="lblSupervisor" runat="server" Text="Supervisor"></asp:Label><br />
                    <asp:Label ID="lblStudent" runat="server" Text="Student"></asp:Label><br />
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>
