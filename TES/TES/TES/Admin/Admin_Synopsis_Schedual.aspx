<%@ Page Language="C#" Title="Synopsis Presentation" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Synopsis_Schedual.aspx.cs" Inherits="TES.Admin.Admin_Synopsis_Schedual" %>

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
                <div class="col-lg-12">
                        <asp:GridView ID="gvPresentationSchedual" runat="server" AutoGenerateColumns="False" DataKeyNames="PresentationID" PageSize="7" AllowPaging="True" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="Thesis.Student.User.FullName" HeaderText="Student Name" SortExpression="Thesis.Student.User.FullName" />
                                <asp:BoundField DataField="Thesis.Student.RegistrationNo" HeaderText="Student Registration#" SortExpression="Thesis.Student.RegistrationNo" />
                                <asp:BoundField DataField="Thesis.Title" HeaderText="Thesis Title" SortExpression="Thesis.Title" />
                                <asp:BoundField DataField="Thesis.Supervisor.User.FullName" HeaderText="Supervisor Name" SortExpression="Thesis.Supervisor.User.FullName" />
                                <asp:BoundField DataField="PresentationTime" HeaderText="Presentation Time" SortExpression="PresentationTime" />
                                <asp:BoundField DataField="DateTime" HeaderText="Presentation Date" SortExpression="DateTime" />
                            </Columns>
                        </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="pull-right">
                    <a href="/Admin/Schedual/Synopsis" class="btn btn-default">Generate</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
