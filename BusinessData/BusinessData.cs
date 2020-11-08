using KI.RIS.DAL;
using System;


namespace BusinessData
{
    using Models;
    using System.Data;

    public class BusinessData : IBusinessData
    {
        public Object objResult;
        public IDbConnection con = null;
        public IDbDataParameter[] paramData;
        public IDbTransaction transaction;
        public bool IsSuccess = true;
        public DataSet dsResult = new DataSet();


        public object CreateUser(Users users)
        {
            Int64 Result = 0;
            try
            {
                transaction = DALHelper.GetTransaction();
                paramData = DALHelperParameterCache.GetSpParameterSet(transaction, "InsertUsers"); foreach (IDbDataParameter Item in paramData)
                {
                    switch (Item.ParameterName)
                    {
                        case "UserId":
                            Item.Value = users.userId;

                            break;
                        case "UserName":
                            Item.Value = users.userName;

                            break;
                        case "Password":
                            Item.Value = users.password;
                            break;
                        case "Email":
                            Item.Value = users.email;
                            break;
                        case "ContactNo":
                            Item.Value = users.contactNo;
                            break;
                        case "IsAdmin":
                            Item.Value = users.isAdmin;
                            break;
                        case "DataVisibility":
                            Item.Value = users.dataVisibility;
                            break;
                        case "IsActive":
                            Item.Value = users.isActive;
                            break;

                    }
                }

                Result = Convert.ToInt16(DALHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "InsertUsers", paramData));

                if (Result > 0)
                {
                    objResult = "User Created Successfully";
                }
                else
                {
                    objResult = "Not Saved";
                }
            }
            catch (Exception ex)
            {
                IsSuccess = false;

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    objResult = "User Already Exists";
                }
                else
                {
                    IsSuccess = false;
                    // ErrorLogDL.InsertErrorLog(ex.Message, "LoginBL : RegisterUser");
                    throw;
                }
            }
            finally
            {
                DALHelper.CloseDB(transaction, IsSuccess);
            }

            return objResult;

        }

        public object GetUsers(long userId)
        {
            try
            {
                con = DALHelper.GetConnection();
                IDbDataParameter[] paramData;

                paramData = DALHelperParameterCache.GetSpParameterSet(con, "GetAllUsers"); foreach (IDbDataParameter Item in paramData)
                {
                    switch (Item.ParameterName)
                    {
                        case "UserId":
                            Item.Value = userId;

                            break;

                    }
                }
                DALHelper.FillDataset(con, CommandType.StoredProcedure, "GetAllUsers", dsResult, new string[] { "User" }, paramData);

                objResult = dsResult.Tables.Contains("User") ? dsResult.Tables["User"] : null;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DALHelper.CloseDB(con);

            }
            return objResult;
        }


        public object GetLogin(Users user)
        {
            try
            {
                con = DALHelper.GetConnection();
                IDbDataParameter[] paramData;
                DataSet dsResult = new DataSet();

                paramData = DALHelperParameterCache.GetSpParameterSet(con, "GetLogin"); foreach (IDbDataParameter Item in paramData)
                {
                    switch (Item.ParameterName)
                    {

                        case "UserName":
                            Item.Value = user.userName;
                            break;
                        case "Password":
                            Item.Value = user.password;
                            break;
                        case "contactNo":
                            Item.Value = user.contactNo;
                            break;
                    }

                }

                DALHelper.FillDataset(con, CommandType.StoredProcedure, "GetLogin", dsResult, new string[] { "Users" }, paramData);

                return dsResult.Tables.Contains("Users") ? dsResult.Tables["Users"] : null;
            }
            catch (Exception ex)
            {
                // ErrorLogDL.InsertErrorLog(ex.Message, "RegisterTravellerUser");
                throw ex;
            }
        }

    }
}
