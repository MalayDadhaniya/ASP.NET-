using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class MenuController : Controller
    {
        // Use SQL Server Authentication (Replace with your credentials)
        private readonly string connectionString = "Server=127.0.0.1,1433;Database=Menu;User Id=your_username;Password=your_password;";

        // GET: Menu
        public ActionResult Index()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            string query = "SELECT Id, Name, Description, Price, ImageUrl FROM menuitems";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                menuItems.Add(new MenuItem
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    Price = reader.GetDecimal(3), // Corrected from GetString
                                    ImageUrl = reader.GetString(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error fetching menu items: " + ex.Message);
            }

            return View(menuItems);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                string query = "INSERT INTO menuitems (Name, Description, Price, ImageUrl) VALUES (@Name, @Description, @Price, @ImageUrl)";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Name", menuItem.Name);
                            cmd.Parameters.AddWithValue("@Description", menuItem.Description);
                            cmd.Parameters.AddWithValue("@Price", menuItem.Price);
                            cmd.Parameters.AddWithValue("@ImageUrl", menuItem.ImageUrl);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error adding menu item: " + ex.Message);
                }
            }

            return View(menuItem);
        }

        // GET: Menu/Edit
        public ActionResult Edit(int id)
        {
            MenuItem item = null;
            string query = "SELECT Id, Name, Description, Price, ImageUrl FROM menuitems WHERE Id = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                item = new MenuItem
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    Price = reader.GetDecimal(3), // Corrected from GetString
                                    ImageUrl = reader.GetString(4)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error fetching menu item: " + ex.Message);
            }

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Menu/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                string query = "UPDATE menuitems SET Name = @Name, Description = @Description, Price = @Price, ImageUrl = @ImageUrl WHERE Id = @Id";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", menuItem.Id);
                            cmd.Parameters.AddWithValue("@Name", menuItem.Name);
                            cmd.Parameters.AddWithValue("@Description", menuItem.Description);
                            cmd.Parameters.AddWithValue("@Price", menuItem.Price);
                            cmd.Parameters.AddWithValue("@ImageUrl", menuItem.ImageUrl);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error updating menu item: " + ex.Message);
                }
            }

            return View(menuItem);
        }

        // GET: Menu/Delete
        public ActionResult Delete(int id)
        {
            MenuItem item = null;
            string query = "SELECT Id, Name, Description, Price, ImageUrl FROM menuitems WHERE Id = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                item = new MenuItem
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    Price = reader.GetDecimal(3), // Corrected from GetString
                                    ImageUrl = reader.GetString(4)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error fetching menu item: " + ex.Message);
            }

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Menu/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string query = "DELETE FROM menuitems WHERE Id = @Id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error deleting menu item: " + ex.Message);
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");
        }
    }
}
