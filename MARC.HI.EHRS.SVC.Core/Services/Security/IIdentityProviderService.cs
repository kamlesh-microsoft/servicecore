﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MARC.HI.EHRS.SVC.Core.Services.Security
{

    /// <summary>
    /// Identifies a class which can generate TFA secrets
    /// </summary>
    public interface ITwoFactorSecretGenerator
    {
        /// <summary>
        /// Gets the name of the TFA generator
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Generate a TFA secret
        /// </summary>
        String GenerateTfaSecret();

        /// <summary>
        /// Validates the secret 
        /// </summary>
        bool Validate(String secret);
    }

    /// <summary>
    /// Identity provider service
    /// </summary>
    public interface IIdentityProviderService 
    {

        /// <summary>
        /// Retrieves an identity from the object
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IIdentity GetIdentity(String userName);

        /// <summary>
        /// Authenticate the user creating an identity
        /// </summary>
        /// <returns></returns>
        IPrincipal Authenticate(String userName, String password);

        /// <summary>
        /// Authenticate the user using two factor authentication
        /// </summary>
        IPrincipal Authenticate(String userName, String password, String tfaSecret);

        /// <summary>
        /// Change user password
        /// </summary>
        void ChangePassword(String userName, String newPassword, IPrincipal authContext);

        /// <summary>
        /// Set the user's two factor authentication secret
        /// </summary>
        String GenerateTfaSecret(String userName);

        /// <summary>
        /// Gets or sets the ITwoFactorSecretGenerator attached to the role provider
        /// </summary>
        ITwoFactorSecretGenerator TwoFactorSecretGenerator { get; set; }
    }
}
