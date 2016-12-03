<%@ Page Language="C#" Title="Add Meeting" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Add_Meeting.aspx.cs" Inherits="TES.Supervisor.Supervisor_Add_Meeting" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Meeting Request</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:DropDownList ID="ddlThesis" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlThesis_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblStudent" runat="server"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-4">
                        <div class="from-group">
                            <asp:Label ID="lblTitle" runat="server" Text="Meeting Date"></asp:Label>
                            <asp:Calendar ID="calMeeting" runat="server" CssClass="table"></asp:Calendar>
                        </div>
                </div>
                <div class="col-lg-4">
                        <div class="from-group">
                            <asp:Label ID="Label2" runat="server" Text="Meeting Time"></asp:Label>
                            <cc1:TimeSelector ID="tsMeeting" runat="server"></cc1:TimeSelector>
                        </div>
                </div>
            </div>
            <div class="row">
                <div class="pull-right">
                    <asp:Button ID="btnAddMeeting" runat="server" Text="Add Meeting" CssClass="btn btn-default" OnClick="btnAddMeeting_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
