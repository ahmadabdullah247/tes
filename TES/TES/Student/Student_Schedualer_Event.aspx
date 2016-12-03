<%@ Page Language="C#" Title="Event Sheet" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_Schedualer_Event.aspx.cs" Inherits="TES.Student.Student_Schedualer_Event" %>

<asp:Content ContentPlaceHolderID="cphBody" runat="server">
<style>
    .Event-Sheet{
        border:1px solid black;
        padding:0px 200px;
    }
    .uLine{
        text-decoration:underline;
        font-weight:bold;
    }
</style>
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Event Calendar</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="Event-Sheet">
                        <h4>Dated: <asp:Label ID="lblEventDate0" runat="server"></asp:Label></h4>
                        <h3 style="text-align:center" class="uLine">Calendar of Events - MS Thesis <asp:Label ID="lblHeaderDate" runat="server"></asp:Label></h3>
                        <h4>All MS students who have registered their Thesis are directed to follow the schedule of events given below:</h4>

                        <h4 class="uLine">For students who registered their thesis in <asp:Label ID="lblSpringDate" runat="server"></asp:Label></h4>

                        <table border="1" class="table table-bordered">
                            <tr>
                                <td>
                                    <p>Submission of Synopsis, as per given format, duly signed by the supervisor. Soft copy is also required.</p>
                                </td>
                                <td style="width:20%;">
                                    <p><asp:Label ID="lblEventDate1" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Synopsis presentations</p>
                                </td>
                                <td>
                                    <p><asp:Label ID="lblEventDate2" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Re-submission of revised synopsis</p>
                                </td>
                                <td>
                                    <p><asp:Label ID="lblEventDate3" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Approval/rejection of synopsis and onward submission to Dean office for the approval</p>
                                </td>
                                <td>
                                    <p><asp:Label ID="lblEventDate4" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                        </table>

                        <h4 class="uLine">For students who registered their thesis in <asp:Label ID="lblFallDate" runat="server"></asp:Label></h4>

                        <table border="1"  class="table table-bordered">
                            <tr>
                                <td>
                                    <p>MS Thesis Submission (soft-copy and one hard-copy in spiral ring binding)</p>
                                </td>
                                <td style="width:20%;">
                                    <p><asp:Label ID="lblEventDate5" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Internal Presentations of completed Thesis </p>
                                </td>
                                <td>
                                    <p><asp:Label ID="lblEventDate6" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Re-presentation (if required) / Final version (two copies with changes incorporated which are suggested in internal presentations), complete in all respects and duly signed by the supervisor along with the Plagiarism free report, in spiral binding to be submitted</p>
                                </td>
                                <td>
                                    <p><asp:Label ID="lblEventDate7" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p>Thesis to be submitted by CS Department to the Examination Section</p>
                                </td>
                                <td>
                                    <p><asp:Label ID="lblEventDate8" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                        </table>

                        <h4>After the final deadline, the thesis will not be forwarded to examination section, which means to carry them forward to the next semester with an “In Progress (IP)” status.</h4>
                        <br /><br /><br /><br />
                        <h4 class="pull-right" style="font-weight:bold;">
                            Incharge Graduate Thesis Committee<br />
                            Department of Computer Science 
                        </h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
