<%@ Page Language="C#" Title="Assign Document" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Assign_Document.aspx.cs" Inherits="TES.Admin.Admin_Assign_Document" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Assign Document to <%: supervisor.User.FullName %></h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseSuccess" runat="server" Visible="false" CssClass="alert alert-success alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Document were allocated.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-danger alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Document were not assigned to.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5">
                    <label>Not Assigned</label><br />
                    <asp:ListBox ID="lbUnassigned" runat="server" CssClass="form-control"></asp:ListBox>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btnLtoR" runat="server" Text=">" CssClass="btn btn-default" OnClick="btnLtoR_Click"/>
                    <asp:Button ID="btnRtoL" runat="server" Text="<" CssClass="btn btn-default" OnClick="btnRtoL_Click"/>
                </div>
                <div class="col-lg-5">
                    <label>Assigned</label><br />
                    <asp:ListBox ID="lbAssigned" runat="server" CssClass="form-control"></asp:ListBox>
                </div>
            </div><br />
            <div class="row">
                <div class="pull-right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
