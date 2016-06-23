<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200298627_v2.TodoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Todo List</h1>
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add ToDO</a>
                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="TodoGridView" AutoGenerateColumns="false" DataKeyNames="TodoID"
                    OnRowDeleting="TodoGridView_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="TodoName" HeaderText="Todo Name" Visible="true"/>
                        <asp:BoundField DataField="TodoNotes" HeaderText="Todo Notes" Visible="true"/>
                        <asp:CheckBoxField DataField="Completed" HeaderText="Completed" Visible="true"/>
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/TodoList.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>  
</asp:Content>
