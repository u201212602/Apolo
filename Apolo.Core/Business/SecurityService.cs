using Apolo.Core.Business.Common;
using Apolo.Core.Data;
using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using Apolo.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolo.Core.Business
{
    public class SecurityService
    {
        ApoloContext context = new ApoloContext();

        public OperationResult GetUserByUsername(string username)
        {
            return new OperationResult { RequestedObject = context.Users.SingleOrDefault(x => x.Username == username) };
        }

        public OperationResult GetUserByID(int id)
        {
            return new OperationResult { RequestedObject = context.Users.SingleOrDefault(x => x.ID == id) };
        }

        public OperationResult GetAllPatients()
        {
            return new OperationResult { RequestedObject = context.Users.Where(x => x.Role == Constants.Roles.PATIENT).ToList() };
        }

        public OperationResult GetAllUsers()
        {
            return new OperationResult { RequestedObject = context.Users.ToList() };
        }

        public OperationResult SaveUser(User user)
        {
            OperationResult operationResult = new OperationResult();
            user.Salt = new Guid();
            user.Password = SecurityUtil.GenerateSaltedHash(user.Password, user.Salt.ToString());
            try
            {
                if(user.ID == 0) // NEW
                {
                    context.Users.Add(user);
                }
                else // EXISTING
                {
                    var originalUser = context.Users.SingleOrDefault(x => x.ID == user.ID);
                    var originalPassword = originalUser.Password;
                    var originalAvatar = originalUser.Avatar;

                    CommonUtil.CopyPropertiesTo(user, originalUser);

                    if(string.IsNullOrEmpty(user.Password))
                    {
                        originalUser.Password = originalPassword;
                    }
                    if(user.Avatar == null)
                    {
                        originalUser.Avatar = originalAvatar;
                    }
                }

                context.SaveChanges();
                operationResult.RequestedObject = user;
            }
            catch
            {
                operationResult.WasSuccessful = false;
            }
            return operationResult;
        }

        public OperationResult ChangeUserBlockStatus(int userId, bool block)
        {
            User user = context.Users.SingleOrDefault(x => x.ID == userId);
            if(user != null)
            {
                user.Blocked = block;
                context.SaveChanges();
            }
            return new OperationResult { RequestedObject = user };
        }
    }
}
