using System.Data;

namespace ConnectMe.UserMicroService.Data
{
    public static class UserProfileDataTable
    {
       public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserType_Id", typeof(string));
            dt.Columns.Add("User_Name", typeof(string));
            dt.Columns.Add("First_Name", typeof(string));
            dt.Columns.Add("Middle_Name", typeof(string));
            dt.Columns.Add("Last_Name", typeof(string));
            dt.Columns.Add("date_of_birth", typeof(DateTime));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("IsActive", typeof(bool));
            dt.Columns.Add("status_Id", typeof(Int16));
            return dt;
        }
    }
}
