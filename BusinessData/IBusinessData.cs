namespace BusinessData
{
    using System;
    using System.Data;

    public interface IBusinessData
    {
        Object CreateUser(DataRow dr);

        Object GetUsers(long userId);

       
    }
}
