using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using SurveyWebApplication.Models;
using System.Data;
using System.Data.SqlClient;
using SurveyWebApplication.ModelViewInfo;


namespace SurveyWebApplication.DAL
{
    public class DatabaseConnection
    {
        string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();


        public List<QuestionSet> GetAllQuestionSet()
        {

            List<QuestionSet> questionSet = new List<QuestionSet>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT SetId, SetName, CreateBy,UpdateBy,CreateDate,UpdateDate,Status FROM QuestionSet";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questionSet.Add(new QuestionSet
                        {
                            SetId = Convert.ToInt32(reader["SetId"]),
                            SetName = reader["SetName"].ToString(),
                            CreateBy = reader["CreateBy"].ToString(),
                            UpdateBy = reader["UpdateBy"].ToString(),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString()),
                            UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString()),
                            Status = reader["Status"].ToString(),

                        });
                    }
                }
                return questionSet;
            }

        }

        public List<Organization> GetOrganizationList(string fromDate,string  toDate)
        {
            List<Organization> list = new List<Organization>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                 string query="";
                if (fromDate == "" || toDate == "")
                {
                    query = "SELECT OrgId, Name, Address, ContactNo, CreateBy, CreateDate FROM Organization";
                }
                else
                {
                    DateTime fo = Convert.ToDateTime(fromDate);
                    var fordate = fo.ToString("MM-dd-yyyy");

                    DateTime to = Convert.ToDateTime(toDate);
                    var todate = to.ToString("MM-dd-yyyy");

                    query = "SELECT OrgId, Name, Address, ContactNo, CreateBy, CreateDate FROM Organization where CAST(CreateDate  AS DATE) between '" + @fordate + "' and '" + @todate+"'";
                }
                
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Organization
                        {
                            OrgId = Convert.ToInt32(reader["OrgId"]),
                            Name = reader["Name"].ToString(),
                            CreateBy = reader["CreateBy"].ToString(),
                            Address = reader["Address"].ToString(),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString()),                           
                            ContactNo = reader["ContactNo"].ToString(),

                        });
                    }
                }
                return list;
            }
        }



        public List<Organization> GetOrganizationList01()
        {
            List<Organization> list = new List<Organization>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
               
                  string  query = "SELECT OrgId, Name, Address, ContactNo, CreateBy, CreateDate FROM Organization";
                

                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Organization
                        {
                            OrgId = Convert.ToInt32(reader["OrgId"]),
                            Name = reader["Name"].ToString(),
                            CreateBy = reader["CreateBy"].ToString(),
                            Address = reader["Address"].ToString(),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString()),
                            ContactNo = reader["ContactNo"].ToString(),

                        });
                    }
                }
                return list;
            }
        }




        public List<OptionType> GetAllOptionType()
        {

            List<OptionType> AllOptionType = new List<OptionType>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT OptionTypeId, OptionTypeName, CreateBy,UpdateBy,CreateDate,UpdateDate,Status FROM OptionType ";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AllOptionType.Add(new OptionType
                        {
                            OptionTypeId = Convert.ToInt32(reader["OptionTypeId"]),
                            OptionTypeName = reader["OptionTypeName"].ToString(),
                            CreateBy = reader["CreateBy"].ToString(),
                            UpdateBy = reader["UpdateBy"].ToString(),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString()),
                            UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString()),
                            Status = reader["Status"].ToString(),
                        });
                    }
                }
                return AllOptionType;
            }

        }



        public string QuestionSetCreate(string setName, string createby, string updateby, DateTime CreateDate, DateTime UpdateDate, string Status, string OrgId)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO QuestionSet (SetName, CreateBy,UpdateBy,CreateDate, UpdateDate,Status,OrgId) VALUES (@setName, @createby, @updateby, @CreateDate, @UpdateDate, @Status,@OrgId)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@SetName", setName);
                    command.Parameters.AddWithValue("@CreateBy", createby);
                    command.Parameters.AddWithValue("@UpdateBy", updateby);
                    command.Parameters.AddWithValue("@CreateDate", CreateDate);
                    command.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@OrgId", OrgId);


                    var rowcount = command.ExecuteNonQuery();
                    if (rowcount > 0)
                    {
                        return "Data inserted successfully!";

                    }
                    else
                    {
                        return "Data inserted Failed!";

                    }

                }


            }

        }





        public List<QuestionManage> GetAllQuestion()
        {

            List<QuestionManage> allQuestion = new List<QuestionManage>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();


                string query = "SELECT QuestionId, QuestionTitle FROM Question";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QuestionManage ques = new QuestionManage
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),



                        };

                        allQuestion.Add(ques);
                    }
                }
                return allQuestion;
            }

        }




        public string CreateQuestion(string QuestionTitle, string createby, string updateby, DateTime CreateDate, DateTime UpdateDate, string Status)
        {

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO Question (QuestionTitle,  CreateBy, UpdateBy, CreateDate, UpdateDate, Status) VALUES (@QuestionTitle,  @createby, @updateby, @CreateDate, @UpdateDate, @Status)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@QuestionTitle", QuestionTitle);

                    command.Parameters.AddWithValue("@CreateBy", createby);
                    command.Parameters.AddWithValue("@UpdateBy", updateby);
                    command.Parameters.AddWithValue("@CreateDate", CreateDate);
                    command.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                    command.Parameters.AddWithValue("@Status", Status);

                    var rowcount = command.ExecuteNonQuery();
                    if (rowcount > 0)
                    {
                        return "Data inserted successfully!";

                    }
                    else
                    {
                        return "Data inserted Failed!";

                    }

                }


            }

        }



        public List<Question> GetAllQuestionList()
        {
            List<Question> AllQuestionList = new List<Question>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT QuestionId,QuestionTitle  FROM Question where QuestionId in (select QuestionId from SetManage) ";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AllQuestionList.Add(new Question
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),

                        });
                    }
                }
                return AllQuestionList;
            }

        }

        public List<QuestionViewModel> GetAllQuestionView()
        {
            List<QuestionViewModel> AllQuestionList = new List<QuestionViewModel>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "select QuestionId,QuestionTitle from Question where QuestionId  not in (select QuestionId from SetManage)";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AllQuestionList.Add(new QuestionViewModel
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),

                        });
                    }
                }
                return AllQuestionList;
            }
        }


        public string QuestionOptionCreate(string QuestionId, string OptionTypeId, string OptionName, string IsActive, string IsCorrect, string createby, string updateby, DateTime CreateDate, DateTime UpdateDate, string Status)
        {

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO Options (OptionName, IsActive, IsCorrect,QuestionId,OptionTypeId, CreateBy, UpdateBy, CreateDate, UpdateDate, Status) VALUES (@OptionName, @IsActive, @IsCorrect,@QuestionId,@OptionTypeId, @createby, @updateby, @CreateDate, @UpdateDate, @Status)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@OptionName", OptionName);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IsCorrect", IsCorrect);
                    command.Parameters.AddWithValue("@QuestionId", QuestionId);
                    command.Parameters.AddWithValue("@OptionTypeId", OptionTypeId);
                    command.Parameters.AddWithValue("@CreateBy", createby);
                    command.Parameters.AddWithValue("@UpdateBy", updateby);
                    command.Parameters.AddWithValue("@CreateDate", CreateDate);
                    command.Parameters.AddWithValue("@UpdateDate", UpdateDate);
                    command.Parameters.AddWithValue("@Status", Status);

                    var rowcount = command.ExecuteNonQuery();
                    if (rowcount > 0)
                    {
                        return "Data inserted successfully!";

                    }
                    else
                    {
                        return "Data inserted Failed!";

                    }

                }


            }
        }



        public List<SetManage> GetAllSetManage()
        {
            List<SetManage> AllSetList = new List<SetManage>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT a.SetManageId, a.QuestionId,b.QuestionTitle, a.SetId, c.SetName FROM SetManage a left join Question b on a.QuestionId=b.QuestionId left join QuestionSet c on a.SetId=c.SetId ";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AllSetList.Add(new SetManage
                        {
                            SetManageId = Convert.ToInt32(reader["SetManageId"]),
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),
                            SetId = Convert.ToInt32(reader["SetId"]),
                            SetName = reader["SetName"].ToString(),


                        });
                    }
                }
                return AllSetList;
            }
        }


        public string SetManageAdd(string SetId, string QuestionId)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO SetManage (SetId, QuestionId) VALUES (@SetId,  @QuestionId)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@SetId", SetId);
                    command.Parameters.AddWithValue("@QuestionId", QuestionId);

                    var rowcount = command.ExecuteNonQuery();
                    if (rowcount > 0)
                    {
                        return "Data inserted successfully!";

                    }
                    else
                    {
                        return "Data inserted Failed!";

                    }

                }


            }
        }

        public bool SetRemove(string SetId, string QuestionId)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "DELETE from SetManage where SetId=@SetId and QuestionId=@QuestionId ";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@SetId", SetId);
                    command.Parameters.AddWithValue("@QuestionId", QuestionId);

                    var rowcount = command.ExecuteNonQuery();
                    if (rowcount > 0)
                    {
                        return true;

                    }
                    else
                    {
                        return false;

                    }

                }


            }
        }

        public List<SurveyViewInfo> GetAllSurveyList(string SetId)
        {
            List<SurveyViewInfo> getQqestionSet = new List<SurveyViewInfo>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "select b.QuestionId,b.QuestionTitle,a.OptionId,a.OptionName,a.IsCorrect,a.OptionTypeId, c.OptionTypeName,d.SetId from Options a left join Question b on a.QuestionId=b.QuestionId left join OptionType c on a.OptionTypeId=c.OptionTypeId left join SetManage d on b.QuestionId=d.QuestionId where d.SetId=" + @SetId;
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        getQqestionSet.Add(new SurveyViewInfo
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),
                            OptionId = Convert.ToInt32(reader["OptionId"]),
                            OptionName = reader["OptionName"].ToString(),
                            OptionTypeId = Convert.ToInt32(reader["OptionTypeId"]),
                            OptionTypeName = reader["OptionTypeName"].ToString(),
                            IsCorrect = Convert.ToBoolean(reader["IsCorrect"]),
                            SetId = Convert.ToInt32(reader["SetId"])
                        });
                    }
                }
                return getQqestionSet;
            }
        }


        public string AnswerSubmit(string CustomerId, string QuestionId, string OptionId, string OptionName, string QuestionTypeId, string CreateBy, DateTime CreateDate)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO QuestionAnswer (CustomerId, QuestionId,OptionId,OptionName,QuestionTypeId,CreateBy,CreateDate) VALUES (@CustomerId, @QuestionId,@OptionId,@OptionName,@QuestionTypeId,@CreateBy,@CreateDate)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@QuestionId", QuestionId);
                    command.Parameters.AddWithValue("@OptionId", OptionId);
                    command.Parameters.AddWithValue("@OptionName", OptionName);
                    command.Parameters.AddWithValue("@QuestionTypeId", QuestionTypeId);
                    command.Parameters.AddWithValue("@CreateBy", CreateBy);
                    command.Parameters.AddWithValue("@CreateDate", CreateDate);


                    var rowcount = command.ExecuteNonQuery();
                    if (rowcount > 0)
                    {
                        return "Data inserted successfully!";

                    }
                    else
                    {
                        return "Data inserted Failed!";

                    }

                }


            }
        }


        public List<SurveyViewInfo> GetAllSurveyList01()
        {
            List<SurveyViewInfo> getQqestionSet = new List<SurveyViewInfo>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "select b.QuestionId,b.QuestionTitle,a.OptionId,a.OptionName,a.IsCorrect,a.OptionTypeId, c.OptionTypeName,d.SetId ,(select count(OptionId) from QuestionAnswer where OptionId=a.OptionId) AnsCount from Options a left join Question b on a.QuestionId=b.QuestionId left join OptionType c on a.OptionTypeId=c.OptionTypeId left join SetManage d on b.QuestionId=d.QuestionId";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        getQqestionSet.Add(new SurveyViewInfo
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),
                            OptionId = Convert.ToInt32(reader["OptionId"]),
                            OptionName = reader["OptionName"].ToString(),
                            OptionTypeId = Convert.ToInt32(reader["OptionTypeId"]),
                            OptionTypeName = reader["OptionTypeName"].ToString(),
                            IsCorrect = Convert.ToBoolean(reader["IsCorrect"]),
                            SetId = Convert.ToInt32(reader["SetId"]),
                            AnsCount = reader["AnsCount"].ToString(),
                        });
                    }
                }
                return getQqestionSet;
            }
        }





        public List<CustomerInformation> GetCustomer(int id)
        {

            List<CustomerInformation> AllCustomer = new List<CustomerInformation>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "select a.CustomerId, a.OptionId,b.CustomerName from QuestionAnswer a left join CustomerInformation b on a.CustomerId=b.CustomerId where a.OptionId= " + @id;
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AllCustomer.Add(new CustomerInformation
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),

                            CustomerName = reader["CustomerName"].ToString(),

                        });
                    }
                }
                return AllCustomer;
            }
        }

        public string OrganizationInsert(string Name, string Address, string ContactNo, string CreateBy, DateTime CreateDate)
        {

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO Organization (Name, Address, ContactNo, CreateBy, CreateDate) VALUES (@Name, @Address, @ContactNo, @CreateBy, @CreateDate)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@ContactNo", ContactNo);
                    command.Parameters.AddWithValue("@CreateBy", CreateBy);
                    command.Parameters.AddWithValue("@CreateDate", CreateDate);
                    var rowcount = command.ExecuteNonQuery();
                    if (rowcount > 0)
                    {
                        return "Data inserted successfully!";

                    }
                    else
                    {
                        return "Data inserted Failed!";

                    }

                }
            }

        }

    }
}
