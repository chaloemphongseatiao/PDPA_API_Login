using System;
using System.Collections.Generic;

namespace DotnetAPI5.Models.Paramenters
{
    public class PostParamenter
    {
        // public class AddPersonal
        // {
        //     public string FirstName { get; set; }
        //     public string LastName { get; set; }
        //     public string Email { get; set; }
        //     public string Mobile { get; set; }
        //     public string Period { get; set; }
        //     public string Favorites { get; set; }
        //     public string DesiredBranch { get; set; }
        //     public string IPAddress { get; set; }
        //     public string CardNumber { get; set; }
        //     public DateTime? CreateDate { get; set; }
        //     public DateTime? UpdateDateTime { get; set; }
        //     public string Comments { get; set; }
        //     public string CarRegistration { get; set; }
        //     public string ChassisNumber { get; set; }
        //     public string ServiceBranch { get; set; }
        //     public string ContactAgency { get; set; }

        // }

        public class VerifyIDCard
        {
            public string CardNumber { get; set; }
        }


        public class VerifyUpdate
        {
            public string CardNumber { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }

        }

        public class LoginAccount
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class SelectConsentList
        {
            // public string FirstName { get; set; }
            // public string LastName { get; set; }
            // public string CardNumber { get; set; }

        }


        public class UpdateConsentProfile
        {
            public long? DPid { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }
            public string Period { get; set; }
            public string Favorites { get; set; }
            public string DesiredBranch { get; set; }
            public string IPAddress { get; set; }
            public string PostComment { get; set; }
            public DateTime? UpdateDateTime { get; set; }
            public string CarRegistration { get; set; }
            public string ChassisNumber { get; set; }
            public string ServiceBranch { get; set; }
            public string ContactAgency { get; set; }


        }

        public class LoginAccounts
        {
            public string Username { get; set; }
            public string Password { get; set; }

        }


        
        public class CreateUserAcc
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }

        }


        




    }
}
