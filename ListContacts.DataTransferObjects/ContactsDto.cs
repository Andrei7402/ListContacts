﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ListContacts.DataTransferObjects
{
    public class ContactsDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(255, ErrorMessage = "Phone number must be between 1 and 255", MinimumLength = 1)]
        [RegularExpression("^[+*[({0,1}[0-9{1,4}[]{0,1}[-\\s\\./0-9]*$")]
        public string MobilePhone { get; set; }

        public string JobTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
    }
}
