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


        public List<OptionType> GetAllOptionType()
        {

            List<OptionType> allOption = new List<OptionType>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT OptionId, OptionTypeName FROM OptionType";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allOption.Add(new OptionType
                        {
                            OptionId = Convert.ToInt32(reader["OptionId"]),
                            OptionTypeName = reader["OptionTypeName"].ToString()
                        });
                    }
                }
                return allOption;
            }

        }


        public List<Questionnaires> GetAllQuestionTitle()
        {

            List<Questionnaires> getQqestion = new List<Questionnaires>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT QuestionId, QuestionTitle FROM Questionnaires where OptionId!=3";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        getQqestion.Add(new Questionnaires
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString()
                        });
                    }
                }
                return getQqestion;
            }

        }



        public string CreateOptionType(string QuestionTitle, string OptionId)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO Questionnaires (QuestionTitle, OptionId) VALUES (@QuestionTitle, @OptionId)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@QuestionTitle", QuestionTitle);
                    command.Parameters.AddWithValue("@OptionId", OptionId);

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





        public List<Question> GetAllQuestion()
        {

            List<Question> allQuestion = new List<Question>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();


                string query = "SELECT a.QuestionId, a.QuestionTitle,a.OptionId,b.OptionTypeName FROM Questionnaires a left join OptionType b on a.OptionId = b.OptionId";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Question ques = new Question
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            QuestionTitle = reader["QuestionTitle"].ToString(),
                            OptionTypeName = reader["OptionTypeName"].ToString()

                        };

                        allQuestion.Add(ques);
                    }
                }
                return allQuestion;
            }

        }




        public string InsertQuestionSet(string SetName, string TypeofQuestion, string Options, string Options1, string Options2, string Options3, string CreateDate, Boolean InActive)
        {

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();

                string sql = "INSERT INTO QuestionSet (SetName, TypeofQuestion, Options,Options1,Options2,Options3, CreateDate, InActive) VALUES (@SetName, @TypeofQuestion, @Options ,@Options1,@Options2,@Options3, @CreateDate, @InActive)";

                using (SqlCommand command = new SqlCommand(sql, connect))
                {
                    command.Parameters.AddWithValue("@SetName", SetName);
                    command.Parameters.AddWithValue("@TypeofQuestion", TypeofQuestion);
                    command.Parameters.AddWithValue("@Options", Options);
                    command.Parameters.AddWithValue("@Options1", Options1);
                    command.Parameters.AddWithValue("@Options2", Options2);
                    command.Parameters.AddWithValue("@Options3", Options3);
                    command.Parameters.AddWithValue("@CreateDate", CreateDate);
                    command.Parameters.AddWithValue("@InActive", InActive);

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





        public List<QuestionSet> GetQuestionSet()
        {
            List<QuestionSet> getQqestionSet = new List<QuestionSet>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "SELECT SetId, SetName,Options,Options1,Options2,Options3,InActive FROM QuestionSet ";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        getQqestionSet.Add(new QuestionSet
                        {
                            SetId = Convert.ToInt32(reader["SetId"]),
                            SetName = reader["SetName"].ToString(),
                            Options = reader["Options"].ToString(),
                            Options1 = reader["Options1"].ToString(),
                            Options2 = reader["Options2"].ToString(),
                            Options3 = reader["Options3"].ToString(),
                            InActive = Convert.ToBoolean(reader["InActive"])

                        });
                    }
                }
                return getQqestionSet;
            }
        }





        public List<QuestionSetManage> GetQuestionAnswer()
        {
            List<QuestionSetManage> Question = new List<QuestionSetManage>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "select a.QuestionId , a.QuestionTitle,SetName=isnull(c.SetName,''),Options= isnull(c.Options,''), Options1=isnull(c.Options1,''),Options2= isnull(c.Options2,''), Options3=isnull(c.Options3,''), b.OptionTypeName from Questionnaires a left join OptionType b on a.OptionId=b.OptionId left join QuestionSet c on a.QuestionId=c.QuestionId";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Question.Add(new QuestionSetManage
                        {
                            QuestionId = Convert.ToInt32(reader["QuestionId"]),
                            SetName = reader["SetName"].ToString(),
                            QuestionTitle = reader["QuestionTitle"].ToString(),
                            Options = reader["Options"].ToString(),
                            Options1 = reader["Options1"].ToString(),
                            Options2 = reader["Options2"].ToString(),
                            Options3 = reader["Options3"].ToString(),
                            OptionTypeName = reader["OptionTypeName"].ToString()


                        });
                    }
                }
                return Question;
            }
        }





        public List<Option> GetQuestionAnswerss()
        {
            List<Option> Question = new List<Option>();

            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "select a.SetName, a.TypeofQuestion,a.Options,a.Options1, a.Options2, a.Options3,OptionTypeName=isnull(b.OptionTypeName,'') from QuestionSet a left join OptionType b on a.TypeofQuestion=b.OptionId";
                SqlCommand command = new SqlCommand(query, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        List<OptionList> obj = new List<OptionList>();

                        var n = new OptionList();
                        n.Options = reader["Options"].ToString();
                        n.Options1 = reader["Options1"].ToString();
                        n.Options2 = reader["Options2"].ToString();
                        n.Options3 = reader["Options3"].ToString();
                        obj.Add(n);
                        
                        Question.Add(new Option
                        {
                            
                            SetName = reader["SetName"].ToString(),
                           
                            OptionList=obj,
                            
                            OptionTypeName = reader["OptionTypeName"].ToString()


                        });
                    }
                }
                return Question;
            }
        }
    }
}