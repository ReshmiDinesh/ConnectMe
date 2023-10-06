using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ConnectMe.UserMicroService.Data.DataAccess
{
    public class UserProfileDataAccess : DataAccessBase, IUserProfileDataEF
    {

        public UserProfileDataAccess(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Model.UserProfile?> AddUserProfileAsync(Model.UserProfile profile)
        {
            DataTable tblUserProfile = UserProfileDataTable.CreateTable();
          
                DataRow dr = tblUserProfile.NewRow();
                dr["User_Name"] = profile.UserName;
                dr["First_Name"] = profile.FirstName;
                dr["Middle_Name"] = profile.MiddleName;
                dr["Last_Name"] = profile.LastName;
                dr["date_of_birth"] = profile.DateOfBirth;
                dr["email"] = profile.Email;
                dr["Gender"] = profile.Gender;
                dr["IsActive"] = profile.IsActive;
                dr["status_Id"] = 1;
                tblUserProfile.Rows.Add(dr);    
          

            //pList.TypeName = “dbo.SalesPersonTerritory”;
            //pList.Value = SalesPersonTerritoryTable();

            using (var connection = await OpenConnectionAsync().ConfigureAwait(false)) 
            {
             
                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@tvpUserProfile", SqlDbType.Structured)
                { 
                    TypeName = "users.UserProfileType",
                          Value = tblUserProfile,
                };

                SqlParameter sqlParameterOutPut = new SqlParameter("@Message", SqlDbType.NVarChar,50);
                sqlParameterOutPut.Direction = ParameterDirection.Output;

                string returnvalue=  await ExecuteNonQueryAsync(connection, CommandType.StoredProcedure, "users.AddUserProfile", parameters, sqlParameterOutPut);
                
            }

            return profile;

        }

        public async Task<bool> DeleteUserProfileAsync(int Id)
        {
           
            string query = "Delete from  [users].[UserProfile] where UserProfile_Id = " + Id.ToString();

            using (var connection = await this.OpenConnectionAsync().ConfigureAwait(false))
            {
                await this.ExecuteNonQueryAsync(connection, System.Data.CommandType.Text, query);

            }

            return true;
        }

        public  async Task<IEnumerable<Model.UserProfile>?> GetAllUserProfileAsync()
        {
            var userProfiles = new List<Model.UserProfile>();
            string query = "select * from  [users].[UserProfile]";

            using(var connection = await this.OpenConnectionAsync().ConfigureAwait(false))
            {
                using (var dataReader = await this.ExecuteReaderAsync(connection,System.Data.CommandType.Text, query))
                {
                    if (dataReader != null && dataReader.HasRows)
                    {
                        while (await dataReader.ReadAsync().ConfigureAwait(false))
                        {
                            userProfiles.Add(
                                new Model.UserProfile
                                { 
                                    //UserProfile_Id UserType_Id User_Name    First_Name   Middle_Name  Last_Name   date_of_birth email     Gender    IsActive status_Id
                                    UserName = (string)dataReader["User_Name"],
                                    FirstName = (string)dataReader["User_Name"],
                                    MiddleName = (string)dataReader["User_Name"],
                                    LastName = (string)dataReader["User_Name"],
                                    DateOfBirth = (DateTime)dataReader["date_of_birth"],
                                    Email = dataReader["email"].ToString(),
                                    Gender = dataReader["Gender"].ToString(),
                                    IsActive = (bool) dataReader["IsActive"],
                                    StatusId = (int)dataReader["status_Id"],
                              
                                });
                        }
                    }
                }
            }

            return userProfiles;
        }

        public async Task<Model.UserProfile?> GetUserProfileAsync(int Id)
        {
            var userProfiles = new Model.UserProfile();
            string query = "select * from  [users].[UserProfile] where UserProfile_Id = " + Id.ToString();

            using (var connection = await this.OpenConnectionAsync().ConfigureAwait(false))
            {
                using (var dataReader = await this.ExecuteReaderAsync(connection, System.Data.CommandType.Text, query).ConfigureAwait(false))
                {
                    if (dataReader.HasRows) 
                    {
                        while (await dataReader.ReadAsync().ConfigureAwait(false))
                        {
                            userProfiles.UserName = (string)dataReader["User_Name"];
                            userProfiles.FirstName = (string)dataReader["User_Name"];
                            userProfiles.MiddleName = (string)dataReader["User_Name"];
                            userProfiles.LastName = (string)dataReader["User_Name"];
                            userProfiles.DateOfBirth = (DateTime)dataReader["date_of_birth"];
                            userProfiles.Email = (string)dataReader["email"];
                            userProfiles.Gender = (string)dataReader["Gender"];
                            userProfiles.IsActive = (bool)dataReader["IsActive"];
                            userProfiles.StatusId = (int)dataReader["status_Id"];
                        }

                    }
                }
             
            }

            return userProfiles;
        }

        public async Task<Model.UserProfile?> UpdateUserProfileAsync(int Id, Model.UserProfile profile)
        {
            DataTable tblUserProfile = UserProfileDataTable.CreateTable();

            DataRow dr = tblUserProfile.NewRow();
            dr["User_Name"] = profile.UserName;
            dr["First_Name"] = profile.FirstName;
            dr["Middle_Name"] = profile.MiddleName;
            dr["Last_Name"] = profile.LastName;
            dr["date_of_birth"] = profile.DateOfBirth;
            dr["email"] = profile.Email;
            dr["Gender"] = profile.Gender;
            dr["IsActive"] = profile.IsActive;
            dr["status_Id"] = 1;
            tblUserProfile.Rows.Add(dr);

            using (var connection = await OpenConnectionAsync().ConfigureAwait(false))
            {

                SqlParameter[] parameters = new SqlParameter[1];

                parameters[0] = new SqlParameter("@tvpUserProfile", SqlDbType.Structured)
                {
                    TypeName = "users.UserProfileType",
                    Value = tblUserProfile,
                };

                parameters[1] = new SqlParameter("@User_Id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = Id
                };


                SqlParameter sqlParameterOutPut = new SqlParameter("@Message", SqlDbType.NVarChar, 50);
                sqlParameterOutPut.Direction = ParameterDirection.Output;

                string returnvalue = await ExecuteNonQueryAsync(connection, CommandType.StoredProcedure, "users.AddUserProfile", parameters, sqlParameterOutPut);

            }

            return profile;

        }
    }
}
