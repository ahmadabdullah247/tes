<%@ Page Language="C#" Title="Meeting Minutes" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Meeting_History_Minutes.aspx.cs" Inherits="TES.Supervisor.Supervisor_Meeting_History_Minutes" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Meeting minutes</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-6">
                    <div class="from-group">
                        <asp:TextBox ID="txtMeetingMin" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <br />
            <div class="row">
                <div class="col-lg-12">
                    <div class="pull-right">
                        <asp:Button ID="btnMeetingMin" runat="server" Text="Add" OnClick="btnMeetingMin_Click" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>



