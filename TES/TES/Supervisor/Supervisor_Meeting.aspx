<%@ Page Language="C#" Title="Set Meeting" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Meeting.aspx.cs" Inherits="TES.Supervisor.Supervisor_Meeting" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Set meeting</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-6">
                    <div role="form">
                        <div class="from-group">
                            <asp:Label ID="lblTitle" runat="server" Text="Meeting Date"></asp:Label>
                            <asp:Calendar ID="calMeeting" runat="server" CssClass="table"></asp:Calendar>
                        </div>
                        <div class="from-group">
                            <asp:Label ID="Label1" runat="server" Text="Meeting Time"></asp:Label>
                            <cc1:TimeSelector ID="tsMeeting" runat="server"></cc1:TimeSelector>
                        </div>
                        <br />
                        <asp:Button ID="btnSetMeeting" runat="server" Text="Add Meeting" OnClick="btnSetMeeting_Click" CssClass="btn btn-default pull-right" />
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
