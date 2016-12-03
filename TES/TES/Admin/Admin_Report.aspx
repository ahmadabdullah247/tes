<%@ Page Language="C#" Title="Report" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Report.aspx.cs" Inherits="TES.Admin.Admin_Report" %>

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
                    <h1 class="page-header">Reports</h1>
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
                    <asp:GridView ID="gvThesisMeeting" runat="server" AutoGenerateColumns="False" DataKeyNames="MeetingID" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="MeetingMin" HeaderText="Meeting Minutes" SortExpression="MeetingMin" />
                            <asp:BoundField DataField="MeetingTime" HeaderText="Meeting Time" SortExpression="MeetingTime" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
