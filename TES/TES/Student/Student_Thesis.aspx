<%@ Page Language="C#" Title="Thesis" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_Thesis.aspx.cs" Inherits="TES.Student.Student_Thesis" %>

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
                <div class="col-lg-12">
                    <asp:Panel ID="pnlSelectSuperVisor" runat="server">
                        <div class="panel panel-default">
                            <div class="panel-heading">Unassigned Supervisor</div>
                            <div class="panel-body">
                                Please Selet a supervisor first.
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlUnassigned" runat="server">
                        <div class="panel panel-default">
                            <div class="panel-heading">Unassigned Thesis</div>
                            <div class="panel-body">
                                You are not assigned with a thesis.
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlAssigned" runat="server">
                        <div class="panel panel-default">
                            <div class="panel-heading">Assigned Thesis</div>
                            <div class="panel-body">
                                Please upload
                                <asp:Label ID="lblUpload" runat="server"></asp:Label>
                                <asp:FileUpload ID="fuThesis" runat="server"/>
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-default" OnClick="btnUpload_Click" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>

