﻿using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Api.ViewModel
{
    public struct PostMessageModel
    {
        [Required]
        public string Message { get; set; }
    }
}
