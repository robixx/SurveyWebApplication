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



        public string QuestionSetCreate(string setName, string createby, string updateby, DateTime CreateDate, DateTime UpdateDate, string Status)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO QuestionSet (SetName, CreateBy,UpdateBy,CreateDate, UpdateDate,Status) VALUES (@setName, @createby, @updateby, @CreateDate, @UpdateDate, @Status)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@SetName", setName);
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





        public List<QuestionManage> GetAllQuestion()
        {

            List<QuestionManage> allQuestion = new List<QuestionManage>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();


                string query = "SELECT a.QuestionId, a.QuestionTitle,a.SetId,c.OptionTypeName,c.OptionTypeId,b.SetName FROM Question a left join OptionType c on a.OptionTypeId = c.OptionTypeId left join QuestionSet b on a.SetId=b.SetId";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QuestionManage ques = new QuestionManage
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),
                            SetId = Convert.ToInt32(reader["SetId"]),
                            OptionTypeName = reader["OptionTypeName"].ToString(),
                            OptionTypeId = Convert.ToInt32(reader["OptionTypeId"]),
                            SetName = reader["SetName"].ToString(),

                        };

                        allQuestion.Add(ques);
                    }
                }
                return allQuestion;
            }

        }




        public string CreateQuestion(string QuestionTitle, string SetId, string OptionTypeId, string createby, string updateby, DateTime CreateDate, DateTime UpdateDate, string Status)
        {

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO Question (QuestionTitle, SetId, OptionTypeId, CreateBy, UpdateBy, CreateDate, UpdateDate, Status) VALUES (@QuestionTitle, @SetId, @OptionTypeId, @createby, @updateby, @CreateDate, @UpdateDate, @Status)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@QuestionTitle", QuestionTitle);
                    command.Parameters.AddWithValue("@SetId", SetId);
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



        public List<Question> GetAllQuestionList()
        {
            List<Question> AllQuestionList = new List<Question>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT QuestionId,QuestionTitle  FROM Question ";
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

        public string QuestionCreate(string QuestionId, string OptionTypeId, string OptionName, string IsCorrect, string IsActive, string createby, string updateby, DateTime CreateDate, DateTime UpdateDate, string Status)
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


        //public List<QuestionSet> GetQuestionSet()
        //{
        //    List<QuestionSet> getQqestionSet = new List<QuestionSet>();

        //    using (SqlConnection connect = new SqlConnection(connection))
        //    {
        //        connect.Open();
        //        string query = "SELECT SetId, SetName,Options,Options1,Options2,Options3,InActive FROM QuestionSet ";
        //        SqlCommand command = new SqlCommand(query, connect);

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                getQqestionSet.Add(new QuestionSet
        //                {
        //                    SetId = Convert.ToInt32(reader["SetId"]),
        //                    SetName = reader["SetName"].ToString(),
        //                    Options = reader["Options"].ToString(),
        //                    Options1 = reader["Options1"].ToString(),
        //                    Options2 = reader["Options2"].ToString(),
        //                    Options3 = reader["Options3"].ToString(),
        //                    InActive = Convert.ToBoolean(reader["InActive"])

        //                });
        //            }
        //        }
        //        return getQqestionSet;
        //    }
        //}





        //public List<QuestionSetManage> GetQuestionAnswer()
        //{
        //    List<QuestionSetManage> Question = new List<QuestionSetManage>();

        //    using (SqlConnection connect = new SqlConnection(connection))
        //    {
        //        connect.Open();
        //        string query = "select a.QuestionId , a.QuestionTitle,SetName=isnull(c.SetName,''),Options= isnull(c.Options,''), Options1=isnull(c.Options1,''),Options2= isnull(c.Options2,''), Options3=isnull(c.Options3,''), b.OptionTypeName from Questionnaires a left join OptionType b on a.OptionId=b.OptionId left join QuestionSet c on a.QuestionId=c.QuestionId";
        //        SqlCommand command = new SqlCommand(query, connect);

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Question.Add(new QuestionSetManage
        //                {
        //                    QuestionId = Convert.ToInt32(reader["QuestionId"]),
        //                    SetName = reader["SetName"].ToString(),
        //                    QuestionTitle = reader["QuestionTitle"].ToString(),
        //                    Options = reader["Options"].ToString(),
        //                    Options1 = reader["Options1"].ToString(),
        //                    Options2 = reader["Options2"].ToString(),
        //                    Options3 = reader["Options3"].ToString(),
        //                    OptionTypeName = reader["OptionTypeName"].ToString()


        //                });
        //            }
        //        }
        //        return Question;
        //    }
        //}





        //public List<Option> GetQuestionAnswerss()
        //{
        //    List<Option> Question = new List<Option>();

        //    using (SqlConnection connect = new SqlConnection(connection))
        //    {
        //        connect.Open();
        //        string query = "select a.SetName, a.TypeofQuestion,a.Options,a.Options1, a.Options2, a.Options3,OptionTypeName=isnull(b.OptionTypeName,'') from QuestionSet a left join OptionType b on a.TypeofQuestion=b.OptionId";
        //        SqlCommand command = new SqlCommand(query, connect);

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {

        //                List<OptionList> obj = new List<OptionList>();

        //                var n = new OptionList();
        //                n.Options = reader["Options"].ToString();
        //                n.Options1 = reader["Options1"].ToString();
        //                n.Options2 = reader["Options2"].ToString();
        //                n.Options3 = reader["Options3"].ToString();
        //                obj.Add(n);

        //                Question.Add(new Option
        //                {

        //                    SetName = reader["SetName"].ToString(),

        //                    OptionList = obj,

        //                    OptionTypeName = reader["OptionTypeName"].ToString()


        //                });
        //            }
        //        }
        //        return Question;
        //    }
        //}
    }
}