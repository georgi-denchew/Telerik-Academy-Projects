using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoListWebApplication
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GridViewTodos.Visible = false;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> GridViewCategories_GetData()
        {
            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();
            return context.Categories.OrderBy(cat => cat.CategoryId);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int categoryId)
        {
            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();

            var categoryToDelete = context.Categories.Find(categoryId);
            context.Categories.Remove(categoryToDelete);
            context.SaveChanges();

            this.GridViewCategories.SelectMethod = "GridViewCategories_GetData";
            this.GridViewCategories.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int categoryId)
        {
        }

        protected void GridViewCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var gridView = (sender as GridView);
            var categoryId = e.Keys["CategoryId"];

            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();
            var category = context.Categories.Find(categoryId);

            if (category == null)
            {
                throw new InvalidOperationException("Category does not exist");
            }

            string newTitle = (gridView.Rows[e.RowIndex].FindControl("TextBoxCategoryName") as TextBox).Text;

            category.Title = newTitle;
            context.SaveChanges();
        }

        protected void LinkButtonAddCategory_Click(object sender, EventArgs e)
        {
            var grid = (sender as LinkButton).Parent;
            var textbox = grid.FindControl("TextBoxNewCategoryName") as TextBox;
            string categoryName = textbox.Text;

            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();
            Category newCategory = new Category() { Title = categoryName };
            context.Categories.Add(newCategory);
            context.SaveChanges();

            textbox.Text = string.Empty;

            Response.Redirect("Default");
        }

        protected void GridViewCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewTodos.SelectMethod = "GridViewTodos_GetData";
            this.GridViewTodos.DataBind();
            this.GridViewTodos.Visible = true;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTodos_DeleteItem(int todoId)
        {
            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();
            var todo = context.Todos.Find(todoId);

            context.Todos.Remove(todo);
            context.SaveChanges();

            this.GridViewTodos.SelectMethod = "GridViewTodos_GetData";
            this.GridViewTodos.DataBind();
        }


        public IQueryable<TodoListWebApplication.Todo> GridViewTodos_GetData()
        {
            if (this.GridViewCategories.SelectedDataKey == null)
            {
                return null;
            }

            int categoryId = (int)this.GridViewCategories.SelectedDataKey.Value;

            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();
            var category = context.Categories.Find(categoryId);

            return category.Todos.AsQueryable();
        }

        protected void LinkButtonAddTodo_Click(object sender, EventArgs e)
        {
            var table = (sender as LinkButton).Parent;

            int categoryId = Convert.ToInt32(this.GridViewCategories.SelectedDataKey.Value);
            string todoName = (table.FindControl("TextBoxNewTodoName") as TextBox).Text;
            string todoText = (table.FindControl("TextBoxNewTodoText") as TextBox).Text;

            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();
            var category = context.Categories.Find(categoryId);
            Todo newTodo = new Todo()
            {
                Title = todoName,
                Text = todoText,
                LastModification = DateTime.Now
            };
            category.Todos.Add(newTodo);
            context.SaveChanges();

            (table.FindControl("TextBoxNewTodoName") as TextBox).Text = string.Empty;
            (table.FindControl("TextBoxNewTodoText") as TextBox).Text = string.Empty;

            this.GridViewTodos.SelectMethod = "GridViewTodos_GetData";
            this.GridViewTodos.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTodos_UpdateItem(int id)
        {
        }

        protected void GridViewTodos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int todoId = Convert.ToInt32(e.Keys["TodoId"]);
            var grid = (sender as GridView);
            string todoName = (grid.Rows[e.RowIndex].FindControl("TextBoxTodoName") as TextBox).Text;
            string todoText = (grid.Rows[e.RowIndex].FindControl("TextBoxTodoText") as TextBox).Text;

            TodoListWebApplicationEntities context = new TodoListWebApplicationEntities();
            var todo = context.Todos.Find(todoId);
            todo.Text = todoText;
            todo.Title = todoName;
            todo.LastModification = DateTime.Now;
            context.SaveChanges();
        }
    }
}