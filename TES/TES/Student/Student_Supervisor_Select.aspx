<%@ Page Language="C#" AutoEventWireup="true" Title="Supervisor" MasterPageFile="~/Student/Student.Master" CodeBehind="Student_Supervisor_Select.aspx.cs" Inherits="TES.Student.Student_Supervisor_Select" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Select Supervisor</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
        <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Meeting request submitted succsefuly.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>

            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Panel ID="pnlSelect" runat="server">
                            <asp:DropDownList ID="ddlSupervisor" runat="server" CssClass="form-control"></asp:DropDownList>
                            <br />
                            <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" CssClass="btn btn-default pull-right"/>
                        </asp:Panel>
                        <asp:Panel ID="pnlAwait" runat="server">
                            <div class="panel panel-default">
                                <div class="panel-heading">Status Await</div>
                                <div class="panel-body">
                                    Email was sent to your selected supervisor. Please wait while they reposnds.
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlApproved" runat="server">
                            <div class="panel panel-default">
                                <div class="panel-heading">Your Supervisor</div>
                                <div class="panel-body">
                                    <asp:Label ID="lblSupervisor" runat="server"></asp:Label> will supervise you through your thesis.

                                </div>
                            </div>
                            <br />
                            <div class="panel panel-default">
                                <div class="panel-heading">Your Co-Supervisor</div>
                                <div class="panel-body">
                                    <asp:Panel ID="pnlSelectCoSupervisoer" runat="server">
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="ddlCoSupervisor" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="pull-right">
                                            <asp:Button ID="btnSelectCoSupervisor" runat="server" Text="Select" OnClick="btnSelectCoSupervisor_Click" CssClass="btn btn-default pull-right" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>

                        </asp:Panel>
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

