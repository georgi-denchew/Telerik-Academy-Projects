<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoListWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-unit">
        <h1>ASP.NET</h1>
    </div>
    <div class="row">
        <div class="span 6">
            <asp:GridView
                ID="GridViewCategories"
                runat="server"
                AutoGenerateColumns="false"
                DataKeyNames="CategoryId"
                PageSize="3"
                AllowPaging="true"
                AllowSorting="true"
                ItemType="TodoListWebApplication.Category"
                SelectMethod="GridViewCategories_GetData"
                OnRowUpdating="GridViewCategories_RowUpdating"
                UpdateMethod="GridViewCategories_UpdateItem"
                DeleteMethod="GridViewCategories_DeleteItem"
                OnSelectedIndexChanged="GridViewCategories_SelectedIndexChanged"
                ShowFooter="true"
                CssClass="table table-hover table-bordered">
                <EmptyDataTemplate>
                    <table class="table table-hover table-bordered" border="1">
                        <tr>
                            <th>Name</th>
                            <th>Insert</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBoxNewCategoryName" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td>
                                <asp:LinkButton ID="LinkButtonAddCategory" runat="server" OnClick="LinkButtonAddCategory_Click" CausesValidation="false" CommandName="Insert">Add Category</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>
                    <asp:CommandField ShowSelectButton="true" HeaderText="Show Todos" />
                    <asp:TemplateField HeaderText="Category Name" SortExpression="Title">
                        <ItemTemplate>
                            <asp:Literal ID="LiteralCategoryName" Text="<%#: Item.Title %>" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxCategoryName" Width="80%" Text="<%# Item.Title %>" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxNewCategoryName" Width="80%" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Operations">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDeleteCategory" runat="server" CommandName="Delete" CausesValidation="false" CommandArgument="<%# Item.CategoryId %>" Text="Delete"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonEditCategory" runat="server" CommandName="Edit" CausesValidation="false" Text="Edit">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButtonUpdateCategory" runat="server" CommandName="Update" CausesValidation="false" Text="Update"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonCancelCategory" runat="server" CommandName="Cancel" CausesValidation="false" Text="Cancel">
                            </asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButtonAddCategory" OnClick="LinkButtonAddCategory_Click" Text="Add Category" CommandName="Insert" CausesValidation="false" runat="server"></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="offset1 span 6">
            <asp:GridView
                ID="GridViewTodos"
                CssClass="table table-hover table-bordered"
                AllowPaging="true"
                PageSize="3"
                DataKeyNames="TodoId"
                AllowSorting="true"
                AutoGenerateColumns="false"
                ItemType="TodoListWebApplication.Todo"
                DeleteMethod="GridViewTodos_DeleteItem"
                UpdateMethod="GridViewTodos_UpdateItem"
                OnRowUpdating="GridViewTodos_RowUpdating"
                SelectMethod="GridViewTodos_GetData"
                ShowFooter="true"
                runat="server">
                <EmptyDataTemplate>
                    <table class="table table-hover table-bordered" border="1">
                        <tr>
                            <th>Add Todo</th>
                            <th>Title</th>
                            <th>Text</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LinkButtonAddTodo" runat="server" OnClick="LinkButtonAddTodo_Click" CausesValidation="false" CommandName="Insert">Add Todo</asp:LinkButton>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxNewTodoName" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxNewTodoText" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Todo Name" SortExpression="Title">
                        <ItemTemplate>
                            <asp:Literal ID="LiteralTodoName" Text='<%#: Item.Title %>' runat="server"></asp:Literal>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxTodoName" Width="80%" Text="<%# Item.Title %>" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxNewTodoName" Width="80%" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Todo Text" SortExpression="Text">
                        <ItemTemplate>
                            <asp:Literal ID="LiteralTodoText" Text="<%#: Item.Text %>" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBoxTodoText" Width="80%" Text="<%# Item.Text %>" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBoxNewTodoText" Width="80%" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Last Modification" SortExpression="LastModification">
                        <ItemTemplate>
                            <asp:Literal ID="LiteralTodoModificationDate" Text="<%#: Item.LastModification %>" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Operations">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDeleteTodo" runat="server" CommandName="Delete" CausesValidation="false" CommandArgument="<%# Item.TodoId %>" Text="Delete"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonEditTodo" runat="server" CommandName="Edit" CausesValidation="false" Text="Edit">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButtonUpdateTodo" runat="server" CommandName="Update" CausesValidation="false" Text="Update"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonCancelTodo" runat="server" CommandName="Cancel" CausesValidation="false" Text="Cancel">
                            </asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButtonAddTodo" OnClick="LinkButtonAddTodo_Click" Text="Add Todo" CommandName="Insert" CausesValidation="false" runat="server"></asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>

</asp:Content>
