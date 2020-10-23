using KI.RIS.DAL;
using System;


namespace BusinessData
{
    using System.Data;

    public class BusinessData : IBusinessData
    {
        public Object objResult;
        public IDbConnection con = null;
        public IDbDataParameter[] paramData;
        public IDbTransaction transaction;
        public bool IsSuccess = true;
        public DataSet dsResult = new DataSet();


        public object CreateUser(DataRow dr)
        {
            Int64 Result = 0;
            try
            {
                transaction = DALHelper.GetTransaction();
                paramData = DALHelperParameterCache.GetSpParameterSet(transaction, "InsertUsers"); foreach (IDbDataParameter Item in paramData)
                {
                    switch (Item.ParameterName)
                    {
                        case "UserName":
                            Item.Value = dr["userName"];

                            break;
                        case "Password":
                            Item.Value = dr["password"];
                            break;
                        case "Email":
                            Item.Value = dr["email"];
                            break;
                        case "ContactNo":
                            Item.Value = dr["contactNo"];
                            break;
                        case "IsAdmin":
                            Item.Value = dr["contactNo"];
                            break;
                        case "DataVisibility":
                            Item.Value = dr["contactNo"];
                            break;
                        case "IsActive":
                            Item.Value = dr["contactNo"];
                            break;

                    }
                }

                Result = Convert.ToInt16(DALHelper.ExecuteNonQuery(transaction, CommandType.StoredProcedure, "InsertUsers", paramData));

                if (Result > 0)
                {
                    objResult = "200"; // Data Saved;
                }
                else
                {
                    objResult = "201"; // Not Saved;
                }
            }
            catch (Exception ex)
            {
                IsSuccess = false;

                if (ex.Message.Contains("UNIQUE KEY"))
                {
                    objResult = "300";  // Existing
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


    }
}
