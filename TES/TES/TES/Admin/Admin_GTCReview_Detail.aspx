<%@ Page Language="C#" Title="Review" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_GTCReview_Detail.aspx.cs" Inherits="TES.Admin.Admin_GTCReview_Detail" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <script type="text/javascript">
         function print_page() {
             window.print();
         }
     </script>
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">GTC Review Reports</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="pull-right">
                    <asp:Button ID="btnPrintPage" runat="server" Text="Print Report" CssClass="btn btn-default" OnClick="btnPrintPage_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <label>Title: </label>
                    <p><%= thesis.Title %></p>
                    <label>Domain: </label>
                    <p><%= thesis.Domain %></p>
                    <label>Status: </label>
                    <p><%= thesis.Status %></p>
                </div>
                <div class="col-lg-6">
                    <label>Supervised By: </label>
                    <p><%= thesis.Supervisor.User.FullName %></p>
                    <label>Implemented By: </label>
                    <p><%= thesis.Student.User.FullName %></p>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvThesis" runat="server" AutoGenerateColumns="False" DataKeyNames="ThesisID" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="Supervisor.User.FullName" HeaderText="Supervisor" SortExpression="Supervisor.User.FullName" />
                            <asp:BoundField DataField="GTCReview" HeaderText="Review" SortExpression="GTCReview" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>