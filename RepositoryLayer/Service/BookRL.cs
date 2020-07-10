using CommonLayer.Model;
using CommonLayer.ShowModel;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class BookRL : IBookRL
    {
        /// <summary>
        /// create field for configuration 
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initialzes the memory and inject the configuration interface
        /// </summary>
        /// <param name="configuration"></param>
        public BookRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// add book
        /// </summary>
        /// <param name="bookShowModel"></param>
        /// <returns></returns>
        public  BookAddModel AddBook(BookShowModel bookShowModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@Book_Title", bookShowModel.BooKTitle));
                paramList.Add(new StoredProcedureParameterData("@Author", bookShowModel.Author));
                paramList.Add(new StoredProcedureParameterData("@Language", bookShowModel.Language));
                paramList.Add(new StoredProcedureParameterData("@Category", bookShowModel.Category));
                paramList.Add(new StoredProcedureParameterData("@ISBN_No", bookShowModel.ISBN));
                paramList.Add(new StoredProcedureParameterData("@Price", bookShowModel.Price));
                paramList.Add(new StoredProcedureParameterData("@Pages", bookShowModel.Pages));
                paramList.Add(new StoredProcedureParameterData("@CreatedDate", DateTime.Now));
                paramList.Add(new StoredProcedureParameterData("@ModifiedDate", DateTime.Now));
                DataTable table = databaseConnection.StoredProcedureExecuteReader("AddBook", paramList);
                var bookData = new BookAddModel();

                foreach (DataRow dataRow in table.Rows)
                {
                    bookData = new BookAddModel();
                    bookData.Id = (int)dataRow["Id"];
                    bookData.BooKTitle = dataRow["Book_Title"].ToString();
                    bookData.Author = dataRow["Author"].ToString();
                    bookData.Language = dataRow["Language"].ToString();
                    bookData.Category = dataRow["Category"].ToString();
                    bookData.ISBN = Convert.ToInt32(dataRow["ISBN_No"]);
                    bookData.Price = Convert.ToInt32(dataRow["Price"]);
                    bookData.Pages = Convert.ToInt32(dataRow["Pages"]);
                    bookData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    bookData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                }
                return bookData;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// search books by book title
        /// </summary>
        /// <param name="searchWord"></param>
        /// <returns></returns>
        public  List<BookAddModel> SearchBook(string searchWord)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();
                paramList.Add(new StoredProcedureParameterData("@SearchTitle", searchWord));
              
                DataTable table =  databaseConnection.StoredProcedureExecuteReader("SearchBookByTitle", paramList);
                var bookData = new BookAddModel();
                List<BookAddModel> bookList = new List<BookAddModel>();
                foreach (DataRow dataRow in table.Rows)
                {
                    bookData = new BookAddModel();
                    bookData.Id = (int)dataRow["Id"];
                    bookData.BooKTitle = dataRow["Book_Title"].ToString();
                    bookData.Author = dataRow["Author"].ToString();
                    bookData.Language = dataRow["Language"].ToString();
                    bookData.Category = dataRow["Category"].ToString();
                    bookData.ISBN = Convert.ToInt32(dataRow["ISBN_No"]);
                    bookData.Price = Convert.ToInt32(dataRow["Price"]);
                    bookData.Pages = Convert.ToInt32(dataRow["Pages"]);
                    bookData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    bookData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                    bookList.Add(bookData);
                }
                if (bookList != null)
                {
                    return bookList;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// get all books 
        /// </summary>
        /// <returns></returns>
        public  List<BookAddModel> GetAllBooks()
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                List<StoredProcedureParameterData> paramList = new List<StoredProcedureParameterData>();

                DataTable table =  databaseConnection.StoredProcedureExecuteReader("GetAllBooks", paramList);
                var bookData = new BookAddModel();
                List<BookAddModel> bookList = new List<BookAddModel>();
                foreach (DataRow dataRow in table.Rows)
                {
                    bookData = new BookAddModel();
                    bookData.Id = (int)dataRow["Id"];
                    bookData.BooKTitle = dataRow["Book_Title"].ToString();
                    bookData.Author = dataRow["Author"].ToString();
                    bookData.Language = dataRow["Language"].ToString();
                    bookData.Category = dataRow["Category"].ToString();
                    bookData.ISBN = Convert.ToInt32(dataRow["ISBN_No"]);
                    bookData.Price = Convert.ToInt32(dataRow["Price"]);
                    bookData.Pages = Convert.ToInt32(dataRow["Pages"]);
                    bookData.CreatedDate = Convert.ToDateTime(dataRow["CreatedDate"]);
                    bookData.ModifiedDate = Convert.ToDateTime(dataRow["ModifiedDate"]);
                    bookList.Add(bookData);
                }
                if (bookList != null)
                {
                    return bookList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// update book by book price
        /// </summary>
        /// <param name="updateBookModel"></param>
        /// <returns></returns>
        public BookAddModel UpdateBookPrice(UpdateBookModel updateBookModel)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                SqlConnection sqlConnection = databaseConnection.GetConnection();
                SqlCommand sqlCommand = databaseConnection.GetCommand("UpdateBookPrice", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@BookId", updateBookModel.BookId);
                sqlCommand.Parameters.AddWithValue("@Price", updateBookModel.Price);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                BookAddModel bookAddModel = new BookAddModel();
                while (sqlDataReader.Read())
                {
                    bookAddModel = new BookAddModel();
                    bookAddModel.Id = (int)sqlDataReader["Id"];
                    bookAddModel.BooKTitle = sqlDataReader["Book_Title"].ToString();
                    bookAddModel.Author = sqlDataReader["Author"].ToString();
                    bookAddModel.Language = sqlDataReader["Language"].ToString();
                    bookAddModel.Category = sqlDataReader["Category"].ToString();
                    bookAddModel.ISBN = (int)sqlDataReader["ISBN_No"];
                    bookAddModel.Price = (int)sqlDataReader["Price"];
                    bookAddModel.Pages = (int)sqlDataReader["Pages"];
                    bookAddModel.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                    bookAddModel.ModifiedDate = DateTime.Now;
                    if (bookAddModel.Id == updateBookModel.BookId)
                    {
                        return bookAddModel;
                    }
                }
                sqlConnection.Close();
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// delete book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool DeleteBook(int bookId)
        {
            try
            {
                DatabaseConnection databaseConnection = new DatabaseConnection(this.configuration);
                SqlConnection sqlConnection = databaseConnection.GetConnection();
                SqlCommand sqlCommand = databaseConnection.GetCommand("DeleteBook", sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@BookId", bookId);
                var response = sqlCommand.ExecuteReader();
                sqlConnection.Close();
                if (response.Equals(0))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
