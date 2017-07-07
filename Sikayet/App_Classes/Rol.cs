using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Sikayet.Models;

namespace Sikayet.App_Classes
{
    public class Rol : RoleProvider
    {
        SikayetContext context = new SikayetContext();

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var kullaniciUser = context.Kullanicis.Where(x=>x.Adi==username).Select(x => x.Adi).FirstOrDefault();
                if (kullaniciUser!=null)
                {
                    return new string[] { "uye" };
                }
                else
                {
                    var kullaniciModerator = context.Moderators.Where(x=>x.KullaniciAdi==username).Select(x => x.KullaniciAdi).FirstOrDefault();
                    if (kullaniciModerator != null)
                    {
                        return new string[] { "moderator" };
                    }
                    
                }

            }

            return new string[] { };
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}