using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptIT_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTableCollection tableCollection;
            AdaptITAcademyDataContext dbContext = new AdaptITAcademyDataContext();
            string action;


            Console.WriteLine("Enter 1 if you want to update database: ");
            action = Console.ReadLine();

            if (action == "1")
            {
            
            
            FileInfo existingFile = new FileInfo(@"C:\Users\Vunene.Maluleke\Desktop\LAB3 ADAPTIT\.vs\Training.xlsx");
            //use EPPlus

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(existingFile.FullName, FileMode.Open, FileAccess.Read))

            {

                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });

                    tableCollection = result.Tables;

                    foreach (System.Data.DataColumn table in tableCollection[0].Columns)
                    {

                        Console.WriteLine(table);

                    }


                }

            }

            DataTable dt = tableCollection[0];

            if (dt != null)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                   
                    }
                }
            }

            Console.WriteLine("************************************************************************************************************************ ");
            Console.WriteLine("Enter 2 if you want to list database: ");
            action = Console.ReadLine();
            if (action == "2")
            {

                var dlName = from dlt in dbContext.Courses
                             select dlt.CourseName;

                foreach (string n in dlName)
                {
                    Console.WriteLine("{0}", n);
                }
            }


            Console.WriteLine("Enter 3 to register a delegate:");
            action = Console.ReadLine();
            if (action == "3")
            {
                String connString = @"Data Source=JHBHO-MICSUPP00\SQLEXPRESS01;Initial Catalog=AdaptIT Academy;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connString))
                        {
                            con.Open();
                            try
                            {
                                Console.WriteLine("Connection Successful...");
                                Console.WriteLine("Enter your name:");
                                String firstName = Console.ReadLine();
                                Console.WriteLine("Enter your surname:");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("Enter your phone Number:");
                                string phoneNumber = Console.ReadLine();
                                Console.WriteLine("Enter your Email:");
                                string email = Console.ReadLine();
                                Console.WriteLine("Enter your Company Name:");
                                string companyName = Console.ReadLine();
                                Console.WriteLine("Enter Dietary Requirement of your choice:");
                                string dietaryRequirement = Console.ReadLine();
                                String insertQuery = "INSERT INTO Delegate (FirstName, LastName, PhoneNumber, Email, CompanyName, DietaryRequirement) " +
                                    "VALUES('" + firstName + "','" + lastName + "','" + phoneNumber + "','" + email + "','" + companyName + "','" + dietaryRequirement + "')";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                                insertCommand.ExecuteNonQuery();
                                Console.WriteLine("Data stored successfully");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
            Console.WriteLine("Enter 4 to register a Course:");
            action = Console.ReadLine();
            if (action == "4")
            {
                String connString = @"Data Source=JHBHO-MICSUPP00\SQLEXPRESS01;Initial Catalog=AdaptIT Academy;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    try
                    {
                        Console.WriteLine("Connection Successful...");
                        Console.WriteLine("Enter your Course Code:");
                        String CourseCode = Console.ReadLine();
                        Console.WriteLine("Enter your Course Name:");
                        string CourseName = Console.ReadLine();
                        Console.WriteLine("Enter your Course Description:");
                        string CourseDescription = Console.ReadLine();
                        String insertQuery = "INSERT INTO Course (CourseCode, CourseName , CourseDescription) " +
                            "VALUES('" + CourseCode + "','" + CourseName + "','" + CourseDescription + "')";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                        insertCommand.ExecuteNonQuery();
                        Console.WriteLine("Data stored successfully");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.WriteLine("Enter 5 to register a Training:");
            action = Console.ReadLine();
            if (action == "5")
            {
                String connString = @"Data Source=JHBHO-MICSUPP00\SQLEXPRESS01;Initial Catalog=AdaptIT Academy;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    try
                    {
                        Console.WriteLine("Connection Successful...");
                        Console.WriteLine("Enter your Training Venue:");
                        String TrainingVenue = Console.ReadLine();
                        Console.WriteLine("Enter your Training Start Date:");
                        string TrainingStartDate = Console.ReadLine();
                        Console.WriteLine("Enter your Training End Date:");
                        string TrainingEndDate = Console.ReadLine();
                        Console.WriteLine("Enter your Number of Seats Left:");
                        string NumberOfSeat = Console.ReadLine();
                        String insertQuery = "INSERT INTO Training (TrainingVenue, TrainingStartDate , TrainingEndDate, NumberOfSeat) " +
                            "VALUES('" + TrainingVenue + "','" + TrainingStartDate  + "','" + TrainingEndDate + "','" + NumberOfSeat  + "')";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                        insertCommand.ExecuteNonQuery();
                        Console.WriteLine("Data stored successfully");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.WriteLine("Enter 6 to register a Delegate Address:");
            action = Console.ReadLine();
            if (action == "6")
            {
                String connString = @"Data Source=JHBHO-MICSUPP00\SQLEXPRESS01;Initial Catalog=AdaptIT Academy;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    try
                    {
                        Console.WriteLine("Connection Successful...");
                        Console.WriteLine("Enter your DelegateID:");
                        String DelegateID = Console.ReadLine();
                        Console.WriteLine("Enter your PhysicalAddress1:");
                        String PhysicalAddress1 = Console.ReadLine();
                        Console.WriteLine("Enter your PhysicalAddress2:");
                        string PhysicalAddress2 = Console.ReadLine();
                        Console.WriteLine("Enter your PhysicalAddressCode:");
                        string PhysicalAddressCode = Console.ReadLine();
                        Console.WriteLine("Enter your PostalAddress1:");
                        String PostalAddress1 = Console.ReadLine();
                        Console.WriteLine("Enter your PostalAddress2:");
                        string PostalAddress2 = Console.ReadLine();
                        Console.WriteLine("Enter your PostalAddressCode:");
                        string PostalAddressCode = Console.ReadLine();
                        String insertQuery = "INSERT INTO DelegateAddress (DelegateID, PhysicalAddress1, PhysicalAddress2 , PhysicalAddressCode, PostalAddress1, PostalAddress2, PostalAddressCode) " +
                            "VALUES('" + DelegateID + "','" + PhysicalAddress1 + "','" + PhysicalAddress2 + "','" + PhysicalAddressCode + "','" +  PostalAddress1 + "','" + PostalAddress2 + "','" +  PostalAddressCode + "')";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                        insertCommand.ExecuteNonQuery();
                        Console.WriteLine("Data stored successfully");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.WriteLine("Enter 7 to register a Course Training:");
            action = Console.ReadLine();
            if (action == "7")
            {
                String connString = @"Data Source=JHBHO-MICSUPP00\SQLEXPRESS01;Initial Catalog=AdaptIT Academy;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    try
                    {
                        Console.WriteLine("Connection Successful...");
                        Console.WriteLine("Enter your DelegateID:");
                        String DelegateID = Console.ReadLine();
                        Console.WriteLine("Enter your TrainingID:");
                        string TrainingID = Console.ReadLine();
                        Console.WriteLine("Enter your Course Code:");
                        String CourseCode = Console.ReadLine();
                        Console.WriteLine("Enter your Course Training Cost:");
                        string CourseTrainingCost = Console.ReadLine();
                        Console.WriteLine("Enter your Registration Closing Date:");
                        string RegistrationClosingDate = Console.ReadLine();
                        String insertQuery = "INSERT INTO CourseTraining (CourseCode, CourseTrainingCost , RegistrationClosingDate, TrainingID, DelegateID ) " +
                            "VALUES ('" + CourseCode + "','" + CourseTrainingCost + "','" + RegistrationClosingDate + "','" + TrainingID + "','" + DelegateID + "')";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                        insertCommand.ExecuteNonQuery();
                        Console.WriteLine("Data stored successfully");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            Console.ReadKey();
            }
        }
    }


