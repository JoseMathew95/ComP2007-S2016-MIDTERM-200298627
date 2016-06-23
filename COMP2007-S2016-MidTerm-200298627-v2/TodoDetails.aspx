<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200298627_v2.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>ToDo Details</h1>
                <div class="form-group">
                    <label class="control-label" for="ToDoTextBox">Todo Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="ToDoTextBox" placeholder="To Do" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="ToDoNotes">Todo Note</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="ToDoNotes" placeholder="Notes" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="Completed">Completed</label>
                    <asp:CheckBox ID="completedCheckbox" runat="server" /> 
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div> 
</asp:Content>
