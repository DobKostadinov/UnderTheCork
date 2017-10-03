﻿using System.ComponentModel.DataAnnotations;

namespace UnderTheCork.Web.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}