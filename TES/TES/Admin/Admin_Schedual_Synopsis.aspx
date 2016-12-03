<%@ Page Language="C#" Title="Schedual Synopsis" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Schedual_Synopsis.aspx.cs" Inherits="TES.Admin.Admin_Schedual_Synopsis" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Synopsis Presentation Schedule</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <asp:Calendar ID="calSynopsisDate" runat="server" CssClass="table"></asp:Calendar>
            </div>
            <div class="row">
                <div class="pull-right">
                    <asp:Button ID="btnSynopsisSchedual" runat="server" Text="Generate Schedual" CssClass="btn btn-default" OnClick="btnSynopsisSchedual_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
