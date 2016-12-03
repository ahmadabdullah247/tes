<%@ Page Language="C#" Title="Thesis History" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_Thesis_History.aspx.cs" Inherits="TES.Student.Student_Thesis_History" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Thesis History</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <!-- Response
            ============================================================================================ -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlResponseFail" runat="server" Visible="false" CssClass="alert alert-warning alert-dismissable response">
                        <i class="fa fa-exclamation-triangle"></i>&nbsp Review is not added by supervisor.
                        <button class="close" data-dismiss="alert">&times;</button>
                    </asp:Panel>
                </div>
        </div>
            <div class="row">
                    <h4><asp:Label ID="lblStatus" runat="server"></asp:Label></h4>
            </div>
            <hr />
        <div class="row">
            <div class="col-lg-12">
                <asp:GridView ID="gvThesis" runat="server" PageSize="7" DataKeyNames="ThesisID" AllowPaging="True" AutoGenerateColumns="false" CssClass="table table-bordered" OnPageIndexChanging="gvThesis_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="FileName" HeaderText="Files" SortExpression="FileName" />

                        <asp:HyperLinkField DataNavigateUrlFields="FileID" DataNavigateUrlFormatString="/Student/Submission/Downlaod/{0}" HeaderText="Downlaod" Text="Downlaod" />
                        <asp:HyperLinkField DataNavigateUrlFields="FileID" DataNavigateUrlFormatString="/Student/Submission/Review/{0}" HeaderText="Review" Text="Review" />
                    </Columns>
                </asp:GridView>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>

