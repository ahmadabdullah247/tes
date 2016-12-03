<%@ Page Language="C#" Title="GTC Review" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_GTCReview.aspx.cs" Inherits="TES.Admin.Admin_GTCReview" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">GTC Review Report</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvGTC" runat="server" AutoGenerateColumns="False" DataKeyNames="ThesisID" PageSize="7" CssClass="table table-bordered" OnPageIndexChanging="gvGTC_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Student.User.FullName" HeaderText="Student" SortExpression="Student.User.FullName" />
                            <asp:BoundField DataField="Supervisor.User.FullName" HeaderText="Supervisor" SortExpression="Supervisor.User.FullName" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />

                            <asp:HyperLinkField DataNavigateUrlFields="ThesisID" NavigateUrl="~/Admin/Admin_GTCReview_Detail.aspx.cs" DataNavigateUrlFormatString="/Admin/Report/Review/{0}" HeaderText="Reviews" Text="Reviews" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
