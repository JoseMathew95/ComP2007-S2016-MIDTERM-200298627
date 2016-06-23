using COMP2007_S2016_MidTerm_200298627_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace COMP2007_S2016_MidTerm_200298627_v2
{
    public partial class TodoDetails : System.Web.UI.Page
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
                int todoID = Convert.ToInt32(Request.QueryString["TodoID"]);
                // query the todo Table using EF and LINQ
                Todo UpdatedTodoList = (from todo in db.Todos
                                        where todo.TodoID == todoID
                                        select todo).FirstOrDefault();

                if (UpdatedTodoList != null)
                {
                    ToDoTextBox.Text = UpdatedTodoList.TodoName;
                    ToDoNotes.Text = UpdatedTodoList.TodoNotes;
                    completedCheckbox.Checked = (bool)UpdatedTodoList.Completed;
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (TodoConnection db = new TodoConnection())
            {
                // use the todo model to create a new todo object and
                // save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a todo in it
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current todo from EF DB
                    newTodo = (from todo in db.Todos
                                  where todo.TodoID == TodoID
                                  select todo).FirstOrDefault();
                }

                // add form data to the new todo record
                newTodo.TodoName = ToDoTextBox.Text;
                newTodo.TodoNotes = ToDoNotes.Text;
                
                newTodo.Completed =    Convert.ToBoolean(completedCheckbox.Checked.ToString());
                // use LINQ to ADO.NET to add / insert new student into the database

                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated todo page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}