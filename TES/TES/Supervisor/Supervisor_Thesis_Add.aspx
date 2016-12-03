<%@ Page Language="C#" Title="Add Thesis" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="Supervisor_Thesis_Add.aspx.cs" Inherits="TES.Supervisor.Supervisor_Thesis_Add" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Add Thesis</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-6">
                    <div role="form">
                        <div class="from-group">
                            <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                            <asp:TextBox ID="txtTitle" runat="server"
                                CssClass="form-control" placeholder="Thesis Title ... "
                                data-maxlength="50" data-minlength="5"
                                data-error="Title must contain 5 to 50 characters." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <div class="from-group">
                            <asp:Label ID="lblDomain" runat="server" Text="Domain"></asp:Label>
                            <asp:TextBox ID="txtDomain" runat="server"
                                CssClass="form-control" placeholder="Domain ... "
                                data-error="Please enter a vaild domain." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                            <br />
                        </div>
                        <div class="from-group">
                            <asp:Label ID="lblDiscription" runat="server" Text="Discription"></asp:Label>
                            <asp:TextBox ID="txtDiscription" runat="server" TextMode="MultiLine"
                                CssClass="form-control" placeholder=" ... "
                                data-error="Please add discription for thesis." required="required"></asp:TextBox>
                            <span class="help-block with-errors"></span>
                        </div>
                        <br />
                        <asp:Button ID="btnAddThesis" runat="server" Text="Add" OnClick="btnAddThesis_Click" CssClass="btn btn-default pull-right" />
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
