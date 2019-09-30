using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.IdentityService
{
    public class IdentityService : IIdentity
    {
        private ApplicationDbContext _ctx {get;set;}

        public IdentityService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ApplicationUser Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _ctx.Users.SingleOrDefault(x => x.Username == username);

            // provjeri da li username postoji
            if (user == null)
                return null;

            // provjera da li je password uredu
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // autentifikacija uspješna
            return user;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _ctx.Users.AsEnumerable();
        }

        public ApplicationUser GetById(int id)
        {
            return _ctx.Users.Find(id);
        }

        public ApplicationUser Create(ApplicationUser user, string password)
        {
            // validacija
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_ctx.Users.Any(x => x.Username == user.Username))
                throw new Exception("Username " + user.Username + " is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            return user;
        }

        public void Update(ApplicationUser userParam, string password = null)
        {
            var user = _ctx.Users.Find(userParam.Id);

            if (user == null)
                throw new Exception("User not found");

            if (userParam.Username != user.Username)
            {
                if (_ctx.Users.Any(x => x.Username == userParam.Username))
                    throw new Exception("Username " + userParam.Username + " is already taken");
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _ctx.Users.Update(user);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _ctx.Users.Find(id);
            if (user != null)
            {
                _ctx.Users.Remove(user);
                _ctx.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Vrijednost ne moze biti prazna.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Neispravna dužina.", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Neispravna dužina.", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}