<%@ Page Language="C#" Title="GTC Review" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="GTC_Thesis_Review.aspx.cs" Inherits="TES.Supervisor.GTC_Thesis_Review" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">GTC Thesis Review</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-6">
                    <div class="from-group">
                        <asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <br />
            <div class="row">
                <div class="col-lg-12">
                    <div class="pull-right">
                        <asp:Button ID="btnReview" runat="server" Text="Add Review" OnClick="btnReview_Click" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>



