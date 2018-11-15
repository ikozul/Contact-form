using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace ContactForm.Models
{
    public class Repo
    {


        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;


        public static List<MailModel> GetAllSubjects()
        {
            List<MailModel> collection = new List<MailModel>();

            ds = SqlHelper.ExecuteDataset(cs, "GetAllContacts");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(new MailModel
                {
                    IDForm = (int)row["IDForm"],
                    Name = row["FirstName"].ToString(),
                    Surname = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Question = row["FormQuestion"].ToString(),
                    Answer = row["FormAnswer"].ToString()
                });
            }
            return collection;
        }

        public static MailModel GetSubjectById(int IDForm)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetContact", IDForm);
            DataRow row = ds.Tables[0].Rows[0];

            MailModel mm = new MailModel
            {
                IDForm = (int)row["IDForm"],
                Name = row["FirstName"].ToString(),
                Surname = row["LastName"].ToString(),
                Email = row["Email"].ToString(),
                Question = row["FormQuestion"].ToString(),
                Answer = row["FormAnswer"].ToString()
            };

            return mm;
        }

        public static void InsertSubject(MailModel mm)
        {
            //SqlHelper.ExecuteNonQuery(cs, "insertContactForm", mm.Name, mm.Surname, mm.Email, mm.Question);

            //Nisam siguran zasto ne radi sqlhelper na ovoj proceduri

            SqlConnection sc1 = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "insert into Contact(FirstName,LastName,Email,FormQuestion,FormAnswer) values('" + mm.Name + "','" + mm.Surname + "','" + mm.Email + "','" + mm.Question + "','')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sc1;

            sc1.Open();

            reader = cmd.ExecuteReader();


            sc1.Close();
        }


        public static void EditSubject(MailModel mm)
        {
            SqlHelper.ExecuteNonQuery(cs, "updateContactForm", mm.IDForm, mm.Name, mm.Surname, mm.Email, mm.Question, mm.Answer);

            /*SqlConnection sc1 = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = $"UPDATE Contact SET FirstName = {mm.Name}, LastName = {mm.Surname}, Email = {mm.Email}, FormQuestion = {mm.Question}, FormAnswer = {mm.Answer} WHERE IDForm = {mm.IDForm})";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sc1;

            sc1.Open();

            reader = cmd.ExecuteReader();

            sc1.Close();*/


        }

    }
}

