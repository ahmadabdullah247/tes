<%@ Page Language="C#" Title="Meeting Minutes" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_Meeting_Minutes.aspx.cs" Inherits="TES.Student.Student_Meeting_Minutes" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Meeting minutes</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-6">
                    <div class="from-group">
                        <asp:TextBox ID="txtMeetingMin" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                    </div>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <br />
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>