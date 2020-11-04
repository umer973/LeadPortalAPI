namespace BusinessData
{
    using Models;
    using System;
    using System.Data;

    public interface IBusinessData
    {
        Object CreateUser(Users users);

        Object GetUsers(long userId);

        Object GetLogin(Users user);



    }
}
