using COMP2007_S2016_MidTerm_200298627_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP2007_S2016_MidTerm_200298627_v2
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Get the todo data
                this.GeTodo();
            }
        }

        protected void GeTodo()
        {
            // connect to EF
            using (TodoConnection db = new TodoConnection())
            {

                // query the todo Table using EF and LINQ
                var TodoList = (from allTodos in db.Todos
                                select allTodos);

                // bind the result to the GridView
                TodoGridView.DataSource = TodoList.ToList();
                TodoGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected todo using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["StudentID"]);

            // use EF to find the selected todo in the DB and remove it
            using (TodoConnection db = new TodoConnection())
            {
                // create object of the todo class and store the query string inside of it
                Todo deletedTodo = (from toDoRecords in db.Todos
                                          where toDoRecords.TodoID == TodoID
                                       select toDoRecords).FirstOrDefault();

                // remove the selected todo from the db
                db.Todos.Remove(deletedTodo);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GeTodo();
            }
        }

    }
}