<%@ Page Language="C#" Title="GTC Review" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_Thesis_GTCReview.aspx.cs" Inherits="TES.Student.Student_Thesis_GTCReview" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Submission Review</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvGTCReview" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="gtc_review1" HeaderText="Review" SortExpression="gtc_review1" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">

                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>


