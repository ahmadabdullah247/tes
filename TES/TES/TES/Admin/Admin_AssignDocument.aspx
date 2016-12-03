<%@ Page Language="C#" Title="Assign Document" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_AssignDocument.aspx.cs" Inherits="TES.Admin.Admin_AssignDocument" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Assign Document to GTC</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvGTC" runat="server" AutoGenerateColumns="False" DataKeyNames="SupervisorId" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="User.FullName" HeaderText="Full Name" SortExpression="User.FullName" />
                            <asp:BoundField DataField="User.Email" HeaderText="Email" SortExpression="User.Email" />
                            <asp:BoundField DataField="User.Contact" HeaderText="Contact" SortExpression="User.Contact" />
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />

                            <asp:HyperLinkField DataNavigateUrlFields="SupervisorId" NavigateUrl="~/Admin/Admin_Faculty.aspx.cs" DataNavigateUrlFormatString="/Admin/AssignDocument/{0}" HeaderText="Assign Document" Text="Assign Document" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
