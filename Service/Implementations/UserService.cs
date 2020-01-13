using Common.HttpHelpers;
using Domain;
using Domain.CustomModels;
using Infraestructure;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IServiceBase<User>
    {
        public EResponseBase<User> Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public EResponseBase<User> Get()
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    response.List = context.User.ToList();
                }
                response.Status = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }
            return response;
        }

        public EResponseBase<User> GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public EResponseBase<User> Insert(User user)
        {
            EResponseBase<User> response = new EResponseBase<User>();
            try
            {
                using (var context = new DataContext())
                {
                    context.User.Add(user);
                    context.SaveChanges();
                }
                response.Status = true;
                response.Message = "Usuario registrado correctamente";
                response.Object = user;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public EResponseBase<User> Update(User model)
        {
            throw new NotImplementedException();
        }
        public EResponseBase<User> Login(LoginRequest request)
        {
            EResponseBase<User> response = new EResponseBase<User>();
            User user = new User();
            try
            {
                using (var context = new DataContext())
                {
                    user = context.User.Where(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();
                }
                if (user != null)
                {
                    response.Object = user;
                    response.Status = true;
                    response.Message = "Bienvenido";
                }
                else
                {
                    throw new Exception("Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }
    }
}
